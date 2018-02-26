namespace WinToolHAB.FrmMain
{
    partial class WTHFrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tclMain = new System.Windows.Forms.TabControl();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.btnOpenHABPath = new System.Windows.Forms.Button();
            this.tbxOpenHABPath = new System.Windows.Forms.TextBox();
            this.lblOpenHABPath = new System.Windows.Forms.Label();
            this.tbxServiceName = new System.Windows.Forms.TextBox();
            this.lblServiceName = new System.Windows.Forms.Label();
            this.lblRunType = new System.Windows.Forms.Label();
            this.cbxRunType = new System.Windows.Forms.ComboBox();
            this.tbpBackup = new System.Windows.Forms.TabPage();
            this.lblKeepLastConfigurationBackups = new System.Windows.Forms.Label();
            this.chkDeleteOldConfigurationBackups = new System.Windows.Forms.CheckBox();
            this.nudKeepLastConfigurationBackups = new System.Windows.Forms.NumericUpDown();
            this.lblKeepLastFullBackups = new System.Windows.Forms.Label();
            this.chkDeleteOldFullBackups = new System.Windows.Forms.CheckBox();
            this.lblBackupManagement = new System.Windows.Forms.Label();
            this.nudKeepLastFullBackups = new System.Windows.Forms.NumericUpDown();
            this.btnClearBackupLog = new System.Windows.Forms.Button();
            this.rtbBackupLog = new System.Windows.Forms.RichTextBox();
            this.lblBackupLog = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.lblBackupProgress = new System.Windows.Forms.Label();
            this.cbxBackupType = new System.Windows.Forms.ComboBox();
            this.lblBackupType = new System.Windows.Forms.Label();
            this.pbrBackupProgress = new System.Windows.Forms.ProgressBar();
            this.btnBackupPath = new System.Windows.Forms.Button();
            this.tbxBackupPath = new System.Windows.Forms.TextBox();
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.tbpRestore = new System.Windows.Forms.TabPage();
            this.btnClearRestoreLog = new System.Windows.Forms.Button();
            this.rtbRestoreLog = new System.Windows.Forms.RichTextBox();
            this.lblRestoreLog = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.lblRestoreProgress = new System.Windows.Forms.Label();
            this.pbrRestoreProgress = new System.Windows.Forms.ProgressBar();
            this.btnRestoreBackupFile = new System.Windows.Forms.Button();
            this.tbxRestoreBackupFile = new System.Windows.Forms.TextBox();
            this.lblRestoreBackupFile = new System.Windows.Forms.Label();
            this.tbpUpdate = new System.Windows.Forms.TabPage();
            this.tbxUpdateURL = new System.Windows.Forms.TextBox();
            this.lblUpdateURL = new System.Windows.Forms.Label();
            this.cbxUpdateType = new System.Windows.Forms.ComboBox();
            this.lblUpdateType = new System.Windows.Forms.Label();
            this.btnClearUpdateLog = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.rtbUpdateLog = new System.Windows.Forms.RichTextBox();
            this.lblUpdateLog = new System.Windows.Forms.Label();
            this.lblUpdateProgress = new System.Windows.Forms.Label();
            this.pbrUpdateProgress = new System.Windows.Forms.ProgressBar();
            this.cbxBeforeUpdating = new System.Windows.Forms.ComboBox();
            this.lblBeforeUpdating = new System.Windows.Forms.Label();
            this.btnUpdateFile = new System.Windows.Forms.Button();
            this.tbxUpdateFile = new System.Windows.Forms.TextBox();
            this.lblUpdateFile = new System.Windows.Forms.Label();
            this.btnUpdatePath = new System.Windows.Forms.Button();
            this.tbxUpdatePath = new System.Windows.Forms.TextBox();
            this.lblUpdatePath = new System.Windows.Forms.Label();
            this.mnuMain.SuspendLayout();
            this.tclMain.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            this.tbpBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepLastConfigurationBackups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepLastFullBackups)).BeginInit();
            this.tbpRestore.SuspendLayout();
            this.tbpUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.GripMargin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(5, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(614, 24);
            this.mnuMain.TabIndex = 3;
            this.mnuMain.Text = "mnuMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tclMain
            // 
            this.tclMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tclMain.Controls.Add(this.tbpGeneral);
            this.tclMain.Controls.Add(this.tbpBackup);
            this.tclMain.Controls.Add(this.tbpRestore);
            this.tclMain.Controls.Add(this.tbpUpdate);
            this.tclMain.Location = new System.Drawing.Point(5, 27);
            this.tclMain.Name = "tclMain";
            this.tclMain.SelectedIndex = 0;
            this.tclMain.Size = new System.Drawing.Size(614, 406);
            this.tclMain.TabIndex = 4;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.btnOpenHABPath);
            this.tbpGeneral.Controls.Add(this.tbxOpenHABPath);
            this.tbpGeneral.Controls.Add(this.lblOpenHABPath);
            this.tbpGeneral.Controls.Add(this.tbxServiceName);
            this.tbpGeneral.Controls.Add(this.lblServiceName);
            this.tbpGeneral.Controls.Add(this.lblRunType);
            this.tbpGeneral.Controls.Add(this.cbxRunType);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(606, 380);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // btnOpenHABPath
            // 
            this.btnOpenHABPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenHABPath.Location = new System.Drawing.Point(571, 65);
            this.btnOpenHABPath.Name = "btnOpenHABPath";
            this.btnOpenHABPath.Size = new System.Drawing.Size(23, 23);
            this.btnOpenHABPath.TabIndex = 6;
            this.btnOpenHABPath.Text = "...";
            this.btnOpenHABPath.UseVisualStyleBackColor = true;
            this.btnOpenHABPath.Click += new System.EventHandler(this.btnOpenHABPath_Click);
            // 
            // tbxOpenHABPath
            // 
            this.tbxOpenHABPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxOpenHABPath.Location = new System.Drawing.Point(130, 67);
            this.tbxOpenHABPath.Name = "tbxOpenHABPath";
            this.tbxOpenHABPath.Size = new System.Drawing.Size(435, 20);
            this.tbxOpenHABPath.TabIndex = 5;
            // 
            // lblOpenHABPath
            // 
            this.lblOpenHABPath.AutoSize = true;
            this.lblOpenHABPath.Location = new System.Drawing.Point(10, 70);
            this.lblOpenHABPath.Name = "lblOpenHABPath";
            this.lblOpenHABPath.Size = new System.Drawing.Size(82, 13);
            this.lblOpenHABPath.TabIndex = 4;
            this.lblOpenHABPath.Text = "OpenHAB &path:";
            // 
            // tbxServiceName
            // 
            this.tbxServiceName.AcceptsReturn = true;
            this.tbxServiceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxServiceName.Location = new System.Drawing.Point(130, 41);
            this.tbxServiceName.Name = "tbxServiceName";
            this.tbxServiceName.Size = new System.Drawing.Size(464, 20);
            this.tbxServiceName.TabIndex = 3;
            // 
            // lblServiceName
            // 
            this.lblServiceName.AutoSize = true;
            this.lblServiceName.Location = new System.Drawing.Point(10, 44);
            this.lblServiceName.Name = "lblServiceName";
            this.lblServiceName.Size = new System.Drawing.Size(75, 13);
            this.lblServiceName.TabIndex = 2;
            this.lblServiceName.Text = "Service &name:";
            // 
            // lblRunType
            // 
            this.lblRunType.AutoSize = true;
            this.lblRunType.Location = new System.Drawing.Point(10, 18);
            this.lblRunType.Name = "lblRunType";
            this.lblRunType.Size = new System.Drawing.Size(107, 13);
            this.lblRunType.TabIndex = 0;
            this.lblRunType.Text = "OpenHAB &started as:";
            // 
            // cbxRunType
            // 
            this.cbxRunType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxRunType.DisplayMember = "WTH_RUN_TYPE.RT_DESCRIPTION";
            this.cbxRunType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRunType.FormattingEnabled = true;
            this.cbxRunType.Location = new System.Drawing.Point(130, 15);
            this.cbxRunType.Name = "cbxRunType";
            this.cbxRunType.Size = new System.Drawing.Size(464, 21);
            this.cbxRunType.TabIndex = 1;
            this.cbxRunType.ValueMember = "WTH_RUN_TYPE.RUN_TYPE_ID";
            this.cbxRunType.SelectionChangeCommitted += new System.EventHandler(this.cbxRunType_SelectionChangeCommitted);
            // 
            // tbpBackup
            // 
            this.tbpBackup.Controls.Add(this.lblKeepLastConfigurationBackups);
            this.tbpBackup.Controls.Add(this.chkDeleteOldConfigurationBackups);
            this.tbpBackup.Controls.Add(this.nudKeepLastConfigurationBackups);
            this.tbpBackup.Controls.Add(this.lblKeepLastFullBackups);
            this.tbpBackup.Controls.Add(this.chkDeleteOldFullBackups);
            this.tbpBackup.Controls.Add(this.lblBackupManagement);
            this.tbpBackup.Controls.Add(this.nudKeepLastFullBackups);
            this.tbpBackup.Controls.Add(this.btnClearBackupLog);
            this.tbpBackup.Controls.Add(this.rtbBackupLog);
            this.tbpBackup.Controls.Add(this.lblBackupLog);
            this.tbpBackup.Controls.Add(this.btnBackup);
            this.tbpBackup.Controls.Add(this.lblBackupProgress);
            this.tbpBackup.Controls.Add(this.cbxBackupType);
            this.tbpBackup.Controls.Add(this.lblBackupType);
            this.tbpBackup.Controls.Add(this.pbrBackupProgress);
            this.tbpBackup.Controls.Add(this.btnBackupPath);
            this.tbpBackup.Controls.Add(this.tbxBackupPath);
            this.tbpBackup.Controls.Add(this.lblBackupPath);
            this.tbpBackup.Location = new System.Drawing.Point(4, 22);
            this.tbpBackup.Name = "tbpBackup";
            this.tbpBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tbpBackup.Size = new System.Drawing.Size(606, 380);
            this.tbpBackup.TabIndex = 1;
            this.tbpBackup.Text = "Backup";
            this.tbpBackup.UseVisualStyleBackColor = true;
            // 
            // lblKeepLastConfigurationBackups
            // 
            this.lblKeepLastConfigurationBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeepLastConfigurationBackups.AutoSize = true;
            this.lblKeepLastConfigurationBackups.Location = new System.Drawing.Point(480, 70);
            this.lblKeepLastConfigurationBackups.Name = "lblKeepLastConfigurationBackups";
            this.lblKeepLastConfigurationBackups.Size = new System.Drawing.Size(54, 13);
            this.lblKeepLastConfigurationBackups.TabIndex = 7;
            this.lblKeepLastConfigurationBackups.Text = "&Keep last:";
            // 
            // chkDeleteOldConfigurationBackups
            // 
            this.chkDeleteOldConfigurationBackups.AutoSize = true;
            this.chkDeleteOldConfigurationBackups.Location = new System.Drawing.Point(130, 69);
            this.chkDeleteOldConfigurationBackups.Name = "chkDeleteOldConfigurationBackups";
            this.chkDeleteOldConfigurationBackups.Size = new System.Drawing.Size(118, 17);
            this.chkDeleteOldConfigurationBackups.TabIndex = 6;
            this.chkDeleteOldConfigurationBackups.Text = "&Delete old backups";
            this.chkDeleteOldConfigurationBackups.UseVisualStyleBackColor = true;
            this.chkDeleteOldConfigurationBackups.CheckedChanged += new System.EventHandler(this.chkDeleteOldConfigurationBackups_CheckedChanged);
            // 
            // nudKeepLastConfigurationBackups
            // 
            this.nudKeepLastConfigurationBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudKeepLastConfigurationBackups.Location = new System.Drawing.Point(544, 67);
            this.nudKeepLastConfigurationBackups.Name = "nudKeepLastConfigurationBackups";
            this.nudKeepLastConfigurationBackups.Size = new System.Drawing.Size(50, 20);
            this.nudKeepLastConfigurationBackups.TabIndex = 8;
            this.nudKeepLastConfigurationBackups.ValueChanged += new System.EventHandler(this.nudKeepLastConfigurationBackups_ValueChanged);
            // 
            // lblKeepLastFullBackups
            // 
            this.lblKeepLastFullBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeepLastFullBackups.AutoSize = true;
            this.lblKeepLastFullBackups.Location = new System.Drawing.Point(480, 70);
            this.lblKeepLastFullBackups.Name = "lblKeepLastFullBackups";
            this.lblKeepLastFullBackups.Size = new System.Drawing.Size(54, 13);
            this.lblKeepLastFullBackups.TabIndex = 25;
            this.lblKeepLastFullBackups.Text = "Keep last:";
            // 
            // chkDeleteOldFullBackups
            // 
            this.chkDeleteOldFullBackups.AutoSize = true;
            this.chkDeleteOldFullBackups.Location = new System.Drawing.Point(130, 69);
            this.chkDeleteOldFullBackups.Name = "chkDeleteOldFullBackups";
            this.chkDeleteOldFullBackups.Size = new System.Drawing.Size(118, 17);
            this.chkDeleteOldFullBackups.TabIndex = 24;
            this.chkDeleteOldFullBackups.Text = "Delete old backups";
            this.chkDeleteOldFullBackups.UseVisualStyleBackColor = true;
            this.chkDeleteOldFullBackups.CheckedChanged += new System.EventHandler(this.cbxDeleteOldFullBackups_CheckedChanged);
            // 
            // lblBackupManagement
            // 
            this.lblBackupManagement.AutoSize = true;
            this.lblBackupManagement.Location = new System.Drawing.Point(10, 70);
            this.lblBackupManagement.Name = "lblBackupManagement";
            this.lblBackupManagement.Size = new System.Drawing.Size(111, 13);
            this.lblBackupManagement.TabIndex = 5;
            this.lblBackupManagement.Text = "Backup &management:";
            // 
            // nudKeepLastFullBackups
            // 
            this.nudKeepLastFullBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudKeepLastFullBackups.Location = new System.Drawing.Point(544, 67);
            this.nudKeepLastFullBackups.Name = "nudKeepLastFullBackups";
            this.nudKeepLastFullBackups.Size = new System.Drawing.Size(50, 20);
            this.nudKeepLastFullBackups.TabIndex = 22;
            this.nudKeepLastFullBackups.ValueChanged += new System.EventHandler(this.nudKeepLastFullBackups_ValueChanged);
            // 
            // btnClearBackupLog
            // 
            this.btnClearBackupLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearBackupLog.Location = new System.Drawing.Point(438, 342);
            this.btnClearBackupLog.Name = "btnClearBackupLog";
            this.btnClearBackupLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearBackupLog.TabIndex = 14;
            this.btnClearBackupLog.Text = "&Clear log";
            this.btnClearBackupLog.UseVisualStyleBackColor = true;
            this.btnClearBackupLog.Click += new System.EventHandler(this.btnClearBackupLog_Click);
            // 
            // rtbBackupLog
            // 
            this.rtbBackupLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbBackupLog.Location = new System.Drawing.Point(130, 119);
            this.rtbBackupLog.Name = "rtbBackupLog";
            this.rtbBackupLog.ReadOnly = true;
            this.rtbBackupLog.Size = new System.Drawing.Size(464, 217);
            this.rtbBackupLog.TabIndex = 12;
            this.rtbBackupLog.TabStop = false;
            this.rtbBackupLog.Text = "";
            this.rtbBackupLog.WordWrap = false;
            // 
            // lblBackupLog
            // 
            this.lblBackupLog.AutoSize = true;
            this.lblBackupLog.Location = new System.Drawing.Point(10, 122);
            this.lblBackupLog.Name = "lblBackupLog";
            this.lblBackupLog.Size = new System.Drawing.Size(64, 13);
            this.lblBackupLog.TabIndex = 11;
            this.lblBackupLog.Text = "Backup log:";
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackup.Location = new System.Drawing.Point(519, 342);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(75, 23);
            this.btnBackup.TabIndex = 13;
            this.btnBackup.Text = "&Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // lblBackupProgress
            // 
            this.lblBackupProgress.AutoSize = true;
            this.lblBackupProgress.Location = new System.Drawing.Point(10, 96);
            this.lblBackupProgress.Name = "lblBackupProgress";
            this.lblBackupProgress.Size = new System.Drawing.Size(90, 13);
            this.lblBackupProgress.TabIndex = 9;
            this.lblBackupProgress.Text = "Backup progress:";
            // 
            // cbxBackupType
            // 
            this.cbxBackupType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxBackupType.DisplayMember = "WTH_BACKUP_TYPE.BT_DESCRIPTION";
            this.cbxBackupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBackupType.FormattingEnabled = true;
            this.cbxBackupType.Location = new System.Drawing.Point(130, 15);
            this.cbxBackupType.Name = "cbxBackupType";
            this.cbxBackupType.Size = new System.Drawing.Size(464, 21);
            this.cbxBackupType.TabIndex = 1;
            this.cbxBackupType.ValueMember = "WTH_BACKUP_TYPE.BACKUP_TYPE_ID";
            this.cbxBackupType.SelectionChangeCommitted += new System.EventHandler(this.cbxBackupType_SelectionChangeCommitted);
            // 
            // lblBackupType
            // 
            this.lblBackupType.AutoSize = true;
            this.lblBackupType.Location = new System.Drawing.Point(10, 18);
            this.lblBackupType.Name = "lblBackupType";
            this.lblBackupType.Size = new System.Drawing.Size(70, 13);
            this.lblBackupType.TabIndex = 0;
            this.lblBackupType.Text = "Backup &type:";
            // 
            // pbrBackupProgress
            // 
            this.pbrBackupProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrBackupProgress.Location = new System.Drawing.Point(130, 93);
            this.pbrBackupProgress.Name = "pbrBackupProgress";
            this.pbrBackupProgress.Size = new System.Drawing.Size(464, 20);
            this.pbrBackupProgress.TabIndex = 10;
            // 
            // btnBackupPath
            // 
            this.btnBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackupPath.Location = new System.Drawing.Point(571, 39);
            this.btnBackupPath.Name = "btnBackupPath";
            this.btnBackupPath.Size = new System.Drawing.Size(23, 23);
            this.btnBackupPath.TabIndex = 4;
            this.btnBackupPath.Text = "...";
            this.btnBackupPath.UseVisualStyleBackColor = true;
            this.btnBackupPath.Click += new System.EventHandler(this.btnBackupPath_Click);
            // 
            // tbxBackupPath
            // 
            this.tbxBackupPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxBackupPath.Location = new System.Drawing.Point(130, 41);
            this.tbxBackupPath.Name = "tbxBackupPath";
            this.tbxBackupPath.Size = new System.Drawing.Size(435, 20);
            this.tbxBackupPath.TabIndex = 3;
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.Location = new System.Drawing.Point(10, 44);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(71, 13);
            this.lblBackupPath.TabIndex = 2;
            this.lblBackupPath.Text = "Backup &path:";
            // 
            // tbpRestore
            // 
            this.tbpRestore.Controls.Add(this.btnClearRestoreLog);
            this.tbpRestore.Controls.Add(this.rtbRestoreLog);
            this.tbpRestore.Controls.Add(this.lblRestoreLog);
            this.tbpRestore.Controls.Add(this.btnRestore);
            this.tbpRestore.Controls.Add(this.lblRestoreProgress);
            this.tbpRestore.Controls.Add(this.pbrRestoreProgress);
            this.tbpRestore.Controls.Add(this.btnRestoreBackupFile);
            this.tbpRestore.Controls.Add(this.tbxRestoreBackupFile);
            this.tbpRestore.Controls.Add(this.lblRestoreBackupFile);
            this.tbpRestore.Location = new System.Drawing.Point(4, 22);
            this.tbpRestore.Name = "tbpRestore";
            this.tbpRestore.Padding = new System.Windows.Forms.Padding(3);
            this.tbpRestore.Size = new System.Drawing.Size(606, 380);
            this.tbpRestore.TabIndex = 2;
            this.tbpRestore.Text = "Restore";
            this.tbpRestore.UseVisualStyleBackColor = true;
            // 
            // btnClearRestoreLog
            // 
            this.btnClearRestoreLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearRestoreLog.Location = new System.Drawing.Point(438, 342);
            this.btnClearRestoreLog.Name = "btnClearRestoreLog";
            this.btnClearRestoreLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearRestoreLog.TabIndex = 8;
            this.btnClearRestoreLog.Text = "&Clear log";
            this.btnClearRestoreLog.UseVisualStyleBackColor = true;
            this.btnClearRestoreLog.Click += new System.EventHandler(this.btnClearRestoreLog_Click);
            // 
            // rtbRestoreLog
            // 
            this.rtbRestoreLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbRestoreLog.Location = new System.Drawing.Point(130, 67);
            this.rtbRestoreLog.Name = "rtbRestoreLog";
            this.rtbRestoreLog.ReadOnly = true;
            this.rtbRestoreLog.Size = new System.Drawing.Size(464, 269);
            this.rtbRestoreLog.TabIndex = 6;
            this.rtbRestoreLog.Text = "";
            this.rtbRestoreLog.WordWrap = false;
            // 
            // lblRestoreLog
            // 
            this.lblRestoreLog.AutoSize = true;
            this.lblRestoreLog.Location = new System.Drawing.Point(10, 70);
            this.lblRestoreLog.Name = "lblRestoreLog";
            this.lblRestoreLog.Size = new System.Drawing.Size(64, 13);
            this.lblRestoreLog.TabIndex = 5;
            this.lblRestoreLog.Text = "Restore log:";
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Location = new System.Drawing.Point(519, 342);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "&Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // lblRestoreProgress
            // 
            this.lblRestoreProgress.AutoSize = true;
            this.lblRestoreProgress.Location = new System.Drawing.Point(10, 44);
            this.lblRestoreProgress.Name = "lblRestoreProgress";
            this.lblRestoreProgress.Size = new System.Drawing.Size(90, 13);
            this.lblRestoreProgress.TabIndex = 3;
            this.lblRestoreProgress.Text = "Restore progress:";
            // 
            // pbrRestoreProgress
            // 
            this.pbrRestoreProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrRestoreProgress.Location = new System.Drawing.Point(130, 41);
            this.pbrRestoreProgress.Name = "pbrRestoreProgress";
            this.pbrRestoreProgress.Size = new System.Drawing.Size(464, 20);
            this.pbrRestoreProgress.TabIndex = 4;
            // 
            // btnRestoreBackupFile
            // 
            this.btnRestoreBackupFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreBackupFile.Location = new System.Drawing.Point(571, 13);
            this.btnRestoreBackupFile.Name = "btnRestoreBackupFile";
            this.btnRestoreBackupFile.Size = new System.Drawing.Size(23, 23);
            this.btnRestoreBackupFile.TabIndex = 2;
            this.btnRestoreBackupFile.Text = "...";
            this.btnRestoreBackupFile.UseVisualStyleBackColor = true;
            this.btnRestoreBackupFile.Click += new System.EventHandler(this.btnRestoreBackupFile_Click);
            // 
            // tbxRestoreBackupFile
            // 
            this.tbxRestoreBackupFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxRestoreBackupFile.Location = new System.Drawing.Point(130, 15);
            this.tbxRestoreBackupFile.Name = "tbxRestoreBackupFile";
            this.tbxRestoreBackupFile.Size = new System.Drawing.Size(435, 20);
            this.tbxRestoreBackupFile.TabIndex = 1;
            // 
            // lblRestoreBackupFile
            // 
            this.lblRestoreBackupFile.AutoSize = true;
            this.lblRestoreBackupFile.Location = new System.Drawing.Point(10, 18);
            this.lblRestoreBackupFile.Name = "lblRestoreBackupFile";
            this.lblRestoreBackupFile.Size = new System.Drawing.Size(102, 13);
            this.lblRestoreBackupFile.TabIndex = 0;
            this.lblRestoreBackupFile.Text = "Restore backup &file:";
            // 
            // tbpUpdate
            // 
            this.tbpUpdate.Controls.Add(this.tbxUpdateURL);
            this.tbpUpdate.Controls.Add(this.lblUpdateURL);
            this.tbpUpdate.Controls.Add(this.cbxUpdateType);
            this.tbpUpdate.Controls.Add(this.lblUpdateType);
            this.tbpUpdate.Controls.Add(this.btnClearUpdateLog);
            this.tbpUpdate.Controls.Add(this.btnUpdate);
            this.tbpUpdate.Controls.Add(this.rtbUpdateLog);
            this.tbpUpdate.Controls.Add(this.lblUpdateLog);
            this.tbpUpdate.Controls.Add(this.lblUpdateProgress);
            this.tbpUpdate.Controls.Add(this.pbrUpdateProgress);
            this.tbpUpdate.Controls.Add(this.cbxBeforeUpdating);
            this.tbpUpdate.Controls.Add(this.lblBeforeUpdating);
            this.tbpUpdate.Controls.Add(this.btnUpdateFile);
            this.tbpUpdate.Controls.Add(this.tbxUpdateFile);
            this.tbpUpdate.Controls.Add(this.lblUpdateFile);
            this.tbpUpdate.Controls.Add(this.btnUpdatePath);
            this.tbpUpdate.Controls.Add(this.tbxUpdatePath);
            this.tbpUpdate.Controls.Add(this.lblUpdatePath);
            this.tbpUpdate.Location = new System.Drawing.Point(4, 22);
            this.tbpUpdate.Name = "tbpUpdate";
            this.tbpUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tbpUpdate.Size = new System.Drawing.Size(606, 380);
            this.tbpUpdate.TabIndex = 3;
            this.tbpUpdate.Text = "Update";
            this.tbpUpdate.UseVisualStyleBackColor = true;
            // 
            // tbxUpdateURL
            // 
            this.tbxUpdateURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUpdateURL.Location = new System.Drawing.Point(130, 67);
            this.tbxUpdateURL.Name = "tbxUpdateURL";
            this.tbxUpdateURL.Size = new System.Drawing.Size(464, 20);
            this.tbxUpdateURL.TabIndex = 17;
            // 
            // lblUpdateURL
            // 
            this.lblUpdateURL.AutoSize = true;
            this.lblUpdateURL.Location = new System.Drawing.Point(10, 70);
            this.lblUpdateURL.Name = "lblUpdateURL";
            this.lblUpdateURL.Size = new System.Drawing.Size(70, 13);
            this.lblUpdateURL.TabIndex = 16;
            this.lblUpdateURL.Text = "Update &URL:";
            // 
            // cbxUpdateType
            // 
            this.cbxUpdateType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxUpdateType.DisplayMember = "WTH_UPDATE_TYPE.UT_DESCRIPTION";
            this.cbxUpdateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUpdateType.FormattingEnabled = true;
            this.cbxUpdateType.Location = new System.Drawing.Point(130, 41);
            this.cbxUpdateType.Name = "cbxUpdateType";
            this.cbxUpdateType.Size = new System.Drawing.Size(464, 21);
            this.cbxUpdateType.TabIndex = 4;
            this.cbxUpdateType.ValueMember = "WTH_UPDATE_TYPE.UPDATE_TYPE_ID";
            this.cbxUpdateType.SelectionChangeCommitted += new System.EventHandler(this.cbxUpdateType_SelectionChangeCommitted);
            // 
            // lblUpdateType
            // 
            this.lblUpdateType.AutoSize = true;
            this.lblUpdateType.Location = new System.Drawing.Point(10, 44);
            this.lblUpdateType.Name = "lblUpdateType";
            this.lblUpdateType.Size = new System.Drawing.Size(68, 13);
            this.lblUpdateType.TabIndex = 3;
            this.lblUpdateType.Text = "Update &type:";
            // 
            // btnClearUpdateLog
            // 
            this.btnClearUpdateLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearUpdateLog.Location = new System.Drawing.Point(438, 342);
            this.btnClearUpdateLog.Name = "btnClearUpdateLog";
            this.btnClearUpdateLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearUpdateLog.TabIndex = 15;
            this.btnClearUpdateLog.Text = "&Clear log";
            this.btnClearUpdateLog.UseVisualStyleBackColor = true;
            this.btnClearUpdateLog.Click += new System.EventHandler(this.btnClearUpdateLog_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(519, 342);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // rtbUpdateLog
            // 
            this.rtbUpdateLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbUpdateLog.Location = new System.Drawing.Point(130, 145);
            this.rtbUpdateLog.Name = "rtbUpdateLog";
            this.rtbUpdateLog.ReadOnly = true;
            this.rtbUpdateLog.Size = new System.Drawing.Size(464, 192);
            this.rtbUpdateLog.TabIndex = 13;
            this.rtbUpdateLog.TabStop = false;
            this.rtbUpdateLog.Text = "";
            this.rtbUpdateLog.WordWrap = false;
            // 
            // lblUpdateLog
            // 
            this.lblUpdateLog.AutoSize = true;
            this.lblUpdateLog.Location = new System.Drawing.Point(10, 148);
            this.lblUpdateLog.Name = "lblUpdateLog";
            this.lblUpdateLog.Size = new System.Drawing.Size(62, 13);
            this.lblUpdateLog.TabIndex = 12;
            this.lblUpdateLog.Text = "Update log:";
            // 
            // lblUpdateProgress
            // 
            this.lblUpdateProgress.AutoSize = true;
            this.lblUpdateProgress.Location = new System.Drawing.Point(10, 122);
            this.lblUpdateProgress.Name = "lblUpdateProgress";
            this.lblUpdateProgress.Size = new System.Drawing.Size(88, 13);
            this.lblUpdateProgress.TabIndex = 10;
            this.lblUpdateProgress.Text = "Update progress:";
            // 
            // pbrUpdateProgress
            // 
            this.pbrUpdateProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbrUpdateProgress.Location = new System.Drawing.Point(130, 119);
            this.pbrUpdateProgress.Name = "pbrUpdateProgress";
            this.pbrUpdateProgress.Size = new System.Drawing.Size(464, 20);
            this.pbrUpdateProgress.TabIndex = 11;
            // 
            // cbxBeforeUpdating
            // 
            this.cbxBeforeUpdating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxBeforeUpdating.DisplayMember = "WTH_BEFORE_UPDATING.BU_DESCRIPTION";
            this.cbxBeforeUpdating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBeforeUpdating.FormattingEnabled = true;
            this.cbxBeforeUpdating.Location = new System.Drawing.Point(130, 93);
            this.cbxBeforeUpdating.Name = "cbxBeforeUpdating";
            this.cbxBeforeUpdating.Size = new System.Drawing.Size(464, 21);
            this.cbxBeforeUpdating.TabIndex = 9;
            this.cbxBeforeUpdating.ValueMember = "WTH_BEFORE_UPDATING.BEFORE_UPDATING_ID";
            this.cbxBeforeUpdating.SelectionChangeCommitted += new System.EventHandler(this.cbxBeforeUpdating_SelectionChangeCommitted);
            // 
            // lblBeforeUpdating
            // 
            this.lblBeforeUpdating.AutoSize = true;
            this.lblBeforeUpdating.Location = new System.Drawing.Point(10, 96);
            this.lblBeforeUpdating.Name = "lblBeforeUpdating";
            this.lblBeforeUpdating.Size = new System.Drawing.Size(85, 13);
            this.lblBeforeUpdating.TabIndex = 8;
            this.lblBeforeUpdating.Text = "&Before updating:";
            // 
            // btnUpdateFile
            // 
            this.btnUpdateFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateFile.Location = new System.Drawing.Point(571, 65);
            this.btnUpdateFile.Name = "btnUpdateFile";
            this.btnUpdateFile.Size = new System.Drawing.Size(23, 23);
            this.btnUpdateFile.TabIndex = 7;
            this.btnUpdateFile.Text = "...";
            this.btnUpdateFile.UseVisualStyleBackColor = true;
            this.btnUpdateFile.Click += new System.EventHandler(this.btnUpdateFile_Click);
            // 
            // tbxUpdateFile
            // 
            this.tbxUpdateFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUpdateFile.Location = new System.Drawing.Point(130, 67);
            this.tbxUpdateFile.Name = "tbxUpdateFile";
            this.tbxUpdateFile.Size = new System.Drawing.Size(435, 20);
            this.tbxUpdateFile.TabIndex = 6;
            // 
            // lblUpdateFile
            // 
            this.lblUpdateFile.AutoSize = true;
            this.lblUpdateFile.Location = new System.Drawing.Point(10, 70);
            this.lblUpdateFile.Name = "lblUpdateFile";
            this.lblUpdateFile.Size = new System.Drawing.Size(61, 13);
            this.lblUpdateFile.TabIndex = 5;
            this.lblUpdateFile.Text = "Update &file:";
            // 
            // btnUpdatePath
            // 
            this.btnUpdatePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePath.Location = new System.Drawing.Point(571, 13);
            this.btnUpdatePath.Name = "btnUpdatePath";
            this.btnUpdatePath.Size = new System.Drawing.Size(23, 23);
            this.btnUpdatePath.TabIndex = 2;
            this.btnUpdatePath.Text = "...";
            this.btnUpdatePath.UseVisualStyleBackColor = true;
            this.btnUpdatePath.Click += new System.EventHandler(this.btnUpdatePath_Click);
            // 
            // tbxUpdatePath
            // 
            this.tbxUpdatePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxUpdatePath.Location = new System.Drawing.Point(130, 15);
            this.tbxUpdatePath.Name = "tbxUpdatePath";
            this.tbxUpdatePath.Size = new System.Drawing.Size(435, 20);
            this.tbxUpdatePath.TabIndex = 1;
            // 
            // lblUpdatePath
            // 
            this.lblUpdatePath.AutoSize = true;
            this.lblUpdatePath.Location = new System.Drawing.Point(10, 18);
            this.lblUpdatePath.Name = "lblUpdatePath";
            this.lblUpdatePath.Size = new System.Drawing.Size(69, 13);
            this.lblUpdatePath.TabIndex = 0;
            this.lblUpdatePath.Text = "Update &path:";
            // 
            // WTHFrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.tclMain);
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "WTHFrmMain";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WinToolHAB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WTHFrmMain_FormClosing);
            this.Load += new System.EventHandler(this.WTHFrmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tclMain.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            this.tbpGeneral.PerformLayout();
            this.tbpBackup.ResumeLayout(false);
            this.tbpBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepLastConfigurationBackups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeepLastFullBackups)).EndInit();
            this.tbpRestore.ResumeLayout(false);
            this.tbpRestore.PerformLayout();
            this.tbpUpdate.ResumeLayout(false);
            this.tbpUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tclMain;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpBackup;
        private System.Windows.Forms.Label lblRunType;
        private System.Windows.Forms.ComboBox cbxRunType;
        private System.Windows.Forms.TextBox tbxServiceName;
        private System.Windows.Forms.Label lblServiceName;
        private System.Windows.Forms.Button btnOpenHABPath;
        private System.Windows.Forms.TextBox tbxOpenHABPath;
        private System.Windows.Forms.Label lblOpenHABPath;
        private System.Windows.Forms.Button btnBackupPath;
        private System.Windows.Forms.TextBox tbxBackupPath;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.ProgressBar pbrBackupProgress;
        private System.Windows.Forms.ComboBox cbxBackupType;
        private System.Windows.Forms.Label lblBackupType;
        private System.Windows.Forms.Label lblBackupProgress;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label lblBackupLog;
        private System.Windows.Forms.RichTextBox rtbBackupLog;
        private System.Windows.Forms.Button btnClearBackupLog;
        private System.Windows.Forms.TabPage tbpRestore;
        private System.Windows.Forms.Button btnRestoreBackupFile;
        private System.Windows.Forms.TextBox tbxRestoreBackupFile;
        private System.Windows.Forms.Label lblRestoreBackupFile;
        private System.Windows.Forms.Button btnClearRestoreLog;
        private System.Windows.Forms.RichTextBox rtbRestoreLog;
        private System.Windows.Forms.Label lblRestoreLog;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label lblRestoreProgress;
        private System.Windows.Forms.ProgressBar pbrRestoreProgress;
        private System.Windows.Forms.Label lblKeepLastFullBackups;
        private System.Windows.Forms.CheckBox chkDeleteOldFullBackups;
        private System.Windows.Forms.Label lblBackupManagement;
        private System.Windows.Forms.NumericUpDown nudKeepLastFullBackups;
        private System.Windows.Forms.Label lblKeepLastConfigurationBackups;
        private System.Windows.Forms.CheckBox chkDeleteOldConfigurationBackups;
        private System.Windows.Forms.NumericUpDown nudKeepLastConfigurationBackups;
        private System.Windows.Forms.TabPage tbpUpdate;
        private System.Windows.Forms.Button btnUpdatePath;
        private System.Windows.Forms.TextBox tbxUpdatePath;
        private System.Windows.Forms.Label lblUpdatePath;
        private System.Windows.Forms.Button btnUpdateFile;
        private System.Windows.Forms.TextBox tbxUpdateFile;
        private System.Windows.Forms.Label lblUpdateFile;
        private System.Windows.Forms.ComboBox cbxBeforeUpdating;
        private System.Windows.Forms.Label lblBeforeUpdating;
        private System.Windows.Forms.Label lblUpdateProgress;
        private System.Windows.Forms.ProgressBar pbrUpdateProgress;
        private System.Windows.Forms.Button btnClearUpdateLog;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RichTextBox rtbUpdateLog;
        private System.Windows.Forms.Label lblUpdateLog;
        private System.Windows.Forms.ComboBox cbxUpdateType;
        private System.Windows.Forms.Label lblUpdateType;
        private System.Windows.Forms.Label lblUpdateURL;
        private System.Windows.Forms.TextBox tbxUpdateURL;

        public System.Windows.Forms.ComboBox RunType
        {
            get
            {
                return this.cbxRunType;
            }
        }

        public System.Windows.Forms.TextBox ServiceName
        {
            get
            {
                return this.tbxServiceName;
            }
        }

        public System.Windows.Forms.TextBox OpenHABPath
        {
            get
            {
                return this.tbxOpenHABPath;
            }
        }

        public System.Windows.Forms.ComboBox BackupType
        {
            get
            {
                return this.cbxBackupType;
            }
        }

        public System.Windows.Forms.TextBox BackupPath
        {
            get
            {
                return this.tbxBackupPath;
            }
        }

        public System.Windows.Forms.CheckBox DeleteOldFullBackups
        {
            get
            {
                return this.chkDeleteOldFullBackups;
            }
        }

        public System.Windows.Forms.NumericUpDown KeepLastFullBackups
        {
            get
            {
                return this.nudKeepLastFullBackups;
            }
        }

        public System.Windows.Forms.CheckBox DeleteOldConfigurationBackups
        {
            get
            {
                return this.chkDeleteOldConfigurationBackups;
            }
        }

        public System.Windows.Forms.NumericUpDown KeepLastConfigurationBackups
        {
            get
            {
                return this.nudKeepLastConfigurationBackups;
            }
        }

        public System.Windows.Forms.ProgressBar BackupProgress
        {
            get
            {
                return this.pbrBackupProgress;
            }
        }      
        
        public System.Windows.Forms.RichTextBox BackupLog
        {
            get
            {
                return this.rtbBackupLog;
            }
        }

        public System.Windows.Forms.Button Backup
        {
            get
            {
                return this.btnBackup;
            }
        }

        public System.Windows.Forms.Button ClearBackupLog
        {
            get
            {
                return this.btnClearBackupLog;
            }
        }

        public System.Windows.Forms.TextBox RestoreBackupFile
        {
            get
            {
                return this.tbxRestoreBackupFile;
            }
        }

        public System.Windows.Forms.ProgressBar RestoreProgress
        {
            get
            {
                return this.pbrRestoreProgress;
            }
        }

        public System.Windows.Forms.RichTextBox RestoreLog
        {
            get
            {
                return this.rtbRestoreLog;
            }
        }

        public System.Windows.Forms.Button Restore
        {
            get
            {
                return this.btnRestore;
            }
        }

        public System.Windows.Forms.Button ClearRestoreLog
        {
            get
            {
                return this.btnClearRestoreLog;
            }
        }

        public System.Windows.Forms.TextBox UpdatePath
        {
            get
            {
                return this.tbxUpdatePath;
            }
        }

        public System.Windows.Forms.ComboBox UpdateType
        {
            get
            {
                return this.cbxUpdateType;
            }
        }

        public System.Windows.Forms.TextBox UpdateURL
        {
            get
            {
                return this.tbxUpdateURL;
            }
        }

        public System.Windows.Forms.TextBox UpdateFile
        {
            get
            {
                return this.tbxUpdateFile;
            }            
        }

        public System.Windows.Forms.ComboBox BeforeUpdating
        {
            get
            {
                return this.cbxBeforeUpdating;
            }
        }

        public System.Windows.Forms.ProgressBar UpdateProgress
        {
            get
            {
                return this.pbrUpdateProgress;
            }
        }

        public System.Windows.Forms.RichTextBox UpdateLog
        {
            get
            {
                return this.rtbUpdateLog;
            }
        }

        public System.Windows.Forms.Button PerformUpdate
        {
            get
            {
                return this.btnUpdate;
            }
        }

        public System.Windows.Forms.Button ClearUpdateLog
        {
            get
            {
                return this.btnClearUpdateLog;
            }
        }
    }
}

