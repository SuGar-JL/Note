# C#杂记

## 1.UUID生成id：

tring id = System.Guid.NewGuid().ToString();

一句话即可，但此时id中有“-”符号存在，使用下面语句可变为纯字母+数字。

string id = System.Guid.NewGuid().ToString("N");

## 2.时间比较：

https://www.cnblogs.com/rwh871212/p/6999704.html

```C#
DateTime t1 = new DateTime(100);   
DateTime t2 = new DateTime(20);   
    
if (DateTime.Compare(t1, t2) > 0) Console.WriteLine("t1 > t2");     
if (DateTime.Compare(t1, t2) == 0) Console.WriteLine("t1 == t2");     
if (DateTime.Compare(t1, t2) < 0) Console.WriteLine("t1 < t2"); 
```

## 3.字符串转时间：

```C#
string st1="12:13";
string st2="14:14";
DateTime dt1=Convert.ToDateTime(st1);
DateTime dt2=Convert.ToDateTime(st2);
```

## 4.获取当前时间：

```C#
DateTime dt3=DateTime.Now;
```

## 5.命名方法委托：

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

## 6.使用方法回调，实现给文本框赋值：

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

## 7.获得某数据类型的范围（尺寸）

```C#
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



# 学习C#

## 一、数据类型

### 1.引用类型（Reference types）

引用类型不包含存储在变量中的实际数据，但它们包含对变量的引用。

换句话说，它们指的是一个内存位置。使用多个变量时，引用类型可以指向一个内存位置。如果内存位置的数据是由一个变量改变的，其他变量会自动反映这种值的变化。**内置的** 引用类型有：**object**、**dynamic** 和 **string**。

用户自定义引用类型有：class、interface 或 delegate。

### 2.对象（Object）类型

**对象（Object）类型** 是 C# 通用类型系统（Common Type System - CTS）中所有数据类型的终极基类。Object 是 System.Object 类的别名。所以对象（Object）类型可以被分配任何其他类型（值类型、引用类型、预定义类型或用户自定义类型）的值。但是，在分配值之前，需要先进行类型转换。

当一个值类型转换为对象类型时，则被称为 **装箱**；另一方面，当一个对象类型转换为值类型时，则被称为 **拆箱**。

### 3.动态（Dynamic）类型:

​	您可以存储任何类型的值在动态数据类型变量中。这些变量的类型检查是在运行时发生的。

声明动态类型的语法：

```C#
dynamic d = 20;
```

动态类型与对象类型相似，但是对象类型变量的类型检查是在编译时发生的，而动态类型变量的类型检查是在运行时发生的。

### 4.字符串（String）类型

**字符串（String）类型** 允许您给变量分配任何字符串值。字符串（String）类型是 System.String 类的别名。它是从对象（Object）类型派生的。字符串（String）类型的值可以通过两种形式进行分配：引号和 @引号。

```C#
String str = "w3cschool.cn";

@"w3cschool.cn";

//C# string 字符串的前面可以加 @（称作"逐字字符串"）将转义字符（\）当作普通字符对待，比如：
string str = @"C:\Windows";
//等价于：
string str = "C:\\Windows";

//@字符串中可以任意换行，换行符及缩进空格都计算在字符串长度之内。
string str = @"<script type=""text/javascript"">
    <!--     -->
    </script>";

