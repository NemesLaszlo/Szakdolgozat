using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimtToo.VisualReactive;

namespace UI_TFS_ServerOperation
{
    public partial class TFS_Operator : Form
    {
        public TFS_Operator()
        {
            InitializeComponent();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            if (LeftTransformMenu.Width == 50)
            {
                LeftTransformMenu.Visible = false;
                LeftTransformMenu.Width = 225;
                PanelAnimator.ShowSync(LeftTransformMenu);
                LogoAnimator.Hide(smallLogo);
                LogoAnimator.Show(BigLogo);
            }
            else
            {
                LogoAnimator.Hide(BigLogo);
                LogoAnimator.Show(smallLogo);
                LeftTransformMenu.Visible = false;
                LeftTransformMenu.Width = 50;
                PanelAnimator.ShowSync(LeftTransformMenu);
            }
        }

        private void sideMenu_Click(object sender, EventArgs e)
        {
            VSReactive<int>.SetState("menu", int.Parse(((Control)sender).Tag.ToString()));
        }
    }
}
