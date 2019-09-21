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
using System.Configuration;
using System.Text.RegularExpressions;
using System.Drawing;

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

                try
                {
                    ConfigurationManager.RefreshSection("PBICollectionSection");
                    ConfigurationManager.RefreshSection("Connection");
                    ConfigurationManager.RefreshSection("MailInformation");
                    ConfigurationManager.RefreshSection("system.diagnostics");

                    // Controller ReInit
                    informationParser = new InformationParser();
                    log = informationParser.Init_Log();
                    serverOperator = informationParser.Init_ServerOperation(log);
                    mailSender = informationParser.Init_MailSender(log);

                    // Server information setting to the Upload page
                    ServerCollectionInfoLabel.Text = informationParser.CurrentTfsCollectionName;
                    ServerTeamProjectInfoLabel.Text = informationParser.CurrentTeamProjectName;
                    UploadActiveButton.Text = "Active";
                    UploadActiveButton.ForeColor = Color.SeaGreen;
                    ServerCollectionInfoLabel.Refresh();
                    ServerTeamProjectInfoLabel.Refresh();
                    UploadActiveButton.Refresh();
                    FileRichTextBox.Clear();
                }
                catch(Exception)
                {
                    log.Error("Server connection fail!");
                    log.Flush();
                    ServerCollectionInfoLabel.Text = "Fail";
                    ServerTeamProjectInfoLabel.Text = "Fail";
                    UploadActiveButton.Text = "Inactive";
                    UploadActiveButton.ForeColor = Color.Red;
                    Alert.AlertCreation("Server connection fail!", AlertType.error);
                }
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
            // Relod Config Period for changes.
            ConfigurationManager.RefreshSection("PBICollectionSection");
            ConfigurationManager.RefreshSection("Connection");
            ConfigurationManager.RefreshSection("MailInformation");
            ConfigurationManager.RefreshSection("system.diagnostics");

            // Controller evet calling.
            bool result = false;
            if (UploadActiveButton.Text.Equals("Active"))
            {
                result = informationParser.Upload_Process(true, serverOperator,log);
                FileOperations writer = new FileOperations(log);
                writer.WriteInCSV(informationParser.CurrentTeamProjectName, serverOperator.datasForFileModification);
            }
            else
            {
                Alert.AlertCreation("Server Connection Problem!", AlertType.error);
                return;
            }

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
                CustomMessageBox messageBox = new CustomMessageBox("Are you sure that you would like to Delete form the Server by Id?");
                messageBox.ShowDialog();
                if (messageBox.returnValue == true)
                {
                    Alert.AlertCreation("Yes", AlertType.info);
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
                else
                {
                    Alert.AlertCreation("No", AlertType.info);
                }             
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
                for (int i = 0; i < str.Length; ++i)
                {
                    deleteDatas.Add(str[i]);
                }
                CustomMessageBox messageBox = new CustomMessageBox("Are you sure that you would like to Delete form the Server by Ids?");
                messageBox.ShowDialog();
                if (messageBox.returnValue == true)
                {
                    Alert.AlertCreation("Yes", AlertType.info);
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
                else
                {
                    Alert.AlertCreation("No", AlertType.info);
                }
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
                    SelctedFileTextBox.Text = strFileName;
                    SelctedFileTextBox.Visible = true;
                    Alert.AlertCreation("Load Success!", AlertType.success);
                }
            }
        }

        /// <summary>
        /// Button click, Delete WorkItems by Ids from a File.
        /// </summary>
        private void DeleteFileButton_Click(object sender, EventArgs e)
        {
            string deleteFile = SelctedFileTextBox.Text;
            if (String.IsNullOrEmpty(deleteFile))
            {
                Alert.AlertCreation("Browse a File!", AlertType.error);
                return;
            }
            else
            {
                CustomMessageBox messageBox = new CustomMessageBox("Are you sure that you would like to Delete form the Server by Selected File?");
                messageBox.ShowDialog();
                if (messageBox.returnValue == true)
                {
                    Alert.AlertCreation("Yes", AlertType.info);
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
                        Alert.AlertCreation("Delete From File Failed!", AlertType.error);
                        FileDeleteProgressBar.Value = 0;
                        return;
                    }
                    FileDeleteProgressBar.Value = 0;
                    SelctedFileTextBox.Visible = false;
                }
                else
                {
                    Alert.AlertCreation("No", AlertType.info);
                }
            }
        }

        private void subCompleteDelete_Click(object sender, EventArgs e)
        {
            subDeleteTabPages.SetPage(2);
        }

        /// <summary>
        /// Total Server Content Delete.
        /// </summary>
        private void DeleteAllButton_Click(object sender, EventArgs e)
        {
            CustomMessageBox messageBox = new CustomMessageBox("Are you sure that you would like to Delete the server content?");
            messageBox.ShowDialog();
            if (messageBox.returnValue == true)
            {
                Alert.AlertCreation("Yes", AlertType.info);
                informationParser.ServerContentDelete_Process(serverOperator, mailSender);
                for (int i = 0; i <= 100; ++i)
                {
                    AllServerDeleteProgressBar.Value = i;
                    AllServerDeleteProgressBar.Update();
                }
                Alert.AlertCreation("Delete Server Content Success!", AlertType.success);
                AllServerDeleteProgressBar.Value = 0;
            }
            else
            {
                Alert.AlertCreation("No", AlertType.info);
            }
        }

        // Delete section end -------------------------------------------------

        // File section start -------------------------------------------------

        /// <summary>
        /// Click event, Load the current "Month" created upload file.
        /// </summary>
        private void subOpenCurrentFile_Click(object sender, EventArgs e)
        {
            string currentFile = informationParser.GetUpToDateFileCSV(informationParser.CurrentTeamProjectName);
            if (String.IsNullOrEmpty(currentFile))
            {
                Alert.AlertCreation("There is no Actual Monnt File!", AlertType.error);
                return;
            }
            else
            {
                Alert.AlertCreation("Actual Mont File Loaded!", AlertType.success);
                FileRichTextBox.Text = informationParser.GetFileContent(currentFile);
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
                    FileRichTextBox.Text = informationParser.GetFileContent(strFileName);
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
                        sr.Close();
                        fs.Close();
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

        // Info section start -------------------------------------------------

        private void subContact_Click(object sender, EventArgs e)
        {
            subInfoPages.SetPage(0);
        }

        private void subBugReport_Click(object sender, EventArgs e)
        {
            subInfoPages.SetPage(1);
        }

        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://docs.microsoft.com/en-us/azure/devops/server/tfs-is-now-azure-devops-server?view=azure-devops");
        }

        /// <summary>
        /// Click event, Send a mail on the contact section.
        /// </summary>
        private void ContactSendButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(NameTextBox.Text) || String.IsNullOrEmpty(MailTextBox.Text) || 
                String.IsNullOrEmpty(SubjectTextBox.Text) || String.IsNullOrEmpty(ContentTextBox.Text))
            {
                Alert.AlertCreation("Fill Every Field!", AlertType.error);
                return;
            }
            else
            {
                string emailRegex = "^[a-zA-Z0-9_+&*-]+(?:\\." +
                                    "[a-zA-Z0-9_+&*-]+)*@" +
                                    "(?:[a-zA-Z0-9-]+\\.)+[a-z" +
                                    "A-Z]{2,7}$";

                bool isEmail = Regex.IsMatch(MailTextBox.Text, emailRegex);
                if (isEmail)
                {
                    bool result = informationParser.SendMail(mailSender, log, SubjectTextBox.Text,
                        "Mail sender Name: " + NameTextBox.Text + "<br>" + "Mail Sender Address: " + MailTextBox.Text + "<br>" + ContentTextBox.Text, null);
                    if (result)
                    {
                        Alert.AlertCreation("Mail has been sent.", AlertType.success);
                        NameTextBox.Clear();
                        MailTextBox.Clear();
                        SubjectTextBox.Clear();
                        ContentTextBox.Clear();
                    }
                    else
                    {
                        Alert.AlertCreation("Mail Problem. (Check SMTP)", AlertType.error);
                        return;
                    }
                }
                else
                {
                    Alert.AlertCreation("Mail Address Format Problem.", AlertType.error);
                    return;
                }            
            }
        }

        /// <summary>
        /// Check which button is active on the Report section for Subject type.
        /// </summary>
        /// <returns></returns>
        private string CheckSelectedReportButton()
        {
            if(FunctionBugButton.selected == true && UIBugButton.selected == false && OtherBugButton.selected == false)
            {
                return FunctionBugButton.Text;

            }else if (FunctionBugButton.selected == false && UIBugButton.selected == true && OtherBugButton.selected == false)
            {
                return UIBugButton.Text;

            }else if (FunctionBugButton.selected == false && UIBugButton.selected == false && OtherBugButton.selected == true)
            {
                return OtherBugButton.Text;
            }
            return null;
        }

        /// <summary>
        /// Click event, Send a Bug Report on the Report section.
        /// </summary>
        private void BugReportSendButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(BugNameTextBox.Text) || String.IsNullOrEmpty(BugMailTextBox.Text) 
                || String.IsNullOrEmpty(BugContentTextBox.Text) || 
                (FunctionBugButton.selected == false && UIBugButton.selected == false && OtherBugButton.selected == false))
            {
                Alert.AlertCreation("Fill Every Field!", AlertType.error);
                return;
            }
            else
            {
                string emailRegex = "^[a-zA-Z0-9_+&*-]+(?:\\." +
                                    "[a-zA-Z0-9_+&*-]+)*@" +
                                    "(?:[a-zA-Z0-9-]+\\.)+[a-z" +
                                    "A-Z]{2,7}$";

                bool isEmail = Regex.IsMatch(BugMailTextBox.Text, emailRegex);
                if (isEmail)
                {
                    string subject = CheckSelectedReportButton();
                    bool result = informationParser.SendMail(mailSender, log, subject, 
                        "Mail sender Name: " + BugNameTextBox.Text + "<br>" + "Mail Sender Address: " + BugMailTextBox.Text + "<br>" + BugContentTextBox.Text, null);
                    if (result)
                    {
                        Alert.AlertCreation("Bug Report has been sent.", AlertType.success);
                        BugNameTextBox.Clear();
                        BugMailTextBox.Clear();
                        FunctionBugButton.selected = false;
                        UIBugButton.selected = false;
                        OtherBugButton.selected = false;
                        BugContentTextBox.Clear();
                    }
                    else
                    {
                        Alert.AlertCreation("Report Problem.", AlertType.error);
                        return;
                    }
                }
                else
                {
                    Alert.AlertCreation("Mail Address Format Problem.", AlertType.error);
                    return;
                }
            }
        }

        // Info section end -------------------------------------------------
    }
}
