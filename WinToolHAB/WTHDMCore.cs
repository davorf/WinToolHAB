using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Microsoft.Win32;
using System.IO.Compression;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.ServiceProcess;
using System.Net;

namespace WinToolHAB.DMCore
{
    public enum OperationType
    {
        Backup,
        Restore,
        Update
    }

    public partial class WTHDMCore : Component
    {
        FrmMain.WTHFrmMain MainForm = null;

        public WTHDMCore(FrmMain.WTHFrmMain AMainForm)
        {
            MainForm = AMainForm;

            InitializeComponent();

            CoreInitialize();
        }

        public WTHDMCore(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            CoreInitialize();
        }

        private bool UpdateDownloadComplete;

        private void bwrCompressFullBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateFullBackup();
        }

        private void bwrCompressFullBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (OperationTypeId == OperationType.Update)
                MainForm.UpdateProgress.Value = e.ProgressPercentage;
            else
                MainForm.BackupProgress.Value = e.ProgressPercentage;
        }

        private void bwrCompressFullBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MainForm.ClearBackupLog.Enabled = true;
            MainForm.Backup.Enabled = true;
            Application.UseWaitCursor = false;
            Cursor.Position = Cursor.Position;

            MessageBox.Show("Backup operation complete", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bwrCompressConfigurationBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            CreateConfigurationBackup();
        }

        private void bwrCompressConfigurationBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (OperationTypeId == OperationType.Update)
                MainForm.UpdateProgress.Value = e.ProgressPercentage;
            else
                MainForm.BackupProgress.Value = e.ProgressPercentage;
        }   

        private void bwrCompressConfigurationBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MainForm.ClearBackupLog.Enabled = true;
            MainForm.Backup.Enabled = true;
            Application.UseWaitCursor = false;
            Cursor.Position = Cursor.Position;

            MessageBox.Show("Backup operation complete", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bwrRestoreBackup_DoWork(object sender, DoWorkEventArgs e)
        {
            RestoreBackup();
        }

        private void bwrRestoreBackup_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainForm.RestoreProgress.Value = e.ProgressPercentage;
        }

        private void bwrRestoreBackup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartOpenHABService();

            MainForm.ClearRestoreLog.Enabled = true;
            MainForm.Restore.Enabled = true;
            Application.UseWaitCursor = false;
            Cursor.Position = Cursor.Position;

            MessageBox.Show("Restore operation complete", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bwrPerformUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateOpenHAB();
        }

        private void bwrPerformUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MainForm.UpdateProgress.Value = e.ProgressPercentage;
        }

        private void bwrPerformUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StartOpenHABService();

            MainForm.ClearUpdateLog.Enabled = true;
            MainForm.PerformUpdate.Enabled = true;
            Application.UseWaitCursor = false;
            Cursor.Position = Cursor.Position;

            MessageBox.Show("Update operation complete", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs OpenHABDownloadProgressArguments)
        {
            bwrPerformUpdate.ReportProgress(OpenHABDownloadProgressArguments.ProgressPercentage);
        }

        private void DownloadFileCompletedCallback (object sender, AsyncCompletedEventArgs OpenHABDownloadCompletedArguments)
        {
            UpdateDownloadComplete = true;
        }

        public void GetRegistrySettings()
        {
            RegistryKey WTHRegistryKey = Registry.LocalMachine.OpenSubKey("Software\\WinToolHAB", true);

            int RunTypeValue = 0;
            string ServiceName = "";
            string OpenHABPath = "";

            int BackupTypeValue = 0;
            string BackupPath = "";

            string UpdatePath = "";
            int UpdateTypeValue = 0;
            string UpdateURL = "";
            int BeforeUpdatingValue = 0;

            if (WTHRegistryKey == null)
            {
                WTHRegistryKey = Registry.LocalMachine.OpenSubKey("Software", true);

                WTHRegistryKey.CreateSubKey("WinToolHAB");
                WTHRegistryKey = WTHRegistryKey.OpenSubKey("WinToolHAB", true);

                WTHRegistryKey.SetValue("RunType", 0, RegistryValueKind.DWord);
                WTHRegistryKey.SetValue("ServiceName", "", RegistryValueKind.String);
                WTHRegistryKey.SetValue("OpenHABPath", "", RegistryValueKind.String);
                WTHRegistryKey.SetValue("BackupType", 0, RegistryValueKind.DWord);
                WTHRegistryKey.SetValue("BackupPath", "", RegistryValueKind.String);
                WTHRegistryKey.SetValue("DeleteOldFullBackups", false, RegistryValueKind.DWord);
                WTHRegistryKey.SetValue("KeepLastFullBackups", 0, RegistryValueKind.DWord);
                WTHRegistryKey.SetValue("DeleteOldConfigurationBackups", false, RegistryValueKind.DWord);
                WTHRegistryKey.SetValue("KeepLastConfigurationBackups", 0, RegistryValueKind.DWord);
                WTHRegistryKey.SetValue("UpdatePath", "", RegistryValueKind.String);
                WTHRegistryKey.SetValue("UpdateType", 0, RegistryValueKind.DWord);
                WTHRegistryKey.SetValue("UpdateURL", "", RegistryValueKind.String);
                WTHRegistryKey.SetValue("BeforeUpdating", 0, RegistryValueKind.DWord);
            }
            else
            {
                if (WTHRegistryKey.GetValue("RunType") != null)
                    int.TryParse(WTHRegistryKey.GetValue("RunType").ToString(), out RunTypeValue);
                else
                    RunTypeValue = 0;

                if (WTHRegistryKey.GetValue("ServiceName") != null)
                    ServiceName = WTHRegistryKey.GetValue("ServiceName").ToString();
                else
                    ServiceName = "";

                if (WTHRegistryKey.GetValue("OpenHABPath") != null)
                    OpenHABPath = WTHRegistryKey.GetValue("OpenHABPath").ToString();
                else
                    OpenHABPath = "";

                if (WTHRegistryKey.GetValue("BackupType") != null)
                    int.TryParse(WTHRegistryKey.GetValue("BackupType").ToString(), out BackupTypeValue);
                else
                    BackupTypeValue = 0;

                if (WTHRegistryKey.GetValue("BackupPath") != null)
                    BackupPath = WTHRegistryKey.GetValue("BackupPath").ToString();
                else
                    BackupPath = "";

                if (WTHRegistryKey.GetValue("DeleteOldFullBackups") != null)
                    MainForm.DeleteOldFullBackupsValue = Convert.ToBoolean(WTHRegistryKey.GetValue("DeleteOldFullBackups"));
                else
                    MainForm.DeleteOldFullBackupsValue = false;

                if (WTHRegistryKey.GetValue("KeepLastFullBackups") != null)
                    MainForm.KeepLastFullBackupsValue = Convert.ToInt16(WTHRegistryKey.GetValue("KeepLastFullBackups"));
                else
                    MainForm.KeepLastFullBackupsValue = 0;

                if (WTHRegistryKey.GetValue("DeleteOldConfigurationBackups") != null)
                    MainForm.DeleteOldConfigurationBackupsValue = Convert.ToBoolean(WTHRegistryKey.GetValue("DeleteOldConfigurationBackups"));
                else
                    MainForm.DeleteOldConfigurationBackupsValue = false;

                if (WTHRegistryKey.GetValue("KeepLastConfigurationBackups") != null)
                    MainForm.KeepLastConfigurationBackupsValue = Convert.ToInt16(WTHRegistryKey.GetValue("KeepLastConfigurationBackups"));
                else
                    MainForm.KeepLastConfigurationBackupsValue = 0;

                if (WTHRegistryKey.GetValue("UpdatePath") != null)
                    UpdatePath = WTHRegistryKey.GetValue("UpdatePath").ToString();
                else
                    UpdatePath = "";

                if (WTHRegistryKey.GetValue("UpdateType") != null)
                    int.TryParse(WTHRegistryKey.GetValue("UpdateType").ToString(), out UpdateTypeValue);
                else
                    UpdateTypeValue = 0;

                if (WTHRegistryKey.GetValue("UpdateURL") != null)
                    UpdateURL = WTHRegistryKey.GetValue("UpdateURL").ToString();
                else
                    UpdateURL = "";

                if (WTHRegistryKey.GetValue("BeforeUpdating") != null)
                    int.TryParse(WTHRegistryKey.GetValue("BeforeUpdating").ToString(), out BeforeUpdatingValue);
                else
                    BeforeUpdatingValue = 0;

                if (RunTypeValue == 0)
                    RunTypeValue = 1;

                if (BackupTypeValue == 0)
                    BackupTypeValue = 1;

                if (UpdateTypeValue == 0)
                    UpdateTypeValue = 1;

                if (BeforeUpdatingValue == 0)
                    BeforeUpdatingValue = 1;

                MainForm.RunType.SelectedValue = RunTypeValue;
                MainForm.RunTypeValue = RunTypeValue;

                if (ServiceName.Trim() != "")
                    MainForm.ServiceName.Text = ServiceName;

                if (OpenHABPath.Trim() != "")
                    MainForm.OpenHABPath.Text = OpenHABPath;

                MainForm.BackupType.SelectedValue = BackupTypeValue;
                MainForm.BackupTypeValue = BackupTypeValue;

                if (BackupPath.Trim() != "")
                    MainForm.BackupPath.Text = BackupPath;

                MainForm.DeleteOldFullBackups.Checked = MainForm.DeleteOldFullBackupsValue;
                MainForm.KeepLastFullBackups.Value = MainForm.KeepLastFullBackupsValue;

                MainForm.DeleteOldConfigurationBackups.Checked = MainForm.DeleteOldConfigurationBackupsValue;
                MainForm.KeepLastConfigurationBackups.Value = MainForm.KeepLastConfigurationBackupsValue;

                if (UpdatePath.Trim() != "")
                    MainForm.UpdatePath.Text = UpdatePath;

                MainForm.UpdateType.SelectedValue = UpdateTypeValue;
                MainForm.UpdateTypeValue = UpdateTypeValue;

                if (UpdateURL.Trim() != "")
                    MainForm.UpdateURL.Text = UpdateURL;

                MainForm.BeforeUpdating.SelectedValue = BeforeUpdatingValue;
                MainForm.BeforeUpdatingValue = BeforeUpdatingValue;
            }                

            WTHRegistryKey.Close();
        }

        public void SaveRegistrySettings()
        {
            RegistryKey WTHRegistryKey = Registry.LocalMachine.OpenSubKey("Software\\WinToolHAB", true);

            int RunTypeValue = 0;
            string ServiceName = "";
            string OpenHABPath = "";

            int BackupTypeValue = 0;
            string BackupPath = "";

            string UpdatePath = "";
            int UpdateTypeValue = 0;
            string UpdateURL = "";
            int BeforeUpdatingValue = 0;

            int.TryParse(MainForm.RunType.SelectedValue.ToString(), out RunTypeValue);
            ServiceName = MainForm.ServiceName.Text.Trim();
            OpenHABPath = MainForm.OpenHABPath.Text.Trim();

            int.TryParse(MainForm.BackupType.SelectedValue.ToString(), out BackupTypeValue);
            BackupPath = MainForm.BackupPath.Text.Trim();

            UpdatePath = MainForm.UpdatePath.Text.Trim();
            int.TryParse(MainForm.UpdateType.SelectedValue.ToString(), out UpdateTypeValue);
            UpdateURL = MainForm.UpdateURL.Text.Trim();
            int.TryParse(MainForm.BeforeUpdating.SelectedValue.ToString(), out BeforeUpdatingValue);

            WTHRegistryKey.SetValue("RunType", RunTypeValue, RegistryValueKind.DWord);
            WTHRegistryKey.SetValue("ServiceName", ServiceName, RegistryValueKind.String);
            WTHRegistryKey.SetValue("OpenHABPath", OpenHABPath, RegistryValueKind.String);
            WTHRegistryKey.SetValue("BackupType", BackupTypeValue, RegistryValueKind.DWord);
            WTHRegistryKey.SetValue("BackupPath", BackupPath, RegistryValueKind.String);
            WTHRegistryKey.SetValue("DeleteOldFullBackups", MainForm.DeleteOldFullBackupsValue, RegistryValueKind.DWord);
            WTHRegistryKey.SetValue("KeepLastFullBackups", MainForm.KeepLastFullBackupsValue, RegistryValueKind.DWord);
            WTHRegistryKey.SetValue("DeleteOldConfigurationBackups", MainForm.DeleteOldConfigurationBackupsValue, RegistryValueKind.DWord);
            WTHRegistryKey.SetValue("KeepLastConfigurationBackups", MainForm.KeepLastConfigurationBackupsValue, RegistryValueKind.DWord);
            WTHRegistryKey.SetValue("UpdatePath", UpdatePath, RegistryValueKind.String);
            WTHRegistryKey.SetValue("UpdateType", UpdateTypeValue, RegistryValueKind.DWord);
            WTHRegistryKey.SetValue("UpdateURL", UpdateURL, RegistryValueKind.String);
            WTHRegistryKey.SetValue("BeforeUpdating", BeforeUpdatingValue, RegistryValueKind.DWord);

            WTHRegistryKey.Close();
        }

        public void WriteLog(string LogLine, bool BoldLogLine = false, bool ErrorOccured = false)
        {
            if (LogObject.InvokeRequired)
            {
                if (BoldLogLine)
                {
                    MainForm.Invoke
                    (
                        (MethodInvoker)delegate
                        {
                            LogObject.SelectionFont = new Font(LogObject.Font, FontStyle.Bold);
                        }
                    );
                }

                if (ErrorOccured)
                {
                    MainForm.Invoke
                    (
                        (MethodInvoker)delegate
                        {
                            LogObject.ForeColor = Color.Red;
                        }
                    );
                }

                MainForm.Invoke
                (
                    (MethodInvoker)delegate
                    {
                        LogObject.AppendText(LogLine + Environment.NewLine);
                    }
                );
            }
            else
            {
                if (BoldLogLine)
                {
                    LogObject.SelectionFont = new Font(LogObject.Font, FontStyle.Bold);
                }

                if (ErrorOccured)
                {
                    LogObject.ForeColor = Color.Red;
                }

                LogObject.AppendText(LogLine + Environment.NewLine);
            }
        }

        public bool OpenHABRunningAsApplication()
        {
            if ((Process.GetProcessesByName("java").Length > 0) && (Process.GetProcessesByName("cmd").Length > 0))
                return true;
            else
                return false;
        }

        private void CoreInitialize()
        {
            OperationTypeId = OperationType.Backup;

            dstRunType.Tables[0].Rows.Add(1, "Windows Service");
            dstRunType.Tables[0].Rows.Add(2, "Windows Application");

            dstBackupType.Tables[0].Rows.Add(1, "Full backup");
            dstBackupType.Tables[0].Rows.Add(2, "Configuration backup");

            dstUpdateType.Tables[0].Rows.Add(1, "Online update");
            dstUpdateType.Tables[0].Rows.Add(2, "Local update");

            dstBeforeUpdating.Tables[0].Rows.Add(1, "Do not create backup");
            dstBeforeUpdating.Tables[0].Rows.Add(2, "Create full backup");
            dstBeforeUpdating.Tables[0].Rows.Add(3, "Create configuration backup");
        }

        private void CreateFullBackup()
        {
            int NumberOfBackupsToDelete = 0;
            string BackupZipFileName = "";

            TotalNumberOfItems += Directory.GetFiles(MainForm.OpenHABPath.Text.Trim(), "*.*", SearchOption.AllDirectories).Length;

            if (MainForm.DeleteOldConfigurationBackups.Checked)
            {
                NumberOfBackupsToDelete = Directory.GetFiles(MainForm.BackupPath.Text.Trim(), "OpenHAB_Full*.zip", SearchOption.TopDirectoryOnly).Length;
                NumberOfBackupsToDelete -= Convert.ToInt16(MainForm.KeepLastConfigurationBackups.Value);
                NumberOfBackupsToDelete++;

                if (NumberOfBackupsToDelete > 0)
                {
                    TotalNumberOfItems += NumberOfBackupsToDelete;

                    var BackupPathFolder = new DirectoryInfo(MainForm.BackupPath.Text.Trim());
                    FileInfo[] FilesToDelete = BackupPathFolder.EnumerateFiles("OpenHAB_Full*.zip").Take(NumberOfBackupsToDelete).OrderBy(BackupWriteTime => BackupWriteTime.LastWriteTime).ToArray();

                    foreach (var FileToDelete in FilesToDelete)
                    {
                        try
                        {
                            CurrentItemNumber++;

                            FileToDelete.Delete();

                            WriteLog("Deleting full backup: " + FileToDelete.Name + Environment.NewLine, true);
                        }
                        catch (Exception DeleteException)
                        {
                            WriteLog("Cannot delete full backup: " + FileToDelete.Name + " (" + DeleteException.Message + ")" + Environment.NewLine, true, true);
                        }
                    }
                }
            }

            BackupZipFileName = MainForm.BackupPath.Text.Trim() + "\\OpenHAB_Full_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip";

            ZipArchive BackupZipFile = null;

            try
            {
                BackupZipFile = ZipFile.Open(BackupZipFileName, ZipArchiveMode.Create);

                WriteLog("Creating full backup archive: " + BackupZipFileName + Environment.NewLine, true);
            }
            catch (Exception CompressionException)
            {
                WriteLog("Cannot create full backup archive: " + BackupZipFileName + " (" + CompressionException.Message + ")" + Environment.NewLine, true, true);

                return;
            }

            foreach (string FileToBackup in Directory.GetFiles(MainForm.OpenHABPath.Text.Trim(), "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    CurrentItemNumber++;

                    BackupZipFile.CreateEntryFromFile(FileToBackup, FileToBackup.Substring(MainForm.OpenHABPath.Text.Trim().Length + 1));

                    if (OperationTypeId == OperationType.Update)
                        bwrPerformUpdate.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);
                    else
                        bwrCompressFullBackup.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);

                    WriteLog("Compressing file: " + FileToBackup);
                }
                catch (Exception CompressionException)
                {
                    WriteLog("Cannot compress file: " + FileToBackup + " (" + CompressionException.Message + ")", false, true);
                }
            }

            BackupZipFile.Dispose();

            WriteLog(Environment.NewLine + "Full backup complete" + Environment.NewLine, true);
        }

        private void CreateConfigurationBackup()
        {
            int NumberOfBackupsToDelete = 0;
            string BackupZipFileName = "";

            TotalNumberOfItems += Directory.GetFiles(MainForm.OpenHABPath.Text.Trim() + "\\userdata", "*.*", SearchOption.AllDirectories).Length;
            TotalNumberOfItems += Directory.GetFiles(MainForm.OpenHABPath.Text.Trim() + "\\conf", "*.*", SearchOption.AllDirectories).Length;

            if (MainForm.DeleteOldConfigurationBackups.Checked)
            {
                NumberOfBackupsToDelete = Directory.GetFiles(MainForm.BackupPath.Text.Trim(), "OpenHAB_Configuration*.zip", SearchOption.TopDirectoryOnly).Length;
                NumberOfBackupsToDelete -= Convert.ToInt16(MainForm.KeepLastConfigurationBackups.Value);
                NumberOfBackupsToDelete++;

                if (NumberOfBackupsToDelete > 0)
                {
                    TotalNumberOfItems += NumberOfBackupsToDelete;

                    var BackupPathFolder = new DirectoryInfo(MainForm.BackupPath.Text.Trim());
                    FileInfo[] FilesToDelete = BackupPathFolder.EnumerateFiles("OpenHAB_Configuration*.zip").Take(NumberOfBackupsToDelete).OrderBy(BackupWriteTime => BackupWriteTime.LastWriteTime).ToArray();

                    foreach (var FileToDelete in FilesToDelete)
                    {
                        try
                        {
                            CurrentItemNumber++;

                            FileToDelete.Delete();

                            WriteLog("Deleting configuration backup: " + FileToDelete.Name + Environment.NewLine, true);
                        }
                        catch (Exception DeleteException)
                        {
                            WriteLog("Cannot delete configuration backup: " + FileToDelete.Name + " (" + DeleteException.Message + ")" + Environment.NewLine, true, true);
                        }
                    }
                }
            }

            BackupZipFileName = MainForm.BackupPath.Text.Trim() + "\\OpenHAB_Configuration_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip";

            ZipArchive BackupZipFile = null;

            try
            {
                BackupZipFile = ZipFile.Open(BackupZipFileName, ZipArchiveMode.Create);

                WriteLog("Creating configuration backup archive: " + BackupZipFileName + Environment.NewLine, true);
            }
            catch (Exception CompressionException)
            {
                WriteLog("Cannot create configuration backup archive: " + BackupZipFileName + " (" + CompressionException.Message + ")", true, true);

                return;
            }

            foreach (string FileToBackup in Directory.GetFiles(MainForm.OpenHABPath.Text.Trim() + "\\userdata", "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    CurrentItemNumber++;

                    BackupZipFile.CreateEntryFromFile(FileToBackup, FileToBackup.Substring(MainForm.OpenHABPath.Text.Trim().Length + 1));

                    if (OperationTypeId == OperationType.Update)
                        bwrPerformUpdate.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);
                    else
                        bwrCompressConfigurationBackup.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);

                    WriteLog("Compressing file: " + FileToBackup);
                }
                catch (Exception CompressionException)
                {
                    WriteLog("Cannot compress file: " + FileToBackup + " (" + CompressionException.Message + ")", false, true);
                }
            }

            foreach (string FileToBackup in Directory.GetFiles(MainForm.OpenHABPath.Text.Trim() + "\\conf", "*.*", SearchOption.AllDirectories))
            {
                try
                {
                    CurrentItemNumber++;

                    BackupZipFile.CreateEntryFromFile(FileToBackup, FileToBackup.Substring(MainForm.OpenHABPath.Text.Trim().Length + 1));

                    if (OperationTypeId == OperationType.Update)
                        bwrPerformUpdate.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);
                    else
                        bwrCompressConfigurationBackup.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);

                    WriteLog("Compressing file: " + FileToBackup);
                }
                catch (Exception CompressionException)
                {
                    WriteLog("Cannot compress file: " + FileToBackup + " (" + CompressionException.Message + ")", false, true);
                }
            }

            BackupZipFile.Dispose();

            WriteLog(Environment.NewLine + "Configuration backup complete" + Environment.NewLine, true);
        }

        private void RestoreBackup()
        {            
            if (!StopOpenHABService())
                return;

            ZipArchive ZipFileToExtract = null;

            try
            {
                ZipFileToExtract = ZipFile.Open(MainForm.RestoreBackupFile.Text.Trim(), ZipArchiveMode.Read);

                WriteLog("Restoring backup archive: " + MainForm.RestoreBackupFile.Text.Trim() + Environment.NewLine, true);
            }
            catch (Exception RestoreException)
            {
                WriteLog("Cannot restore backup archive: " + MainForm.RestoreBackupFile.Text.Trim() + " (" + RestoreException.Message + ")" + Environment.NewLine, true, true);

                return;
            }

            foreach (ZipArchiveEntry ZipEntryToCount in ZipFileToExtract.Entries)
            {
                if (!string.IsNullOrEmpty(ZipEntryToCount.FullName))
                    TotalNumberOfItems++;
            }

            foreach (ZipArchiveEntry ZipEntryToExtract in ZipFileToExtract.Entries)
            {
                CurrentItemNumber++;

                if (!Directory.Exists(new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Substring(0, new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Length - ZipEntryToExtract.Name.Length)))
                {
                    Directory.CreateDirectory(new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Substring(0, new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Length - ZipEntryToExtract.Name.Length));

                    bwrRestoreBackup.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);

                    WriteLog("Creating folder: " + new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Substring(0, new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Length - ZipEntryToExtract.Name.Length));
                }

                try
                {
                    ZipEntryToExtract.ExtractToFile(new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath, true);

                    bwrRestoreBackup.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);

                    WriteLog("Extracting file: " + ZipEntryToExtract.FullName);
                }
                catch (Exception RestoreException)
                {
                    bwrRestoreBackup.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);

                    WriteLog("Cannot extract file: " + ZipEntryToExtract.FullName + " (" + RestoreException.Message + ")", false, true);
                }
            }

            ZipFileToExtract.Dispose();

            WriteLog(Environment.NewLine + "Restore complete" + Environment.NewLine, true);
        }

        private void UpdateOpenHAB()
        {
            string OpenHABUpdateFileWithPath;

            if (MainForm.UpdateTypeValue == 1)
            {
                UpdateDownloadComplete = false;

                Uri UpdateFileURI;
                string OpenHABUpdateFile;
                WebClient OpenHABDownload = new WebClient();

                WriteLog("Downloading OpenHAB update" + Environment.NewLine, true);

                Uri.TryCreate(MainForm.UpdateURL.Text.Trim(), UriKind.Absolute, out UpdateFileURI);
                OpenHABUpdateFile = Path.GetFileName(UpdateFileURI.LocalPath);

                OpenHABUpdateFileWithPath = new Uri(MainForm.UpdatePath.Text.Trim() + "\\" + OpenHABUpdateFile.Trim()).LocalPath;

                if (File.Exists(OpenHABUpdateFileWithPath))
                    File.Delete(OpenHABUpdateFileWithPath);

                OpenHABDownload.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
                OpenHABDownload.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompletedCallback);

                try
                {                    
                    OpenHABDownload.DownloadFileAsync(new System.Uri(MainForm.UpdateURL.Text.Trim()), OpenHABUpdateFileWithPath.Trim());

                    while (!UpdateDownloadComplete)
                    {
                        Application.DoEvents();
                    }    
                }
                catch (Exception DownloadException)
                {
                    WriteLog("An error occured while downloading OpenHAB update (" + DownloadException.Message + ")" + Environment.NewLine, true, true);

                    return;
                }

                TotalNumberOfItems = 0;
                CurrentItemNumber = 0;
                bwrPerformUpdate.ReportProgress(0);
            }
            else
            {
                OpenHABUpdateFileWithPath = MainForm.UpdateFile.Text.Trim();
            }            

            if (!StopOpenHABService())
                return;

            ZipArchive ZipFileToExtract = null;

            try
            {
                ZipFileToExtract = ZipFile.Open(OpenHABUpdateFileWithPath.Trim(), ZipArchiveMode.Read);
            }
            catch (Exception UpdateException)
            {
                WriteLog("Cannot update OpenHAB using update file: " + OpenHABUpdateFileWithPath.Trim() + " (" + UpdateException.Message + ")" + Environment.NewLine, true, true);

                return;
            }

            foreach (ZipArchiveEntry ZipEntryToCount in ZipFileToExtract.Entries)
            {
                if (!string.IsNullOrEmpty(ZipEntryToCount.FullName))
                    TotalNumberOfItems++;
            }

            if (MainForm.BeforeUpdatingValue == 2)
                CreateFullBackup();
            else if (MainForm.BeforeUpdatingValue == 3)
                CreateConfigurationBackup();

            WriteLog("Updating OpenHAB using update file: " + OpenHABUpdateFileWithPath.Trim() + Environment.NewLine, true);

            var FilesToDelete = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "DeleteList.dat");

            foreach (var FileToDelete in FilesToDelete)
            {
                bool IsFolder = false;

                if ((!FileToDelete.ToString().Trim().Contains("*")) && (!FileToDelete.ToString().Trim().Contains("?")) && (Directory.Exists(new Uri(MainForm.OpenHABPath.Text.Trim() + "\\" + FileToDelete.ToString().Trim()).LocalPath)))
                    if (File.GetAttributes(new Uri(MainForm.OpenHABPath.Text.Trim() + "\\" + FileToDelete.ToString().Trim()).LocalPath).HasFlag(FileAttributes.Directory))
                        IsFolder = true;

                if (IsFolder)
                {
                    try
                    {
                        Directory.Delete(new Uri(MainForm.OpenHABPath.Text.Trim() + "\\" + FileToDelete.ToString().Trim()).LocalPath, true);

                        WriteLog("Deleting folder: " + new Uri(MainForm.OpenHABPath.Text.Trim() + "\\" + FileToDelete.ToString().Trim()).LocalPath);
                    }
                    catch (Exception DeleteException)
                    {
                        WriteLog("Cannot delete folder: " + new Uri(MainForm.OpenHABPath.Text.Trim() + "\\" + FileToDelete.ToString().Trim()).LocalPath + " (" + DeleteException.Message + ")", false, true);
                    }
                }
                else
                {
                    foreach (var SingleFile in Directory.GetFiles(new Uri(MainForm.OpenHABPath.Text.Trim() + "\\").LocalPath, FileToDelete))
                    {
                        try
                        {
                            File.Delete(SingleFile.ToString().Trim());

                            WriteLog("Deleting file: " + SingleFile.ToString().Trim());
                        }
                        catch (Exception DeleteException)
                        {
                            WriteLog("Cannot delete file: " + SingleFile.ToString().Trim() + " (" + DeleteException.Message + ")", false, true);
                        }
                    }
                }
            }

            foreach (ZipArchiveEntry ZipEntryToExtract in ZipFileToExtract.Entries)
            {
                CurrentItemNumber++;

                if (String.IsNullOrEmpty(ZipEntryToExtract.Name))
                {
                    if (!Directory.Exists(new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Substring(0, new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Length - ZipEntryToExtract.Name.Length)))
                    {
                        try
                        {
                            Directory.CreateDirectory(new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Substring(0, new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Length - ZipEntryToExtract.Name.Length));

                            bwrPerformUpdate.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);

                            WriteLog("Creating folder: " + new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Substring(0, new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Length - ZipEntryToExtract.Name.Length));
                        }
                        catch (Exception UpdateException)
                        {
                            WriteLog("Cannot create folder: " + new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Substring(0, new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath.Length - ZipEntryToExtract.Name.Length) + " (" + UpdateException.Message + ")", false, true);
                        }
                    }
                }
                else
                {
                    try
                    {
                        ZipEntryToExtract.ExtractToFile(new Uri(Path.Combine(MainForm.OpenHABPath.Text.Trim(), ZipEntryToExtract.FullName)).LocalPath, false);

                        bwrPerformUpdate.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);

                        WriteLog("Extracting file: " + ZipEntryToExtract.FullName);
                    }
                    catch (Exception UpdateException)
                    {
                        bwrPerformUpdate.ReportProgress(CurrentItemNumber * 100 / TotalNumberOfItems);

                        WriteLog("Skipping file extraction: " + ZipEntryToExtract.FullName + " (" + UpdateException.Message.ToString() + ")");
                    }
                }
            }

            ZipFileToExtract.Dispose();

            WriteLog(Environment.NewLine + "Update complete" + Environment.NewLine, true);
        }

        private bool StopOpenHABService()
        {
            ServiceController WindowsServiceControler = ServiceController.GetServices().FirstOrDefault(OpenHABService => OpenHABService.ServiceName == MainForm.ServiceName.Text.Trim());

            if (WindowsServiceControler != null)
            {
                if (WindowsServiceControler.Status == ServiceControllerStatus.Running)
                {
                    try
                    {
                        WriteLog("Stopping OpenHAB service" + Environment.NewLine, true);

                        WindowsServiceControler.Stop();
                        WindowsServiceControler.WaitForStatus(ServiceControllerStatus.Stopped);

                        System.Threading.Thread.Sleep(3000);

                        WriteLog("OpenHAB service stopped" + Environment.NewLine, true);

                        return true;
                    }
                    catch (InvalidOperationException)
                    {
                        if (OperationTypeId == OperationType.Update)
                            WriteLog("Unable to stop OpenHAB service (Updating OpenHAB interrupted)", true, true);
                        else
                            WriteLog("Unable to stop OpenHAB service (Restoring backup interrupted)", true, true);

                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void StartOpenHABService()
        {
            if (MainForm.RunTypeValue == 1)
            {
                ServiceController WindowsServiceControler = ServiceController.GetServices().FirstOrDefault(OpenHABService => OpenHABService.ServiceName == MainForm.ServiceName.Text.Trim());

                if (WindowsServiceControler != null)
                {
                    if (WindowsServiceControler.Status == ServiceControllerStatus.Stopped)
                    {
                        try
                        {
                            WriteLog("Starting OpenHAB service" + Environment.NewLine, true);

                            WindowsServiceControler.Start();
                            WindowsServiceControler.WaitForStatus(ServiceControllerStatus.Running);

                            WriteLog("OpenHAB service started" + Environment.NewLine, true);
                        }
                        catch (InvalidOperationException)
                        {
                            WriteLog("Unable to start OpenHAB service", true, true);
                        }
                    }
                }
            }
        }

        private OperationType operationType;
        public OperationType OperationTypeId
        {
            get
            {
                return this.operationType;
            }
            set
            {
                operationType = value;

                switch (operationType)
                {
                    case OperationType.Backup:
                        LogObject = MainForm.BackupLog;
                        break;
                    case OperationType.Restore:
                        LogObject = MainForm.RestoreLog;
                        break;
                    case OperationType.Update:
                        LogObject = MainForm.UpdateLog;
                        break;
                    default:
                        LogObject = MainForm.BackupLog;
                        break;
                }
            }
        }

        private RichTextBox LogObject { get; set; }
        public int TotalNumberOfItems { get; set; }
        public int CurrentItemNumber { get; set; }
    }
}
