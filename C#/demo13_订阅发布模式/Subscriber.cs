using System;
using System.Collections.Generic;
using System.Text;

namespace demo13_订阅发布模式
{
    //订阅者
    public class Subscriber
    {
        private string _subscriberName;

        public Subscriber(string subscriberName)
        {
            this._subscriberName = subscriberName;
        }

        //value代表接受到的参数，即订阅器对象
        public ISubscribe AddSubscribe { set { value.SubscribeEvent += Show; } }
        public ISubscribe RemoveSubscribe { set { value.SubscribeEvent -= Show; } }

        private void Show(string str)
        {
            //发布者发布到订阅器（PublishEvent），订阅器发布到订阅者（SubscribeEvent）
            Console.WriteLine(string.Format("我是{0}，我收到订阅的消息是:{1}", _subscriberName, str));
        }
    }
}
