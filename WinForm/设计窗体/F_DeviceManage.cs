using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using DataCollect;

namespace DataCollect
{
    /// <summary>
    /// 设备管理页面只有一个，采用单例模式
    /// </summary>
    public partial class F_DeviceManage : DockContent
    {
        private static F_DeviceManage Instance;
        public F_DeviceManage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取设备管理的实例
        /// </summary>
        /// <returns></returns>
        public static F_DeviceManage GetInstance()
        {
            if (Instance == null)
            {
                Instance = new F_DeviceManage();
            }
            return Instance;
        }
        private void F_DeviceManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instance = null;  // 否则下次打开时报错，提示“无法访问已释放对象”
        }
    }
}
