using System;
using System.Diagnostics;
using System.Reflection;

namespace demo18_反射
{
    public class TestA
    {
        public string property { get; set; }
        public void method1()
        {
            property = "method1";
            Console.WriteLine($"方法{ property }执行A");
        }
        public void method2()
        {
            property = "method2";
            Console.WriteLine($"方法{ property }执行A");
        }
    }
    public class TestB
    {
        public string property { get; set; }
        public void method1()
        {
            property = "method1";
            Console.WriteLine($"方法{ property }执行B");
        }
        public void method2()
        {
            property = "method2";
            Console.WriteLine($"方法{ property }执行B");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            //1.GetType() 需实例来调用，因此静态类不能用
            DateTime dataTime = new DateTime();
            Type type = dataTime.GetType();
            //输出DateTime类的属性名称
            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                Console.WriteLine(property.Name);
            }
            Console.WriteLine("".PadRight(20, '-'));

            //2.typeof() 无需通过实例调用，而是将类型作为参数，因此静态类也能用
            //ThreadPriorityLevel priority = (ThreadPriorityLevel)Enum.Parse(typeof(ThreadPriorityLevel), "Idle");
            Type type1 = typeof(DateTime);
            //输出DateTime类的方法名称
            foreach (System.Reflection.MethodInfo methodInfo in type1.GetMethods())
            {
                Console.WriteLine(methodInfo.Name);
            }
            Console.WriteLine("".PadRight(20, '-'));

            //用反射操作类TestA的属性与方法
            var testA = new TestA();
            Type type2 = typeof(TestA);
            //Type type2 = testA.GetType();
            var property1 = type2.GetProperty("property");
            property1.SetValue(testA, "反射设置属性值");
            Console.WriteLine(testA.property);//反射设置属性值
            //按名称获取方法
            var method1 = type2.GetMethod("method1");
            //调用方法（实例，参数object[]）
            method1.Invoke(testA, null);
            var method2 = type2.GetMethod("method2");
            method2.Invoke(testA, null);
            Console.WriteLine("".PadRight(20, '-'));

            //根据字符串创建类的实例
            Console.Write("输入类名称（TestA/TestB）：");
            string className = Console.ReadLine();
            var instance = Assembly.Load("demo18_反射").CreateInstance("demo18_反射." + className);
            //根据用户输入调用方法（控制台的感觉）
            Console.Write("输入方法名称（method1/method2）：");
            string methodName = Console.ReadLine();
            var method = instance.GetType().GetMethod(methodName.Trim());
            method.Invoke(instance, null);
        }
    }
}
