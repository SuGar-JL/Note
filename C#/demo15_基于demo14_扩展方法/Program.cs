using System;
using System.Collections;
using System.Collections.Generic;

namespace demo15_基于demo14_扩展方法
{
    class MyList : IEnumerable<int>
    {
        public int[] nums;
        public int Count()
        {
            int count = 0;
            var e = this.GetEnumerator();
            while (e.MoveNext())
            {
                count++;
            }
            return count;
        }

        public IEnumerator<int> GetEnumerator()
        {
            //throw new NotImplementedException();
            foreach (var item in nums)
            {
                yield return item;//顺序返回
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyList() { nums = new int[] { 1, 2, 3, 4, 5 } };
            var enumerator1 = list.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                Console.WriteLine(enumerator1.Current);
                var enumerator2 = list.GetEnumerator();
                while (enumerator2.MoveNext())
                {
                    Console.WriteLine("\t" + enumerator2.Current);
                }
            }
            Console.WriteLine("Count:" + list.Count());//Count:5

            //给MyList扩展一个获取最大值的方法
            //当不允许直接更改MyList类时就可以这样
            //1.新建一个静态类
            //2.新建一个静态方法，参数中指示给谁扩展方法（this关键字）
            Console.WriteLine("MaxValue:" + list.Max());//MaxValue: 5

            //给多的扩展方法的使用，如给string类扩展一个自己的方法
            //觉得int.Parse(str)不好用，改成ToInt()
            string str = "123";
            Console.WriteLine("用改造的方法将string转int:" + str.ToInt().GetType());//用改造的方法将string转int: System.Int32
        }
    }
}
