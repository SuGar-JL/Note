using System;
using System.Collections.Generic;
using System.Threading.Tasks;
/// <summary>
/// 多任务Task
/// 获得返回结果
/// </summary>
namespace demo24_多任务
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Run<string>(() => PiCalculator.Calculate(100000));
            foreach (var busySymbol in Utility.BusySymbols())
            {
                if (task.IsCompleted)
                {
                    Console.WriteLine('\b');
                    break;
                }
                Console.WriteLine(busySymbol);//太快的话，这会被忽略
            }

            Console.WriteLine();

            Console.WriteLine(task.Result);//会阻塞调用任务室外线程

            System.Diagnostics.Trace.Assert(task.IsCompleted);//判断task.IsCompleted真假，false则出现弹框
        }
        public class PiCalculator
        {
            public static string Calculate(int digits = 100)
            {
                int sum = 0;
                for (int i = 0; i < digits; i++)
                {
                    sum += digits;

                    for (int j = 0; j < digits; j++)
                    {
                        //
                    }
                }
                    return "任务结束";
            }
        }

        public class Utility
        {
            public static IEnumerable<char> BusySymbols()
            {
                string busySymbols = @"-\|/-\|/";
                int next = 0;
                while (true)
                {
                    yield return busySymbols[next];
                    next = (next + 1) % busySymbols.Length;
                    yield return '\b';
                }
            }
        }

    }
}
