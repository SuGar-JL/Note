# 1.停靠窗体

库：DockPanelSuite

1.NuGet包管理=>安装DockPanelSuite

![image-20200904204627749](C:\Users\hp\AppData\Roaming\Typora\typora-user-images\image-20200904204627749.png)

2.工具箱=>DockPanel Suite=>将DockPanel拖到主窗体（假设为Form1）上

![image-20200904204827694](C:\Users\hp\AppData\Roaming\Typora\typora-user-images\image-20200904204827694.png)

3.设置DockPanel

- Dock = Fill
- DocumentStyle = DockingMdi

4.设置主窗体（Form1）

- IsMdiContainer = true

5.新建用于停靠的窗体（Form2）

- Form2要继承自 DockContent

  ```C#
  using System;
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Data;
  using System.Drawing;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;
  using System.Windows.Forms;
  using WeifenLuo.WinFormsUI.Docking;////
  
  namespace Test
  {
      public partial class Form2 : DockContent////
      {
          public Form2()
          {
              InitializeComponent();
          }
      }
  }
  ```

6.在主窗体加载事件中创建Form2以显示

```C#
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 设计窗体
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f_DeviceManage  = new Form2();
            Form2.Show(dockPanel1);//让Form2在dockPanel1中显示
            Form2.DockTo(dockPanel1, DockStyle.Left);//让Form2显示在dockPanel1左边
        }
    }
}
```

7.设置Form2

- DockAreas不包括Document，从而不能显示在中间（占领全部，就像Dock = Fill 一样）

# 2.winform自带的工具栏调整

## 2.1 调整工具栏的高度

1. AutoSize = False
2. 设置Size

## 2.2 调整工具栏的按钮及图片大小

1. 调整工具栏
   - ImageScalingSize = 想要的大小（此时，按钮边框变大）
2. 调整按钮
   - Size = 想要的大小（和ImageScalingSize 匹配比较好）
3. 如果不对，反复调这两个参数\

# 3.