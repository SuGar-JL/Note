using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace demo16_标准查询操作符
{
    /// <summary>
    /// 专利类
    /// </summary>
    public class Patent
    {
        public string Title { get; set; }
        public string YearOfPublication { get; set; }
        public string ApplicationNumber { get; set; }
        //发明家Id
        public long[] InventorIds { get; set; }
        public override string ToString()
        {
            return $"{Title} ({YearOfPublication})";
        }
    }
    /// <summary>
    /// 发明家类
    /// </summary>
    public class Inventor
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{Name} ({City}, {State})";
        }
    }
    public static class PatentData
    {
        public static readonly Inventor[] inventors = new Inventor[]
        {
            new Inventor()
            {
                Name = "Benjamin Franklin", City = "Philadelphia",
                State = "PA", Country = "USA", Id = 1,
            },
            new Inventor()
            {
                Name = "Orville Wright", City = "Kitty Hawk",
                State = "NC", Country = "USA", Id = 2,
            },
            new Inventor()
            {
                Name = "Wilbur Wright", City = "Kitty Hawk",
                State = "NC", Country = "USA", Id = 3,
            },
            new Inventor()
            {
                Name = "Samuel Morse", City = "New York",
                State = "NY", Country = "USA", Id = 4,
            },
            new Inventor()
            {
                Name = "George Stephenson", City = "wylam",
                State = "Northumbeland", Country = "UK", Id = 5,
            },
            new Inventor()
            {
                Name = "John Michaelis", City = "Chicago",
                State = "IL", Country = "USA", Id = 6,
            },
            new Inventor()
            {
                Name = "Mary Phelps Jacob", City = "New York",
                State = "NY", Country = "USA", Id = 7,
            }
        };
        public static readonly Patent[] patents = new Patent[]
        {
            new Patent()
            {
                Title="Bifocals", YearOfPublication = "1784",
                InventorIds = new long[]{ 1 }
            },
             new Patent()
            {
                Title="Phonograph", YearOfPublication = "1877",
                InventorIds = new long[]{ 1 }
            },
             new Patent()
            {
                Title="Kinetoscope", YearOfPublication = "1888",
                InventorIds = new long[]{ 1 }
            },
             new Patent()
            {
                Title="Electrical TeleGraph", YearOfPublication = "1837",
                InventorIds = new long[]{ 4 }
            },
             new Patent()
            {
                Title="Flying Machine", YearOfPublication = "1903",
                InventorIds = new long[]{ 2, 3 }
            },
             new Patent()
            {
                Title="Steam Locomotive", YearOfPublication = "1815",
                InventorIds = new long[]{ 5 }
            },
             new Patent()
            {
                Title="Droplet Deposition Apparatus", YearOfPublication = "1989",
                InventorIds = new long[]{ 6 }
            },
             new Patent()
            {
                Title="Backless Brassere", YearOfPublication = "1914",
                InventorIds = new long[]{ 7 }
            }

        };
    }
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Patent> patents = PatentData.patents;
            Print(patents);
            Console.WriteLine("".PadRight(50, '-'));

            IEnumerable<Inventor> inventors = PatentData.inventors;
            Print(inventors);
            Console.WriteLine("".PadRight(50, '-'));

            //1.Where操作符, 返回的是一个新的IEnumerable<T>集合，因此，后面是可以继续.Where（..）的，成为链式Where，也可以继续调用其它的标准查询操作符
            patents = patents.Where(patent => patent.YearOfPublication.StartsWith("18"));
            Print(patents);
            Console.WriteLine("".PadRight(50, '-'));

            //2.Select操作符返回的是一个新的IEnumerable<T>集合
            IEnumerable<string> fileList = Directory.GetFiles("D:/学习/笔记/Note/C#/demo16_标准查询操作符");
            IEnumerable<FileInfo> files = fileList.Select(file => new FileInfo(file));
            Print(files);
            Console.WriteLine("".PadRight(50, '-'));
            //用元组(string FileName, long Size)
            IEnumerable<(string FileName, long Size)> files1 = fileList.Select(
                file =>//Func委托（有参数有返回值）
                {
                    FileInfo fileInfo = new FileInfo(file);
                    return (//返回一个元组，也可以用匿名类型（new {fileInfo.Name, fileInfo.Lenght}）,但要改(string FileName, long Size)
                        FileName: fileInfo.Name,
                        Size: fileInfo.Length
                    );
                });
            Print(files1);
            Console.WriteLine("".PadRight(50, '-'));
            //Where与Select:
            //Where减少行（记录数），Selext减少列（字段数）或类型转换

            //3.Count()集合计数
            //年份以18开头的专利数目
            Console.WriteLine($"Patent18__ Count: {patents.Count()}");
            Console.WriteLine("".PadRight(50, '-'));
            //年份以18开头，7结尾的专利数目
            //@可以使字符串换行写
            Console.WriteLine($@"Patent18_7 Count: {
                patents.Count(patent => patent.YearOfPublication.EndsWith("7"))
                }");
            Console.WriteLine("".PadRight(50, '-'));

            List<int> l = new List<int>();
            l.Any();//尝试遍历集合中的一项，成功返回true，常用于判断集合的Count是否大于0，即是否有元素

            //LINQ之“推迟执行”概念
            Console.WriteLine("".PadRight(10, '-') + "LINQ之“推迟执行”概念" + "".PadRight(10, '-'));
            IEnumerable<Patent> patents1 = PatentData.patents;
            bool result;
            #region 这段代码，在没有迭代集合时是不会执行的
            patents1 = patents1.Where(
                patent =>
                {
                    if (result = patent.YearOfPublication.StartsWith("18"))
                    {
                        Console.WriteLine("\t" + patent);
                    }
                    return result;
                }
            );
            #endregion
            Console.WriteLine("1.patents prior to the 1900s are:");//90年代的专利
            foreach (var patent in patents1)
            {

            }

            Console.WriteLine();
            Console.WriteLine("2.A second listing of patents prior to the 1900s are:");//90年代的专利
            Console.WriteLine($"There are { patents1.Count() } patents prior to 1900.");

            Console.WriteLine();
            Console.WriteLine("3.A third listing of patents prior to the 1900s are:");//90年代的专利
            patents1 = patents1.ToArray();
            Console.WriteLine($"There are { patents1.Count() } patents prior to 1900.");


        }

        private static void Print<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
