using System;
using System.Linq;
using System.Windows.Forms;
using System.ServiceProcess;
using System.IO;
using System.Net;

namespace WinToolHAB.FrmMain
{
    public partial class WTHFrmMain : Form
    {
        DMCore.WTHDMCore CoreDataModule;        

        public WTHFrmMain()
        {
            InitializeComponent();

            CoreDataModule = new DMCore.WTHDMCore(this);            

            cbxRunType.DataSource = CoreDataModule.RunType;
            cbxBackupType.DataSource = CoreDataModule.BackupType;
            cbxUpdateType.DataSource = CoreDataModule.UpdateType;
            cbxBeforeUpdating.DataSource = CoreDataModule.BeforeUpdating;

            CoreDataModule.GetRegistrySettings();
        }

        private void WTHFrmMain_Load(object sender, EventArgs e)
        {
            pbrBackupProgress.Minimum = 0;
            pbrBackupProgress.Maximum = 100;
            pbrBackupProgress.Step = 1;
            pbrBackupProgress.Value = 0;

            pbrRestoreProgress.Minimum = 0;
            pbrRestoreProgress.Maximum = 100;
            pbrRestoreProgress.Step = 1;
            pbrRestoreProgress.Value = 0;

            pbrUpdateProgress.Minimum = 0;
            pbrUpdateProgress.Maximum = 100;
            pbrUpdateProgress.Step = 1;
            pbrUpdateProgress.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(10000);

            int Vrijednost;

            Int32.TryParse(cbxRunType.SelectedValue.ToString(), out Vrijednost);

            MessageBox.Show(Vrijednost.ToString());
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbxRunType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int SelectedRunTypeValue;
            Int32.TryParse(cbxRunType.SelectedValue.ToString(), out SelectedRunTypeValue);

            if (RunTypeValue != SelectedRunTypeValue)
                RunTypeValue = SelectedRunTypeValue;
        }

        private void cbxBackupType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int SelectedBackupTypeValue;
            Int32.TryParse(cbxBackupType.SelectedValue.ToString(), out SelectedBackupTypeValue);

            if (BackupTypeValue != SelectedBackupTypeValue)
                BackupTypeValue = SelectedBackupTypeValue;
        }

        private void btnOpenHABPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog OpenHABPath = new FolderBrowserDialog();

            DialogResult OpenHABPathResult = OpenHABPath.ShowDialog();