```

### 5.指针类型（Pointer types）

指针类型变量存储另一种类型的内存地址。C# 中的指针与 C 或 C++ 中的指针有相同的功能。

```C#
//声明
type* identifier;
//如：
char* cptr;
int* iptr;
```

### 6.可空类型（Nullable）: ?

用于数据库

```C#
声明一个 nullable 类型（可空类型）的语法如下：
<data_type> ? <variable_name> = null;
int? num1 = null;
int? num2 = 45;
double? num3 = new double?();
double? num4 = 3.14157;
bool? boolval = new bool?();
```

### 7.值类型（Value types）

值类型变量可以直接分配给一个值。它们是从类 **System.ValueType** 中派生的。

值类型直接包含数据。比如 **int、char、float**，它们分别存储数字、字母、浮点数。当您声明一个 **int** 类型时，系统分配内存来存储值。

下表列出了 C# 2010 中可用的值类型：

| 类型    | 描述                                 | 范围                                                    | 默认值 |
| :------ | :----------------------------------- | :------------------------------------------------------ | :----- |
| bool    | 布尔值                               | True 或 False                                           | False  |
| byte    | 8 位无符号整数                       | 0 到 255                                                | 0      |
| char    | 16 位 Unicode 字符                   | U +0000 到 U +ffff                                      | ''     |
| decimal | 128 位精确的十进制值，28-29 有效位数 | (-7.9 x 1028 到 7.9 x 1028) / 100 到 28（金融计算常用） | 0.0M   |
| double  | 64 位双精度浮点型                    | (+/-)5.0 x 10-324 到 (+/-)1.7 x 10308                   | 0.0D   |
| float   | 32 位单精度浮点型                    | -3.4 x 1038 到 + 3.4 x 1038                             | 0.0F   |
| int     | 32 位有符号整数类型                  | -2,147,483,648 到 2,147,483,647                         | 0      |
| long    | 64 位有符号整数类型                  | -923,372,036,854,775,808 到 9,223,372,036,854,775,807   | 0L     |
| sbyte   | 8 位有符号整数类型                   | -128 到 127                                             | 0      |
| short   | 16 位有符号整数类型                  | -32,768 到 32,767                                       | 0      |
| uint    | 32 位无符号整数类型                  | 0 到 4,294,967,295                                      | 0      |
| ulong   | 64 位无符号整数类型                  | 0 到 18,446,744,073,709,551,615                         | 0      |
| ushort  | 16 位无符号整数类型                  | 0 到 65,535                                             | 0      |

如需得到一个类型或一个变量在特定平台上的准确尺寸，可以使用 **sizeof** 方法。表达式 *sizeof(type)* 产生以字节为单位存储对象或类型的存储尺寸。下面举例获取任何机器上 *int* 类型的存储尺寸：

```C#
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

当上面的代码被编译和执行时，它会产生下列结果：

```C#
Size of int: 4
```



## 二、运算符

### 1.sizeof

sizeof()返回数据类型的大小。sizeof(int)，将返回 4. 

### 2.typeof()

typeof()返回 class 的类型。typeof(StreamReader);

### 3.&

&返回变量的地址。&a; 将得到变量的实际地址。

### 4.*

`*`变量的指针。`*a`; 将指向一个变量。

### 5.? 

三元运算符

### 6.is

is判断对象是否为某一类型。If( Ford is Car) // 检查 Ford 是否是 Car 类的一个对象。

### 7.as

as强制转换，即使转换失败也不会抛出异常。

```C#
Object obj = new StringReader("Hello");
StringReader r = obj as StringReader;
```

### 8.Null 合并运算符（ ?? ）

Null 合并运算符用于定义可空类型和引用类型的默认值。Null 合并运算符为类型转换定义了一个预设值，以防可空类型的值为 Null。Null 合并运算符把操作数类型隐式转换为另一个可空（或不可空）的值类型的操作数的类型。

```c#
//如果第一个操作数的值为 null，则运算符返回第二个操作数的值，否则返回第一个操作数的值。下面的实例演示了这点：
double? num1 = null;
double? num2 = 3.14157;
double num3;
num3 = num1 ?? 5.34; 
Console.WriteLine("num3 的值： {0}", num3);
num3 = num2 ?? 5.34;
Console.WriteLine("num3 的值： {0}", num3);
Console.ReadLine();
```



## 三、类和对象：

### 1.partial关键字：

定义部分类或部分方法，部分类主要用于当一个类中的内容较多时将相似类中的内容拆分到不同的类中，并且部分类的名称必须相同。

### 2.析构函数：

构造方法是在创建类的对象时执行的，而析构方法则是在垃圾回收、释放资源时使用的。

```C#
~类名()
{
  语句块；
}
```

### 3.get 访问器和 set 访问器：

```C#
public int Id{get; set;}
public string Name{get; set;}
public double Price{get; set;}
/////////////////////////////////////////////
public double Price
{
    get
    {
        return price;
    }
    set
    {
     if(value >= 0)
     {
         price = value;
     }
     else
     {
         price = 0;
     }
    }
}
//////////////////////////////////////////////////
public int Id{get;}=1;
///////////////////////////////////////////
public int Id{private get; set;}
////////////////////////////////////
```

### 4.Console 类:

| 方法      | 作用                     |
| --------- | ------------------------ |
| Write     | 向控制台输出内容后不换行 |
| WriteLine | 向控制台输出内容后换行   |
| Read      | 从控制台上读取一个字符   |
| ReadLine  | 从控制台上读取一行字符   |

### 5.Math 类：

| 方法    | 描述                                                   |
| ------- | ------------------------------------------------------ |
| Abs     | 取绝对值                                               |
| Ceiling | 返回大于或等于指定的双精度浮点数的最小整数值（上取整） |
| Floor   | 返回小于或等于指定的双精度浮点数的最大整数值（下取整） |
| Equals  | 返回指定的对象实例是否相等                             |
| Max     | 返回两个数中较大数的值                                 |
| Min     | 返回两个数中较小数的值                                 |
| Sqrt    | 返回指定数字的平方根                                   |
| Round   | 返回四舍五入后的值                                     |

