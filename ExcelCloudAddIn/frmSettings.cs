using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ExcelCloudAddIn
{
    public partial class FrmSettings : UserControl
    {
        Excel.Range inputRange;
        Excel.Range outputRange;

        OpenFileDialog ofd = new OpenFileDialog();
        Job job = new Job();

        public FrmSettings()
        {
            InitializeComponent();
        }

        private void btnSelectInputCells_Click(object sender, EventArgs e)
        {
            inputRange = Globals.ThisAddIn.Application.Selection as Excel.Range;
            if (inputRange != null)
            {
                this.txtInputCells.Text = inputRange.Address;
            }
        }

        private void btnSelectOutputCells_Click(object sender, EventArgs e)
        {
            outputRange = Globals.ThisAddIn.Application.Selection as Excel.Range;
            if (outputRange != null)
            {
                this.txtOutputCells.Text = outputRange.Address;
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.dataGridTask.Rows.Add(ofd.SafeFileName, ofd.FileName);
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridTask.SelectedRows)
            {
                this.dataGridTask.Rows.RemoveAt(item.Index);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (IsFrmValid())
            {
                this.ConfigureJob();
                this.job.SubmitJob();
            }
        }

        public bool IsFrmValid()
        {
            if (this.txtInputCells.Text == string.Empty
                || this.txtOutputCells.Text == string.Empty
                || this.comboInputType.SelectedIndex == -1
                || this.comboJobExecution.SelectedIndex == -1
                || this.txtHost.Text == string.Empty
                || this.numericPort.Value <= 0
                || this.txtUsername.Text == string.Empty
                || this.txtPassword.Text == string.Empty)
            {
                this.SetNotification(0);
                return false;
            }
            else
            {
                return true;
            }
        }

        // Summary:
        //     Assign 
        //
        // Returns:
        //     
        public void ConfigureJob()
        {
            try
            {
                this.SetNotification(1);
                // Set Job details
                Excel.Range inputParam;
                for (int i = 1; i <= inputRange.Count; i++)
                {
                    inputParam = (Excel.Range)inputRange.Item[i];
                    job.inputDatas.Add(inputParam.Value2 == null ? "0" : inputParam.Value2.ToString());
                }

                foreach (DataGridViewRow dr in this.dataGridTask.Rows)
                {
                    if (dr.Cells["taskPath"].Value != null)
                    {
                        job.tasks.Add(dr.Cells["taskPath"].Value.ToString());
                    }
                }
                job.inputType = this.comboInputType.Text;
                job.jobExecution = this.comboJobExecution.Text;
                job.numRows = inputRange.Rows.Count;
                job.numColumns = inputRange.Columns.Count;

                // Set Server details
                job.usingAneka = this.checkBoxAneka.Checked;
                job.serverDetails["host"] = this.txtHost.Text;
                job.serverDetails["port"] = Regex.Match((string)this.numericPort.Value.ToString(), @"\d+").Value;
                job.serverDetails["username"] = this.txtUsername.Text;
                job.serverDetails["password"] = this.txtPassword.Text;
                
                // Set Excel details
                job.outputRange = outputRange;
                Trace.WriteLine("Job Configured");
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
        }
        

        public void SetNotification(int status)
        {
            switch (status)
            {
                case 0:
                    this.lblNotification.ForeColor = System.Drawing.Color.Red;
                    this.lblNotification.Text = "Please fill all the fields before submitting task";
                    break;
                case 1:
                    this.lblNotification.ForeColor = System.Drawing.Color.Blue;
                    this.lblNotification.Text = "Configuring job...";
                    break;
                case 2:
                    this.lblNotification.ForeColor = System.Drawing.Color.Blue;
                    this.lblNotification.Text = "Submitting tasks...";
                    break;
                case 3:
                    this.lblNotification.ForeColor = System.Drawing.Color.Green;
                    this.lblNotification.Text = "Running tasks...";
                    break;
                case 4:
                    this.lblNotification.ForeColor = System.Drawing.Color.Green;
                    this.lblNotification.Text = "Task completed succesfully";
                    break;
            }
        }
    }
}
