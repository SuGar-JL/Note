using System;
using System.Collections.Generic;
using System.Text;

namespace demo13_订阅发布模式
{
    //定义订阅事件
    public delegate void SubscribeHandle(string str);
    //定义订阅接口
    public interface ISubscribe
    {
        event SubscribeHandle SubscribeEvent;
    }
}