### 6.Random 类：

| 方法                              | 描述                                                   |
| --------------------------------- | ------------------------------------------------------ |
| Next()                            | 每次产生一个不同的随机正整数                           |
| Next(int max Value)               | 产生一个比 max Value 小的正整数                        |
| Next(int min Value,int max Value) | 产生一个 minValue~maxValue 的正整数，但不包含 maxValue |
| NextDouble()                      | 产生一个0.0~1.0的浮点数                                |
| NextBytes(byte[] buffer)          | 用随机数填充指定字节数的数组                           |

### 7.DateTime 类：

| 方法                     | 描述                                     |
| ------------------------ | ---------------------------------------- |
| Date                     | 获取实例的日期部分                       |
| Day                      | 获取该实例所表示的日期是一个月的第几天   |
| DayOfWeek                | 获取该实例所表示的日期是一周的星期几     |
| DayOfYear                | 获取该实例所表示的日期是一年的第几天     |
| Add(Timespan value)      | 在指定的日期实例上添加时间间隔值 value   |
| AddDays(double value)    | 在指定的日期实例上添加指定天数 value     |
| AddHours(double value)   | 在指定的日期实例上添加指定的小时数 value |
| AddMinutes(double value) | 在指定的日期实例上添加指定的分钟数 value |
| AddSeconds(double value) | 在指定的日期实例上添加指定的秒数 value   |
| AddMonths(int value)     | 在指定的日期实例上添加指定的月份 value   |
| AddYears (int value)     | 在指定的日期实例上添加指定的年份 value   |

## 四、字符串：

### 1.字符串常用方法：

| 编号 | 属性或方法名 | 作用                                                         |
| ---- | ------------ | ------------------------------------------------------------ |
| 1    | Length       | 获取字符串的长度，即字符串中字符的个数                       |
| 2    | IndexOf      | 返回整数，得到指定的字符串在原字符串中第一次出现的位置       |
| 3    | LastlndexOf  | 返回整数，得到指定的字符串在原字符串中最后一次出现的位置     |
| 4    | Starts With  | 返回布尔型的值，判断某个字符串是否以指定的字符串开头         |
| 5    | EndsWith     | 返回布尔型的值，判断某个字符串是否以指定的字符串结尾         |
| 6    | ToLower      | 返回一个新的字符串，将字符串中的大写字母转换成小写字母       |
| 7    | ToUpper      | 返回一个新的字符串，将字符串中的小写字母转换成大写字母       |
| 8    | Trim         | 返回一个新的字符串，不带任何参数时表示将原字符串中前后的空格删除。 参数为字符数组时表示将原字符串中含有的字符数组中的字符删除 |
| 9    | Remove       | 返回一个新的字符串，将字符串中指定位置的字符串移除           |
| 10   | TrimStart    | 返回一个新的字符串，将字符串中左侧的空格删除                 |
| 11   | TrimEnd      | 返回一个新的字符串，将字符串中右侧的空格删除                 |
| 12   | PadLeft      | 返回一个新的字符串，从字符串的左侧填充空格达到指定的字符串长度 |
| 13   | PadRight     | 返回一个新的字符串，从字符串的右侧填充空格达到指定的字符串长度 |
| 14   | Split        | 返回一个字符串类型的数组，根据指定的字符数组或者字符串数组中的字符 或字符串作为条件拆分字符串 |
| 15   | Replace      | 返回一个新的字符串，用于将指定字符串替换给原字符串中指定的字符串 str.Replace(",", "_"); |
| 16   | Substring    | 返回一个新的字符串，用于截取指定的字符串 str.Substring(beginIndex, endIndex); |
| 17   | Insert       | 返回一个新的字符串，将一个字符串插入到另一个字符串中指定索引的位置 str.Insert(1, "@@@"); |
| 18   | Concat       | 返回一个新的字符串，将多个字符串合并成一个字符串             |

### 2.数据类型转换：

1. 隐式类型转换：

   这些转换是 C# 默认的以安全方式进行的转换，不会导致数据丢失。例如，从小的整数类型转换为大的整数类型，从派生类转换为基类。

   隐式数值转换包括以下几种：

   - 从 sbyte 类型到 short,int,long,float,double,或 decimal 类型。
   - 从 byte 类型到 short,ushort,int,uint,long,ulong,float,double,或 decimal 类型。
   - 从 short 类型到 int,long,float,double,或 decimal 类型。
   - 从 ushort 类型到 int,uint,long,ulong,float,double,或 decimal 类型。
   - 从 int 类型到 long,float,double,或 decimal 类型。
   - 从 uint 类型到 long,ulong,float,double,或 decimal 类型。
   - 从 long 类型到 float,double,或 decimal 类型。
   - 从 ulong 类型到 float,double,或 decimal 类型。
   - 从 char 类型到 ushort,int,uint,long,ulong,float,double,或 decimal 类型。
   - 从 float 类型到 double 类型。

