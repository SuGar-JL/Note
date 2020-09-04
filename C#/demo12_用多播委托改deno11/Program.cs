using System;
using System.Collections.Generic;

namespace demo12_用多播委托改deno11
{
    class Program
    {

        class Person
        {
            private readonly string name;
            private NewsPaper newsPaper;

            public Person(string n)
            {
                this.name = n;
            }
            public void SetNewsPaper(object sender, PublisherArgs args)
            {
                //假设有多个Publisher
                if (sender is Publisher)
                {
                    args.NewsPaper.PublisherName = (sender as Publisher).name;
                }
                this.newsPaper = args.NewsPaper;
            }

            public void ReadNewsPaper()
            {
                Console.WriteLine("{0}收到{1}发布商发布的名为{2}的报纸，内容为{3}", this.name, this.newsPaper.PublisherName, this.newsPaper.Title, this.newsPaper.Content);
            }
        }

        class Company
        {
            private readonly string name;
            private NewsPaper newsPaper;

            public Company(string n)
            {
                this.name = n;
            }
            public void SetNewsPaper(object sender, PublisherArgs args)
            {
                //假设有多个Publisher
                if (sender is Publisher)
                {
                    args.NewsPaper.PublisherName = (sender as Publisher).name;
                }
                this.newsPaper = args.NewsPaper;
            }

            public void ReadNewsPaper()
            {
                Console.WriteLine("{0}收到{1}发布商发布的名为{2}的报纸，内容为{3}", this.name, this.newsPaper.PublisherName, this.newsPaper.Title, this.newsPaper.Content);
            }
        }
        class NewsPaper
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string PublisherName { get; set; }
        }
        class PublisherArgs : EventArgs
        {
            public NewsPaper NewsPaper { get; set; }
            public PublisherArgs(NewsPaper newsPaper)
            {
                this.NewsPaper = newsPaper;
            }
        }
        class Publisher
        {
            public string name;
            public Publisher(string n)
            {
                this.name = n;
            }
            //加个event关键字
            //public event Action<NewsPaper> subscribers = null;
            //把发布者名称传递出去
            //public event Action<Object, NewsPaper> subscribers = null;
            //将NewsPaper封装成事件参数
            //EventHandler默认第一个参数是Object,第二个参数是继承自System.EventArgs的一个类
            public event EventHandler<PublisherArgs> Subscribers = null;

            public void SendNewsPaper(NewsPaper newsPaper)
            {
                //newsPaper.publisherName = this.name;
                //这是一股脑的处理，没法处理异常
                //subscribers?.Invoke(newsPaper);//Event?.Invoke() 若event不为null，则baiinvoke，这是C#6的新语法du。zhi   ?.称为空值传dao播运算符。
                
                //异常处理方法
                if (Subscribers != null)
                {
                    //转为list一个一个处理
                    foreach (EventHandler<PublisherArgs> subscriber in Subscribers.GetInvocationList())
                    {
                        try
                        {
                            subscriber(this, new PublisherArgs(newsPaper));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            //核心思想：发布者不知道发布给谁，只管发布

            var A = new Person("a");
            var B = new Person("b");

            var CA = new Company("Ca");
            var CB = new Company("Cb");

            var pA = new Publisher("发布商X");
            //pA.subscribers = A.SetNewsPaper;//加了event关键字，不能使用+ 和 -
            pA.Subscribers += A.SetNewsPaper;//event关键字有效避免把+= 写成 =
            pA.Subscribers += B.SetNewsPaper;
            //模拟委托链出异常
            pA.Subscribers += (o,n) => { throw new ApplicationException("There's a error here!"); };
            pA.Subscribers += CA.SetNewsPaper;
            pA.Subscribers += CB.SetNewsPaper;
            pA.SendNewsPaper(new NewsPaper() { Title = "XX报", Content = "XXXX" });//无有参构造时可以这样初始化
            //没有加event关键字之前是可以这样调用的，现在不可以了，直接编译报错，只能Publisher类调用（包容类），外部类不能调用
            //pA.subscribers(new NewsPaper() { title = "XX报", content = "XXXX" });//无有参构造时可以这样初始化

            A.ReadNewsPaper();
            B.ReadNewsPaper();
            CA.ReadNewsPaper();
            CB.ReadNewsPaper();

        }
    }
}
