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
            VSReactive<int>.Subscribe("ContentControllerPages", e => ContentControllerPages.SelectedIndex = e);
        }

        private void subDeleteByIds_Click(object sender, EventArgs e)
        {
            subDeleteTabPages.SetPage(0);
        }

        private void subDeleteFromFile_Click(object sender, EventArgs e)
        {
            subDeleteTabPages.SetPage(1);
        }

        private void subCompleteDelete_Click(object sender, EventArgs e)
        {
            subDeleteTabPages.SetPage(2);
        }

        private void subContact_Click(object sender, EventArgs e)
        {
            subInfoPages.SetPage(0);
        }

        private void subBugReport_Click(object sender, EventArgs e)
        {
            subInfoPages.SetPage(1);
        }
    }


}