2. 显示类型转换：

   显式类型转换，即强制类型转换。显式转换需要强制转换运算符，而且强制转换会造成数据丢失。

   常用的类型转换方法如下表所示。

   | 方法       | 描述                                              |
   | ---------- | ------------------------------------------------- |
   | ToBoolean  | 如果可能的话，把类型转换为布尔型。                |
   | ToByte     | 把类型转换为字节类型。                            |
   | ToChar     | 如果可能的话，把类型转换为单个 Unicode 字符类型。 |
   | ToDateTime | 把类型（整数或字符串类型）转换为 日期-时间 结构。 |
   | ToDecimal  | 把浮点型或整数类型转换为十进制类型。              |
   | ToDouble   | 把类型转换为双精度浮点型。                        |
   | ToInt16    | 把类型转换为 16 位整数类型。                      |
   | ToInt32    | 把类型转换为 32 位整数类型。                      |
   | ToInt64    | 把类型转换为 64 位整数类型。                      |
   | ToSbyte    | 把类型转换为有符号字节类型。                      |
   | ToSingle   | 把类型转换为小浮点数类型。                        |
   | ToString   | 把类型转换为字符串类型。                          |
   | ToType     | 把类型转换为指定类型。                            |
   | ToUInt16   | 把类型转换为 16 位无符号整数类型。                |
   | ToUInt32   | 把类型转换为 32 位无符号整数类型。                |
   | ToUInt64   | 把类型转换为 64 位无符号整数类型。                |

3. 强制类型转换：

   ```C#
   double dbl_num = 12345678910.456;
   int k = (int) dbl_num ;//此处运用了强制转换
   ```

4. Parse 方法:

   数据类型  变量=数据类型.Parse(字符串类型的值);

5. Convert 方法:

   数据类型 变量名 = convert.To数据类型(变量名);

   | 方法                 | 说明                       |
   | -------------------- | -------------------------- |
   | Convert.ToInt16()    | 转换为整型(short)          |
   | Convert.ToInt32()    | 转换为整型(int)            |
   | Convert.ToInt64()    | 转换为整型(long)           |
   | Convert.ToChar()     | 转换为字符型(char)         |
   | Convert.ToString()   | 转换为字符串型(string)     |
   | Convert.ToDateTime() | 转换为日期型(datetime)     |
   | Convert.ToDouble()   | 转换为双精度浮点型(double) |
   | Conert.ToSingle()    | 转换为单精度浮点型(float)  |

6. 装箱与拆箱

   在 C# 语言中数据类型分为值类型和引用类型，将值类型转换为引用类型的操作称为装箱，相应地将引用类型转换成值类型称为拆箱。

   ```C#
   //装箱
   int a=100;
   string str=a.ToString();
   //拆箱
   a=int.Parse(str);
   ```

### 3.正则表达式：

   正则表达式中的元字符

| 编号 | 字符 | 描述                       |
| ---- | ---- | -------------------------- |
| 1    | .    | 匹配除换行符以外的所有字符 |
| 2    | \w   | 匹配字母、数字、下画线     |
| 3    | \s   | 匹配空白符（空格）         |
| 4    | \d   | 匹配数字                   |
| 5    | \b   | 匹配表达式的开始或结束     |
| 6    | ^    | 匹配表达式的开始           |
| 7    | $    | 匹配表达式的结束           |

   正则表达式中表示重复的字符

| 编 号 | 字 符 | 描 述         |
| ----- | ----- | ------------- |
| 1     | *     | 0次或多次字符 |
| 2     | ?     | 0次或1次字符  |
| 3     | +     | 1次或多次字符 |
| 4     | {n}   | n次字符       |
| 5     | {n,M} | n到M次字符    |
| 6     | {n, } | n次以上字符   |

   正则表达式中使用`|`分隔符表示多个正则表达式之间的或者关系，也就是在匹配某一个字符串时满足其中一个正则表达式即可。

   在 C# 语言中使用正则表达式时要用到 Regex 类,该类在 System.Text.RegularExpressions 名称空间中。

   在 Regex 类中使用 IsMatch 方法判断所匹配的字符串是否满足正则表达式的要求。

   ```C#
   class Program
   {
       static void Main(string[] args)
       {
           Console.WriteLine("请输入一个邮箱");
           string email = Console.ReadLine();
           Regex regex = new Regex(@"^(\w)+(\.\w)*@(\w)+((\.\w+)+)$");
           if (regex.IsMatch(email))
           {
               Console.WriteLine("邮箱格式正确。");
           }
           else
           {
               Console.WriteLine("邮箱格式不正确。");
           }
       }
   }
   ```

