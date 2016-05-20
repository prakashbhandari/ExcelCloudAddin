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
            this.comboInputType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTask = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.lblInputCells = new System.Windows.Forms.Label();
            this.lblOutputCells = new System.Windows.Forms.Label();
            this.txtOutputCells = new System.Windows.Forms.TextBox();
            this.txtInputCells = new System.Windows.Forms.TextBox();
            this.btnSelectOutputCells = new System.Windows.Forms.Button();
            this.btnSelectInputCells = new System.Windows.Forms.Button();
            this.tabServerDetails = new System.Windows.Forms.TabPage();
            this.checkBoxAneka = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.btnRun = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.tabJobDetails.SuspendLayout();
            this.groupBoxTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTask)).BeginInit();
            this.tabServerDetails.SuspendLayout();
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
            this.groupBoxTask.Controls.Add(this.comboInputType);
            this.groupBoxTask.Controls.Add(this.label1);
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
            this.dataGridTask.Size = new System.Drawing.Size(224, 77);
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
            // comboInputType
            // 
            this.comboInputType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInputType.FormattingEnabled = true;
            this.comboInputType.Items.AddRange(new object[] {
            "Parameter",
            "File"});
            this.comboInputType.Location = new System.Drawing.Point(10, 145);
            this.comboInputType.Name = "comboInputType";
            this.comboInputType.Size = new System.Drawing.Size(134, 21);
            this.comboInputType.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Input Type";
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
            this.tabServerDetails.Controls.Add(this.checkBoxAneka);
            this.tabServerDetails.Controls.Add(this.txtPassword);
            this.tabServerDetails.Controls.Add(this.label2);
            this.tabServerDetails.Controls.Add(this.lblPassword);
            this.tabServerDetails.Controls.Add(this.txtHost);
            this.tabServerDetails.Controls.Add(this.txtUsername);
            this.tabServerDetails.Controls.Add(this.label3);
            this.tabServerDetails.Controls.Add(this.label4);
            this.tabServerDetails.Controls.Add(this.numericPort);
            this.tabServerDetails.Location = new System.Drawing.Point(4, 25);
            this.tabServerDetails.Name = "tabServerDetails";
            this.tabServerDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabServerDetails.Size = new System.Drawing.Size(271, 351);
            this.tabServerDetails.TabIndex = 1;
            this.tabServerDetails.Text = "Server Details";
            this.tabServerDetails.UseVisualStyleBackColor = true;
            // 
            // checkBoxAneka
            // 
            this.checkBoxAneka.AutoSize = true;
            this.checkBoxAneka.Checked = true;
            this.checkBoxAneka.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAneka.Location = new System.Drawing.Point(15, 6);
            this.checkBoxAneka.Name = "checkBoxAneka";
            this.checkBoxAneka.Size = new System.Drawing.Size(93, 17);
            this.checkBoxAneka.TabIndex = 20;
            this.checkBoxAneka.Text = "Using Aneka?";
            this.checkBoxAneka.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(13, 199);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 29;
            this.txtPassword.Text = "prakash191";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Host or IP";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 180);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 28;
            this.lblPassword.Text = "Password";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(15, 50);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(157, 20);
            this.txtHost.TabIndex = 22;
            this.txtHost.Text = "10.0.2.15";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(15, 150);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(110, 20);
            this.txtUsername.TabIndex = 27;
            this.txtUsername.Text = "prakashbhandari";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Service Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Username";
            // 
            // numericPort
            // 
            this.numericPort.Location = new System.Drawing.Point(15, 101);
            this.numericPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(93, 20);
            this.numericPort.TabIndex = 25;
            this.numericPort.Value = new decimal(new int[] {
            9090,
            0,
            0,
            0});
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.Location = new System.Drawing.Point(228, 435);
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
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tabSettings);
            this.Controls.Add(this.lblNotification);
            this.Name = "FrmSettings";
            this.Size = new System.Drawing.Size(316, 475);
            this.tabSettings.ResumeLayout(false);
            this.tabJobDetails.ResumeLayout(false);
            this.tabJobDetails.PerformLayout();
            this.groupBoxTask.ResumeLayout(false);
            this.groupBoxTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTask)).EndInit();
            this.tabServerDetails.ResumeLayout(false);
            this.tabServerDetails.PerformLayout();
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
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.GroupBox groupBoxTask;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.ComboBox comboJobExecution;
        private System.Windows.Forms.Label lblJobExecution;
        private System.Windows.Forms.ComboBox comboInputType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTask;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.DataGridView dataGridTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskPath;
    }
}
