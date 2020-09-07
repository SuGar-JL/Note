using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace demo20_序列化
{
    [Serializable]//可序列化的
    class Test
    {
        public string id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public override string ToString()
        {
            return $"id: {id} \r\nname: {name} \r\nage: {age}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test() { id = "1", name = "sjl", age = 18 };
            //序列化
            using (var stream = File.Open(typeof(Test).Name, FileMode.Create, FileAccess.ReadWrite))
            {
                var buff = new BinaryFormatter();
                buff.Serialize(stream, test);
            }

            Test test1 = null;
            //反序列化
            using (var stream = File.Open(typeof(Test).Name, FileMode.Open, FileAccess.ReadWrite))
            {
                var buff = new BinaryFormatter();
                test1 = (Test)buff.Deserialize(stream);
            }
            Console.WriteLine(test1);
        }
    }
}
