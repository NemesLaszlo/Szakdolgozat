namespace UI_TFS_ServerOperation
{
    partial class subMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subMenu));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Settings = new System.Windows.Forms.TabPage();
            this.subOpenCurrentConfig = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subReset = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subConfigLoad = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subSave = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Upload = new System.Windows.Forms.TabPage();
            this.subUploadStart = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subUploadConfigCheck = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Delete = new System.Windows.Forms.TabPage();
            this.subDeleteByIds = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subCompleteDelete = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subDeleteFromFile = new Bunifu.Framework.UI.BunifuFlatButton();
            this.File = new System.Windows.Forms.TabPage();
            this.subOpenCurrentFile = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subOpenFileBrowse = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Log = new System.Windows.Forms.TabPage();
            this.subLogExternal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subOpenCurrentLog = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subLogBrowse = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Info = new System.Windows.Forms.TabPage();
            this.subContact = new Bunifu.Framework.UI.BunifuFlatButton();
            this.subBugReport = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Dashboard = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Settings.SuspendLayout();
            this.Upload.SuspendLayout();
            this.Delete.SuspendLayout();
            this.File.SuspendLayout();
            this.Log.SuspendLayout();
            this.Info.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Settings);
            this.tabControl1.Controls.Add(this.Upload);
            this.tabControl1.Controls.Add(this.Delete);
            this.tabControl1.Controls.Add(this.File);
            this.tabControl1.Controls.Add(this.Log);
            this.tabControl1.Controls.Add(this.Info);
            this.tabControl1.Location = new System.Drawing.Point(-8, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(245, 664);
            this.tabControl1.TabIndex = 0;
            // 
            // Settings
            // 
            this.Settings.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Settings.Controls.Add(this.subOpenCurrentConfig);
            this.Settings.Controls.Add(this.subReset);
            this.Settings.Controls.Add(this.subConfigLoad);
            this.Settings.Controls.Add(this.subSave);
            this.Settings.Location = new System.Drawing.Point(4, 22);
            this.Settings.Name = "Settings";
            this.Settings.Padding = new System.Windows.Forms.Padding(3);
            this.Settings.Size = new System.Drawing.Size(237, 638);
            this.Settings.TabIndex = 0;
            this.Settings.Text = "Settings";
            // 
            // subOpenCurrentConfig
            // 
            this.subOpenCurrentConfig.Active = false;
            this.subOpenCurrentConfig.Activecolor = System.Drawing.Color.Gainsboro;
            this.subOpenCurrentConfig.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subOpenCurrentConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subOpenCurrentConfig.BorderRadius = 0;
            this.subOpenCurrentConfig.ButtonText = "         Open Current Config";
            this.subOpenCurrentConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subOpenCurrentConfig.DisabledColor = System.Drawing.Color.Gray;
            this.subOpenCurrentConfig.Iconcolor = System.Drawing.Color.Transparent;
            this.subOpenCurrentConfig.Iconimage = null;
            this.subOpenCurrentConfig.Iconimage_right = null;
            this.subOpenCurrentConfig.Iconimage_right_Selected = null;
            this.subOpenCurrentConfig.Iconimage_Selected = null;
            this.subOpenCurrentConfig.IconMarginLeft = 0;
            this.subOpenCurrentConfig.IconMarginRight = 0;
            this.subOpenCurrentConfig.IconRightVisible = false;
            this.subOpenCurrentConfig.IconRightZoom = 0D;
            this.subOpenCurrentConfig.IconVisible = false;
            this.subOpenCurrentConfig.IconZoom = 50D;
            this.subOpenCurrentConfig.IsTab = true;
            this.subOpenCurrentConfig.Location = new System.Drawing.Point(0, 6);
            this.subOpenCurrentConfig.Name = "subOpenCurrentConfig";
            this.subOpenCurrentConfig.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subOpenCurrentConfig.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subOpenCurrentConfig.OnHoverTextColor = System.Drawing.Color.Black;
            this.subOpenCurrentConfig.selected = false;
            this.subOpenCurrentConfig.Size = new System.Drawing.Size(235, 48);
            this.subOpenCurrentConfig.TabIndex = 8;
            this.subOpenCurrentConfig.Text = "         Open Current Config";
            this.subOpenCurrentConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subOpenCurrentConfig.Textcolor = System.Drawing.Color.DimGray;
            this.subOpenCurrentConfig.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // subReset
            // 
            this.subReset.Active = false;
            this.subReset.Activecolor = System.Drawing.Color.Gainsboro;
            this.subReset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subReset.BorderRadius = 0;
            this.subReset.ButtonText = "          Reset";
            this.subReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subReset.DisabledColor = System.Drawing.Color.Gray;
            this.subReset.Iconcolor = System.Drawing.Color.Transparent;
            this.subReset.Iconimage = null;
            this.subReset.Iconimage_right = null;
            this.subReset.Iconimage_right_Selected = null;
            this.subReset.Iconimage_Selected = null;
            this.subReset.IconMarginLeft = 0;
            this.subReset.IconMarginRight = 0;
            this.subReset.IconRightVisible = false;
            this.subReset.IconRightZoom = 0D;
            this.subReset.IconVisible = false;
            this.subReset.IconZoom = 50D;
            this.subReset.IsTab = true;
            this.subReset.Location = new System.Drawing.Point(-4, 94);
            this.subReset.Name = "subReset";
            this.subReset.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subReset.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subReset.OnHoverTextColor = System.Drawing.Color.Black;
            this.subReset.selected = false;
            this.subReset.Size = new System.Drawing.Size(235, 48);
            this.subReset.TabIndex = 7;
            this.subReset.Text = "          Reset";
            this.subReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subReset.Textcolor = System.Drawing.Color.DimGray;
            this.subReset.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // subConfigLoad
            // 
            this.subConfigLoad.Active = false;
            this.subConfigLoad.Activecolor = System.Drawing.Color.Gainsboro;
            this.subConfigLoad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subConfigLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subConfigLoad.BorderRadius = 0;
            this.subConfigLoad.ButtonText = "          Import Config";
            this.subConfigLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subConfigLoad.DisabledColor = System.Drawing.Color.Gray;
            this.subConfigLoad.Iconcolor = System.Drawing.Color.Transparent;
            this.subConfigLoad.Iconimage = null;
            this.subConfigLoad.Iconimage_right = null;
            this.subConfigLoad.Iconimage_right_Selected = null;
            this.subConfigLoad.Iconimage_Selected = null;
            this.subConfigLoad.IconMarginLeft = 0;
            this.subConfigLoad.IconMarginRight = 0;
            this.subConfigLoad.IconRightVisible = false;
            this.subConfigLoad.IconRightZoom = 0D;
            this.subConfigLoad.IconVisible = false;
            this.subConfigLoad.IconZoom = 50D;
            this.subConfigLoad.IsTab = true;
            this.subConfigLoad.Location = new System.Drawing.Point(-4, 49);
            this.subConfigLoad.Name = "subConfigLoad";
            this.subConfigLoad.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subConfigLoad.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subConfigLoad.OnHoverTextColor = System.Drawing.Color.Black;
            this.subConfigLoad.selected = false;
            this.subConfigLoad.Size = new System.Drawing.Size(235, 48);
            this.subConfigLoad.TabIndex = 5;
            this.subConfigLoad.Text = "          Import Config";
            this.subConfigLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subConfigLoad.Textcolor = System.Drawing.Color.DimGray;
            this.subConfigLoad.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // subSave
            // 
            this.subSave.Active = false;
            this.subSave.Activecolor = System.Drawing.Color.Gainsboro;
            this.subSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subSave.BorderRadius = 0;
            this.subSave.ButtonText = "          Save";
            this.subSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subSave.DisabledColor = System.Drawing.Color.Gray;
            this.subSave.Iconcolor = System.Drawing.Color.Transparent;
            this.subSave.Iconimage = null;
            this.subSave.Iconimage_right = null;
            this.subSave.Iconimage_right_Selected = null;
            this.subSave.Iconimage_Selected = null;
            this.subSave.IconMarginLeft = 0;
            this.subSave.IconMarginRight = 0;
            this.subSave.IconRightVisible = false;
            this.subSave.IconRightZoom = 0D;
            this.subSave.IconVisible = false;
            this.subSave.IconZoom = 50D;
            this.subSave.IsTab = true;
            this.subSave.Location = new System.Drawing.Point(-6, 139);
            this.subSave.Name = "subSave";
            this.subSave.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subSave.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subSave.OnHoverTextColor = System.Drawing.Color.Black;
            this.subSave.selected = false;
            this.subSave.Size = new System.Drawing.Size(235, 48);
            this.subSave.TabIndex = 4;
            this.subSave.Text = "          Save";
            this.subSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subSave.Textcolor = System.Drawing.Color.DimGray;
            this.subSave.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // Upload
            // 
            this.Upload.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Upload.Controls.Add(this.subUploadStart);
            this.Upload.Controls.Add(this.subUploadConfigCheck);
            this.Upload.Location = new System.Drawing.Point(4, 22);
            this.Upload.Name = "Upload";
            this.Upload.Padding = new System.Windows.Forms.Padding(3);
            this.Upload.Size = new System.Drawing.Size(237, 638);
            this.Upload.TabIndex = 1;
            this.Upload.Text = "Upload";
            // 
            // subUploadStart
            // 
            this.subUploadStart.Active = false;
            this.subUploadStart.Activecolor = System.Drawing.Color.Gainsboro;
            this.subUploadStart.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subUploadStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subUploadStart.BorderRadius = 0;
            this.subUploadStart.ButtonText = "          Start";
            this.subUploadStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subUploadStart.DisabledColor = System.Drawing.Color.Gray;
            this.subUploadStart.Iconcolor = System.Drawing.Color.Transparent;
            this.subUploadStart.Iconimage = null;
            this.subUploadStart.Iconimage_right = null;
            this.subUploadStart.Iconimage_right_Selected = null;
            this.subUploadStart.Iconimage_Selected = null;
            this.subUploadStart.IconMarginLeft = 0;
            this.subUploadStart.IconMarginRight = 0;
            this.subUploadStart.IconRightVisible = false;
            this.subUploadStart.IconRightZoom = 0D;
            this.subUploadStart.IconVisible = false;
            this.subUploadStart.IconZoom = 50D;
            this.subUploadStart.IsTab = true;
            this.subUploadStart.Location = new System.Drawing.Point(-6, 6);
            this.subUploadStart.Name = "subUploadStart";
            this.subUploadStart.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subUploadStart.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subUploadStart.OnHoverTextColor = System.Drawing.Color.Black;
            this.subUploadStart.selected = false;
            this.subUploadStart.Size = new System.Drawing.Size(235, 48);
            this.subUploadStart.TabIndex = 19;
            this.subUploadStart.Text = "          Start";
            this.subUploadStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subUploadStart.Textcolor = System.Drawing.Color.DimGray;
            this.subUploadStart.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // subUploadConfigCheck
            // 
            this.subUploadConfigCheck.Active = false;
            this.subUploadConfigCheck.Activecolor = System.Drawing.Color.Gainsboro;
            this.subUploadConfigCheck.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subUploadConfigCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subUploadConfigCheck.BorderRadius = 0;
            this.subUploadConfigCheck.ButtonText = "          Check";
            this.subUploadConfigCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subUploadConfigCheck.DisabledColor = System.Drawing.Color.Gray;
            this.subUploadConfigCheck.Iconcolor = System.Drawing.Color.Transparent;
            this.subUploadConfigCheck.Iconimage = null;
            this.subUploadConfigCheck.Iconimage_right = null;
            this.subUploadConfigCheck.Iconimage_right_Selected = null;
            this.subUploadConfigCheck.Iconimage_Selected = null;
            this.subUploadConfigCheck.IconMarginLeft = 0;
            this.subUploadConfigCheck.IconMarginRight = 0;
            this.subUploadConfigCheck.IconRightVisible = false;
            this.subUploadConfigCheck.IconRightZoom = 0D;
            this.subUploadConfigCheck.IconVisible = false;
            this.subUploadConfigCheck.IconZoom = 50D;
            this.subUploadConfigCheck.IsTab = true;
            this.subUploadConfigCheck.Location = new System.Drawing.Point(-4, 51);
            this.subUploadConfigCheck.Name = "subUploadConfigCheck";
            this.subUploadConfigCheck.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subUploadConfigCheck.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subUploadConfigCheck.OnHoverTextColor = System.Drawing.Color.Black;
            this.subUploadConfigCheck.selected = false;
            this.subUploadConfigCheck.Size = new System.Drawing.Size(235, 48);
            this.subUploadConfigCheck.TabIndex = 18;
            this.subUploadConfigCheck.Text = "          Check";
            this.subUploadConfigCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subUploadConfigCheck.Textcolor = System.Drawing.Color.DimGray;
            this.subUploadConfigCheck.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Delete.Controls.Add(this.subDeleteByIds);
            this.Delete.Controls.Add(this.subCompleteDelete);
            this.Delete.Controls.Add(this.subDeleteFromFile);
            this.Delete.Location = new System.Drawing.Point(4, 22);
            this.Delete.Name = "Delete";
            this.Delete.Padding = new System.Windows.Forms.Padding(3);
            this.Delete.Size = new System.Drawing.Size(237, 638);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Delete";
            // 
            // subDeleteByIds
            // 
            this.subDeleteByIds.Active = false;
            this.subDeleteByIds.Activecolor = System.Drawing.Color.Gainsboro;
            this.subDeleteByIds.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subDeleteByIds.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subDeleteByIds.BorderRadius = 0;
            this.subDeleteByIds.ButtonText = "          Delete By Ids";
            this.subDeleteByIds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subDeleteByIds.DisabledColor = System.Drawing.Color.Gray;
            this.subDeleteByIds.Iconcolor = System.Drawing.Color.Transparent;
            this.subDeleteByIds.Iconimage = null;
            this.subDeleteByIds.Iconimage_right = null;
            this.subDeleteByIds.Iconimage_right_Selected = null;
            this.subDeleteByIds.Iconimage_Selected = null;
            this.subDeleteByIds.IconMarginLeft = 0;
            this.subDeleteByIds.IconMarginRight = 0;
            this.subDeleteByIds.IconRightVisible = false;
            this.subDeleteByIds.IconRightZoom = 0D;
            this.subDeleteByIds.IconVisible = false;
            this.subDeleteByIds.IconZoom = 50D;
            this.subDeleteByIds.IsTab = true;
            this.subDeleteByIds.Location = new System.Drawing.Point(-4, 6);
            this.subDeleteByIds.Name = "subDeleteByIds";
            this.subDeleteByIds.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subDeleteByIds.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subDeleteByIds.OnHoverTextColor = System.Drawing.Color.Black;
            this.subDeleteByIds.selected = false;
            this.subDeleteByIds.Size = new System.Drawing.Size(235, 48);
            this.subDeleteByIds.TabIndex = 11;
            this.subDeleteByIds.Tag = "0";
            this.subDeleteByIds.Text = "          Delete By Ids";
            this.subDeleteByIds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subDeleteByIds.Textcolor = System.Drawing.Color.DimGray;
            this.subDeleteByIds.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.subDeleteByIds.Click += new System.EventHandler(this.subDeleteClick_Click);
            // 
            // subCompleteDelete
            // 
            this.subCompleteDelete.Active = false;
            this.subCompleteDelete.Activecolor = System.Drawing.Color.Gainsboro;
            this.subCompleteDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subCompleteDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subCompleteDelete.BorderRadius = 0;
            this.subCompleteDelete.ButtonText = "          Complete Delete";
            this.subCompleteDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subCompleteDelete.DisabledColor = System.Drawing.Color.Gray;
            this.subCompleteDelete.Iconcolor = System.Drawing.Color.Transparent;
            this.subCompleteDelete.Iconimage = null;
            this.subCompleteDelete.Iconimage_right = null;
            this.subCompleteDelete.Iconimage_right_Selected = null;
            this.subCompleteDelete.Iconimage_Selected = null;
            this.subCompleteDelete.IconMarginLeft = 0;
            this.subCompleteDelete.IconMarginRight = 0;
            this.subCompleteDelete.IconRightVisible = false;
            this.subCompleteDelete.IconRightZoom = 0D;
            this.subCompleteDelete.IconVisible = false;
            this.subCompleteDelete.IconZoom = 50D;
            this.subCompleteDelete.IsTab = true;
            this.subCompleteDelete.Location = new System.Drawing.Point(-4, 96);
            this.subCompleteDelete.Name = "subCompleteDelete";
            this.subCompleteDelete.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subCompleteDelete.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subCompleteDelete.OnHoverTextColor = System.Drawing.Color.Black;
            this.subCompleteDelete.selected = false;
            this.subCompleteDelete.Size = new System.Drawing.Size(235, 48);
            this.subCompleteDelete.TabIndex = 10;
            this.subCompleteDelete.Tag = "2";
            this.subCompleteDelete.Text = "          Complete Delete";
            this.subCompleteDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subCompleteDelete.Textcolor = System.Drawing.Color.DimGray;
            this.subCompleteDelete.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.subCompleteDelete.Click += new System.EventHandler(this.subDeleteClick_Click);
            // 
            // subDeleteFromFile
            // 
            this.subDeleteFromFile.Active = false;
            this.subDeleteFromFile.Activecolor = System.Drawing.Color.Gainsboro;
            this.subDeleteFromFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subDeleteFromFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subDeleteFromFile.BorderRadius = 0;
            this.subDeleteFromFile.ButtonText = "          Delete From File";
            this.subDeleteFromFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subDeleteFromFile.DisabledColor = System.Drawing.Color.Gray;
            this.subDeleteFromFile.Iconcolor = System.Drawing.Color.Transparent;
            this.subDeleteFromFile.Iconimage = null;
            this.subDeleteFromFile.Iconimage_right = null;
            this.subDeleteFromFile.Iconimage_right_Selected = null;
            this.subDeleteFromFile.Iconimage_Selected = null;
            this.subDeleteFromFile.IconMarginLeft = 0;
            this.subDeleteFromFile.IconMarginRight = 0;
            this.subDeleteFromFile.IconRightVisible = false;
            this.subDeleteFromFile.IconRightZoom = 0D;
            this.subDeleteFromFile.IconVisible = false;
            this.subDeleteFromFile.IconZoom = 50D;
            this.subDeleteFromFile.IsTab = true;
            this.subDeleteFromFile.Location = new System.Drawing.Point(-4, 51);
            this.subDeleteFromFile.Name = "subDeleteFromFile";
            this.subDeleteFromFile.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subDeleteFromFile.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subDeleteFromFile.OnHoverTextColor = System.Drawing.Color.Black;
            this.subDeleteFromFile.selected = false;
            this.subDeleteFromFile.Size = new System.Drawing.Size(235, 48);
            this.subDeleteFromFile.TabIndex = 9;
            this.subDeleteFromFile.Tag = "1";
            this.subDeleteFromFile.Text = "          Delete From File";
            this.subDeleteFromFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subDeleteFromFile.Textcolor = System.Drawing.Color.DimGray;
            this.subDeleteFromFile.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.subDeleteFromFile.Click += new System.EventHandler(this.subDeleteClick_Click);
            // 
            // File
            // 
            this.File.BackColor = System.Drawing.Color.WhiteSmoke;
            this.File.Controls.Add(this.subOpenCurrentFile);
            this.File.Controls.Add(this.subOpenFileBrowse);
            this.File.Location = new System.Drawing.Point(4, 22);
            this.File.Name = "File";
            this.File.Padding = new System.Windows.Forms.Padding(3);
            this.File.Size = new System.Drawing.Size(237, 638);
            this.File.TabIndex = 3;
            this.File.Text = "File";
            // 
            // subOpenCurrentFile
            // 
            this.subOpenCurrentFile.Active = false;
            this.subOpenCurrentFile.Activecolor = System.Drawing.Color.Gainsboro;
            this.subOpenCurrentFile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subOpenCurrentFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subOpenCurrentFile.BorderRadius = 0;
            this.subOpenCurrentFile.ButtonText = "          Open Current File";
            this.subOpenCurrentFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subOpenCurrentFile.DisabledColor = System.Drawing.Color.Gray;
            this.subOpenCurrentFile.Iconcolor = System.Drawing.Color.Transparent;
            this.subOpenCurrentFile.Iconimage = null;
            this.subOpenCurrentFile.Iconimage_right = null;
            this.subOpenCurrentFile.Iconimage_right_Selected = null;
            this.subOpenCurrentFile.Iconimage_Selected = null;
            this.subOpenCurrentFile.IconMarginLeft = 0;
            this.subOpenCurrentFile.IconMarginRight = 0;
            this.subOpenCurrentFile.IconRightVisible = false;
            this.subOpenCurrentFile.IconRightZoom = 0D;
            this.subOpenCurrentFile.IconVisible = false;
            this.subOpenCurrentFile.IconZoom = 50D;
            this.subOpenCurrentFile.IsTab = true;
            this.subOpenCurrentFile.Location = new System.Drawing.Point(-4, 6);
            this.subOpenCurrentFile.Name = "subOpenCurrentFile";
            this.subOpenCurrentFile.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subOpenCurrentFile.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subOpenCurrentFile.OnHoverTextColor = System.Drawing.Color.Black;
            this.subOpenCurrentFile.selected = false;
            this.subOpenCurrentFile.Size = new System.Drawing.Size(235, 48);
            this.subOpenCurrentFile.TabIndex = 13;
            this.subOpenCurrentFile.Text = "          Open Current File";
            this.subOpenCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subOpenCurrentFile.Textcolor = System.Drawing.Color.DimGray;
            this.subOpenCurrentFile.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // subOpenFileBrowse
            // 
            this.subOpenFileBrowse.Active = false;
            this.subOpenFileBrowse.Activecolor = System.Drawing.Color.Gainsboro;
            this.subOpenFileBrowse.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subOpenFileBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subOpenFileBrowse.BorderRadius = 0;
            this.subOpenFileBrowse.ButtonText = "          Open File Browse";
            this.subOpenFileBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subOpenFileBrowse.DisabledColor = System.Drawing.Color.Gray;
            this.subOpenFileBrowse.Iconcolor = System.Drawing.Color.Transparent;
            this.subOpenFileBrowse.Iconimage = null;
            this.subOpenFileBrowse.Iconimage_right = null;
            this.subOpenFileBrowse.Iconimage_right_Selected = null;
            this.subOpenFileBrowse.Iconimage_Selected = null;
            this.subOpenFileBrowse.IconMarginLeft = 0;
            this.subOpenFileBrowse.IconMarginRight = 0;
            this.subOpenFileBrowse.IconRightVisible = false;
            this.subOpenFileBrowse.IconRightZoom = 0D;
            this.subOpenFileBrowse.IconVisible = false;
            this.subOpenFileBrowse.IconZoom = 50D;
            this.subOpenFileBrowse.IsTab = true;
            this.subOpenFileBrowse.Location = new System.Drawing.Point(-4, 51);
            this.subOpenFileBrowse.Name = "subOpenFileBrowse";
            this.subOpenFileBrowse.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subOpenFileBrowse.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subOpenFileBrowse.OnHoverTextColor = System.Drawing.Color.Black;
            this.subOpenFileBrowse.selected = false;
            this.subOpenFileBrowse.Size = new System.Drawing.Size(235, 48);
            this.subOpenFileBrowse.TabIndex = 12;
            this.subOpenFileBrowse.Text = "          Open File Browse";
            this.subOpenFileBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subOpenFileBrowse.Textcolor = System.Drawing.Color.DimGray;
            this.subOpenFileBrowse.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Log.Controls.Add(this.subLogExternal);
            this.Log.Controls.Add(this.subOpenCurrentLog);
            this.Log.Controls.Add(this.subLogBrowse);
            this.Log.Location = new System.Drawing.Point(4, 22);
            this.Log.Name = "Log";
            this.Log.Padding = new System.Windows.Forms.Padding(3);
            this.Log.Size = new System.Drawing.Size(237, 638);
            this.Log.TabIndex = 4;
            this.Log.Text = "Log";
            // 
            // subLogExternal
            // 
            this.subLogExternal.Active = false;
            this.subLogExternal.Activecolor = System.Drawing.Color.Gainsboro;
            this.subLogExternal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subLogExternal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subLogExternal.BorderRadius = 0;
            this.subLogExternal.ButtonText = "          Open Log External";
            this.subLogExternal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subLogExternal.DisabledColor = System.Drawing.Color.Gray;
            this.subLogExternal.Iconcolor = System.Drawing.Color.Transparent;
            this.subLogExternal.Iconimage = null;
            this.subLogExternal.Iconimage_right = null;
            this.subLogExternal.Iconimage_right_Selected = null;
            this.subLogExternal.Iconimage_Selected = null;
            this.subLogExternal.IconMarginLeft = 0;
            this.subLogExternal.IconMarginRight = 0;
            this.subLogExternal.IconRightVisible = false;
            this.subLogExternal.IconRightZoom = 0D;
            this.subLogExternal.IconVisible = false;
            this.subLogExternal.IconZoom = 50D;
            this.subLogExternal.IsTab = true;
            this.subLogExternal.Location = new System.Drawing.Point(-4, 96);
            this.subLogExternal.Name = "subLogExternal";
            this.subLogExternal.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subLogExternal.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subLogExternal.OnHoverTextColor = System.Drawing.Color.Black;
            this.subLogExternal.selected = false;
            this.subLogExternal.Size = new System.Drawing.Size(235, 48);
            this.subLogExternal.TabIndex = 16;
            this.subLogExternal.Text = "          Open Log External";
            this.subLogExternal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subLogExternal.Textcolor = System.Drawing.Color.DimGray;
            this.subLogExternal.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // subOpenCurrentLog
            // 
            this.subOpenCurrentLog.Active = false;
            this.subOpenCurrentLog.Activecolor = System.Drawing.Color.Gainsboro;
            this.subOpenCurrentLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subOpenCurrentLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subOpenCurrentLog.BorderRadius = 0;
            this.subOpenCurrentLog.ButtonText = "          Open Current Log";
            this.subOpenCurrentLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subOpenCurrentLog.DisabledColor = System.Drawing.Color.Gray;
            this.subOpenCurrentLog.Iconcolor = System.Drawing.Color.Transparent;
            this.subOpenCurrentLog.Iconimage = null;
            this.subOpenCurrentLog.Iconimage_right = null;
            this.subOpenCurrentLog.Iconimage_right_Selected = null;
            this.subOpenCurrentLog.Iconimage_Selected = null;
            this.subOpenCurrentLog.IconMarginLeft = 0;
            this.subOpenCurrentLog.IconMarginRight = 0;
            this.subOpenCurrentLog.IconRightVisible = false;
            this.subOpenCurrentLog.IconRightZoom = 0D;
            this.subOpenCurrentLog.IconVisible = false;
            this.subOpenCurrentLog.IconZoom = 50D;
            this.subOpenCurrentLog.IsTab = true;
            this.subOpenCurrentLog.Location = new System.Drawing.Point(-4, 6);
            this.subOpenCurrentLog.Name = "subOpenCurrentLog";
            this.subOpenCurrentLog.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subOpenCurrentLog.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subOpenCurrentLog.OnHoverTextColor = System.Drawing.Color.Black;
            this.subOpenCurrentLog.selected = false;
            this.subOpenCurrentLog.Size = new System.Drawing.Size(235, 48);
            this.subOpenCurrentLog.TabIndex = 15;
            this.subOpenCurrentLog.Text = "          Open Current Log";
            this.subOpenCurrentLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subOpenCurrentLog.Textcolor = System.Drawing.Color.DimGray;
            this.subOpenCurrentLog.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // subLogBrowse
            // 
            this.subLogBrowse.Active = false;
            this.subLogBrowse.Activecolor = System.Drawing.Color.Gainsboro;
            this.subLogBrowse.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subLogBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subLogBrowse.BorderRadius = 0;
            this.subLogBrowse.ButtonText = "          Open Log Browse";
            this.subLogBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subLogBrowse.DisabledColor = System.Drawing.Color.Gray;
            this.subLogBrowse.Iconcolor = System.Drawing.Color.Transparent;
            this.subLogBrowse.Iconimage = null;
            this.subLogBrowse.Iconimage_right = null;
            this.subLogBrowse.Iconimage_right_Selected = null;
            this.subLogBrowse.Iconimage_Selected = null;
            this.subLogBrowse.IconMarginLeft = 0;
            this.subLogBrowse.IconMarginRight = 0;
            this.subLogBrowse.IconRightVisible = false;
            this.subLogBrowse.IconRightZoom = 0D;
            this.subLogBrowse.IconVisible = false;
            this.subLogBrowse.IconZoom = 50D;
            this.subLogBrowse.IsTab = true;
            this.subLogBrowse.Location = new System.Drawing.Point(-4, 51);
            this.subLogBrowse.Name = "subLogBrowse";
            this.subLogBrowse.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subLogBrowse.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subLogBrowse.OnHoverTextColor = System.Drawing.Color.Black;
            this.subLogBrowse.selected = false;
            this.subLogBrowse.Size = new System.Drawing.Size(235, 48);
            this.subLogBrowse.TabIndex = 14;
            this.subLogBrowse.Text = "          Open Log Browse";
            this.subLogBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subLogBrowse.Textcolor = System.Drawing.Color.DimGray;
            this.subLogBrowse.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            // 
            // Info
            // 
            this.Info.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Info.Controls.Add(this.subContact);
            this.Info.Controls.Add(this.subBugReport);
            this.Info.Location = new System.Drawing.Point(4, 22);
            this.Info.Name = "Info";
            this.Info.Padding = new System.Windows.Forms.Padding(3);
            this.Info.Size = new System.Drawing.Size(237, 638);
            this.Info.TabIndex = 5;
            this.Info.Text = "Info";
            // 
            // subContact
            // 
            this.subContact.Active = false;
            this.subContact.Activecolor = System.Drawing.Color.Gainsboro;
            this.subContact.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subContact.BorderRadius = 0;
            this.subContact.ButtonText = "          Contact";
            this.subContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subContact.DisabledColor = System.Drawing.Color.Gray;
            this.subContact.Iconcolor = System.Drawing.Color.Transparent;
            this.subContact.Iconimage = null;
            this.subContact.Iconimage_right = null;
            this.subContact.Iconimage_right_Selected = null;
            this.subContact.Iconimage_Selected = null;
            this.subContact.IconMarginLeft = 0;
            this.subContact.IconMarginRight = 0;
            this.subContact.IconRightVisible = false;
            this.subContact.IconRightZoom = 0D;
            this.subContact.IconVisible = false;
            this.subContact.IconZoom = 50D;
            this.subContact.IsTab = true;
            this.subContact.Location = new System.Drawing.Point(-4, 6);
            this.subContact.Name = "subContact";
            this.subContact.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subContact.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subContact.OnHoverTextColor = System.Drawing.Color.Black;
            this.subContact.selected = false;
            this.subContact.Size = new System.Drawing.Size(235, 48);
            this.subContact.TabIndex = 17;
            this.subContact.Tag = "0";
            this.subContact.Text = "          Contact";
            this.subContact.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subContact.Textcolor = System.Drawing.Color.DimGray;
            this.subContact.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.subContact.Click += new System.EventHandler(this.subInfoClick_Click);
            // 
            // subBugReport
            // 
            this.subBugReport.Active = false;
            this.subBugReport.Activecolor = System.Drawing.Color.Gainsboro;
            this.subBugReport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.subBugReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.subBugReport.BorderRadius = 0;
            this.subBugReport.ButtonText = "          Bug Report";
            this.subBugReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.subBugReport.DisabledColor = System.Drawing.Color.Gray;
            this.subBugReport.Iconcolor = System.Drawing.Color.Transparent;
            this.subBugReport.Iconimage = null;
            this.subBugReport.Iconimage_right = null;
            this.subBugReport.Iconimage_right_Selected = null;
            this.subBugReport.Iconimage_Selected = null;
            this.subBugReport.IconMarginLeft = 0;
            this.subBugReport.IconMarginRight = 0;
            this.subBugReport.IconRightVisible = false;
            this.subBugReport.IconRightZoom = 0D;
            this.subBugReport.IconVisible = false;
            this.subBugReport.IconZoom = 50D;
            this.subBugReport.IsTab = true;
            this.subBugReport.Location = new System.Drawing.Point(-4, 51);
            this.subBugReport.Name = "subBugReport";
            this.subBugReport.Normalcolor = System.Drawing.Color.WhiteSmoke;
            this.subBugReport.OnHovercolor = System.Drawing.Color.WhiteSmoke;
            this.subBugReport.OnHoverTextColor = System.Drawing.Color.Black;
            this.subBugReport.selected = false;
            this.subBugReport.Size = new System.Drawing.Size(235, 48);
            this.subBugReport.TabIndex = 16;
            this.subBugReport.Tag = "1";
            this.subBugReport.Text = "          Bug Report";
            this.subBugReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.subBugReport.Textcolor = System.Drawing.Color.DimGray;
            this.subBugReport.TextFont = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.subBugReport.Click += new System.EventHandler(this.subInfoClick_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.Dashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 80);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Dashboard
            // 
            this.Dashboard.AutoSize = true;
            this.Dashboard.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Dashboard.ForeColor = System.Drawing.Color.DimGray;
            this.Dashboard.Location = new System.Drawing.Point(77, 36);
            this.Dashboard.Name = "Dashboard";
            this.Dashboard.Size = new System.Drawing.Size(95, 19);
            this.Dashboard.TabIndex = 0;
            this.Dashboard.Text = "Dashboard";
            // 
            // subMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "subMenu";
            this.Size = new System.Drawing.Size(225, 579);
            this.tabControl1.ResumeLayout(false);
            this.Settings.ResumeLayout(false);
            this.Upload.ResumeLayout(false);
            this.Delete.ResumeLayout(false);
            this.File.ResumeLayout(false);
            this.Log.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Settings;
        private System.Windows.Forms.TabPage Upload;
        private System.Windows.Forms.TabPage Delete;
        private System.Windows.Forms.TabPage File;
        private System.Windows.Forms.TabPage Log;
        private System.Windows.Forms.TabPage Info;
        private Bunifu.Framework.UI.BunifuFlatButton subSave;
        private Bunifu.Framework.UI.BunifuFlatButton subConfigLoad;
        private Bunifu.Framework.UI.BunifuFlatButton subReset;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Dashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuFlatButton subOpenCurrentConfig;
        private Bunifu.Framework.UI.BunifuFlatButton subDeleteByIds;
        private Bunifu.Framework.UI.BunifuFlatButton subCompleteDelete;
        private Bunifu.Framework.UI.BunifuFlatButton subDeleteFromFile;
        private Bunifu.Framework.UI.BunifuFlatButton subOpenCurrentFile;
        private Bunifu.Framework.UI.BunifuFlatButton subOpenFileBrowse;
        private Bunifu.Framework.UI.BunifuFlatButton subLogExternal;
        private Bunifu.Framework.UI.BunifuFlatButton subOpenCurrentLog;
        private Bunifu.Framework.UI.BunifuFlatButton subLogBrowse;
        private Bunifu.Framework.UI.BunifuFlatButton subContact;
        private Bunifu.Framework.UI.BunifuFlatButton subBugReport;
        private Bunifu.Framework.UI.BunifuFlatButton subUploadStart;
        private Bunifu.Framework.UI.BunifuFlatButton subUploadConfigCheck;
    }
}
