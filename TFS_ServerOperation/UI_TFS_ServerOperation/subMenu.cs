using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimtToo.VisualReactive;

namespace UI_TFS_ServerOperation
{
    public partial class subMenu : UserControl
    {
        public subMenu()
        {
            InitializeComponent();
            if (Program.isInDesignMode()) return;

            VSReactive<int>.Subscribe("menu", e => tabControl1.SelectedIndex = e);
        }

        private void subOpenCurrentConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
