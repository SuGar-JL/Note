# C#杂记

## 1.UUID生成id：

tring id = System.Guid.NewGuid().ToString();

一句话即可，但此时id中有“-”符号存在，使用下面语句可变为纯字母+数字。

string id = System.Guid.NewGuid().ToString("N");

## 2.时间比较：

https://www.cnblogs.com/rwh871212/p/6999704.html

```csharp
DateTime t1 = new DateTime(100);   
DateTime t2 = new DateTime(20);   
    
if (DateTime.Compare(t1, t2) > 0) Console.WriteLine("t1 > t2");     
if (DateTime.Compare(t1, t2) == 0) Console.WriteLine("t1 == t2");     
if (DateTime.Compare(t1, t2) < 0) Console.WriteLine("t1 < t2"); 
```

## 3.字符串转时间：

```csharp
string st1="12:13";
string st2="14:14";
DateTime dt1=Convert.ToDateTime(st1);
DateTime dt2=Convert.ToDateTime(st2);
```

## 4.获取当前时间：

```csharp
DateTime dt3=DateTime.Now;
```

## 5.命名方法委托：

```csharp
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
    public static void SayHello(string str)
    {
        Console.WriteLine("Hello {0}!", str);
    }
}
```

## 6.使用方法回调，实现给文本框赋值：

```csharp
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

## 7.获得某数据类型的范围（尺寸）

```csharp
namespace DataTypeApplication
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Size of int: {0}", sizeof(int));
         Console.ReadLine();
      }
   }
}
```

## 8.C# 的访问权限修饰符

类的默认访问标识符是 **internal**，成员的默认访问标识符是 **private**。

这里只说与java不同的：

### Internal修饰符：

Internal 访问说明符允许一个类将其成员变量和成员函数暴露给当前程序中的其他函数和对象。换句话说，带有 internal 访问修饰符的任何成员可以被定义在该成员所定义的应用程序内的任何类或方法访问。

```csharp
using System;

namespace RectangleApplication
{
    class Rectangle
    {
        //成员变量
        internal double length;
        internal double width;
        
        double GetArea()
        {
            return length * width;
        }
       public void Display()
        {
            Console.WriteLine("长度： {0}", length);
            Console.WriteLine("宽度： {0}", width);
            Console.WriteLine("面积： {0}", GetArea());
        }
    }//end class Rectangle    
    class ExecuteRectangle
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.length = 4.5;
            r.width = 3.5;
            r.Display();
            Console.ReadLine();
        }
    }
}
```

### Protected Internal 访问修饰符

Protected Internal 访问修饰符允许一个类将其成员变量和成员函数对同一应用程序内的子类以外的其他的类对象和函数进行隐藏。这也被用于实现继承。\

### 范围比较

-  (1) Pubilc ：任何公有成员可以被外部的类访问。
-  (2) Private ：只有同一个类中的函数可以访问它的私有成员。
-  (3) Protected ：该类内部和继承类中可以访问。
-  (4) internal : 同一个程序集的对象可以访问。
-  (5) Protected internal ：3 和 4 的并集，符合任意一条都可以访问。

```csharp
private < internal/protected < protected internal < public
```

## 9.using三种用法

- `using`指令：

  `using + 命名空间名字`，这样可以在程序中直接用命令空间中的类型，而不必指定类型的详细命名空间，类似于Java的import，这个功能也是最常用的，几乎每个cs的程序都会用到。
  例如：``using System`; 一般都会出现在`*.cs`中。

- `using`别名。`using + 别名` = 包括详细命名空间信息的具体的类型。
  这种做法有个好处就是当同一个.cs引用了两个不同的命名空间，但两个命名空间都包括了一个相同名字的类型的时候。当需要用到这个类型的时候，就每个地方都要用详细命名空间的办法来区分这些相同名字的类型。而用别名的方法会更简洁，用到哪个类就给哪个类做别名声明就可以了。注意：并不是说两个名字重复，给其中一个用了别名，另外一个就不需要用别名了，如果两个都要使用，则两个都需要用using来定义别名的。

  ```C#
  using System;
  
  //using 别名
  using aClass = NameSpace1.MyClass;
  using bClass = NameSpace2.MyClass;
   
  namespace NameSpace1 
  {
      public class MyClass 
      {
          public override string ToString() 
          {
              return "You are in NameSpace1.MyClass";
          }
      }
  }
   
  namespace NameSpace2 
  {
      class MyClass 
      {
          public override string ToString() 
          {
              return "You are in NameSpace2.MyClass";
          }
      }
  }
   
  namespace testUsing
  {
      using NameSpace1;
      using NameSpace2;
      /// <summary>
      /// Class1 的摘要说明。
      /// </summary>
      class Class1
      {
          /// <summary>
          /// 应用程序的主入口点。
          /// </summary>
          [STAThread]
          static void Main(string[] args)
          {
              //
              // TODO: 在此处添加代码以启动应用程序
              //
   
              aClass my1 = new aClass();
              Console.WriteLine(my1);
              bClass my2 = new bClass();
              Console.WriteLine(my2);
              Console.WriteLine("Press any key");
              Console.Read();
          }
      }
  }
  ```

- `using`语句

  定义一个范围，在范围结束时处理对象。
  场景：
  当在某个代码段中使用了类的实例，而希望无论因为什么原因，只要离开了这个代码段就自动调用这个类实例的Dispose（要实现IDisposeable接口的Dispose方法）。
  要达到这样的目的，用try...catch来捕捉异常也是可以的，但用using也很方便。

  ```C#
  using (Class1 cls1 = new Class1(), cls2 = new Class1())
  {
    // the code using cls1, cls2
  } // call the Dispose on cls1 and cls2
  ```

## 10.[STAThread]

​	https://blog.csdn.net/zmj_tata/article/details/42120159

## 11.C#内置泛型委托

​	像java中的内建函数式接口

​	https://www.jianshu.com/p/4775095f2902

## 12.string.Empty、"" 与 null

- string.Empty不分配内存空间，""分配空的内存空间，null无指向

- 为了跨平台用string.Empty

- 大多数情况下 "" 和 string.Empty 可以互换使用

  ```C#
  string s = "";
  string s2 = string.Empty;
  if (s == string.Empty) {
  　　//
  }
  //if语句成立
  ```

- 判定为空字符串的几种写法，按照性能从高到低的顺序是：s.Length == 0 优于 s == string.Empty 优于 s == ""

## 13.Invoke用法 

​	https://blog.csdn.net/qq_40232834/article/details/108417771

## 14.foreach与for的比较

​	foreach是只读循环，不能在遍历时进行更改操作

​	多线程时的更改也不行

​	https://blog.csdn.net/qq_40232834/article/details/108417647

## 15.初始化器

- 集合初始化器

  ```csharp
  var list = new List<int>() { 1, 2 };
  ```

- 对象初始化器

  ```csharp
  class A
  {
  	public int a;
  }
  
  var a = new A() { a = 1 };
  ```

## 16.匿名类型

```csharp
var a = new { a = 1 };
```

## 17.隐式类型

```csharp
var
```

## 18.将类作为集合（自定义集合）

- 类要实现 `IEnumerable<T>`接口
- 维护一个数组
- 迭代自定义集合

## 19.扩展方法



