using System;

namespace demo01_数组_Array类
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 数组 方法一
            //声明数组
            int[] nums;
            //初始化数组
            nums = new int[3];
            //给数组赋值
            nums[0] = 0;
            nums[1] = 1;
            nums[2] = 2;
            //遍历数组
            //for循环
            Console.Write("数组为：[");
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == nums.Length - 1)
                {
                    Console.Write(nums[i].ToString());
                }
                else
                {
                    Console.Write(nums[i].ToString() + ",");
                }
            }
            Console.WriteLine("]");
            //foreach
            Console.Write("数组为：[");
            int j = 0;
            foreach (var item in nums)
            {
                if (j == nums.Length - 1)
                {
                    Console.Write(item.ToString());
                }
                else
                {
                    Console.Write(item.ToString() + ",");
                }
                j++;

            }
            Console.WriteLine("]");
            #endregion

            #region 数组 方法二
            //初始化数组
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = new int[3] { 1, 2, 3 };
            int[] nums3 = new int[] { 1, 2, 3 };
            #endregion

            #region 数组间相互赋值
            int[] nums4 = { 1, 2, 3, };
            int[] nums5 = nums4;
            #endregion

            #region Array类
            #region 属性
            //1. IsFixedSize属性 指示数组是否有固定大小
            int[] a = { 1, 2, 3 };
            bool isFS = a.IsFixedSize;
            Console.WriteLine(isFS);

            //2. IsReadOnly属性 指示数组是否只读
            bool isRO = a.IsReadOnly;
            Console.WriteLine(isRO);

            //3. Length属性 获取数组长度（32位整数）
            int len = a.Length;
            Console.WriteLine(len);

            //4. LongLength属性 获取数组长度（64位整数）
            long len1 = a.Length;
            Console.WriteLine(len1);

            //5. Rank属性 获取数组的秩（维度）
            int[,] b = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            int r = b.Rank;
            Console.WriteLine(r);
            #endregion

            #region 方法
            int[] c = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //1. Clear方法 设置数组某部分元素为0
            Array.Clear(c, 6, 3);
            PrintArray(c);//数组为：[1,2,3,4,5,6,0,0,0]

            //2. Copy方法 从数组的第一个元素开始复制某个范围的元素到另一个数组的第一个元素位置
            int[] d = { 11, 22, 33 };
            Array.Copy(c, d, 3);
            PrintArray(d);//数组为：[1,2,3] 覆盖原数组的前三位

            //3. CopyTo方法 从当前的一维数组中复制所有的元素到一个指定的一维数组的指定索引位置
            d.CopyTo(c, 6);
            PrintArray(c);//数组为：[1,2,3,4,5,6,1,2,3] 也会覆盖

            //4. GetLength方法 指定维度的数组中的元素总数 (int)
            int[,] e = { { 1, 2 }, { 3, 4 } };
            int len2 = e.GetLength(1);
            Console.WriteLine(len2);//2

            //5. GetLongLength方法 指定维度的数组中的元素总数 (long)

            //6. GetLowerBound方法 获取数组中指定维度的下界
            int bound = e.GetLowerBound(1);
            Console.WriteLine(bound);//0

            //7. GetType方法 获取当前实例的类型。从对象（Object）继承
            Console.WriteLine(e.GetType());//System.Int32[,]

            //8. GetUpperBound方法 获取数组中指定维度的上界
            int bound1 = e.GetUpperBound(1);
            Console.WriteLine(bound1);//1

            //9. GetValue(Int32) 获取一维数组中指定位置的值。索引由一个 32 位整数指定
            int v = (int)d.GetValue(1);
            Console.WriteLine(v);//2

            //10. IndexOf(Array, Object) 搜索指定的对象，返回整个一维数组中第一次出现的索引
            int index = Array.IndexOf(d, 11);
            Console.WriteLine(index);//-1 (找不到)

            //11. Reverse(Array)方法 逆转整个一维数组中元素的顺序。
            Array.Reverse(d);
            PrintArray(d);//数组为：[3,2,1]

            //12. SetValue(Object, Int32)方法 给一维数组中指定位置的元素设置值。索引由一个 32 位整数指定。
            d.SetValue(4, 2);
            PrintArray(d);//数组为：[3,2,4]

            //13. Sort(Array)方法 使用数组的每个元素的 IComparable 实现来排序整个一维数组中的元素。
            Array.Sort(d);
            PrintArray(d);//数组为：[2,3,4]

            //14. ToString方法 返回一个表示当前对象的字符串。从对象（Object）继承。
            Console.WriteLine(d.ToString());//System.Int32[]
            #endregion
            #endregion

        }

        #region 打印数组方法
        public static void PrintArray(int[] arr)
        {
            Console.Write("数组为：[");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    Console.Write(arr[i]);
                }
                else
                {
                    Console.Write(arr[i] + ",");
                }
            }
            Console.WriteLine("]");
        }
        #endregion
    }
}
