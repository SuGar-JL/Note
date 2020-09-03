using System;

namespace demo02_结构struct
{
    class Program
    {
        struct Location
        {
            public int X;
            public int Y;

            //只能定义有参构造方法
            public Location(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        static void Main(string[] args)
        {
            Location loc = new Location(0, 0);
            //结构为值类型，使用方法不能改变它的值
            method(loc);
            Console.WriteLine("Location is:({0},{1})", loc.X, loc.Y);//Location is:(0,0)
        }
        static void method(Location loc)
        {
            loc.X = 1;
            loc.Y = 1;
        }
    }
}
