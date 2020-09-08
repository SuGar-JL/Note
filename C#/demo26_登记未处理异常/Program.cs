using System;
using System.Diagnostics;
using System.Threading;

namespace demo26_登记未处理异常
{
    class Program
    {
        public static Stopwatch clock = new Stopwatch();
        static void Main(string[] args)
        {
            try
            {
                clock.Start();

                // Register a callback to receive notifications
                // of any unhandled exception
                // （译）注册一个回调接收任何未处理的异常通知
                AppDomain.CurrentDomain.UnhandledException +=
                  (s, e) =>
                  {
                      Message("Event handler starting");
                      //这句应该是模拟thread在做任务，要等thread醒来，程序才会由于异常崩溃
                      Delay(4000);
                  };
                Thread thread = new Thread(() =>
                {
                    Message("Throwing exception.");
                    throw new Exception();
                });
                thread.Start();

                Delay(10000);
            }
            finally
            {
                Message("Finally block running.");
            }
        }

        static void Delay(int i)
        {
            Message($"Sleeping for {i} ms");
            Thread.Sleep(i);
            Message("Awake");
        }

        static void Message(string text)
        {
            Console.WriteLine(
                $"{Thread.CurrentThread.ManagedThreadId}:{text}");
        }
    }
}
