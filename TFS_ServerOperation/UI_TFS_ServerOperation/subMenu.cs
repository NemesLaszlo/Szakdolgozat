using System;
using System.Windows.Forms;
using KimtToo.VisualReactive;
using System.IO;
using System.Reflection;
using TFS_ServerOperation;
using System.Threading;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;

namespace UI_TFS_ServerOperation
{
    public partial class subMenu : UserControl
    {
        private InformationParser informationParser;
        private Logger log;
        private ServerOperationManager serverOperator;
        private MailSender mailSender;

        //check values for the Temp config save
        int counterLoad = 0;
        int counterDialogLoad = 0;

        public subMenu()
        {
            InitializeComponent();
            if (Program.isInDesignMode()) return;

            // Controller Init
            informationParser = new InformationParser();
            log = informationParser.Init_Log();
            serverOperator = informationParser.Init_ServerOperation(log);
            mailSender = informationParser.Init_MailSender(log);

            // Server information setting to the Upload page
            ServerCollectionInfoLabel.Text = informationParser.CurrentTfsCollectionName;
            ServerTeamProjectInfoLabel.Text = informationParser.CurrentTeamProjectName;

            //BarLabel init part
            UploadBar.LabelVisible = true;
            OneElemDeleteBar.LabelVisible = true;
            MoreElemDeleteBar.LabelVisible = true;
            FileDeleteProgressBar.LabelVisible = true;
            AllServerDeleteProgressBar.LabelVisible = true;

            VSReactive<int>.Subscribe("menu", e => tabControl1.SelectedIndex = e);
            VSReactive<int>.Subscribe("ContentControllerPages", e => ContentControllerPages.SelectedIndex = e);
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

        /// <summary>
        /// Click event, open the curret configuration of the uploader, where we can check our setting before usage.
        /// </summary>
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

        /// <summary>
        /// Click event, we are able to load other files to config and run our program.
        /// </summary>
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

        /// <summary>
        /// Click event, reset the config file for the start original.
        /// </summary>
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

        /// <summary>
        /// Click evet, Save the curret loaded config file for the other events in the program.
        /// </summary>
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

        /// <summary>
        /// Click event, Start the upload the WorkItems structure to the configured server.
        /// </summary>
        private void subUploadStart_Click(object sender, EventArgs e)
        {
            // Controller evet calling.
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

        // Delete section start -------------------------------------------------

        private void subDeleteByIds_Click(object sender, EventArgs e)
        {
            subDeleteTabPages.SetPage(0);
        }

        /// <summary>
        /// Button Click, Delete WokrItem by Id from textBox.
        /// </summary>
        private void OneElemDeleteButton_Click(object sender, EventArgs e)
        {
            List<string> deleteDatas = new List<string>();
            string deleteId = OneDeleteTextBox.Text;
            if (String.IsNullOrEmpty(deleteId))
            {
                Alert.AlertCreation("Give Id to Delete!", AlertType.error);
                return;
            }
            else
            {
                deleteDatas.Add(deleteId);
                bool result = informationParser.DeleteByIds_Process(deleteDatas, serverOperator, mailSender);
                if (result)
                {
                    for (int i = 0; i <= 100; ++i)
                    {
                        OneElemDeleteBar.Value = i;
                        OneElemDeleteBar.Update();
                    }
                    Alert.AlertCreation("Delete Success by Id", AlertType.success);
                }
                else
                {
                    Alert.AlertCreation("WokrItem does not exist!", AlertType.error);
                    OneElemDeleteBar.Value = 0;
                    return;
                }
                OneElemDeleteBar.Value = 0;
                OneDeleteTextBox.Clear();
            }
        }
        /// <summary>
        /// Button click, Delete WorkItems by Ids from a textBox.
        /// </summary>
        private void MoreElemDeleteButton_Click(object sender, EventArgs e)
        {
            List<string> deleteDatas = new List<string>();
            string deleteId = MoreDeleteTextBox.Text;
            if (String.IsNullOrEmpty(deleteId))
            {
                Alert.AlertCreation("Give Ids to Delete!", AlertType.error);
                return;
            }
            else
            {
                string[] str = deleteId.Split(' ');
                for(int i = 0; i < str.Length; ++i)
                {
                    deleteDatas.Add(str[i]);
                }
                bool result = informationParser.DeleteByIds_Process(deleteDatas, serverOperator, mailSender);
                if (result)
                {
                    for (int i = 0; i <= 100; ++i)
                    {
                        MoreElemDeleteBar.Value = i;
                        MoreElemDeleteBar.Update();
                    }
                    Alert.AlertCreation("Delete Success by Ids", AlertType.success);
                }
                else
                {
                    Alert.AlertCreation("WokrItems does not exist!", AlertType.error);
                    MoreElemDeleteBar.Value = 0;
                    return;
                }
                MoreElemDeleteBar.Value = 0;
                MoreDeleteTextBox.Clear();
            }
        }

        private void subDeleteFromFile_Click(object sender, EventArgs e)
        {
            subDeleteTabPages.SetPage(1);
        }

        /// <summary>
        /// Select file for the delete section (from file) 
        /// </summary>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((fileStream = openFileDialog.OpenFile()) != null)
                {
                    string strFileName = openFileDialog.FileName;
                    SelectedFile.Text = strFileName;
                    SelectedFile.Visible = true;
                    Alert.AlertCreation("Load Success!", AlertType.success);
                }
            }
        }