### 4.Regex 类：

| 字符        | 描述                                                         |
| ----------- | ------------------------------------------------------------ |
| \           | 转义字符，将一个具有特殊功能的字符转义为一个普通字符，或反过来 |
| (pattern)   | 匹配 pattern 并获取这一匹配                                  |
| (?:pattern) | 匹配 pattern 但不获取匹配结果                                |
| (?=pattern) | 正向预查，在任何匹配 pattern 的字符串开始处匹配查找字符串    |
| (?!pattern) | 负向预查，在任何不匹配 pattern 的字符串开始处匹配查找字符串  |
| x\|y        | 匹配x或y。例如，‘z\|food’能匹配“z”或“food”。‘(z\|f)ood’则匹配“zood”或“food” |
| [xyz]       | 字符集合。匹配所包含的任意一个字符。例如，‘[abc]’可以匹配“plain”中的‘a’ |
| [^xyz]      | 负值字符集合。匹配未包含的任意字符。例如，‘[^abc]’可以匹配“plain”中的‘p’ |
| [a-z]       | 匹配指定范围内的任意字符。例如，‘[a-z]’可以匹配'a'到'z'范围内的任意小写字母字符 |
| [^a-z]      | 匹配不在指定范围内的任意字符。例如，‘[^a-z]’可以匹配不在‘a’～‘z’'内的任意字符 |
| \B          | 匹配非单词边界                                               |
| \D          | 匹配一个非数字字符，等价于 [^0-9]                            |
| \f          | 匹配一个换页符                                               |
| \n          | 匹配一个换行符                                               |
| \r          | 匹配一个回车符                                               |
| \S          | 匹配任何非空白字符                                           |
| \t          | 匹配一个制表符                                               |
| \v          | 匹配一个垂直制表符。等价于 \x0b 和 \cK                       |
| \W          | 匹配任何非单词字符。等价于`[^A-Za-z0-9_]`                    |

| 编号 | 正则表达式               | 作用                                                         |
| ---- | ------------------------ | ------------------------------------------------------------ |
| 1    | \d{15}\|\d{18}           | 验证身份证号码（15位或18位）                                 |
| 2    | \d{3}-\d{8}\|\d{4}-\d{7} | 验证国内的固定电话（区号有3位或4位，并在区号和电话号码之 间加上-） |
| 3    | ^[1-9]\d*$               | 验证字符串中都是正整数                                       |
| 4    | ^-[1-9]\d*$              | 验证字符串中都是负整数                                       |
| 5    | ^-?[1-9]\d*$             | 验证字符串中是整数                                           |
| 6    | ^[A-Za-z]+$              | 验证字符串中全是字母                                         |
| 7    | A[A-Za-z0-9]+$           | 验证字符串由数字和字母构成                                   |
| 8    | [\u4e00-\u9fa5]          | 匹配字符串中的中文                                           |
| 9    | [^\x00-\xff]             | 匹配字符串中的双字节字符（包括汉字）                         |

## 五、数组：

```C#
//声明数组
datatype[] arrayName;
//例如：
double[] balance;
//初始化数组
double[] balance = new double[10];
balance[0] = 4500.0;

double[] balance = { 2340.0, 4523.69, 3421.0};

int [] marks = new int[5]  { 99,  98, 92, 97, 95};
int [] marks = new int[]  { 99,  98, 92, 97, 95};
//也可以赋值一个数组变量到另一个目标数组变量中。在这种情况下，目标和源会指向相同的内存位置
int [] marks = new int[]  { 99,  98, 92, 97, 95};
int[] score = marks;
```

### 1.交错数组

数组的数组

### 2.Array 类

#### 属性：

| 序号 | 属性 & 描述                                                  |
| :--- | :----------------------------------------------------------- |
| 1    | **IsFixedSize** 获取一个值，该值指示数组是否带有固定大小。   |
| 2    | **IsReadOnly** 获取一个值，该值指示数组是否只读。            |
| 3    | **Length** 获取一个 32 位整数，该值表示所有维度的数组中的元素总数。 |
| 4    | **LongLength** 获取一个 64 位整数，该值表示所有维度的数组中的元素总数。 |
| 5    | **Rank** 获取数组的秩（维度）。                              |