            if (OpenHABPathResult == DialogResult.OK && !string.IsNullOrWhiteSpace(OpenHABPath.SelectedPath))
                tbxOpenHABPath.Text = OpenHABPath.SelectedPath;
        }

        private void btnBackupPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog BackupPath = new FolderBrowserDialog();

            DialogResult BackupPathResult = BackupPath.ShowDialog();

            if (BackupPathResult == DialogResult.OK && !string.IsNullOrWhiteSpace(BackupPath.SelectedPath))
                tbxBackupPath.Text = BackupPath.SelectedPath;
        }

        private void cbxDeleteOldFullBackups_CheckedChanged(object sender, EventArgs e)
        {
            if (DeleteOldFullBackupsValue != chkDeleteOldFullBackups.Checked)
                DeleteOldFullBackupsValue = chkDeleteOldFullBackups.Checked;
        }

        private void chkDeleteOldConfigurationBackups_CheckedChanged(object sender, EventArgs e)
        {
            if (DeleteOldConfigurationBackupsValue != chkDeleteOldConfigurationBackups.Checked)
                DeleteOldConfigurationBackupsValue = chkDeleteOldConfigurationBackups.Checked;
        }

        private void nudKeepLastFullBackups_ValueChanged(object sender, EventArgs e)
        {
            if (KeepLastFullBackupsValue != Convert.ToInt16(nudKeepLastFullBackups.Value))
                KeepLastFullBackupsValue = Convert.ToInt16(nudKeepLastFullBackups.Value);
        }

        private void nudKeepLastConfigurationBackups_ValueChanged(object sender, EventArgs e)
        {
            if (KeepLastConfigurationBackupsValue != Convert.ToInt16(nudKeepLastConfigurationBackups.Value))
                KeepLastConfigurationBackupsValue = Convert.ToInt16(nudKeepLastConfigurationBackups.Value);
        }

        private void btnClearBackupLog_Click(object sender, EventArgs e)
        {
            ClearBackupLogText();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            CoreDataModule.OperationTypeId = DMCore.OperationType.Backup;

            if (!ValidateSettings())
                return;

            ClearBackupLogText();
            CreateBackup();
        }

        private void btnRestoreBackupFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog BackupFile = new OpenFileDialog();

            BackupFile.Title = "Select backup file to restore";
            BackupFile.DefaultExt = "zip";
            BackupFile.Filter = "Zip archives (*.zip)|*.zip|All files (*.*)|*.*";
            BackupFile.FilterIndex = 1;
            BackupFile.CheckPathExists = true;
            BackupFile.CheckFileExists = true;
            BackupFile.RestoreDirectory = true;

            if (!string.IsNullOrEmpty(tbxBackupPath.Text.Trim()) && Directory.Exists(tbxBackupPath.Text.Trim()))
                BackupFile.InitialDirectory = tbxBackupPath.Text.Trim();
            else
                BackupFile.InitialDirectory = @"C:\";

            DialogResult BackupFileResult = BackupFile.ShowDialog();

            if (BackupFileResult == DialogResult.OK && !string.IsNullOrEmpty(BackupFile.FileName))
                tbxRestoreBackupFile.Text = BackupFile.FileName;
        }

        private void btnClearRestoreLog_Click(object sender, EventArgs e)
        {
            ClearRestoreLogText();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            CoreDataModule.OperationTypeId = DMCore.OperationType.Restore;

            if (!ValidateSettings())
                return;

            ClearRestoreLogText();
            RestoreBackup();
        }

        private void btnUpdatePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog UpdatePath = new FolderBrowserDialog();

            DialogResult UpdatePathResult = UpdatePath.ShowDialog();

            if (UpdatePathResult == DialogResult.OK && !string.IsNullOrWhiteSpace(UpdatePath.SelectedPath))
                tbxUpdatePath.Text = UpdatePath.SelectedPath;
        }

        private void cbxUpdateType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int SelectedUpdateTypeValue;
            Int32.TryParse(cbxUpdateType.SelectedValue.ToString(), out SelectedUpdateTypeValue);

            if (UpdateTypeValue != SelectedUpdateTypeValue)
                UpdateTypeValue = SelectedUpdateTypeValue;
        }

        private void btnUpdateFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog UpdateFile = new OpenFileDialog();

            UpdateFile.Title = "Select update file";
            UpdateFile.DefaultExt = "zip";
            UpdateFile.Filter = "Zip archives (*.zip)|*.zip|All files (*.*)|*.*";
            UpdateFile.FilterIndex = 1;
            UpdateFile.CheckPathExists = true;
            UpdateFile.CheckFileExists = true;
            UpdateFile.RestoreDirectory = true;

            if (!string.IsNullOrEmpty(tbxUpdatePath.Text.Trim()) && Directory.Exists(tbxUpdatePath.Text.Trim()))
                UpdateFile.InitialDirectory = tbxUpdatePath.Text.Trim();
            else
                UpdateFile.InitialDirectory = @"C:\";

            DialogResult UpdateFileResult = UpdateFile.ShowDialog();

            if (UpdateFileResult == DialogResult.OK && !string.IsNullOrEmpty(UpdateFile.FileName))
                tbxUpdateFile.Text = UpdateFile.FileName;
        }

        private void cbxBeforeUpdating_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int SelectedBeforeUpdatingValue;
            Int32.TryParse(cbxBeforeUpdating.SelectedValue.ToString(), out SelectedBeforeUpdatingValue);

            if (BeforeUpdatingValue != SelectedBeforeUpdatingValue)
                BeforeUpdatingValue = SelectedBeforeUpdatingValue;
        }

        private void btnClearUpdateLog_Click(object sender, EventArgs e)
        {
            ClearUpdateLogText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CoreDataModule.OperationTypeId = DMCore.OperationType.Update;

            if (!ValidateSettings())
                return;

            ClearUpdateLogText();
            PerformOpenHABUpdate();
        }

        private void WTHFrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CoreDataModule.SaveRegistrySettings();
        }

        private void CreateBackup()
        {
            Application.UseWaitCursor = true;
            btnBackup.Enabled = false;
            btnClearBackupLog.Enabled = false;

            if (rtbBackupLog.CanFocus)
                rtbBackupLog.Focus();

            if (BackupTypeValue == 1)
                CoreDataModule.CompressFullBackup.RunWorkerAsync();
            else
                CoreDataModule.CompressConfigurationBackup.RunWorkerAsync();
        }

        private void ClearBackupLogText()
        {
            CoreDataModule.TotalNumberOfItems = 0;
            CoreDataModule.CurrentItemNumber = 0;
            pbrBackupProgress.Value = 0;
            rtbBackupLog.Clear();
        }

        private void RestoreBackup()
        {
            if (CoreDataModule.OpenHABRunningAsApplication())
            {
                if (MessageBox.Show("You need to shut down all OpenHAB instances before restoring backup.", "OpenHAB is running", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                    RestoreBackup();
            }
            else
            {
                if (MessageBox.Show("Restoring backup will replace all existing files with files contained in a backup. Are you sure you want to continue restoring backup?", "Restore backup?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.UseWaitCursor = true;
                    btnRestore.Enabled = false;
                    btnClearRestoreLog.Enabled = false;

                    if (rtbRestoreLog.CanFocus)
                        rtbRestoreLog.Focus();

                    CoreDataModule.ExtractBackup.RunWorkerAsync();
                }
            }
        }

        private void ClearRestoreLogText()
        {
            CoreDataModule.TotalNumberOfItems = 0;
            CoreDataModule.CurrentItemNumber = 0;
            pbrRestoreProgress.Value = 0;
            rtbRestoreLog.Clear();
        }

        private void PerformOpenHABUpdate()
        {
            if (CoreDataModule.OpenHABRunningAsApplication())
            {
                if (MessageBox.Show("You need to shut down all OpenHAB instances before updating OpenHAB.", "OpenHAB is running", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                    PerformOpenHABUpdate();
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to continue updating OpenHAB?", "Update OpenHAB?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.UseWaitCursor = true;
                    btnUpdate.Enabled = false;
                    btnClearUpdateLog.Enabled = false;

                    if (rtbUpdateLog.CanFocus)
                        rtbUpdateLog.Focus();

                    CoreDataModule.PerformOpenHABUpdate.RunWorkerAsync();
                }
            }
        }

        private void ClearUpdateLogText()
        {
            CoreDataModule.TotalNumberOfItems = 0;
            CoreDataModule.CurrentItemNumber = 0;
            pbrUpdateProgress.Value = 0;
            rtbUpdateLog.Clear();
        }

        private bool ValidateSettings()
        {
            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Restore || CoreDataModule.OperationTypeId == DMCore.OperationType.Update) && (RunTypeValue == 1) && (tbxServiceName.Text.Trim() == ""))
            {
                MessageBox.Show("Service name field is empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpGeneral;

                if (tbxServiceName.CanFocus)
                    tbxServiceName.Focus();

                return false;
            }

            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Restore || CoreDataModule.OperationTypeId == DMCore.OperationType.Update) && (RunTypeValue == 1))
            {
                ServiceController WindowsServiceControler = ServiceController.GetServices().FirstOrDefault(OpenHABService => OpenHABService.ServiceName == tbxServiceName.Text.Trim());

                if (WindowsServiceControler == null)
                {
                    MessageBox.Show("Service name field refers to a service that does not exist (" + tbxServiceName.Text.Trim() + ")", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tclMain.SelectedTab = tbpGeneral;

                    if (tbxServiceName.CanFocus)
                        tbxServiceName.Focus();

                    return false;
                }
            }

            if (tbxOpenHABPath.Text.Trim() == "")
            {
                MessageBox.Show("OpenHAB path field is empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpGeneral;

                if (tbxOpenHABPath.CanFocus)
                    tbxOpenHABPath.Focus();

                return false;
            }

            if (!Directory.Exists(tbxOpenHABPath.Text.Trim()))
            {
                MessageBox.Show("OpenHAB path field refers to a folder that does not exist (" + tbxOpenHABPath.Text.Trim() + ")", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpGeneral;

                if (tbxOpenHABPath.CanFocus)
                    tbxOpenHABPath.Focus();

                return false;
            }

            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Backup || CoreDataModule.OperationTypeId == DMCore.OperationType.Restore) && (tbxBackupPath.Text.Trim() == ""))
            {
                MessageBox.Show("Backup path field is empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpBackup;

                if (tbxBackupPath.CanFocus)
                    tbxBackupPath.Focus();

                return false;
            }

            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Backup || CoreDataModule.OperationTypeId == DMCore.OperationType.Restore) && (!Directory.Exists(tbxBackupPath.Text.Trim())))
            {
                MessageBox.Show("Backup path field refers to a folder that does not exist (" + tbxOpenHABPath.Text.Trim() + ")", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpBackup;

                if (tbxBackupPath.CanFocus)
                    tbxBackupPath.Focus();

                return false;
            }

            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Restore) && (!File.Exists(tbxRestoreBackupFile.Text.Trim())))
            {
                MessageBox.Show("Restore backup file field refers to a file that does not exist (" + tbxRestoreBackupFile.Text.Trim() + ")", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpRestore;

                if (tbxRestoreBackupFile.CanFocus)
                    tbxRestoreBackupFile.Focus();

                return false;
            }

            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Update) && (tbxUpdatePath.Text.Trim() == ""))
            {
                MessageBox.Show("Update path field is empty", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpUpdate;

                if (tbxUpdatePath.CanFocus)
                    tbxUpdatePath.Focus();

                return false;
            }

            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Update) && (!Directory.Exists(tbxUpdatePath.Text.Trim())))
            {
                MessageBox.Show("Update path field refers to a folder that does not exist (" + tbxUpdatePath.Text.Trim() + ")", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpUpdate;

                if (tbxUpdatePath.CanFocus)
                    tbxUpdatePath.Focus();

                return false;
            }

            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Update) && (UpdateTypeValue == 1) && (tbxUpdateURL.Text.Trim().Substring(tbxUpdateURL.Text.Trim().Length - 4, 4) != ".zip"))
            {
                MessageBox.Show("Update URL field does not refer to a file or refers to an unsupported file format (" + tbxUpdateURL.Text.Trim() + ")", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpUpdate;

                if (tbxUpdateURL.CanFocus)
                    tbxUpdateURL.Focus();

                return false;
            }

            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Update) && (UpdateTypeValue == 1))
            {
                bool UpdateFileExists = false;

                HttpWebResponse UpdateFileExistsResponse = null;
                var UpdateFileExistsRequest = (HttpWebRequest)WebRequest.Create(tbxUpdateURL.Text.Trim());

                UpdateFileExistsRequest.Method = "HEAD";
                UpdateFileExistsRequest.Timeout = 5000;
                UpdateFileExistsRequest.AllowAutoRedirect = false;

                try
                {
                    UpdateFileExistsResponse = (HttpWebResponse)UpdateFileExistsRequest.GetResponse();
                    UpdateFileExists = (UpdateFileExistsResponse.StatusCode == HttpStatusCode.OK);
                }
                catch
                {
                    UpdateFileExists = false;
                }
                finally
                {
                    if (UpdateFileExistsResponse != null)
                        UpdateFileExistsResponse.Close();
                }

                if (!UpdateFileExists)
                {
                    MessageBox.Show("Update URL field refers to a file that does not exist (" + tbxUpdateURL.Text.Trim() + ")", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tclMain.SelectedTab = tbpUpdate;

                    if (tbxUpdateURL.CanFocus)
                        tbxUpdateURL.Focus();

                    return false;
                }
            }

            if ((CoreDataModule.OperationTypeId == DMCore.OperationType.Update) && (UpdateTypeValue == 2) && (!File.Exists(tbxUpdateFile.Text.Trim())))
            {
                MessageBox.Show("Update file field refers to a file that does not exist (" + tbxUpdateFile.Text.Trim() + ")", "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tclMain.SelectedTab = tbpUpdate;

                if (tbxUpdateFile.CanFocus)
                    tbxUpdateFile.Focus();

                return false;
            }

            return true;
        }

        private int runTypeValue;
        public int RunTypeValue
        {
            get
            {
                return this.runTypeValue;
            }
            set
            {
                runTypeValue = value;

                if (runTypeValue == 2)
                {
                    tbxServiceName.Enabled = false;
                    tbxServiceName.Clear();
                }
                else
                {
                    tbxServiceName.Enabled = true;
                }                
            }
        }

        private int backupTypeValue;
        public int BackupTypeValue
        {
            get
            {
                return this.backupTypeValue;
            }

            set
            {
                backupTypeValue = value;

                chkDeleteOldFullBackups.Visible = (backupTypeValue == 1);
                nudKeepLastFullBackups.Visible = (backupTypeValue == 1);

                chkDeleteOldConfigurationBackups.Visible = (backupTypeValue != 1);
                nudKeepLastConfigurationBackups.Visible = (backupTypeValue != 1);
            }
        }

        private bool deleteOldFullBackupsValue;
        public bool DeleteOldFullBackupsValue
        {
            get
            {
                return this.deleteOldFullBackupsValue;
            }
            set
            {
                deleteOldFullBackupsValue = value;

                if (deleteOldFullBackupsValue)
                    nudKeepLastFullBackups.Enabled = true;
                else
                    nudKeepLastFullBackups.Enabled = false;
            }
        }

        public int KeepLastFullBackupsValue { get; set; }

        private bool deleteOldConfigurationBackupsValue;
        public bool DeleteOldConfigurationBackupsValue
        {
            get
            {
                return this.deleteOldConfigurationBackupsValue;
            }
            set
            {
                deleteOldConfigurationBackupsValue = value;

                if (deleteOldConfigurationBackupsValue)
                    nudKeepLastConfigurationBackups.Enabled = true;
                else
                    nudKeepLastConfigurationBackups.Enabled = false;
            }
        }

        public int KeepLastConfigurationBackupsValue { get; set; }

        private int updateTypeValue;
        public int UpdateTypeValue
        {
            get
            {
                return this.updateTypeValue;
            }
            set
            {
                updateTypeValue = value;

                lblUpdateURL.Visible = (updateTypeValue == 1);
                tbxUpdateURL.Visible = (updateTypeValue == 1);

                lblUpdateFile.Visible = (updateTypeValue != 1);
                tbxUpdateFile.Visible = (updateTypeValue != 1);
                btnUpdateFile.Visible = (updateTypeValue != 1);
            }
        }

        public int BeforeUpdatingValue { get; set; }
    }
}
