using System;

namespace demo13_订阅发布模式
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SubscribePublish
            //新建两个订阅器
            SubPubComponet subPubComponet1 = new SubPubComponet("订阅器1");
            SubPubComponet subPubComponet2 = new SubPubComponet("订阅器2");
            //新建两个发布者
            //多态
            IPublish publisher1 = new Publisher("TJVictor1");
            IPublish publisher2 = new Publisher("TJVictor2");
            //与订阅器关联
            publisher1.PublishEvent += subPubComponet1.PublishEvent;
            publisher1.PublishEvent += subPubComponet2.PublishEvent;
            publisher2.PublishEvent += subPubComponet2.PublishEvent;
            //新建两个订阅者
            Subscriber s1 = new Subscriber("订阅人1");
            Subscriber s2 = new Subscriber("订阅人2");
            //进行订阅
            s1.AddSubscribe = subPubComponet1;
            s1.AddSubscribe = subPubComponet2;
            s2.AddSubscribe = subPubComponet2;

            //发布者发布消息
            //1.Notity方法使用PublishEvent委托将消息发布到订阅器
            //2.订阅器收到发布者的消息后，使用SubscribeEvent委托将消息整合后发布给订阅者
            //3.订阅者收到消息后整合输出
            //期间设计委托的连续执行（在一个委托引用的方法中使用另一个委托）
            publisher1.Notify("博客1");
            publisher2.Notify("博客2");
            //发送结束符号
            Console.WriteLine("".PadRight(50, '-'));
            //s1取消对订阅器2的订阅
            s1.RemoveSubscribe = subPubComponet2;
            //发布者发布消息
            publisher1.Notify("博客1");
            publisher2.Notify("博客2");
            //发送结束符号
            Console.WriteLine("".PadRight(50, '-'));
            #endregion

            #region Console.ReadLine();
            Console.ReadLine();
            #endregion
        }
    }
}
