# 学习C#

## 一、数据类型

### 1.引用类型（Reference types）

引用类型不包含存储在变量中的实际数据，但它们包含对变量的引用。

换句话说，它们指的是一个内存位置。使用多个变量时，引用类型可以指向一个内存位置。如果内存位置的数据是由一个变量改变的，其他变量会自动反映这种值的变化。**内置的** 引用类型有：**object**、**dynamic** 和 **string**。

用户自定义引用类型有：class、interface 或 delegate。

### 2.对象（Object）类型

**对象（Object）类型** 是 csharp 通用类型系统（Common Type System - CTS）中所有数据类型的终极基类。Object 是 System.Object 类的别名。所以对象（Object）类型可以被分配任何其他类型（值类型、引用类型、预定义类型或用户自定义类型）的值。但是，在分配值之前，需要先进行类型转换。

当一个值类型转换为对象类型时，则被称为 **装箱**；另一方面，当一个对象类型转换为值类型时，则被称为 **拆箱**。

### 3.动态（Dynamic）类型:

​	您可以存储任何类型的值在动态数据类型变量中。这些变量的类型检查是在运行时发生的。

声明动态类型的语法：

```csharp
dynamic d = 20;
```

动态类型与对象类型相似，但是对象类型变量的类型检查是在编译时发生的，而动态类型变量的类型检查是在运行时发生的。

### 4.字符串（String）类型

**字符串（String）类型** 允许您给变量分配任何字符串值。字符串（String）类型是 System.String 类的别名。它是从对象（Object）类型派生的。字符串（String）类型的值可以通过两种形式进行分配：引号和 @引号。

```csharp
String str = "w3cschool.cn";

@"w3cschool.cn";

//csharp string 字符串的前面可以加 @（称作"逐字字符串"）将转义字符（\）当作普通字符对待，比如：
string str = @"C:\Windows";
//等价于：
string str = "C:\\Windows";

//@字符串中可以任意换行，换行符及缩进空格都计算在字符串长度之内。
string str = @"<script type=""text/javascript"">
    <!--     -->
    </script>";

```

### 5.指针类型（Pointer types）

指针类型变量存储另一种类型的内存地址。csharp 中的指针与 C 或 C++ 中的指针有相同的功能。

```csharp
//声明
type* identifier;
//如：
char* cptr;
int* iptr;
```

### 6.可空类型（Nullable）: ?

用于数据库

```csharp
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

下表列出了 csharp 2010 中可用的值类型：

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

当上面的代码被编译和执行时，它会产生下列结果：

```csharp
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

`as`强制转换，即使转换失败也不会抛出异常。

```csharp
Object obj = new StringReader("Hello");
StringReader r = obj as StringReader;
```

### 8.Null 合并运算符（ ?? ）

Null 合并运算符用于定义可空类型和引用类型的默认值。Null 合并运算符为类型转换定义了一个预设值，以防可空类型的值为 Null。Null 合并运算符把操作数类型隐式转换为另一个可空（或不可空）的值类型的操作数的类型。

```csharp
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

```csharp
~类名()
{
  语句块；
}
```

### 3.get 访问器和 set 访问器：

```csharp
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

   这些转换是 csharp 默认的以安全方式进行的转换，不会导致数据丢失。例如，从小的整数类型转换为大的整数类型，从派生类转换为基类。

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

   ```csharp
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

   在 csharp 语言中数据类型分为值类型和引用类型，将值类型转换为引用类型的操作称为装箱，相应地将引用类型转换成值类型称为拆箱。

   ```csharp
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

   在 csharp 语言中使用正则表达式时要用到 Regex 类,该类在 System.Text.RegularExpressions 名称空间中。

   在 Regex 类中使用 IsMatch 方法判断所匹配的字符串是否满足正则表达式的要求。

   ```csharp
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
| 3    | \^[1-9]\d*$              | 验证字符串中都是正整数                                       |
| 4    | ^-[1-9]\d*$              | 验证字符串中都是负整数                                       |
| 5    | ^-?[1-9]\d*$             | 验证字符串中是整数                                           |
| 6    | \^[A-Za-z]+$             | 验证字符串中全是字母                                         |
| 7    | A[A-Za-z0-9]+$           | 验证字符串由数字和字母构成                                   |
| 8    | [\u4e00-\u9fa5]          | 匹配字符串中的中文                                           |
| 9    | [^\x00-\xff]             | 匹配字符串中的双字节字符（包括汉字）                         |

## 五、数组：

```csharp
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
| 1    | **Clear(Array, Index, Lenght)** 根据元素的类型，设置数组中某个范围的元素为零、为 false 或者为 null。 |
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

