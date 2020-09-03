using System;

namespace demo06_委托
{
    //声明委托
    delegate double Function(double x);
    class Test
    {
        double a;
        public Test(double a)
        {
            this.a = a;
        }
        public double Multiply(double x)
        {
            return this.a * x;
        }
    }
    class Program
    {
        static double Square(double x)
        {
            return x * x;
        }
        static double[] Apply(double[] a, Function f)
        {
            double[] result = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = f(a[i]);
            }
            return result;
        }
        static void print(double[] d)
        {
            for (int i = 0; i < d.Length; i++)
            {
                Console.Write(d[i] + " ");
            }
            Console.Write("\r\n");
        }
        static void Main(string[] args)
        {
            //委托（方法引用）
            //委托引用的方法必须与委托有一致的返回类型和参数列表

            ///1.委托作为函数参数
            double[] a = { 1, 2, 3 };
            //委托引用普通方法
            double[] squares = Apply(a, Square);//平方
            print(squares);
            double[] sines = Apply(a, Math.Sin);//求sin
            print(sines);
            //委托引用实例方法
            Test test = new Test(4);
            double[] doubles = Apply(a, test.Multiply);//乘4
            print(doubles);
            //委托匿名方法
            double[] doubles1 = Apply(a, (double x) => x * 2.0);//乘2
            print(doubles1);

            ///2.单独使用委托
            //1.实例化委托
            Function f = new Function(Square);
            //2.使用委托对象调用方法
            double r = f(5);//5x5
            Console.WriteLine(r);//25


        }
    }
}
