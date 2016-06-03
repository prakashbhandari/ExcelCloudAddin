namespace ExcelCloudAddIn
{
    partial class FrmSettings
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
            this.comboJobExecution = new System.Windows.Forms.ComboBox();
            this.lblJobExecution = new System.Windows.Forms.Label();
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
            this.groupBoxAneka = new System.Windows.Forms.GroupBox();
            this.numericAnekaPort = new System.Windows.Forms.NumericUpDown();
            this.txtAnekaHost = new System.Windows.Forms.TextBox();
            this.lblAnekaPort = new System.Windows.Forms.Label();
            this.lblAnekaHost = new System.Windows.Forms.Label();
            this.txtAnekaPassword = new System.Windows.Forms.TextBox();
            this.txtAnekaUsername = new System.Windows.Forms.TextBox();
            this.lblAnekaPassword = new System.Windows.Forms.Label();
            this.lblAnekaUsername = new System.Windows.Forms.Label();
            this.checkBoxAneka = new System.Windows.Forms.CheckBox();
            this.lblLibraryDir = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.progressBarTask = new System.Windows.Forms.ProgressBar();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.tabJobDetails.SuspendLayout();
            this.groupBoxTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTask)).BeginInit();
            this.tabServerDetails.SuspendLayout();
            this.groupBoxAneka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnekaPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification.Location = new System.Drawing.Point(21, 16);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(172, 16);
            this.lblNotification.TabIndex = 21;
            this.lblNotification.Text = "Fill the details and click Run";
            // 
            // tabSettings
            // 
            this.tabSettings.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabSettings.Controls.Add(this.tabJobDetails);
            this.tabSettings.Controls.Add(this.tabServerDetails);
            this.tabSettings.Location = new System.Drawing.Point(18, 45);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(279, 380);
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
            this.tabJobDetails.Size = new System.Drawing.Size(271, 351);
            this.tabJobDetails.TabIndex = 0;
            this.tabJobDetails.Text = "Job Details";
            // 
            // groupBoxTask
            // 
            this.groupBoxTask.Controls.Add(this.dataGridTask);
            this.groupBoxTask.Controls.Add(this.btnRemoveTask);
            this.groupBoxTask.Controls.Add(this.comboJobExecution);
            this.groupBoxTask.Controls.Add(this.lblJobExecution);
            this.groupBoxTask.Controls.Add(this.lblTask);
            this.groupBoxTask.Controls.Add(this.btnAddTask);
            this.groupBoxTask.Location = new System.Drawing.Point(14, 108);
            this.groupBoxTask.Name = "groupBoxTask";
            this.groupBoxTask.Size = new System.Drawing.Size(240, 228);
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
            this.dataGridTask.Size = new System.Drawing.Size(224, 131);
            this.dataGridTask.TabIndex = 39;
            // 
            // taskName
            // 
            this.taskName.HeaderText = "Task Name";
            this.taskName.Name = "taskName";
            this.taskName.Width = 85;
            // 
            // taskPath
            // 
            this.taskPath.HeaderText = "Task Path";
            this.taskPath.Name = "taskPath";
            this.taskPath.Width = 135;
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(187, 14);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(45, 23);
            this.btnRemoveTask.TabIndex = 38;
            this.btnRemoveTask.Text = "- Rem";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // comboJobExecution
            // 
            this.comboJobExecution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboJobExecution.FormattingEnabled = true;
            this.comboJobExecution.Items.AddRange(new object[] {
            "Row based",
            "Column based"});
            this.comboJobExecution.Location = new System.Drawing.Point(10, 194);
            this.comboJobExecution.Name = "comboJobExecution";
            this.comboJobExecution.Size = new System.Drawing.Size(134, 21);
            this.comboJobExecution.TabIndex = 37;
            // 
            // lblJobExecution
            // 
            this.lblJobExecution.AutoSize = true;
            this.lblJobExecution.Location = new System.Drawing.Point(7, 174);
            this.lblJobExecution.Name = "lblJobExecution";
            this.lblJobExecution.Size = new System.Drawing.Size(74, 13);
            this.lblJobExecution.TabIndex = 36;
            this.lblJobExecution.Text = "Job Execution";
            // 
            // lblTask
            // 
            this.lblTask.AutoSize = true;
            this.lblTask.Location = new System.Drawing.Point(8, 20);
            this.lblTask.Name = "lblTask";
            this.lblTask.Size = new System.Drawing.Size(31, 13);
            this.lblTask.TabIndex = 31;
            this.lblTask.Text = "Task";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(133, 13);
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
            this.tabServerDetails.Controls.Add(this.groupBoxAneka);
            this.tabServerDetails.Controls.Add(this.checkBoxAneka);
            this.tabServerDetails.Controls.Add(this.lblLibraryDir);
            this.tabServerDetails.Controls.Add(this.label2);
            this.tabServerDetails.Controls.Add(this.txtHost);
            this.tabServerDetails.Controls.Add(this.label3);
            this.tabServerDetails.Controls.Add(this.numericPort);
            this.tabServerDetails.Location = new System.Drawing.Point(4, 25);
            this.tabServerDetails.Name = "tabServerDetails";
            this.tabServerDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabServerDetails.Size = new System.Drawing.Size(271, 351);
            this.tabServerDetails.TabIndex = 1;
            this.tabServerDetails.Text = "Server Details";
            this.tabServerDetails.UseVisualStyleBackColor = true;
            // 
            // txtLibraryDir
            // 
            this.txtLibraryDir.Location = new System.Drawing.Point(16, 123);
            this.txtLibraryDir.Name = "txtLibraryDir";
            this.txtLibraryDir.Size = new System.Drawing.Size(156, 20);
            this.txtLibraryDir.TabIndex = 27;
            // 
            // groupBoxAneka
            // 
            this.groupBoxAneka.Controls.Add(this.numericAnekaPort);
            this.groupBoxAneka.Controls.Add(this.txtAnekaHost);
            this.groupBoxAneka.Controls.Add(this.lblAnekaPort);
            this.groupBoxAneka.Controls.Add(this.lblAnekaHost);
            this.groupBoxAneka.Controls.Add(this.txtAnekaPassword);
            this.groupBoxAneka.Controls.Add(this.txtAnekaUsername);
            this.groupBoxAneka.Controls.Add(this.lblAnekaPassword);
            this.groupBoxAneka.Controls.Add(this.lblAnekaUsername);
            this.groupBoxAneka.Location = new System.Drawing.Point(15, 179);
            this.groupBoxAneka.Name = "groupBoxAneka";
            this.groupBoxAneka.Size = new System.Drawing.Size(241, 166);
            this.groupBoxAneka.TabIndex = 26;
            this.groupBoxAneka.TabStop = false;
            this.groupBoxAneka.Text = "Aneka Details";
            // 
            // numericAnekaPort
            // 
            this.numericAnekaPort.Location = new System.Drawing.Point(9, 89);
            this.numericAnekaPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericAnekaPort.Name = "numericAnekaPort";
            this.numericAnekaPort.Size = new System.Drawing.Size(84, 20);
            this.numericAnekaPort.TabIndex = 8;
            this.numericAnekaPort.Value = new decimal(new int[] {
            9090,
            0,
            0,
            0});
            // 
            // txtAnekaHost
            // 
            this.txtAnekaHost.Location = new System.Drawing.Point(9, 38);
            this.txtAnekaHost.Name = "txtAnekaHost";
            this.txtAnekaHost.Size = new System.Drawing.Size(147, 20);
            this.txtAnekaHost.TabIndex = 7;
            this.txtAnekaHost.Text = "10.0.2.15";
            // 
            // lblAnekaPort
            // 
            this.lblAnekaPort.AutoSize = true;
            this.lblAnekaPort.Location = new System.Drawing.Point(9, 67);
            this.lblAnekaPort.Name = "lblAnekaPort";
            this.lblAnekaPort.Size = new System.Drawing.Size(99, 13);
            this.lblAnekaPort.TabIndex = 5;
            this.lblAnekaPort.Text = "Aneka Service Port";
            // 
            // lblAnekaHost
            // 
            this.lblAnekaHost.AutoSize = true;
            this.lblAnekaHost.Location = new System.Drawing.Point(7, 19);
            this.lblAnekaHost.Name = "lblAnekaHost";
            this.lblAnekaHost.Size = new System.Drawing.Size(88, 13);
            this.lblAnekaHost.TabIndex = 4;
            this.lblAnekaHost.Text = "Aneka Host or IP";
            // 
            // txtAnekaPassword
            // 
            this.txtAnekaPassword.Location = new System.Drawing.Point(125, 137);
            this.txtAnekaPassword.Name = "txtAnekaPassword";
            this.txtAnekaPassword.PasswordChar = '*';
            this.txtAnekaPassword.Size = new System.Drawing.Size(100, 20);
            this.txtAnekaPassword.TabIndex = 3;
            this.txtAnekaPassword.Text = "prakash191";
            // 
            // txtAnekaUsername
            // 
            this.txtAnekaUsername.Location = new System.Drawing.Point(9, 136);
            this.txtAnekaUsername.Name = "txtAnekaUsername";
            this.txtAnekaUsername.Size = new System.Drawing.Size(100, 20);
            this.txtAnekaUsername.TabIndex = 2;
            this.txtAnekaUsername.Text = "prakashbhandari";
            // 
            // lblAnekaPassword
            // 
            this.lblAnekaPassword.AutoSize = true;
            this.lblAnekaPassword.Location = new System.Drawing.Point(122, 117);
            this.lblAnekaPassword.Name = "lblAnekaPassword";
            this.lblAnekaPassword.Size = new System.Drawing.Size(53, 13);
            this.lblAnekaPassword.TabIndex = 1;
            this.lblAnekaPassword.Text = "Password";
            // 
            // lblAnekaUsername
            // 
            this.lblAnekaUsername.AutoSize = true;
            this.lblAnekaUsername.Location = new System.Drawing.Point(9, 116);
            this.lblAnekaUsername.Name = "lblAnekaUsername";
            this.lblAnekaUsername.Size = new System.Drawing.Size(55, 13);
            this.lblAnekaUsername.TabIndex = 0;
            this.lblAnekaUsername.Text = "Username";
            // 
            // checkBoxAneka
            // 
            this.checkBoxAneka.AutoSize = true;
            this.checkBoxAneka.Checked = true;
            this.checkBoxAneka.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAneka.Location = new System.Drawing.Point(16, 153);
            this.checkBoxAneka.Name = "checkBoxAneka";
            this.checkBoxAneka.Size = new System.Drawing.Size(93, 17);
            this.checkBoxAneka.TabIndex = 20;
            this.checkBoxAneka.Text = "Using Aneka?";
            this.checkBoxAneka.UseVisualStyleBackColor = true;
            this.checkBoxAneka.CheckedChanged += new System.EventHandler(this.checkBoxAneka_CheckedChanged);
            // 
            // lblLibraryDir
            // 
            this.lblLibraryDir.AutoSize = true;
            this.lblLibraryDir.Location = new System.Drawing.Point(13, 106);
            this.lblLibraryDir.Name = "lblLibraryDir";
            this.lblLibraryDir.Size = new System.Drawing.Size(54, 13);
            this.lblLibraryDir.TabIndex = 6;
            this.lblLibraryDir.Text = "Library Dir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Host or IP";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(15, 27);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(157, 20);
            this.txtHost.TabIndex = 22;
            this.txtHost.Text = "10.0.2.15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Service Port";
            // 
            // numericPort
            // 
            this.numericPort.Location = new System.Drawing.Point(15, 76);
            this.numericPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(93, 20);
            this.numericPort.TabIndex = 25;
            this.numericPort.Value = new decimal(new int[] {
            9990,
            0,
            0,
            0});
            // 
            // progressBarTask
            // 
            this.progressBarTask.Location = new System.Drawing.Point(22, 427);
            this.progressBarTask.MarqueeAnimationSpeed = 0;
            this.progressBarTask.Minimum = 1;
            this.progressBarTask.Name = "progressBarTask";
            this.progressBarTask.Size = new System.Drawing.Size(182, 23);
            this.progressBarTask.Step = 1;
            this.progressBarTask.TabIndex = 33;
            this.progressBarTask.Value = 1;
            this.progressBarTask.Visible = false;
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(228, 427);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(65, 23);
            this.btnRun.TabIndex = 32;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.progressBarTask);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.lblNotification);
            this.Name = "FrmSettings";
            this.Size = new System.Drawing.Size(316, 468);
            this.tabSettings.ResumeLayout(false);
            this.tabJobDetails.ResumeLayout(false);
            this.tabJobDetails.PerformLayout();
            this.groupBoxTask.ResumeLayout(false);
            this.groupBoxTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTask)).EndInit();
            this.tabServerDetails.ResumeLayout(false);
            this.tabServerDetails.PerformLayout();
            this.groupBoxAneka.ResumeLayout(false);
            this.groupBoxAneka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAnekaPort)).EndInit();
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
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.CheckBox checkBoxAneka;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxTask;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.ComboBox comboJobExecution;
        private System.Windows.Forms.Label lblJobExecution;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView dataGridTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskPath;
        private System.Windows.Forms.ProgressBar progressBarTask;
        private System.Windows.Forms.GroupBox groupBoxAneka;
        private System.Windows.Forms.NumericUpDown numericAnekaPort;
        private System.Windows.Forms.TextBox txtAnekaHost;
        private System.Windows.Forms.Label lblLibraryDir;
        private System.Windows.Forms.Label lblAnekaPort;
        private System.Windows.Forms.Label lblAnekaHost;
        private System.Windows.Forms.TextBox txtAnekaPassword;
        private System.Windows.Forms.TextBox txtAnekaUsername;
        private System.Windows.Forms.Label lblAnekaPassword;
        private System.Windows.Forms.Label lblAnekaUsername;
        private System.Windows.Forms.TextBox txtLibraryDir;
    }
}
