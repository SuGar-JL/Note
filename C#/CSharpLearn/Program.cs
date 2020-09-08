using System;
using System.Threading.Tasks;

namespace CSharpLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            bool parentTaskFaulted = false;
            Task task = new Task(() =>
            {
                Console.WriteLine("先驱任务要抛异常");
                throw new InvalidOperationException();
            });
            Task continuationTask = task.ContinueWith(
                (antecedentTask) =>
                {
                    parentTaskFaulted =
                        antecedentTask.IsFaulted;
                    Console.WriteLine("延续任务执行");
                }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
            continuationTask.Wait();
            if (!parentTaskFaulted)
            {
                Console.WriteLine("抛异常1");
                throw new Exception("Parent task should be faulted");
            }
            if (!task.IsFaulted)
            {
                Console.WriteLine("抛异常2");
                throw new Exception("Task should be faulted");
            }

            task.Exception.Handle(eachException =>
            {
                Console.WriteLine(
                    $"ERROR: { eachException.Message }");
                return true;
            });
        }
    }
}
