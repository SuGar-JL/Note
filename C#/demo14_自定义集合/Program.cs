using System;
using System.Collections;
using System.Collections.Generic;

namespace demo14_自定义集合
{
    class Program
    {
        class MyList : IEnumerable<int>
        {
            public int[] nums;

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
                //throw new NotImplementedException();
                return GetEnumerator();
            }

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
        }
        static void Main(string[] args)
        {
            var list = new MyList() { nums = new int[] { 1, 2, 3, 4, 5 } };
            var enumerator1 = list.GetEnumerator();
            while (enumerator1.MoveNext())
            {
                Console.WriteLine(enumerator1.Current);
                var enumerator2 = list.GetEnumerator();
                while(enumerator2.MoveNext())
                {
                    Console.WriteLine("\t" + enumerator2.Current);
                }
            }
            Console.WriteLine("Count:" + list.Count());
        }
    }
}