        /// <summary>
        /// Button click, Delete WorkItems by Ids from a File.
        /// </summary>
        private void DeleteFileButton_Click(object sender, EventArgs e)
        {
            string deleteFile = SelectedFile.Text;
            if (String.IsNullOrEmpty(deleteFile))
            {
                Alert.AlertCreation("Browse a File!", AlertType.error);
                return;
            }
            else
            {
                bool result = informationParser.DeleteFromFile_Process(deleteFile, serverOperator, mailSender);
                if (result)
                {
                    for (int i = 0; i <= 100; ++i)
                    {
                        FileDeleteProgressBar.Value = i;
                        FileDeleteProgressBar.Update();
                    }
                    Alert.AlertCreation("Delete From File Success!", AlertType.success);
                }
                else
                {
                    Alert.AlertCreation("Delete From File Failed! Check the Log!", AlertType.error);
                    FileDeleteProgressBar.Value = 0;
                    return;
                }
                FileDeleteProgressBar.Value = 0;
            }
        }

        private void subCompleteDelete_Click(object sender, EventArgs e)
        {
            subDeleteTabPages.SetPage(2);
        }

        // Delete section end -------------------------------------------------

        // File section start -------------------------------------------------

        /// <summary>
        /// Get the current Month file and give the path.
        /// </summary>
        /// <returns>Actual Month path as string.</returns>
        private string GetCurrentMontFileForOpen()
        {
            string currentMonth = string.Empty;
            DateTime today = DateTime.Today;
            string upToDateMonth = today.Month.ToString();

            string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.csv", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (file.Contains(upToDateMonth))
                {
                    currentMonth = file;
                }
            }
            return currentMonth;
        }

        /// <summary>
        /// Click event, Load the current "Month" created upload file.
        /// </summary>
        private void subOpenCurrentFile_Click(object sender, EventArgs e)
        {
            string currentFile = GetCurrentMontFileForOpen();
            if (String.IsNullOrEmpty(currentFile))
            {
                Alert.AlertCreation("There is no Actual Monnt File!", AlertType.error);
                return;
            }
            else
            {
                Alert.AlertCreation("Actual Mont File Loaded!", AlertType.success);
                FileRichTextBox.Text = System.IO.File.ReadAllText(currentFile);
            }
        }

        /// <summary>
        /// Open File Browser and open any file.
        /// </summary>
        private void subOpenFileBrowse_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((fileStream = openFileDialog.OpenFile()) != null)
                {
                    string strFileName = openFileDialog.FileName;
                    string fileText = System.IO.File.ReadAllText(strFileName);
                    FileRichTextBox.Text = fileText;
                    Alert.AlertCreation("Load Success!", AlertType.success);
                }
            }
        }

        // File section end -------------------------------------------------

        // Log section start -------------------------------------------------

        /// <summary>
        /// Click event, Load the current "Log" created upload file.
        /// </summary>
        private void subOpenCurrentLog_Click(object sender, EventArgs e)
        {
            string actualLogPath = log.datedPath;
            if (String.IsNullOrEmpty(actualLogPath))
            {
                Alert.AlertCreation("There is no Actual Log File!", AlertType.error);
                return;
            }
            else
            {
                try
                {
                    Alert.AlertCreation("Actual Log File Loaded!", AlertType.success);
                    using (var fs = new FileStream(actualLogPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var sr = new StreamReader(fs, Encoding.Default))
                    {
                        LogRichTextBox.Text = sr.ReadToEnd();
                    }

                }
                catch (Exception)
                {
                    Alert.AlertCreation("Do something before!", AlertType.warning);
                }
            }
        }

        /// <summary>
        /// Open File Browser and open any Log file.
        /// </summary>
        private void subLogBrowse_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((fileStream = openFileDialog.OpenFile()) != null)
                {
                    string strFileName = openFileDialog.FileName;
                    string fileText = System.IO.File.ReadAllText(strFileName);
                    FileRichTextBox.Text = fileText;
                    Alert.AlertCreation("Load Success!", AlertType.success);
                }
            }
        }

        /// <summary>
        /// Open actual log in external application.
        /// </summary>
        private void subLogExternal_Click(object sender, EventArgs e)
        {
            string actualLogPath = log.datedPath;
            if (String.IsNullOrEmpty(actualLogPath))
            {
                Alert.AlertCreation("There is no Actual Log File!", AlertType.error);
                return;
            }
            else
            {
                Process.Start("notepad.exe", actualLogPath);
                Alert.AlertCreation("Actual Log File Loaded In External!", AlertType.success);
            }
        }

        // Log section end -------------------------------------------------
    }


}
