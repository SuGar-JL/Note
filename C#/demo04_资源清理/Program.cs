using System;

namespace demo04_资源清理
{
    class Program
    {
        class Test : IDisposable
        {
            public void Dispose()
            {
                //throw new NotImplementedException();
                Console.WriteLine("销毁中。。。");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("调用资源前");
            //调用资源
            using (Test test = new Test())
            {
                Console.WriteLine("使用资源");
            }
            Console.WriteLine("调用资源后");

            //运行结果：
            //调用资源前
            //使用资源
            //销毁中。。。
            //调用资源后
        }
    }
}
