using System;

namespace demo09_var类型
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             传统定义变量是已经知道变量的类型，如： int a = 1； string b = “qwer”；
             用Var类型预先不用知道变量的类型；根据你给变量赋值来判定变量属于什么类型；如
             var a = 1； 则a是整型，var a = “qwer”；则a是字符型，但使用Var类型要注意：
                1：必须在定义时初始化，即不能先定义后初始化，如：var a；a = 1；这样是不允许的
                2：一旦初始化完成，不能再给变量赋与初始化不同的变量
                3：var类型的变量必须是局部变量
             */
            var a = 1;
            Type aType = a.GetType();
            Console.WriteLine(aType); //System.Int32

            var b = "hello";
            Type bType = b.GetType();
            Console.WriteLine(bType); //System.String

            //a = "abc";//一旦初始化完成，不能再给变量赋与初始化不同的变量


        }
    }
}
