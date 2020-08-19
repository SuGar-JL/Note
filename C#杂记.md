# C#杂记

1. ###### UUID生成id：

   tring id = System.Guid.NewGuid().ToString();

   一句话即可，但此时id中有“-”符号存在，使用下面语句可变为纯字母+数字。

   string id = System.Guid.NewGuid().ToString("N");

2. ###### 时间比较：

   https://www.cnblogs.com/rwh871212/p/6999704.html

   ```C#
   DateTime t1 = new DateTime(100);   
   DateTime t2 = new DateTime(20);   
       
   if (DateTime.Compare(t1, t2) > 0) Console.WriteLine("t1 > t2");     
   if (DateTime.Compare(t1, t2) == 0) Console.WriteLine("t1 == t2");     
   if (DateTime.Compare(t1, t2) < 0) Console.WriteLine("t1 < t2"); 
   ```

3. ###### 字符串转时间：

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

5. ###### 命名方法委托：

   ```C#
   class Program
   {
       public delegate void MyDelegate();
       static void Main(string[] args)
       {
           MyDelegate myDelegate = new MyDelegate(Test.SayHello);
           myDelegate();
       }
   }
   class Test
   {
       public static void SayHello()
       {
           Console.WriteLine("Hello Delegate!");
       }
   }
   ```

6. ###### 使用方法回调，实现给文本框赋值：

   ```C#
   namespace MultiThreadDemo
   {
       public partial class Form1 : Form
       {
           public Form1()
           {
               InitializeComponent();
           }
   
           //定义回调
           private delegate void setTextValueCallBack(int value);
           //声明回调
           private setTextValueCallBack setCallBack;
   
           private void btn_Test_Click(object sender, EventArgs e)
           {
               //实例化回调
               setCallBack = new setTextValueCallBack(SetValue);
               //创建一个线程去执行这个方法:创建的线程默认是前台线程
               Thread thread = new Thread(new ThreadStart(Test));
               //Start方法标记这个线程就绪了，可以随时被执行，具体什么时候执行这个线程，由CPU决定
               //将线程设置为后台线程
               thread.IsBackground = true;
               thread.Start();
           }
   
           private void Test()
           {
               for (int i = 0; i < 10000; i++)
               {
                   //使用回调
                   textBox1.Invoke(setCallBack, i);
               }
           }
   
           /// <summary>
           /// 定义回调使用的方法
           /// </summary>
           /// <param name="value"></param>
           private void SetValue(int value)
           {
               this.textBox1.Text = value.ToString();
           }
       }
   }
   ```

   

