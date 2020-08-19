# C#杂记

1. UUID生成id：

   tring id = System.Guid.NewGuid().ToString();

   一句话即可，但此时id中有“-”符号存在，使用下面语句可变为纯字母+数字。

   string id = System.Guid.NewGuid().ToString("N");

2. 时间比较：

   https://www.cnblogs.com/rwh871212/p/6999704.html

   ```C#
   DateTime t1 = new DateTime(100);   
   DateTime t2 = new DateTime(20);   
       
   if (DateTime.Compare(t1, t2) > 0) Console.WriteLine("t1 > t2");     
   if (DateTime.Compare(t1, t2) == 0) Console.WriteLine("t1 == t2");     
   if (DateTime.Compare(t1, t2) < 0) Console.WriteLine("t1 < t2"); 
   ```

3. 字符串转时间：

   ```C#
   string st1="12:13";
   string st2="14:14";
   DateTime dt1=Convert.ToDateTime(st1);
   DateTime dt2=Convert.ToDateTime(st2);
   ```

4. 获取当前时间：

   ```C#
   DateTime dt3=DateTime.Now;
   ```

   