#### 方法：

| 序号 | 方法 & 描述                                                  |
| :--- | :----------------------------------------------------------- |
| 1    | **Clear** 根据元素的类型，设置数组中某个范围的元素为零、为 false 或者为 null。 |
| 2    | **Copy(Array, Array, Int32)** 从数组的第一个元素开始复制某个范围的元素到另一个数组的第一个元素位置。长度由一个 32 位整数指定。 |
| 3    | **CopyTo(Array, Int32)** 从当前的一维数组中复制所有的元素到一个指定的一维数组的指定索引位置。索引由一个 32 位整数指定。 |
| 4    | **GetLength** 获取一个 32 位整数，该值表示指定维度的数组中的元素总数。 |
| 5    | **GetLongLength** 获取一个 64 位整数，该值表示指定维度的数组中的元素总数。 |
| 6    | **GetLowerBound** 获取数组中指定维度的下界。                 |
| 7    | **GetType** 获取当前实例的类型。从对象（Object）继承。       |
| 8    | **GetUpperBound** 获取数组中指定维度的上界。                 |
| 9    | **GetValue(Int32)** 获取一维数组中指定位置的值。索引由一个 32 位整数指定。 |
| 10   | **IndexOf(Array, Object)** 搜索指定的对象，返回整个一维数组中第一次出现的索引。 |
| 11   | **Reverse(Array)** 逆转整个一维数组中元素的顺序。            |
| 12   | **SetValue(Object, Int32)** 给一维数组中指定位置的元素设置值。索引由一个 32 位整数指定。 |
| 13   | **Sort(Array)** 使用数组的每个元素的 IComparable 实现来排序整个一维数组中的元素。 |
| 14   | **ToString** 返回一个表示当前对象的字符串。从对象（Object）继承。 |

## 集合：

所有集合类或与集合相关的接口命名空间都是 System.Collection，在该命名空间中提供的常用接口如下表所示。

| 接口名称              | 作用                                                         |
| --------------------- | ------------------------------------------------------------ |
| IEnumerable           | 用于迭代集合中的项，该接口是一种声明式的接口                 |
| IEnumerator           | 用于迭代集合中的项，该接口是一种实现式的接口                 |
| ICollection           | .NET 提供的标准集合接口，所有的集合类都会直接或间接地实现这个接口 |
| IList                 | 继承自 IEnumerable 和 ICollection 接口，用于提供集合的项列表，并允许访问、查找集合中的项 |
| IDictionary           | 继承自 IEnumerable 和 ICollection 接口，与 IList 接口提供的功能类似，但集 合中的项是以键值对的形式存取的 |
| IDictionaryEnumerator | 用于迭代 IDictionary 接口类型的集合                          |

针对上表中的接口有一些常用的接口实现类，如下表所示。

| 类名称     | 实现接口                                                  | 特点                                                         |
| ---------- | --------------------------------------------------------- | ------------------------------------------------------------ |
| ArrayList  | ICollection、IList、IEnumerable、ICloneable               | 集合中元素的个数是可变的，提供添加、删除等方法               |
| Queue      | ICollection、IEnumerable、ICloneable                      | 集合实现了先进先出的机制，即元素将在集合的尾部添加、在集合的头部移除 |
| Stack      | ICollection、IEnumerable、ICloneable                      | 集合实现了先进后出的机制，即元素将在集合的尾部添加、在集合的尾部移除 |
| Hashtable  | IDictionary、ICollection、IEnumerable、 ICloneable 等接口 | 集合中的元素是以键值对的形式存放的，是 DictionaryEntry 类型的 |
| SortedList | IDictionary、ICollection、IEnumerable、 ICloneable 等接口 | 与 Hashtable 集合类似，集合中的元素以键值对的形式存放，不同的是该集合会按照 key 值自动对集合中的元素排序 |

### 1.ArrayList 类

| 构造方法                 | 作用                                                         |
| ------------------------ | ------------------------------------------------------------ |
| ArrayList()              | 创建 ArrayList 的实例，集合的容量是默认初始容量              |
| ArrayList(ICollection c) | 创建 ArrayList 的实例，该实例包含从指定实例中复制的元素，并且初始容量与复制的元素个数相同 |
| ArrayList(int capacity)  | 创建 ArrayList 的实例，并设置其初始容量                      |

ArrayList 类中常用的属性和方法如下表所示。

