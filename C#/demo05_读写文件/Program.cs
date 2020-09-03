using System;
using System.IO;

namespace demo05_读写文件
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileStream F = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //for (int i = 1; i <= 20; i++)
            //{
            //    F.WriteByte((byte)i);
            //}
            //F.Position = 0;
            //for (int i = 0; i <= 20; i++)
            //{
            //    Console.Write(F.ReadByte() + " ");
            //}
            //F.Close();
            //Console.ReadKey();

            //StreamWriter/StreamReader 从流中写/读字符
            using (var sw = new StreamWriter(new FileStream("test1.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                sw.WriteLine("write into test1.txt");
                //sw.Close();//可以不写，using会默认调用Dispose方法来清理
            }

            using (var sr = new StreamReader("test1.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());//write into test1.txt
            }
        }
    }
}
