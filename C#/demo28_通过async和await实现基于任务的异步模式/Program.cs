using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace demo28_通过async和await实现基于任务的异步模式
{
    public class Program
    {
        private static async Task WriteWebRequestSizeAsync(string url)
        {
            try
            {
                WebRequest webRequest =
                    WebRequest.Create(url);
                //到这之前都在主线程
                //生成新的Task来执行GetResponseAsync()
                //webRequest.GetResponseAsync()返回值为Task<WebResponse>，由于await存在，转为WebResponse
                WebResponse response = await webRequest.GetResponseAsync();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    //生成新的Task来执行ReadToEndAsync()
                    //reader.ReadToEndAsync()返回值为Task<string>，由于await存在，转为string
                    string text = await reader.ReadToEndAsync();
                    Console.WriteLine(FormatBytes(text.Length));
                }
            }
            catch (WebException)
            {
                // ...
            }
            catch (IOException)
            {
                // ...
            }
            catch (NotSupportedException)
            {
                // ...
            }
        }

        public static void Main(string[] args)
        {
            string url = "http://www.IntelliTect.com";
            if (args.Length > 0)
            {
                url = args[0];
            }

            Console.Write(url);

            Task task = WriteWebRequestSizeAsync(url);
            //等待task完成
            while (!task.Wait(100))
            {
                Console.Write(".");
            }
        }

        static public string FormatBytes(long bytes)
        {
            string[] magnitudes =
                new string[] { "GB", "MB", "KB", "Bytes" };
            long max =
                (long)Math.Pow(1024, magnitudes.Length);

            return string.Format("{1:##.##} {0}",
                magnitudes.FirstOrDefault(
                    magnitude =>
                        bytes > (max /= 1024)) ?? "0 Bytes",
                    (decimal)bytes / (decimal)max).Trim();
        }
    }
}