| 属性或方法                                                  | 作用                                                         |
| ----------------------------------------------------------- | ------------------------------------------------------------ |
| int Add(object value)                                       | 向集合中添加 object 类型的元素，返回元素在集合中的下标       |
| void AddRange(ICollection c)                                | 向集合中添加另一个集合 c                                     |
| Capacity                                                    | 属性，用于获取或设置集合中可以包含的元素个数                 |
| void Clear()                                                | 从集合中移除所有元素                                         |
| bool Contains(object item)                                  | 判断集合中是否含有 item 元素，若含有该元素则返回 True, 否则返回 False |
| void CopyTo(Array array)                                    | 从目标数组 array 的第 0 个位置开始，将整个集合中的元素复制到类型兼容的数组 array 中 |
| void CopyTo(Array array,int arraylndex)                     | 从目标数组 array 的指定索引 arraylndex 处，将整个集合中的元素赋值到类型兼容的数组 array 中 |
| void CopyTo(int index,Array array,int arrayIndex,int count) | 从目标数组 array 的指定索引 arrayindex 处，将集合中从指定索引 index 开始的 count 个元素复制到类型兼容的数组 array 中 |
| Count                                                       | 属性，用于获取集合中实际含有的元素个数                       |
| int IndexOf(object value)                                   | 返回 value 值在集合中第一次出现的位置                        |
| int IndexOf(object value,int startIndex)                    | 返回 value 值在集合的 startindex 位置开始第一次出现的位置    |
| int IndexOf(object value,int startIndex,int count)          | 返回 value 值在集合的 startindex 位置开始 count 个元素中第一次出现的位置 |
| int LastIndexOf(object value)                               | 返回 value 值在集合中最后一次出现的位置                      |
| int LastIndexOf(object value,int startIndex)                | 返回 value 值在集合的 startindex 位置开始最后一次出现的位置  |
| int LastIndexOf(object value,int startIndex,int count)      | 入元素 value值在集合的 startindex 位置开始 count 个元素中最后一次出现的位置 |
| void Insert(int index,object value)                         | 返回 value 向集合中的指定索引 index 处插                     |
| void InsertRange(int index,ICollection c)                   | 向集合中的指定索引 index 处插入一个集合                      |
| void Remove(object obj)                                     | 将指定兀素 obj 从集合中移除                                  |
| void RemoveAt(int index)                                    | 移除集合中指定位置 index 处的元素                            |
| void RemoveRange(int index,int count)                       | 移除集合中从指定位置 index 处的 count 个元素                 |
| void Reverse()                                              | 将集合中的元素顺序反转                                       |
| void Reverse(int index,int count)                           | 将集合中从指定位置 index 处的 count 个元素反转               |
| void Sort()                                                 | 将集合中的元素排序，默认从小到大排序                         |
| void Sort(IComparer comparer)                               | 将集合中的元素按照比较器 comparer 的方式排序                 |
| void Sort(int index,int count,IComparer comparer)           | 将集合中的元素从指定位置 index 处的 count 个元素按照比较器 comparer 的方式排序 |
| void TrimToSize()                                           | 将集合的大小设置为集合中元素的实际个数                       |

### 2.Queue (队列) 

| 构造方法                              | 作用                                                         |
| ------------------------------------- | ------------------------------------------------------------ |
| Queue()                               | 创建 Queue 的实例，集合的容量是默认初始容量 32 个元素，使用默认的增长因子 |
| Queue(ICollection col)                | 创建 Queue 的实例，该实例包含从指定实例中复制的元素，并且初始容量与复制的元素个数、增长因子相同 |
| Queue(int capacity)                   | 创建 Queue 的实例，并设置其指定的元素个数，默认增长因子      |
| Queue(int capacity, float growFactor) | 创建 Queue 的实例，并设置其指定的元素个数和增长因子          |

Queue类中常用的属性和方法如下表所示。

| 属性或方法                          | 作用                                                   |
| ----------------------------------- | ------------------------------------------------------ |
| Count                               | 属性，获取 Queue 实例中包含的元素个数                  |
| void Clear()                        | 清除 Queue 实例中的元素                                |
| bool Contains(object obj)           | 判断 Queue 实例中是否含有 obj 元素                     |
| void CopyTo(Array array, int index) | 将 array 数组从指定索引处的元素开始复制到 Queue 实例中 |
| object Dequeue()                    | 移除并返回位于 Queue 实例开始处的对象                  |
| void Enqueue(object obj)            | 将对象添加到 Queue 实例的结尾处                        |
| object Peek()                       | 返回位于 Queue 实例开始处的对象但不将其移除            |
| object[] ToArray()                  | 将 Queue 实例中的元素复制到新数组                      |
| void TrimToSize()                   | 将容量设置为 Queue 实例中元素的实际数目                |
| IEnumerator GetEnumerator()         | 返回循环访问 Queue 实例的枚举数                        |

### 3.Stack (栈)

