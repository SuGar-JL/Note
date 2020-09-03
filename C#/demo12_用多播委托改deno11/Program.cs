using System;
using System.Collections.Generic;

namespace demo12_用多播委托改deno11
{
    class Program
    {
        //interface IBody
        //{
        //    void SetNewsPaper(NewsPaper newsPaper);
        //}

        class Person/* : IBody*/
        {
            private string name;
            private NewsPaper newsPaper;

            public Person(string n)
            {
                this.name = n;
            }
            public void SetNewsPaper(NewsPaper newsPaper)
            {
                this.newsPaper = newsPaper;
            }

            public void ReadNewsPaper()
            {
                Console.WriteLine("{0}收到{1}发布商发布的名为{2}的报纸，内容为{3}", this.name, this.newsPaper.publisherName, this.newsPaper.title, this.newsPaper.content);
            }
        }

        class Company/* : IBody*/
        {
            private string name;
            private NewsPaper newsPaper;

            public Company(string n)
            {
                this.name = n;
            }
            public void SetNewsPaper(NewsPaper newsPaper)
            {
                this.newsPaper = newsPaper;
            }

            public void ReadNewsPaper()
            {
                Console.WriteLine("{0}收到{1}发布商发布的名为{2}的报纸，内容为{3}", this.name, this.newsPaper.publisherName, this.newsPaper.title, this.newsPaper.content);
            }
        }
        class NewsPaper
        {
            public string title { get; set; }
            public string content { get; set; }
            public string publisherName { get; set; }
        }

        class Publisher
        {
            private string name;
            public Publisher(string n)
            {
                this.name = n;
            }
            //public List<IBody> bodies = new List<IBody>();
            public Action<NewsPaper> subscribers { get; set; }

            public void SendNewsPaper(NewsPaper newsPaper)
            {
                newsPaper.publisherName = this.name;
                //this.bodies.ForEach(b => b.SetNewsPaper(newsPaper));
                subscribers(newsPaper);

            }
        }
        static void Main(string[] args)
        {
            //核心思想：发布者不知道发布给谁，只管发布

            var A = new Person("a");
            var B = new Person("b");

            var CA = new Company("Ca");
            var CB = new Company("Cb");

            //var pA = new Publisher("发布商A");
            //var pB = new Publisher("发布商B");

            //pA.bodies.Add(A);
            //pA.bodies.Add(CA);

            //pB.bodies.Add(B);
            //pB.bodies.Add(CB);

            //pA.SendNewsPaper(new NewsPaper("NA", "C_A"));
            //pB.SendNewsPaper(new NewsPaper("NB", "C_B"));

            var pA = new Publisher("发布商X");
            pA.subscribers = A.SetNewsPaper;
            pA.subscribers += B.SetNewsPaper;
            pA.subscribers += CA.SetNewsPaper;
            pA.subscribers += CB.SetNewsPaper;
            pA.SendNewsPaper(new NewsPaper() { title = "XX报", content = "XXXX" });

            A.ReadNewsPaper();
            B.ReadNewsPaper();
            CA.ReadNewsPaper();
            CB.ReadNewsPaper();

        }
    }
}
