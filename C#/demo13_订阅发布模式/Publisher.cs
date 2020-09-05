using System;
using System.Collections.Generic;
using System.Text;

namespace demo13_订阅发布模式
{
    public class Publisher : IPublish
    {
        private string _publisherName;

        public Publisher(string publisherName)
        {
            this._publisherName = publisherName;
        }
        //实现接口
        private event PublishHandle PublishEvent;
        event PublishHandle IPublish.PublishEvent
        {
            add { PublishEvent += value; }
            remove { PublishEvent -= value; }
        }
        //实现接口
        public void Notify(string str)
        {
            if (PublishEvent != null)
                //使用发布委托（传入参数，这里参数是：string.Format("我是{0},我发布{1}消息", _publisherName, str)）
                //使用的委托来自订阅器，所以接下来去执行订阅器的方法
                //str来自main方法中Notify()调用传入的参数
                //委托链长度为1
                PublishEvent.Invoke(string.Format("我是{0},我发布{1}消息", _publisherName, str));
        }
    }
}