| 构造方法               | 作用                                                         |
| ---------------------- | ------------------------------------------------------------ |
| Stack()                | 使用初始容量创建 Stack 的对象                                |
| Stack(ICollection col) | 创建 Stack 的实例，该实例包含从指定实例中复制的元素，并且初始容量与复制的元素个数、增长因子相同 |
| Stack(int capacity)    | 创建 Stack 的实例，并设置其初始容量                          |

Stack 类中的常用属性和方法如下表所示。

| 属性或方法           | 作用                                       |
| -------------------- | ------------------------------------------ |
| Push(object obj)     | 向栈中添加元素，也称入栈                   |
| object Peek()        | 用于获取栈顶元素的值，但不移除栈顶元素的值 |
| object Pop()         | 用于移除栈顶元素的值，并移除栈顶元素       |
| Clear()              | 从 Stack 中移除所有的元素                  |
| Contains(object obj) | 判断某个元素是否在 Stack 中                |
| object[] ToArray()   | 复制 Stack 到一个新的数组中                |

### 4.Hashtable 类

Hashtable 类提供的构造方法有很多，最常用的是不含参数的构造方法，即通过如下代码来实例化 Hashtable 类。

Hashtable 对象名 = new Hashtable ();

Hashtable 类中常用的属性和方法如下表所示。

| 属性或方法                        | 作用                                  |
| --------------------------------- | ------------------------------------- |
| Count                             | 集合中存放的元素的实际个数            |
| void Add(object key,object value) | 向集合中添加元素                      |
| void Remove(object key)           | 根据指定的 key 值移除对应的集合元素   |
| void Clear()                      | 清空集合                              |
| ContainsKey (object key)          | 判断集合中是否包含指定 key 值的元素   |
| ContainsValue(object value)       | 判断集合中是否包含指定 value 值的元素 |

### 5.SortedList 类

SortedList 集合中所使用的属性和方法与上一节《[C# Hashtable](http://c.biancheng.net/view/2897.html)》中介绍的 Hashtable 比较类似，这里不再赘述。

## Dictionary用法：

1、创建及初始化

 Dictionary<int,string> myDictionary = new Dictionary<int,string>();

 2、添加元素

```C#
myDictionary.Add(1,"C#");
myDictionary.Add(2,"C++");
myDictionary.Add(3,"ASP.NET");
myDictionary.Add(4,"MVC");
```

 3、通过Key查找元素

```C#
if(myDictionary.ContainsKey(1))
{
	Console.WriteLine("Key:{0},Value:{1}","1", myDictionary[1]);
}
```

 4、通过KeyValuePair遍历元素

```C#
foreach(KeyValuePair<int,string>kvp in myDictionary)
{
	Console.WriteLine("Key = {0}, Value = {1}",kvp.Key, kvp.Value);
}
```

5、仅遍历键 Keys 属性

```C#
Dictionary<int,string>.KeyCollection keyCol=myDictionary.Keys;
foreach(intkey in keyCol)
{
	Console.WriteLine("Key = {0}", key);
}
```

6、仅遍历值 Valus属性

```C#
Dictionary<int,string>.ValueCollection valueCol=myDictionary.Values;
foreach(stringvalueinvalueCol)
{
	Console.WriteLine("Value = {0}", value);
}
```

7、通过Remove方法移除指定的键值

```C#
myDictionary.Remove(1);
if(myDictionary.ContainsKey(1))
{
　　Console.WriteLine("Key:{0},Value:{1}","1", myDictionary[1]);
}
else
{
	Console.WriteLine("不存在 Key : 1"); 
}
```



**其它常见属性和方法的说明：**

| Comparer      | 获取用于确定字典中的键是否相等的 IEqualityComparer |
| ------------- | -------------------------------------------------- |
| Count         | 获取包含在 Dictionary中的键/值对的数目             |
| Item          | 获取或设置与指定的键相关联的值                     |
| Keys          | 获取包含 Dictionary中的键的集合                    |
| Values        | 获取包含 Dictionary中的值的集合                    |
| Add           | 将指定的键和值添加到字典中                         |
| Clear         | 从 Dictionary中移除所有的键和值                    |
| ContainsKey   | 确定 Dictionary是否包含指定的键                    |
| ContainsValue | 确定 Dictionary是否包含特定值                      |
| GetEnumerator | 返回循环访问 Dictionary的枚举数                    |
| GetType       | 获取当前实例的 Type （从 Object 继承）             |
| Remove        | 从 Dictionary中移除所指定的键的值                  |
| ToString      | 返回表示当前 Object的 String （从 Object 继承）    |
| TryGetValue   | 获取与指定的键相关联的值                           |