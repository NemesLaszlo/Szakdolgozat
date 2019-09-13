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
using System.IO;
using System.Reflection;
using TFS_ServerOperation;
using System.Diagnostics;

namespace UI_TFS_ServerOperation
{
    public partial class subMenu : UserControl
    {
        private InformationParser informationParser;
        private Logger log;
        private MailSender mailSender;
        private ServerOperationManager serverOperator;

        private void ControllerInit()
        {
            InformationParser informationParser = new InformationParser();
            //Logger log = informationParser.Init_Log();
            //MailSender mailSender = informationParser.Init_MailSender(log);
            //ServerOperationManager serverOperator = informationParser.Init_ServerOperation(log);
        }

        public subMenu()
        {
            InitializeComponent();
            ControllerInit();

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

        // Settings section start -------------------------------------------------

        private void subOpenCurrentConfig_Click(object sender, EventArgs e)
        {
            string path = informationParser.GetCurrentPathToBin();
            SettingsRichTextBox.Text = System.IO.File.ReadAllText(path);
        }

        private void subConfigLoad_Click(object sender, EventArgs e)
        {

        }

        private void subReset_Click(object sender, EventArgs e)
        {

        }

        private void subSave_Click(object sender, EventArgs e)
        {

        }

        // Settings section end -------------------------------------------------

    }


}
