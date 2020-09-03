using System;

//声明委托
delegate int NumberChanger(int n);
namespace demo07_委托的多播
{
    class Program
    {
        static int num = 10;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }
        public static int getNum()
        {
            return num;
        }

        static void Main(string[] args)
        {
            // 创建委托实例
            NumberChanger nc;
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
            nc = nc1;
            nc += nc2;
            // 调用多播，实现同时调用多个方法
            nc(5);//先加上5，再乘上5
            Console.WriteLine("Value of Num: {0}", getNum());//75
            Console.ReadKey();
        }
    }
}