## 六、集合：

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

| 类名称                  | 实现接口                                                  | 特点                                                         |
| ----------------------- | --------------------------------------------------------- | ------------------------------------------------------------ |
| ArrayList               | ICollection、IList、IEnumerable、ICloneable               | 集合中元素的个数是可变的，提供添加、删除等方法               |
| Queue                   | ICollection、IEnumerable、ICloneable                      | 集合实现了先进先出的机制，即元素将在集合的尾部添加、在集合的头部移除 |
| Stack                   | ICollection、IEnumerable、ICloneable                      | 集合实现了先进后出的机制，即元素将在集合的尾部添加、在集合的尾部移除 |
| Hashtable               | IDictionary、ICollection、IEnumerable、 ICloneable 等接口 | 集合中的元素是以键值对的形式存放的，是 DictionaryEntry 类型的 |
| SortedList              | IDictionary、ICollection、IEnumerable、 ICloneable 等接口 | 与 Hashtable 集合类似，集合中的元素以键值对的形式存放，不同的是该集合会按照 key 值自动对集合中的元素排序 |
| List<T>                 |                                                           |                                                              |
| LinkedList<T>           |                                                           | 双向                                                         |
| Dictionary<TKey,TValue> |                                                           | 字典，基于哈希表，查询速度很快                               |
| SortedDictionary<k,v>   |                                                           |                                                              |

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

