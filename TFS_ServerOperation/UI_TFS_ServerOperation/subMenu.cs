using System;
using System.Windows.Forms;
using KimtToo.VisualReactive;
using System.IO;
using System.Reflection;
using TFS_ServerOperation;
using System.Threading;

namespace UI_TFS_ServerOperation
{
    public partial class subMenu : UserControl
    {
        private InformationParser informationParser;
        private Logger log;
        private ServerOperationManager serverOperator;
        private MailSender mailSender;

        int counterLoad = 0;
        int counterDialogLoad = 0;

        public subMenu()
        {
            InitializeComponent();
            if (Program.isInDesignMode()) return;

            informationParser = new InformationParser();
            log = informationParser.Init_Log();
            serverOperator = informationParser.Init_ServerOperation(log);
            mailSender = informationParser.Init_MailSender(log);

            ServerCollectionInfoLabel.Text = informationParser.CurrentTfsCollectionName;
            ServerTeamProjectInfoLabel.Text = informationParser.CurrentTeamProjectName;

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

        /// <summary>
        /// Save the curret config setting to temp, and after we can bring it back with reset button option.
        /// </summary>
        private void TempSaveCopy()
        {
            if (Directory.Exists(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                string[] files = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "UI_TFS_ServerOperation.exe.config", SearchOption.AllDirectories);
                foreach (var s in files)
                {
                    System.IO.File.Copy(s, Path.Combine(Path.GetTempPath(), Path.GetFileName(s)), true);
                }
            }
        }

        private void subOpenCurrentConfig_Click(object sender, EventArgs e)
        {
            if (counterLoad == 0)
            {
                TempSaveCopy();
                ++counterLoad;
            }
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string configLocation = Path.Combine(executableLocation, "UI_TFS_ServerOperation.exe.config");
            SettingsRichTextBox.Text = System.IO.File.ReadAllText(configLocation);
        }

        private void subConfigLoad_Click(object sender, EventArgs e)
        {
            if(counterDialogLoad == 0)
            {
                TempSaveCopy();
                ++counterDialogLoad;
            }
            Stream configStream;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                if ((configStream = openFileDialog.OpenFile()) != null)
                {
                    string strFileName = openFileDialog.FileName;
                    string fileText = System.IO.File.ReadAllText(strFileName);
                    SettingsRichTextBox.Text = fileText;
                }
            }
        }

        private void subReset_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(Path.GetTempPath()))
            {
                string[] files = Directory.GetFiles(Path.GetTempPath(), "UI_TFS_ServerOperation.exe.config", SearchOption.AllDirectories);
                foreach (var s in files)
                {
                    System.IO.File.Copy(s, Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Path.GetFileName(s)), true);
                }
            }
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string configLocation = Path.Combine(executableLocation, "UI_TFS_ServerOperation.exe.config");
            SettingsRichTextBox.Text = System.IO.File.ReadAllText(configLocation);
            Alert.AlertCreation("Config Reset Done!", AlertType.info);
        }

        private void subSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.SettingsRichTextBox.Text) || string.IsNullOrWhiteSpace(this.SettingsRichTextBox.Text))
            {
                Alert.AlertCreation("Load Something!", AlertType.error);
                return;
            }
            else
            {
                string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string configLocation = Path.Combine(executableLocation, "UI_TFS_ServerOperation.exe.config");

                TextWriter writer = new StreamWriter(configLocation);

                writer.Write(SettingsRichTextBox.Text);
                writer.Close();
                Alert.AlertCreation("Save Success!", AlertType.success);
            }
        }

        // Settings section end -------------------------------------------------

        // Upload section start -------------------------------------------------

        private void subUploadStart_Click(object sender, EventArgs e)
        {
            bool result = informationParser.UploadAndMailSend_Process(true, serverOperator, mailSender, log);
            if (result)
            {
                for (int i = 0; i <= 100; ++i)
                {
                    UploadBar.Value = i;
                    UploadBar.Update();
                }
                Alert.AlertCreation("Upload Success!", AlertType.success);
            }
            else
            {
                Alert.AlertCreation("Upload Failed! Check the LOG!", AlertType.error);
            }
            Thread.Sleep(1000);
            UploadBar.Value = 0;
        }

        // Upload section end -------------------------------------------------



    }


}
