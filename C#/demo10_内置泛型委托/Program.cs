using System;
using System.Collections.Generic;
using System.Linq;

namespace demo10_内置泛型委托
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Action<T>委托示例 有参数无返回值的委托
            //需求：打印出整型集合list的元素
            //List<int> list = { 1, 2, 3, 4, 5 };//不能这样写
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            //将匿名方法分配给 Action<T> 委托实例
            //Action<int> concat1 = delegate (int i) { Console.WriteLine(i); };
            //Action<int> concat1 = new Action<int>(i => Console.WriteLine(i));
            Action<int> concat1 = i => Console.WriteLine(i);

            //list.ForEach(i => Console.WriteLine(i));
            list.ForEach(concat1);//ForEach的参数是是Action<T>委托
            Console.WriteLine("==========");
            #endregion

            #region Func<T,TResult>委托示例 有参数有返回值的委托（返回值类型为最后一个参数）
            //需求：查找整型集合list中大于3的所有元素组成的新集合，并打印出集合元素
            List<int> list1 = new List<int>() { 1, 2, 3, 4, 5 };
            //将匿名方法分配给 Func<T,TResult> 委托实例
            //Func<int, bool> concat2 = delegate (int i) { return i > 3; };
            Func<int, bool> concat2 = i => i > 3;//输入参数为int，返回值为bool
            var newlist1 = list1.Where(concat2).ToList();//Linq查询，找符合条件的元素 public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate);
            newlist1.ForEach(i => Console.WriteLine(i.ToString()));//ForEach的参数是Action<T>委托
            Console.WriteLine("==========");
            #endregion

            #region  Predicate<T>委托示例 有且只有一个参数，返回值为bool
            //需求：查找整型集合list中大于3的所有元素组成的新集合，并打印出集合元素
            List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 };
            //将匿名方法分配给 Predicate<T> 委托实例
            //Predicate<int> concat3 = delegate (int i) { return i > 3; };
            Predicate<int> concat3 = i => i > 3;
            var newlist2 = list2.FindAll(concat3);//List<T> FindAll(Predicate<T> match);
            var newInt = list2.Find(concat3);//T Find(Predicate<T> match);返回第一个符合条件的
            newlist2.ForEach(i => Console.WriteLine(i));
            Console.WriteLine(newInt);
            Console.WriteLine("==========");
            #endregion

            #region  Comparison<T>委托示例 比较同一类型的两个对象
            //需求：将整型集合list中的所有元素倒序排列打印出来
            List<int> list3 = new List<int>() { 1, 2, 3, 4, 5 };
            //将匿名方法分配给 Comparison<T> 委托实例
            //Comparison<int> concat4 = delegate (int i, int j) { return j - i; };
            Comparison<int> concat4 = (i, j) => j - i;
            list.Sort(concat4);//倒序排序 void Sort(Comparison<T> comparison);
            list.ForEach(c => Console.WriteLine(c.ToString()));
            Console.WriteLine("==========");
            #endregion
        }
    }
}
