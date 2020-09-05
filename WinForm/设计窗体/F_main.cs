using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCollect
{
    public partial class F_main : Form
    {

        public F_main()
        {
            InitializeComponent();
        }

        private void F_main_Load(object sender, EventArgs e)
        {
            F_DeviceManage f_DeviceManage = F_DeviceManage.GetInstance();
            f_DeviceManage.Show(dockPanel1);
            f_DeviceManage.DockTo(dockPanel1, DockStyle.Left);//左边停靠
        }

        private void tSB_设备管理_Click(object sender, EventArgs e)
        {
            F_DeviceManage f_DeviceManage = F_DeviceManage.GetInstance();
            f_DeviceManage.Show(dockPanel1);
            f_DeviceManage.DockTo(dockPanel1, DockStyle.Left);//左边停靠
        }
    }
}
