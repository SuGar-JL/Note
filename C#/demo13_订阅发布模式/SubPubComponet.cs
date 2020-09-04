using System;
using System.Collections.Generic;
using System.Text;

//设计订阅器。显然订阅器要实现双向解耦，就一定要继承ISubscribe, IPublish两个接口，这也是为什么用接口不用抽象类的原因(类是单继承)。
namespace demo13_订阅发布模式
{

    public class SubPubComponet : ISubscribe, IPublish
    {
        //订阅器名称
        private string _subName;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="subName"></param>
        public SubPubComponet(string subName)
        {
            this._subName = subName;

            PublishEvent += new PublishHandle(Notify);
        }

        #region ISubscribe Members
        event SubscribeHandle subscribeEvent;
        event SubscribeHandle ISubscribe.SubscribeEvent
        {
            add { subscribeEvent += value; }
            remove { subscribeEvent -= value; }
        }
        #endregion

        #region IPublish Members
        public PublishHandle PublishEvent;
        event PublishHandle IPublish.PublishEvent
        {
            add { PublishEvent += value; }
            remove { PublishEvent -= value; }
        }
        #endregion

        public void Notify(string str)
        {
            //str来自发布者使用发布委托出传入的参数
            //使用订阅者委托（传入参数：string.Format("消息来源{0}:消息内容:{1}", _subName, str)）
            if (subscribeEvent != null)
                subscribeEvent.Invoke(string.Format("消息来源{0}:消息内容:{1}", _subName, str));
        }
    }
}
