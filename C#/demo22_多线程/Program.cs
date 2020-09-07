using System;
using System.Threading.Tasks;

namespace demo22_多线程
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建使用线程
            var task = new Task(() => {
                for (int i = 0; i < 500; i++)
                {
                    Console.WriteLine(i);
                }
            });
            task.Start();//启动线程
            task.Wait();//阻塞住，不然main主线程执行结束后，task也跟着被关闭了，就不会打印到499

            //有返回值
            var task1 = Task.Factory.StartNew(() => "返回值");
            Console.WriteLine(task1.Result);//task1.Result与wait一样会阻塞

        }
    }
}