SortedList 集合中所使用的属性和方法与上一节《[csharp Hashtable](http://c.biancheng.net/view/2897.html)》中介绍的 Hashtable 比较类似，这里不再赘述。

## 七、结构(Struct)：

### 定义结构

```csharp
using System;
     
struct Books
{
   public string title;
   public string author;
   public string subject;
   public int book_id;
};  

public class testStructure
{
   public static void Main(string[] args)
   {

      Books Book1;        /* 声明 Book1，类型为 Book */
      Books Book2;        /* 声明 Book2，类型为 Book */

      /* book 1 详述 */
      Book1.title = "C Programming";
      Book1.author = "Nuha Ali"; 
      Book1.subject = "C Programming Tutorial";
      Book1.book_id = 6495407;

      /* book 2 详述 */
      Book2.title = "Telecom Billing";
      Book2.author = "Zara Ali";
      Book2.subject =  "Telecom Billing Tutorial";
      Book2.book_id = 6495700;

      /* 打印 Book1 信息 */
      Console.WriteLine( "Book 1 title : {0}", Book1.title);
      Console.WriteLine("Book 1 author : {0}", Book1.author);
      Console.WriteLine("Book 1 subject : {0}", Book1.subject);
      Console.WriteLine("Book 1 book_id :{0}", Book1.book_id);

      /* 打印 Book2 信息 */
      Console.WriteLine("Book 2 title : {0}", Book2.title);
      Console.WriteLine("Book 2 author : {0}", Book2.author);
      Console.WriteLine("Book 2 subject : {0}", Book2.subject);
      Console.WriteLine("Book 2 book_id : {0}", Book2.book_id);       

      Console.ReadKey();

   }
}


当上面的代码被编译和执行时，它会产生下列结果：

Book 1 title : C Programming
Book 1 author : Nuha Ali
Book 1 subject : C Programming Tutorial
Book 1 book_id : 6495407
Book 2 title : Telecom Billing
Book 2 author : Zara Ali
Book 2 subject : Telecom Billing Tutorial
Book 2 book_id : 6495700
```

### csharp 结构的特点

您已经用了一个简单的名为 Books 的结构。在 csharp 中的结构与传统的 C 或 C++ 中的结构不同。csharp 中的结构有以下特点：

- 结构可带有方法、字段、索引、属性、运算符方法和事件。
- 结构可定义构造函数，但**不能定义析构函数**。但是，您**不能为结构定义默认的构造函数**。默认的构造函数是自动定义的，且不能被改变。
- 与类不同，结构**不能继承**其他的结构或类。
- 结构**不能作为**其他结构或类的**基础结构**。
- 结构**可实现一个或多个接口**。
- 结构**成员**不能指定为 abstract、virtual 或 protected。
- 当您使用 **New** 操作符创建一个结构对象时，会调用适当的构造函数来创建结构。与类不同，**结构可以不使用 New** 操作符即可被实例化。
- 如果不使用 New 操作符，只有在所有的字段都被初始化之后，字段才被赋值，对象才被使用。

### 类 vs 结构

类和结构有以下几个基本的不同点：

- 类是引用类型，结构是**值类型**。
- 结构不支持继承。
- 结构不能声明默认的构造函数。

针对上述讨论，让我们重写前面的实例：

```csharp
using System;
     
struct Books
{
    //属性
   private string title;
   private string author;
   private string subject;
   private int book_id;
    //方法
   public void getValues(string t, string a, string s, int id)
   {
      title = t;
      author = a;
      subject = s;
      book_id = id;
   }
   public void display()
   {
      Console.WriteLine("Title : {0}", title);
      Console.WriteLine("Author : {0}", author);
      Console.WriteLine("Subject : {0}", subject);
      Console.WriteLine("Book_id :{0}", book_id);
   }

};  

public class testStructure
{
   public static void Main(string[] args)
   {

      Books Book1 = new Books(); /* 声明 Book1，类型为 Book */
      Books Book2 = new Books(); /* 声明 Book2，类型为 Book */

      /* book 1 详述 */
      Book1.getValues("C Programming",
      "Nuha Ali", "C Programming Tutorial",6495407);

      /* book 2 详述 */
      Book2.getValues("Telecom Billing",
      "Zara Ali", "Telecom Billing Tutorial", 6495700);

      /* 打印 Book1 信息 */
      Book1.display();

      /* 打印 Book2 信息 */
      Book2.display(); 

      Console.ReadKey();

   }
}


当上面的代码被编译和执行时，它会产生下列结果：

Title : C Programming
Author : Nuha Ali
Subject : C Programming Tutorial
Book_id : 6495407
Title : Telecom Billing
Author : Zara Ali
Subject : Telecom Billing Tutorial
Book_id : 6495700
```

## 八、枚举（Enum）声明与使用：

枚举是**值数据类型**。换句话说，枚举包含自己的值，且不能继承或传递继承。

声明：

```csharp
enum <enum_name>
{ 
    enumeration list 
};
```

其中，

- *enum_name* 指定枚举的类型名称。
- *enumeration list* 是一个用逗号分隔的标识符列表。

枚举列表中的每个符号代表一个整数值，一个比它前面的符号大的整数值。默认情况下，第一个枚举符号的值是 0.例如：

```csharp
enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };

//实例
using System;
namespace EnumApplication
{
   class EnumProgram
   {
      enum Days { Sun, Mon, tue, Wed, thu, Fri, Sat };

      static void Main(string[] args)
      {
         int WeekdayStart = (int)Days.Mon;
         int WeekdayEnd = (int)Days.Fri;
         Console.WriteLine("Monday: {0}", WeekdayStart);//Monday: 1
         Console.WriteLine("Friday: {0}", WeekdayEnd);//Friday: 5
         Console.ReadKey();
      }
   }
}
```



## 九、Dictionary用法：

1、创建及初始化

 Dictionary<int,string> myDictionary = new Dictionary<int,string>();

 2、添加元素

```csharp
myDictionary.Add(1,"csharp");
myDictionary.Add(2,"C++");
myDictionary.Add(3,"ASP.NET");
myDictionary.Add(4,"MVC");
```

 3、通过Key查找元素

```csharp
if(myDictionary.ContainsKey(1))
{
	Console.WriteLine("Key:{0},Value:{1}","1", myDictionary[1]);
}
```

 4、通过KeyValuePair遍历元素

```csharp
foreach(KeyValuePair<int,string>kvp in myDictionary)
{
	Console.WriteLine("Key = {0}, Value = {1}",kvp.Key, kvp.Value);
}
```

5、仅遍历键 Keys 属性

```csharp
Dictionary<int,string>.KeyCollection keyCol=myDictionary.Keys;
foreach(intkey in keyCol)
{
	Console.WriteLine("Key = {0}", key);
}
```

6、仅遍历值 Valus属性

```csharp
Dictionary<int,string>.ValueCollection valueCol=myDictionary.Values;
foreach(stringvalueinvalueCol)
{
	Console.WriteLine("Value = {0}", value);
}
```

7、通过Remove方法移除指定的键值

```csharp
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

## 十、类

1. 类的默认访问标识符是 **internal**，成员的默认访问标识符是 **private**。

2. 成员变量是对象的属性（从设计角度），且它们**保持私有**来实现**封装**

### 1. 析构函数

	也叫对象的终结器

   - 当类的对象超出范围时执行，调用对象结束执行
   - 无返回值，无参数
   - 用于在结束程序（比如关闭文件、释放内存等）之前释放资源
   - 不能继承或重载

   ```csharp
   using System;
   namespace LineApplication
   {
      class Line
      {
         private double length;   // 线条的长度
         public Line()  // 构造函数
         {
            Console.WriteLine("对象已创建");
         }
         ~Line() //析构函数
         {
            Console.WriteLine("对象已删除");
         }
   
         public void setLength( double len )
         {
            length = len;
         }
         public double getLength()
         {
            return length;
         }
   
         static void Main(string[] args)
         {
            Line line = new Line();
            // 设置线条长度
            line.setLength(6.0);
            Console.WriteLine("线条的长度： {0}", line.getLength());           
         }
      }
   }
   
   //输出：
   对象已创建
   线条的长度： 6
   对象已删除
   ```


### 2. 静态成员：static

- 无论创建多少个类的对象，只会有一个该静态成员的副本，可用于记住创建了多少个类对象
- 静态成员（属性和方法）属于类，无论哪个对象对其修改，都是改的同一个，使用时要注意

### 3. 继承

is a  狗是哺乳动物
java中用关键字extands实现继承，C#用“:”

#### 基类的初始化

```csharp
public Tabletop(double l, double w) : base(l, w)
{ }
```

### 4. 多态性

#### 分类

1. 静态多态性：函数的响应是在编译时发生的
2. 动态多态性：函数的响应是在运行时发生的。

#### 静态多态性

在编译时，函数和对象的连接机制被称为**早期绑定**，也被称为**静态绑定**。

##### 实现

- 函数重载
- 运算符重载

###### 函数重载

函数名称相同，参数类型不同/参数数目不同，不能重载只有返回类型不同的函数声明。

###### 运算符重载

（关键字 `operator`）重定义或重载 C# 中内置的运算符
重载 + 运算符来把两个 Box 对象相加：

```csharp
public static Box operator+ (Box b, Box c)
{
	Box box = new Box();
	box.length = b.length + c.length;
	box.breadth = b.breadth + c.breadth;
	box.height = b.height + c.height;
	return box;
}
//使用：
Box3 = Box1 + Box2;
```

*不是所有的运算符都能重载。*

#### 动态多态性

##### 实现

- 抽象类
- 虚方法

###### 抽象类

关键字 `abstract`
有关抽象类的一些规则：

1. 抽象类不能实例化
2. 抽象类外部不能声明抽象方法
3. 关键字 `sealed`，可以将类声明为密封类，不能被继承。但抽象类不能被声明为 `sealed`

抽象类定义：

```csharp
//抽象类
abstract class Shape
{
	//抽象方法
	public abstract int area();
}

class Test : Shape
{	
	//重写抽象类方法：override关键字，java中用于重写检查，看抽象类是否有此方法以及重写的正确性
	public override int area ()
	{ 
		Console.WriteLine("Rectangle 类的面积：");
		return (width * length); 
	}
}
```

###### 虚方法

关键字 `virtual`

- 当有一个定义在类（不是抽象类）中的*函数需要在继承类中实现*时，可以使用虚方法
- 虚方法可以在不同的继承类中有不同的实现。对虚方法的调用是在运行时发生的

```csharp
using System;
namespace PolymorphismApplication
{
	class Shape 
	{
		protected int width, height;
		public Shape( int a=0, int b=0)
		{
			width = a;
			height = b;
		}
		//虚方法
		public virtual int area()
		{
			Console.WriteLine("父类的面积：");
			return 0;
		}
	}
	class Rectangle: Shape
	{
		public Rectangle( int a=0, int b=0): base(a, b)
		{

		}
		//重写虚方法
		public override int area ()
		{
			Console.WriteLine("Rectangle 类的面积：");
			return (width * height); 
		}
	}
}
```

**抽象方法和虚方法的区别:**

1. 虚方法必须有实现部分，抽象方法没有提供实现部分，抽象方法是一种强制派生类覆盖的方法，否则派生类将不能被实例化。
2. 抽象方法只能在抽象类中声明，虚方法不是。如果类包含抽象方法，那么该类也是抽象的，也必须声明类是抽象的。
3. 抽象方法必须在派生类中重写，这一点和接口类似，虚方法不需要再派生类中重写。
4. 简单说，抽象方法是需要子类去实现的。虚方法是已经实现了的，可以被子类覆盖，也可以不覆盖，取决于需求。

### 5. 接口

接口定义了所有类继承接口时应遵循的语法合同。接口定义了语法合同 "是什么" 部分，派生类定义了语法合同 "怎么做" 部分。

#### 接口声明

`interface`关键字，与类的声明类似。默认是` public` 的。

```csharp
	public interface ITransactions
	{
		// 接口成员（方法只有名称，没有方法体）
		void showTransaction();
		double getAmount();
	}
```

#### 接口实现

方式和继承一样，用“`:`”

```csharp
public class Transaction : ITransactions
{
	private string tCode;
  	private string date;
  	private double amount;
  	public Transaction()
  	{
		tCode = " ";
	 	date = " ";
         amount = 0.0;
  	}
  	public Transaction(string c, string d, double a)
  	{
	 	tCode = c;
	 	date = d;
	 	amount = a;
  	}
  	//实现接口的方法
  	public double getAmount()
  	{
	 	return amount;
  	}
  	//实现接口的方法
  	public void showTransaction()
  	{
	 	Console.WriteLine("Transaction: {0}", tCode);
	 	Console.WriteLine("Date: {0}", date);
	 	Console.WriteLine("Amount: {0}", getAmount());
  	}
}
```

#### 接口使用的注意事项

1. 接口方法不能用public abstract等修饰。
2. 接口内不能有字段变量，构造函数。
3. 接口内可以定义属性（有get和set的方法）。如string color { get ; set ; }这种。
4. 实现接口时，必须和接口的格式一致。
5. 必须实现接口的所有方法。

### 6. 命名空间

在不同的命名空间可以声明相同名称的类，有点像`java`的包`package`

#### 使用命名空间

```csharp
using System;
namespace first_space
{
	class namespace_cl
	{
		public void func()
		{
			Console.WriteLine("Inside first_space");
		}
	}
}
namespace second_space
{
	class namespace_cl
	{
		public void func()
		{
			Console.WriteLine("Inside second_space");
		}
	}
}

class TestClass
{
	static void Main(string[] args)
	{
        //实例化命名空间的类
		first_space.namespace_cl fc = new first_space.namespace_cl();
		second_space.namespace_cl sc = new second_space.namespace_cl();
		fc.func();
		c.func();
		Console.ReadKey();
	}
}
```

#### using 关键字

相当于`java`中的`import`关键字

#### 命名空间的嵌套

```csharp
using System;
using first_space;
//这句是关键
using first_space.second_space;

namespace first_space
{
   class abc
   {
      public void func()
      {
         Console.WriteLine("Inside first_space");
      }
   }
   namespace second_space
   {
      class efg
      {
         public void func()
         {
            Console.WriteLine("Inside second_space");
         }
      }
   }   
}
 
class TestClass
{
   static void Main(string[] args)
   {
      abc fc = new abc();
      efg sc = new efg();
      fc.func();
      sc.func();
      Console.ReadKey();
   }
}
```

### 7. 预处理器指令

1. 预处理器指令 以 # 开始。且在一行上，只有空白字符可以出现在预处理器指令之前。预处理器指令不是语句，所以它们不以分号`;`结束。
2. C# 编译器没有一个单独的预处理器，但是，指令被处理时就像是有一个单独的预处理器一样。在 C# 中，预处理器指令用于在条件编译中起作用。与 C 和 C++ 不同指令不用，它们不是用来创建宏。一个预处理器指令必须是该行上的唯一指令。

**C# 预处理器指令列表:**

| 预处理器指令 | 描述                                                         |
| :----------- | :----------------------------------------------------------- |
| #define      | 定义符号。                                                   |
| #if          | 它用于测试符号是否为真。                                     |
| #else        | 它用于创建复合条件指令，与 #if 一起使用。                    |
| #elif        | 它用于创建复合条件指令。                                     |
| #endif       | 指定一个条件指令的结束。                                     |
| #line        | 它可以让您修改编译器的行数以及（可选地）输出错误和警告的文件名。 |
| #error       | 它允许从代码的指定位置生成一个错误。                         |
| #warning     | 它允许从代码的指定位置生成一级警告。                         |
| #region      | 它可以让您在使用 Visual Studio Code Editor 的大纲特性时，指定一个可展开或折叠的代码块。 |
| #endregion   | 它标识着 #region 块的结束。                                  |

#### #define 预处理器

`#define` 预处理器指令创建符号常量。
`#define` 允许您定义一个符号，这样，通过使用符号作为传递给` #if `指令的表达式，表达式将返回` true`。它的语法如下：

```csharp
#define symbol
```

下面的程序说明了这点：

```csharp
#define PI 
using System;
namespace PreprocessorDAppl
{
   class Program
   {
      static void Main(string[] args)
      {
         #if (PI)
            Console.WriteLine("PI is defined");
         #else
            Console.WriteLine("PI is not defined");
         #endif
         Console.ReadKey();
      }
   }
}
```

当上面的代码被编译和执行时，它会产生下列结果：

```csharp
PI is defined
```

#### 条件指令

使用` #if `指令来创建一个条件指令。用于测试符号是否为真。如果为真，编译器会执行 #if 和下一个指令之间的代码。

条件指令的语法：

```csharp
#if symbol [operator symbol]...
```

其中，`symbol `是要测试的符号名称。您也可以使用 `true` 和 `false`，或在符号前放置否定运算符。

运算符符号是用于评价符号的运算符。可以是下列运算符之一：

- == (equality)
- != (inequality)
- && (and)
- || (or)

也可以用括号把符号和运算符进行分组。条件指令用于在调试版本或编译指定配置时编译代码。一个以 `#if`指令开始的条件指令，必须显示地以一个` #endif `指令终止。

下面的程序演示了条件指令的用法：

```csharp
#define DEBUG
#define VC_V10
using System;
public class TestClass
{
   public static void Main()
   {

      #if (DEBUG && !VC_V10)
         Console.WriteLine("DEBUG is defined");
      #elif (!DEBUG && VC_V10)
         Console.WriteLine("VC_V10 is defined");
      #elif (DEBUG && VC_V10)
         Console.WriteLine("DEBUG and VC_V10 are defined");
      #else
         Console.WriteLine("DEBUG and VC_V10 are not defined");
      #endif
      Console.ReadKey();
   }
}
```

当上面的代码被编译和执行时，它会产生下列结果：

```csharp
DEBUG and VC_V10 are defined
```

### 8. 异常处理

C# 异常处理是建立在四个关键词之上的：`try`、`catch`、`finally` 和 `throw`。

- `try`：一个 `try` 块标识了一个将被激活的特定的异常的代码块。后跟一个或多个` catch` 块。
- `catch`：程序通过异常处理程序捕获异常。`catch` 关键字表示异常的捕获。
- `finally`：`finally` 块用于执行给定的语句，不管异常是否被抛出都会执行。例如，如果您打开一个文件，不管是否出现异常文件都要被关闭。
- `throw`：当问题出现时，程序抛出一个异常。使用 `throw `关键字来完成。

#### 语法

假设一个块将出现异常，一个方法使用`try` 和 `catch` 关键字捕获异常。`try/catch` 块内的代码为受保护的代码，使用 `try/catch `语法如下所示：

```csharp
try
{
   // 引起异常的语句
}
catch( ExceptionName e1 )
{
   // 错误处理代码
}
catch( ExceptionName e2 )
{
   // 错误处理代码
}
catch( ExceptionName eN )
{
   // 错误处理代码
}
finally
{
   // 要执行的语句
}
```

可以列出多个 `catch` 语句捕获不同类型的异常，以防` try` 块在不同的情况下生成多个异常。

#### C# 中的异常类

C# 异常是使用`类`来表示的。C# 中的`异常类`主要是直接或间接地派生于 `System.Exception` 类。`System.ApplicationException` 和 `System.SystemException` 类是派生于 `System.Exception` 类的异常类。

`System.ApplicationException` 类支持由应用程序生成的异常。所以程序员定义的异常都应派生自该类。

`System.SystemException` 类是所有预定义的系统异常的基类。

下表列出了一些派生自 `Sytem.SystemException` 类的预定义的异常类：

| 异常类                            | 描述                                           |
| :-------------------------------- | :--------------------------------------------- |
| System.IO.IOException             | 处理 I/O 错误。                                |
| System.IndexOutOfRangeException   | 处理当方法指向超出范围的数组索引时生成的错误。 |
| System.ArrayTypeMismatchException | 处理当数组类型不匹配时生成的错误。             |
| System.NullReferenceException     | 处理当依从一个空对象时生成的错误。             |
| System.DivideByZeroException      | 处理当除以零时生成的错误。                     |
| System.InvalidCastException       | 处理在类型转换期间生成的错误。                 |
| System.OutOfMemoryException       | 处理空闲内存不足生成的错误。                   |
| System.StackOverflowException     | 处理栈溢出生成的错误。                         |

#### 异常处理

 `try` 和 `catch` 块。使用这些块，把核心程序语句与错误处理语句分离开。

```csharp
using System;
namespace ErrorHandlingApplication
{
    class DivNumbers
    {
        int result;
        DivNumbers()
        {
            result = 0;
        }
        public void division(int num1, int num2)
        {
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            finally
            {
                Console.WriteLine("Result: {0}", result);
            }

        }
        static void Main(string[] args)
        {
            DivNumbers d = new DivNumbers();
            d.division(25, 0);
            Console.ReadKey();
        }
    }
}
```

当上面的代码被编译和执行时，它会产生下列结果：

```csharp
Exception caught: System.DivideByZeroException: Attempted to divide by zero. 
at ...
Result: 0
```

#### 自定义异常

自定义的异常类是派生自 `ApplicationException` 类。

```csharp
using System;
namespace UserDefinedException
{
   class TestTemperature
   {
      static void Main(string[] args)
      {
         Temperature temp = new Temperature();
         try
         {
            temp.showTemp();
         }
         catch(TempIsZeroException e)
         {
            Console.WriteLine("TempIsZeroException: {0}", e.Message);
         }
         Console.ReadKey();
      }
   }
}
//自定义异常
public class TempIsZeroException: ApplicationException
{
	//massage是参数
   public TempIsZeroException(string message): base(message)
   {
   }
}
public class Temperature
{
   int temperature = 0;
   public void showTemp()
   {
      if(temperature == 0)
      {
      	//抛出自定义异常
         throw (new TempIsZeroException("Zero Temperature found"));
      }
      else
      {
         Console.WriteLine("Temperature: {0}", temperature);
      }
   }
}
```

当上面的代码被编译和执行时，它会产生下列结果：

```csharp
TempIsZeroException: Zero Temperature found
```

#### 抛出异常

如果异常是直接或间接派生自 System.Exception 类，可以抛出一个异常。可以在 `catch` 块中使用 `throw` 语句来抛出当前的异常，如下所示：

```csharp
Catch(Exception e)
{
   ...
   Throw e
}
```

### 9. 文件的输入与输出

一个`文件`是一个存储在磁盘中带有指定名称和目录路径的数据集合。当打开文件进行读写时，它变成一个`流`。

从根本上说，*流是通过通信路径传递的字节序列*。有两个主要的流：`输入流` 和 `输出流`。输入流用于从文件读取数据（读操作），输出流用于向文件写入数据（写操作）。

#### C# I/O 类

`System.IO` 命名空间有各种不同的类，用于执行各种文件操作，如创建和删除文件、读取或写入文件，关闭文件等。

下表列出了一些 `System.IO` 命名空间中常用的非抽象类：

| I/O 类         | 描述                               |
| :------------- | :--------------------------------- |
| BinaryReader   | 从二进制流读取原始数据。           |
| BinaryWriter   | 以二进制格式写入原始数据。         |
| BufferedStream | 字节流的临时存储。                 |
| Directory      | 有助于操作目录结构。               |
| DirectoryInfo  | 用于对目录执行操作。               |
| DriveInfo      | 提供驱动器的信息。                 |
| File           | 有助于处理文件。                   |
| FileInfo       | 用于对文件执行操作。               |
| FileStream     | 用于文件中任何位置的读写。         |
| MemoryStream   | 用于随机访问存储在内存中的数据流。 |
| Path           | 对路径信息执行操作。               |
| StreamReader   | 用于从字节流中读取字符。           |
| StreamWriter   | 用于向一个流中写入字符。           |
| StringReader   | 用于读取字符串缓冲区。             |
| StringWriter   | 用于写入字符串缓冲区。             |

#### FileStream 类:

`System.IO` 命名空间中的 `FileStream` 类有助于文件的读写与关闭。该类派生自抽象类 `Stream`。

创建一个 FileStream 对象来创建一个新的文件或打开一个已有的文件。创建 FileStream 对象的语法如下：

```csharp
FileStream <object_name> = new FileStream( <file_name>,
<FileMode Enumerator>, <FileAccess Enumerator>, <FileShare Enumerator>);
```

例如，创建一个 FileStream 对象 F 来读取名为 sample.txt 的文件：

```scharp
FileStream F = new FileStream("sample.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
```

| 参数       | 描述                                                         |
| :--------- | :----------------------------------------------------------- |
| FileMode   | FileMode 枚举定义了各种打开文件的方法。FileMode 枚举的成员有： <br> Append：打开一个已有的文件，并将光标放置在文件的末尾。如果文件不存在，则创建文件。<br>Create：创建一个新的文件。如果文件已存在，则删除旧文件，然后创建新文件。<br>CreateNew：指定操作系统应创建一个新的文件。如果文件已存在，则抛出异常。<br>Open：打开一个已有的文件。如果文件不存在，则抛出异常。<br>OpenOrCreate：指定操作系统应打开一个已有的文件。如果文件不存在，则用指定的名称创建一个新的文件打开。<br>Truncate：打开一个已有的文件，文件一旦打开，就将被截断为零字节大小。然后我们可以向文件写入全新的数据，但是保留文件的初始创建日期。如果文件不存在，则抛出异常。 |
| FileAccess | FileAccess 枚举的成员有：Read、ReadWrite 和 Write。          |
| FileShare  | FileShare 枚举的成员有：<br>Inheritable：允许文件句柄可由子进程继承。Win32 不直接支持此功能。<br>None：谢绝共享当前文件。文件关闭前，打开该文件的任何请求（由此进程或另一进程发出的请求）都将失败。<br>Read：允许随后打开文件读取。如果未指定此标志，则文件关闭前，任何打开该文件以进行读取的请求（由此进程或另一进程发出的请求）都将失败。但是，即使指定了此标志，仍可能需要附加权限才能够访问该文件.<br>ReadWrite：允许随后打开文件读取或写入。如果未指定此标志，则文件关闭前，任何打开该文件以进行读取或写入的请求（由此进程或另一进程发出）都将失败。但是，即使指定了此标志，仍可能需要附加权限才能够访问该文件。<br>Write：允许随后打开文件写入。如果未指定此标志，则文件关闭前，任何打开该文件以进行写入的请求（由此进程或另一进过程发出的请求）都将失败。但是，即使指定了此标志，仍可能需要附加权限才能够访问该文件。<br>Delete：允许随后删除文件。 |

**实例**
下面的程序演示了 FileStream 类的用法：

```csharp
using System;
using System.IO;

namespace FileIOApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream F = new FileStream("test.dat", 
            FileMode.OpenOrCreate, FileAccess.ReadWrite);

            for (int i = 1; i <= 20; i++)
            {
                F.WriteByte((byte)i);
            }
            F.Position = 0;
            for (int i = 0; i <= 20; i++)
            {
                Console.Write(F.ReadByte() + " ");
            }
            F.Close();
            Console.ReadKey();
        }
    }
}
```

当上面的代码被编译和执行时，它会产生下列结果：

```csharp
1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 -1
```

### 10. Dll类库与exe可执行程序

1. Dll （动态链接库）
   不能独立运行，实质为一些函数集（类库）
2. exe引用Dll
   VS项目中的引用里手动引用
   [DllImport(...)] 用于方法上