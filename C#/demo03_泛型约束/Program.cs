using System;

/// <summary>
/// 泛型约束：
///     接口约束：
///     基类约束：
///     引用类型约束：class
///     值类型约束：strut
/// </summary>
namespace demo03_泛型约束
{
    class Program
    {
        class Test
        {
            private int a;
            public void SetA(int a)
            {
                this.a = a;
            }
            public int GetA()
            {
                return this.a;
            }
        }
        /// <summary>
        /// 想在该方法设置Test对象的a属性，但用泛型不能使用对象的.运算符，此时需要泛型约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        static int GetTest<T>(T t)
            where T : Test//T为Test类型，若想在此方法内new Test的对象，需加“, new()”在Test后
        {
            t.SetA(2);
            return t.GetA();
        }
        static void Main(string[] args)
        {
            Test test = new Test();
            Console.WriteLine(GetTest(test));//2
        }
    }
}
