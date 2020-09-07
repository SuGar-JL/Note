using System;
using System.Collections.Generic;
using System.Text;

namespace demo15_基于demo14_扩展方法
{
    static class MyListExMethods
    {
        //给MyList扩展获取最大值方法
        public static int Max(this MyList list)
        {
            var e = list.GetEnumerator();
            int max = int.MinValue;
            while (e.MoveNext())
            {
                if (e.Current > max)
                {
                    max = e.Current;
                }
            }
            return max;
        }

        //给字符串string类扩展ToInt()方法
        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }
    }
}
