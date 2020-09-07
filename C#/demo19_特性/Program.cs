using System;

namespace demo19_特性
{
    class TestA
    {
        //让property为必填项
        [Required]
        public string property { get; set; }

    }
    class TestB
    {
        //让property为必填项
        [Required] //[A, B, ...]
        public string property { get; set; }

    }

    /// <summary>
    /// 自定义特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]//表示该特性只能修饰属性
    public class RequiredAttribute : System.Attribute
    {
        public static bool IsRequired(object obj)
        {
            //拿到类型
            var type = obj.GetType();
            //拿到属性
            var properties = type.GetProperties();
            //获取属性的特性
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(typeof(RequiredAttribute), false);
                //判断是否拿到特性
                if (attributes.Length > 0)
                {
                    //判断字段是否有输入
                    if (property.GetValue(obj, null) == null)
                    {
                        //为空返回false
                        return false;
                    }
                }
            }
            //否则返回true
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var testA = new TestA() { };
            if (RequiredAttribute.IsRequired(testA))
            {
                Console.WriteLine("字段有值");
            }
            else
            {
                Console.WriteLine("字段为空");
            }

            var testB = new TestB() { property = "123"};
            if (RequiredAttribute.IsRequired(testB))
            {
                Console.WriteLine("字段有值");
            }
            else
            {
                Console.WriteLine("字段为空");
            }
        }
    }
}
