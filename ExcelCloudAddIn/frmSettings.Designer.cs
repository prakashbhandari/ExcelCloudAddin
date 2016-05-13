namespace ExcelCloudAddIn
{
    partial class frmSettings
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
            this.lblNotification = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabJobDetails = new System.Windows.Forms.TabPage();
            this.groupBoxTask = new System.Windows.Forms.GroupBox();
            this.dataGridTask = new System.Windows.Forms.DataGridView();
            this.taskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.jobExecution = new System.Windows.Forms.ComboBox();
            this.lblJobExecution = new System.Windows.Forms.Label();
            this.inputType = new System.Windows.Forms.ComboBox();
            this.lblInputType = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.lblInputCells = new System.Windows.Forms.Label();
            this.lblOutputCells = new System.Windows.Forms.Label();
            this.txtOutputCells = new System.Windows.Forms.TextBox();
            this.txtInputCells = new System.Windows.Forms.TextBox();
            this.btnSelectOutputCells = new System.Windows.Forms.Button();
            this.btnSelectInputCells = new System.Windows.Forms.Button();
            this.tabServerDetails = new System.Windows.Forms.TabPage();
            this.txtLibraryDir = new System.Windows.Forms.TextBox();
            this.lblLibraryDir = new System.Windows.Forms.Label();
            this.anekaGroup = new System.Windows.Forms.GroupBox();
            this.txtAnekaPassword = new System.Windows.Forms.TextBox();
            this.lblAnekaPassword = new System.Windows.Forms.Label();
            this.txtAnekaUsername = new System.Windows.Forms.TextBox();
            this.lblAnekaUsername = new System.Windows.Forms.Label();
            this.numericAnekaServicePort = new System.Windows.Forms.NumericUpDown();
            this.lblServicePort = new System.Windows.Forms.Label();
            this.txtAnekaMaster = new System.Windows.Forms.TextBox();
            this.lblMasterHostIP = new System.Windows.Forms.Label();
            this.checkBoxAneka = new System.Windows.Forms.CheckBox();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.tabJobDetails.SuspendLayout();
            this.groupBoxTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTask)).BeginInit();
            this.tabServerDetails.SuspendLayout();
            this.anekaGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnekaServicePort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification.Location = new System.Drawing.Point(15, 11);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(210, 16);
            this.lblNotification.TabIndex = 21;
            this.lblNotification.Text = "Please enter details and click Run";
            // 
            // tabSettings
            // 
            this.tabSettings.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabSettings.Controls.Add(this.tabJobDetails);
            this.tabSettings.Controls.Add(this.tabServerDetails);
            this.tabSettings.Location = new System.Drawing.Point(18, 39);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(279, 422);
            this.tabSettings.TabIndex = 31;
            // 
            // tabJobDetails
            // 
            this.tabJobDetails.BackColor = System.Drawing.SystemColors.Control;
            this.tabJobDetails.Controls.Add(this.groupBoxTask);
            this.tabJobDetails.Controls.Add(this.lblInputCells);
            this.tabJobDetails.Controls.Add(this.lblOutputCells);
            this.tabJobDetails.Controls.Add(this.txtOutputCells);
            this.tabJobDetails.Controls.Add(this.txtInputCells);
            this.tabJobDetails.Controls.Add(this.btnSelectOutputCells);
            this.tabJobDetails.Controls.Add(this.btnSelectInputCells);
            this.tabJobDetails.Location = new System.Drawing.Point(4, 25);
            this.tabJobDetails.Name = "tabJobDetails";
            this.tabJobDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabJobDetails.Size = new System.Drawing.Size(271, 393);
            this.tabJobDetails.TabIndex = 0;
            this.tabJobDetails.Text = "Job Details";
            // 
            // groupBoxTask
            // 
            this.groupBoxTask.Controls.Add(this.dataGridTask);
            this.groupBoxTask.Controls.Add(this.btnRemoveTask);
            this.groupBoxTask.Controls.Add(this.jobExecution);
            this.groupBoxTask.Controls.Add(this.lblJobExecution);
            this.groupBoxTask.Controls.Add(this.inputType);
            this.groupBoxTask.Controls.Add(this.lblInputType);
            this.groupBoxTask.Controls.Add(this.lblTask);
            this.groupBoxTask.Controls.Add(this.btnAddTask);
            this.groupBoxTask.Location = new System.Drawing.Point(15, 108);
            this.groupBoxTask.Name = "groupBoxTask";
            this.groupBoxTask.Size = new System.Drawing.Size(242, 266);
            this.groupBoxTask.TabIndex = 31;
            this.groupBoxTask.TabStop = false;
            this.groupBoxTask.Text = "Task Details";
            // 
            // dataGridTask
            // 
            this.dataGridTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taskName,
            this.taskPath});
            this.dataGridTask.Location = new System.Drawing.Point(10, 40);
            this.dataGridTask.Name = "dataGridTask";
            this.dataGridTask.RowHeadersVisible = false;
            this.dataGridTask.Size = new System.Drawing.Size(224, 122);
            this.dataGridTask.TabIndex = 39;
            // 
            // taskName
            // 
            this.taskName.HeaderText = "Name";
            this.taskName.Name = "taskName";
            this.taskName.Width = 70;
            // 
            // taskPath
            // 
            this.taskPath.HeaderText = "Path";
            this.taskPath.Name = "taskPath";
            this.taskPath.Width = 151;
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(189, 13);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(45, 23);
            this.btnRemoveTask.TabIndex = 38;
            this.btnRemoveTask.Text = "- Rem";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // jobExecution
            // 
            this.jobExecution.FormattingEnabled = true;
            this.jobExecution.Items.AddRange(new object[] {
            "Row based",
            "Column based"});
            this.jobExecution.Location = new System.Drawing.Point(12, 230);
            this.jobExecution.Name = "jobExecution";
            this.jobExecution.Size = new System.Drawing.Size(123, 21);
            this.jobExecution.TabIndex = 37;
            // 
            // lblJobExecution
            // 
            this.lblJobExecution.AutoSize = true;
            this.lblJobExecution.Location = new System.Drawing.Point(9, 211);
            this.lblJobExecution.Name = "lblJobExecution";
            this.lblJobExecution.Size = new System.Drawing.Size(74, 13);
            this.lblJobExecution.TabIndex = 36;
            this.lblJobExecution.Text = "Job Execution";
            // 
            // inputType
            // 
            this.inputType.FormattingEnabled = true;
            this.inputType.Items.AddRange(new object[] {
            "Parameter",
            "File"});
            this.inputType.Location = new System.Drawing.Point(12, 184);
            this.inputType.Name = "inputType";
            this.inputType.Size = new System.Drawing.Size(123, 21);
            this.inputType.TabIndex = 35;
            // 
            // lblInputType
            // 
            this.lblInputType.AutoSize = true;
            this.lblInputType.Location = new System.Drawing.Point(9, 165);
            this.lblInputType.Name = "lblInputType";
            this.lblInputType.Size = new System.Drawing.Size(58, 13);
            this.lblInputType.TabIndex = 34;
            this.lblInputType.Text = "Input Type";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(9, 20);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(31, 13);
            this.lblTask.TabIndex = 31;
            this.lblTask.Text = "Task";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(137, 13);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(46, 23);
            this.btnAddTask.TabIndex = 33;
            this.btnAddTask.Text = "+ Add";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // lblInputCells
            // 
            this.lblInputCells.AutoSize = true;
            this.lblInputCells.Location = new System.Drawing.Point(11, 8);
            this.lblInputCells.Name = "lblInputCells";
            this.lblInputCells.Size = new System.Drawing.Size(56, 13);
            this.lblInputCells.TabIndex = 14;
            this.lblInputCells.Text = "Input Cells";
            // 
            // lblOutputCells
            // 
            this.lblOutputCells.AutoSize = true;
            this.lblOutputCells.Location = new System.Drawing.Point(11, 53);
            this.lblOutputCells.Name = "lblOutputCells";
            this.lblOutputCells.Size = new System.Drawing.Size(64, 13);
            this.lblOutputCells.TabIndex = 15;
            this.lblOutputCells.Text = "Output Cells";
            // 
            // txtOutputCells
            // 
            this.txtOutputCells.Location = new System.Drawing.Point(14, 70);
            this.txtOutputCells.Name = "txtOutputCells";
            this.txtOutputCells.Size = new System.Drawing.Size(134, 20);
            this.txtOutputCells.TabIndex = 18;
            // 
            // txtInputCells
            // 
            this.txtInputCells.Location = new System.Drawing.Point(14, 25);
            this.txtInputCells.Name = "txtInputCells";
            this.txtInputCells.Size = new System.Drawing.Size(134, 20);
            this.txtInputCells.TabIndex = 19;
            // 
            // btnSelectOutputCells
            // 
            this.btnSelectOutputCells.Location = new System.Drawing.Point(155, 70);
            this.btnSelectOutputCells.Name = "btnSelectOutputCells";
            this.btnSelectOutputCells.Size = new System.Drawing.Size(27, 21);
            this.btnSelectOutputCells.TabIndex = 23;
            this.btnSelectOutputCells.Text = "...";
            this.btnSelectOutputCells.UseVisualStyleBackColor = true;
            this.btnSelectOutputCells.Click += new System.EventHandler(this.btnSelectOutputCells_Click);
            // 
            // btnSelectInputCells
            // 
            this.btnSelectInputCells.Location = new System.Drawing.Point(155, 25);
            this.btnSelectInputCells.Name = "btnSelectInputCells";
            this.btnSelectInputCells.Size = new System.Drawing.Size(27, 20);
            this.btnSelectInputCells.TabIndex = 22;
            this.btnSelectInputCells.Text = "...";
            this.btnSelectInputCells.UseVisualStyleBackColor = true;
            this.btnSelectInputCells.Click += new System.EventHandler(this.btnSelectInputCells_Click);
            // 
            // tabServerDetails
            // 
            this.tabServerDetails.Controls.Add(this.txtLibraryDir);
            this.tabServerDetails.Controls.Add(this.lblLibraryDir);
            this.tabServerDetails.Controls.Add(this.anekaGroup);
            this.tabServerDetails.Controls.Add(this.numericPort);
            this.tabServerDetails.Controls.Add(this.lblPort);
            this.tabServerDetails.Controls.Add(this.lblServer);
            this.tabServerDetails.Controls.Add(this.txtServer);
            this.tabServerDetails.Location = new System.Drawing.Point(4, 25);
            this.tabServerDetails.Name = "tabServerDetails";
            this.tabServerDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabServerDetails.Size = new System.Drawing.Size(271, 393);
            this.tabServerDetails.TabIndex = 1;
            this.tabServerDetails.Text = "Server Details";
            this.tabServerDetails.UseVisualStyleBackColor = true;
            // 
            // txtLibraryDir
            // 
            this.txtLibraryDir.Location = new System.Drawing.Point(15, 129);
            this.txtLibraryDir.Name = "txtLibraryDir";
            this.txtLibraryDir.Size = new System.Drawing.Size(167, 20);
            this.txtLibraryDir.TabIndex = 23;
            // 
            // lblLibraryDir
            // 
            this.lblLibraryDir.AutoSize = true;
            this.lblLibraryDir.Location = new System.Drawing.Point(12, 107);
            this.lblLibraryDir.Name = "lblLibraryDir";
            this.lblLibraryDir.Size = new System.Drawing.Size(117, 13);
            this.lblLibraryDir.TabIndex = 22;
            this.lblLibraryDir.Text = "Server Library Directory";
            // 
            // anekaGroup
            // 
            this.anekaGroup.Controls.Add(this.txtAnekaPassword);
            this.anekaGroup.Controls.Add(this.lblAnekaPassword);
            this.anekaGroup.Controls.Add(this.txtAnekaUsername);
            this.anekaGroup.Controls.Add(this.lblAnekaUsername);
            this.anekaGroup.Controls.Add(this.numericAnekaServicePort);
            this.anekaGroup.Controls.Add(this.lblServicePort);
            this.anekaGroup.Controls.Add(this.txtAnekaMaster);
            this.anekaGroup.Controls.Add(this.lblMasterHostIP);
            this.anekaGroup.Controls.Add(this.checkBoxAneka);
            this.anekaGroup.Location = new System.Drawing.Point(15, 163);
            this.anekaGroup.Name = "anekaGroup";
            this.anekaGroup.Size = new System.Drawing.Size(241, 212);
            this.anekaGroup.TabIndex = 21;
            this.anekaGroup.TabStop = false;
            this.anekaGroup.Text = "Aneka";
            // 
            // txtAnekaPassword
            // 
            this.txtAnekaPassword.Enabled = false;
            this.txtAnekaPassword.Location = new System.Drawing.Point(132, 176);
            this.txtAnekaPassword.Name = "txtAnekaPassword";
            this.txtAnekaPassword.PasswordChar = '*';
            this.txtAnekaPassword.Size = new System.Drawing.Size(103, 20);
            this.txtAnekaPassword.TabIndex = 29;
            // 
            // lblAnekaPassword
            // 
            this.lblAnekaPassword.AutoSize = true;
            this.lblAnekaPassword.Location = new System.Drawing.Point(129, 155);
            this.lblAnekaPassword.Name = "lblAnekaPassword";
            this.lblAnekaPassword.Size = new System.Drawing.Size(53, 13);
            this.lblAnekaPassword.TabIndex = 28;
            this.lblAnekaPassword.Text = "Password";
            // 
            // txtAnekaUsername
            // 
            this.txtAnekaUsername.Enabled = false;
            this.txtAnekaUsername.Location = new System.Drawing.Point(10, 176);
            this.txtAnekaUsername.Name = "txtAnekaUsername";
            this.txtAnekaUsername.Size = new System.Drawing.Size(110, 20);
            this.txtAnekaUsername.TabIndex = 27;
            // 
            // lblAnekaUsername
            // 
            this.lblAnekaUsername.AutoSize = true;
            this.lblAnekaUsername.Location = new System.Drawing.Point(7, 155);
            this.lblAnekaUsername.Name = "lblAnekaUsername";
            this.lblAnekaUsername.Size = new System.Drawing.Size(55, 13);
            this.lblAnekaUsername.TabIndex = 26;
            this.lblAnekaUsername.Text = "Username";
            // 
            // numericAnekaServicePort
            // 
            this.numericAnekaServicePort.Enabled = false;
            this.numericAnekaServicePort.Location = new System.Drawing.Point(10, 123);
            this.numericAnekaServicePort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericAnekaServicePort.Name = "numericAnekaServicePort";
            this.numericAnekaServicePort.Size = new System.Drawing.Size(93, 20);
            this.numericAnekaServicePort.TabIndex = 25;
            this.numericAnekaServicePort.Value = new decimal(new int[] {
            9090,
            0,
            0,
            0});
            // 
            // lblServicePort
            // 
            this.lblServicePort.AutoSize = true;
            this.lblServicePort.Location = new System.Drawing.Point(7, 103);
            this.lblServicePort.Name = "lblServicePort";
            this.lblServicePort.Size = new System.Drawing.Size(65, 13);
            this.lblServicePort.TabIndex = 23;
            this.lblServicePort.Text = "Service Port";
            // 
            // txtAnekaMaster
            // 
            this.txtAnekaMaster.Enabled = false;
            this.txtAnekaMaster.Location = new System.Drawing.Point(10, 72);
            this.txtAnekaMaster.Name = "txtAnekaMaster";
            this.txtAnekaMaster.Size = new System.Drawing.Size(157, 20);
            this.txtAnekaMaster.TabIndex = 22;
            // 
            // lblMasterHostIP
            // 
            this.lblMasterHostIP.AutoSize = true;
            this.lblMasterHostIP.Location = new System.Drawing.Point(7, 51);
            this.lblMasterHostIP.Name = "lblMasterHostIP";
            this.lblMasterHostIP.Size = new System.Drawing.Size(89, 13);
            this.lblMasterHostIP.TabIndex = 21;
            this.lblMasterHostIP.Text = "Master Host or IP";
            // 
            // checkBoxAneka
            // 
            this.checkBoxAneka.AutoSize = true;
            this.checkBoxAneka.Location = new System.Drawing.Point(10, 25);
            this.checkBoxAneka.Name = "checkBoxAneka";
            this.checkBoxAneka.Size = new System.Drawing.Size(93, 17);
            this.checkBoxAneka.TabIndex = 20;
            this.checkBoxAneka.Text = "Using Aneka?";
            this.checkBoxAneka.UseVisualStyleBackColor = true;
            this.checkBoxAneka.CheckedChanged += new System.EventHandler(this.checkBoxAneka_CheckedChanged);
            // 
            // numericPort
            // 
            this.numericPort.Location = new System.Drawing.Point(15, 70);
            this.numericPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(120, 20);
            this.numericPort.TabIndex = 19;
            this.numericPort.Value = new decimal(new int[] {
            9990,
            0,
            0,
            0});
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(12, 52);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 16;
            this.lblPort.Text = "Port";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Cursor = System.Windows.Forms.Cursors.No;
            this.lblServer.Location = new System.Drawing.Point(11, 8);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(38, 13);
            this.lblServer.TabIndex = 14;
            this.lblServer.Text = "Server";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(14, 24);
            this.txtServer.Multiline = true;
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(168, 20);
            this.txtServer.TabIndex = 15;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(232, 467);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(65, 23);
            this.btnRun.TabIndex = 32;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.lblNotification);
            this.Name = "frmSettings";
            this.Size = new System.Drawing.Size(316, 502);
            this.tabSettings.ResumeLayout(false);
            this.tabJobDetails.ResumeLayout(false);
            this.tabJobDetails.PerformLayout();
            this.groupBoxTask.ResumeLayout(false);
            this.groupBoxTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTask)).EndInit();
            this.tabServerDetails.ResumeLayout(false);
            this.tabServerDetails.PerformLayout();
            this.anekaGroup.ResumeLayout(false);
            this.anekaGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnekaServicePort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabJobDetails;
        private System.Windows.Forms.Label lblInputCells;
        private System.Windows.Forms.Label lblOutputCells;
        private System.Windows.Forms.TextBox txtOutputCells;
        private System.Windows.Forms.TextBox txtInputCells;
        private System.Windows.Forms.Button btnSelectOutputCells;
        private System.Windows.Forms.Button btnSelectInputCells;
        private System.Windows.Forms.TabPage tabServerDetails;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.NumericUpDown numericPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.CheckBox checkBoxAneka;
        private System.Windows.Forms.GroupBox anekaGroup;
        private System.Windows.Forms.TextBox txtAnekaMaster;
        private System.Windows.Forms.Label lblMasterHostIP;
        private System.Windows.Forms.NumericUpDown numericAnekaServicePort;
        private System.Windows.Forms.Label lblServicePort;
        private System.Windows.Forms.TextBox txtAnekaUsername;
        private System.Windows.Forms.Label lblAnekaUsername;
        private System.Windows.Forms.TextBox txtAnekaPassword;
        private System.Windows.Forms.Label lblAnekaPassword;
        private System.Windows.Forms.GroupBox groupBoxTask;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.ComboBox jobExecution;
        private System.Windows.Forms.Label lblJobExecution;
        private System.Windows.Forms.ComboBox inputType;
        private System.Windows.Forms.Label lblInputType;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView dataGridTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskPath;
        private System.Windows.Forms.TextBox txtLibraryDir;
        private System.Windows.Forms.Label lblLibraryDir;
    }
}
