namespace WinToolHAB.DMCore
{
    partial class WTHDMCore
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
            this.dstRunType = new System.Data.DataSet();
            this.WTH_RUN_TYPE = new System.Data.DataTable();
            this.RUN_TYPE_ID = new System.Data.DataColumn();
            this.RT_DESCRIPTION = new System.Data.DataColumn();
            this.dstBackupType = new System.Data.DataSet();
            this.WTH_BACKUP_TYPE = new System.Data.DataTable();
            this.BACKUP_TYPE_ID = new System.Data.DataColumn();
            this.BT_DESCRIPTION = new System.Data.DataColumn();
            this.bwrCompressConfigurationBackup = new System.ComponentModel.BackgroundWorker();
            this.bwrCompressFullBackup = new System.ComponentModel.BackgroundWorker();
            this.bwrRestoreBackup = new System.ComponentModel.BackgroundWorker();
            this.dstBeforeUpdating = new System.Data.DataSet();
            this.WTH_BEFORE_UPDATING = new System.Data.DataTable();
            this.BEFORE_UPDATING_ID = new System.Data.DataColumn();
            this.BU_DESCRIPTION = new System.Data.DataColumn();
            this.bwrPerformUpdate = new System.ComponentModel.BackgroundWorker();
            this.dstUpdateType = new System.Data.DataSet();
            this.WTH_UPDATE_TYPE = new System.Data.DataTable();
            this.UPDATE_TYPE_ID = new System.Data.DataColumn();
            this.UT_DESCRIPTION = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dstRunType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTH_RUN_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstBackupType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTH_BACKUP_TYPE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstBeforeUpdating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTH_BEFORE_UPDATING)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstUpdateType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTH_UPDATE_TYPE)).BeginInit();
            // 
            // dstRunType
            // 
            this.dstRunType.DataSetName = "dstRunType";
            this.dstRunType.Tables.AddRange(new System.Data.DataTable[] {
            this.WTH_RUN_TYPE});
            // 
            // WTH_RUN_TYPE
            // 
            this.WTH_RUN_TYPE.Columns.AddRange(new System.Data.DataColumn[] {
            this.RUN_TYPE_ID,
            this.RT_DESCRIPTION});
            this.WTH_RUN_TYPE.TableName = "WTH_RUN_TYPE";
            // 
            // RUN_TYPE_ID
            // 
            this.RUN_TYPE_ID.AllowDBNull = false;
            this.RUN_TYPE_ID.ColumnName = "RUN_TYPE_ID";
            this.RUN_TYPE_ID.DataType = typeof(short);
            // 
            // RT_DESCRIPTION
            // 
            this.RT_DESCRIPTION.AllowDBNull = false;
            this.RT_DESCRIPTION.Caption = "RT_DESCRIPTION";
            this.RT_DESCRIPTION.ColumnName = "RT_DESCRIPTION";
            // 
            // dstBackupType
            // 
            this.dstBackupType.DataSetName = "dstBackupType";
            this.dstBackupType.Tables.AddRange(new System.Data.DataTable[] {
            this.WTH_BACKUP_TYPE});
            // 
            // WTH_BACKUP_TYPE
            // 
            this.WTH_BACKUP_TYPE.Columns.AddRange(new System.Data.DataColumn[] {
            this.BACKUP_TYPE_ID,
            this.BT_DESCRIPTION});
            this.WTH_BACKUP_TYPE.TableName = "WTH_BACKUP_TYPE";
            // 
            // BACKUP_TYPE_ID
            // 
            this.BACKUP_TYPE_ID.AllowDBNull = false;
            this.BACKUP_TYPE_ID.ColumnName = "BACKUP_TYPE_ID";
            this.BACKUP_TYPE_ID.DataType = typeof(short);
            // 
            // BT_DESCRIPTION
            // 
            this.BT_DESCRIPTION.AllowDBNull = false;
            this.BT_DESCRIPTION.ColumnName = "BT_DESCRIPTION";
            // 
            // bwrCompressConfigurationBackup
            // 
            this.bwrCompressConfigurationBackup.WorkerReportsProgress = true;
            this.bwrCompressConfigurationBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrCompressConfigurationBackup_DoWork);
            this.bwrCompressConfigurationBackup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwrCompressConfigurationBackup_ProgressChanged);
            this.bwrCompressConfigurationBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrCompressConfigurationBackup_RunWorkerCompleted);
            // 
            // bwrCompressFullBackup
            // 
            this.bwrCompressFullBackup.WorkerReportsProgress = true;
            this.bwrCompressFullBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrCompressFullBackup_DoWork);
            this.bwrCompressFullBackup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwrCompressFullBackup_ProgressChanged);
            this.bwrCompressFullBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrCompressFullBackup_RunWorkerCompleted);
            // 
            // bwrRestoreBackup
            // 
            this.bwrRestoreBackup.WorkerReportsProgress = true;
            this.bwrRestoreBackup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrRestoreBackup_DoWork);
            this.bwrRestoreBackup.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwrRestoreBackup_ProgressChanged);
            this.bwrRestoreBackup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrRestoreBackup_RunWorkerCompleted);
            // 
            // dstBeforeUpdating
            // 
            this.dstBeforeUpdating.DataSetName = "dstBeforeUpdating";
            this.dstBeforeUpdating.Tables.AddRange(new System.Data.DataTable[] {
            this.WTH_BEFORE_UPDATING});
            // 
            // WTH_BEFORE_UPDATING
            // 
            this.WTH_BEFORE_UPDATING.Columns.AddRange(new System.Data.DataColumn[] {
            this.BEFORE_UPDATING_ID,
            this.BU_DESCRIPTION});
            this.WTH_BEFORE_UPDATING.TableName = "WTH_BEFORE_UPDATING";
            // 
            // BEFORE_UPDATING_ID
            // 
            this.BEFORE_UPDATING_ID.AllowDBNull = false;
            this.BEFORE_UPDATING_ID.ColumnName = "BEFORE_UPDATING_ID";
            this.BEFORE_UPDATING_ID.DataType = typeof(short);
            // 
            // BU_DESCRIPTION
            // 
            this.BU_DESCRIPTION.AllowDBNull = false;
            this.BU_DESCRIPTION.ColumnName = "BU_DESCRIPTION";
            // 
            // bwrPerformUpdate
            // 
            this.bwrPerformUpdate.WorkerReportsProgress = true;
            this.bwrPerformUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrPerformUpdate_DoWork);
            this.bwrPerformUpdate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwrPerformUpdate_ProgressChanged);
            this.bwrPerformUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwrPerformUpdate_RunWorkerCompleted);
            // 
            // dstUpdateType
            // 
            this.dstUpdateType.DataSetName = "dstUpdateType";
            this.dstUpdateType.Tables.AddRange(new System.Data.DataTable[] {
            this.WTH_UPDATE_TYPE});
            // 
            // WTH_UPDATE_TYPE
            // 
            this.WTH_UPDATE_TYPE.Columns.AddRange(new System.Data.DataColumn[] {
            this.UPDATE_TYPE_ID,
            this.UT_DESCRIPTION});
            this.WTH_UPDATE_TYPE.TableName = "WTH_UPDATE_TYPE";
            // 
            // UPDATE_TYPE_ID
            // 
            this.UPDATE_TYPE_ID.AllowDBNull = false;
            this.UPDATE_TYPE_ID.ColumnName = "UPDATE_TYPE_ID";
            this.UPDATE_TYPE_ID.DataType = typeof(short);
            // 
            // UT_DESCRIPTION
            // 
            this.UT_DESCRIPTION.AllowDBNull = false;
            this.UT_DESCRIPTION.ColumnName = "UT_DESCRIPTION";
            ((System.ComponentModel.ISupportInitialize)(this.dstRunType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTH_RUN_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstBackupType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTH_BACKUP_TYPE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstBeforeUpdating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTH_BEFORE_UPDATING)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dstUpdateType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WTH_UPDATE_TYPE)).EndInit();

        }

        #endregion

        private System.Data.DataSet dstRunType;
        private System.Data.DataTable WTH_RUN_TYPE;
        private System.Data.DataColumn RUN_TYPE_ID;
        private System.Data.DataColumn RT_DESCRIPTION;
        private System.Data.DataSet dstBackupType;
        private System.Data.DataTable WTH_BACKUP_TYPE;
        private System.Data.DataColumn BACKUP_TYPE_ID;
        private System.Data.DataColumn BT_DESCRIPTION;
        private System.ComponentModel.BackgroundWorker bwrCompressConfigurationBackup;
        private System.ComponentModel.BackgroundWorker bwrCompressFullBackup;
        private System.ComponentModel.BackgroundWorker bwrRestoreBackup;
        private System.Data.DataSet dstBeforeUpdating;
        private System.Data.DataTable WTH_BEFORE_UPDATING;
        private System.Data.DataColumn BEFORE_UPDATING_ID;
        private System.Data.DataColumn BU_DESCRIPTION;
        private System.ComponentModel.BackgroundWorker bwrPerformUpdate;
        private System.Data.DataSet dstUpdateType;
        private System.Data.DataTable WTH_UPDATE_TYPE;
        private System.Data.DataColumn UPDATE_TYPE_ID;
        private System.Data.DataColumn UT_DESCRIPTION;

        public System.Data.DataSet RunType
        {
            get
            {
                return this.dstRunType;
            }
        }

        public System.Data.DataSet BackupType
        {
            get
            {
                return this.dstBackupType;
            }
        }

        public System.ComponentModel.BackgroundWorker CompressFullBackup
        {
            get
            {
                return this.bwrCompressFullBackup;
            }
        }

        public System.ComponentModel.BackgroundWorker CompressConfigurationBackup
        {
            get
            {
                return this.bwrCompressConfigurationBackup;
            }
        }

        public System.ComponentModel.BackgroundWorker ExtractBackup
        {
            get
            {
                return this.bwrRestoreBackup;
            }
        }

        public System.Data.DataSet UpdateType
        {
            get
            {
                return this.dstUpdateType;
            }
        }
        
        public System.Data.DataSet BeforeUpdating
        {
            get
            {
                return this.dstBeforeUpdating;
            }
        }

        public System.ComponentModel.BackgroundWorker PerformOpenHABUpdate
        {
            get
            {
                return this.bwrPerformUpdate;
            }
        }
    }
}
