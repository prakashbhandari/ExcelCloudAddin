using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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

        private static FrmSettings frmSettings = null;
        private static OpenFileDialog ofd = new OpenFileDialog();
        private static Job job;

        public FrmSettings()
        {
            InitializeComponent();
            frmSettings = this;
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
                this.txtLibraryDir.Text = ofd.FileName.Replace(ofd.SafeFileName, "");
            }
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in this.dataGridTask.SelectedCells)
            {
                if (cell.Selected)
                {
                    this.dataGridTask.Rows.RemoveAt(cell.RowIndex);
                }
            }
        }

        private void checkBoxAneka_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxAneka.Enabled = this.checkBoxAneka.Checked;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            this.lblNotification.Text = "";

            if (IsFrmValid())
            {
                job = new Job();
                PrepareJob();
                job.SubmitJob();
            }
        }

        public bool IsFrmValid()
        {
            if (this.txtInputCells.Text == string.Empty
                || this.txtOutputCells.Text == string.Empty
                || this.comboJobExecution.SelectedIndex == -1
                || this.txtHost.Text == string.Empty
                || this.numericPort.Value <= 0
                || this.txtLibraryDir.Text == string.Empty)
            {
                SetStatus(0);
                return false;
            }
            else
            {
                if (this.checkBoxAneka.Checked &&
                    (this.txtAnekaHost.Text == string.Empty
                    || this.numericAnekaPort.Value <= 0
                    || this.txtAnekaPassword.Text == string.Empty
                    || this.txtAnekaPassword.Text == string.Empty)
                )
                {
                    SetStatus(0);
                    return false;
                }
                return true;
            }
        }

        // Summary:
        //     Assign 
        //
        // Returns:
        //     
        public void PrepareJob()
        {
            try
            {
                SetStatus(1);
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
                        job.tasks[dr.Cells["taskName"].Value.ToString()] = dr.Cells["taskPath"].Value.ToString();
                    }
                }
                job.jobExecution = this.comboJobExecution.Text;
                job.numTasks = (this.comboJobExecution.Text.Equals("Row based")) ? inputRange.Rows.Count : inputRange.Columns.Count;
                job.numParams = (this.comboJobExecution.Text.Equals("Row based")) ? inputRange.Columns.Count : inputRange.Rows.Count;

                // Set Server details
                job.usingAneka = this.checkBoxAneka.Checked;
                job.serverDetails["host"] = this.txtHost.Text;
                job.serverDetails["port"] = Regex.Match((string)this.numericPort.Value.ToString(), @"\d+").Value;
                job.serverDetails["libraryDir"] = this.txtLibraryDir.Text;

                // Set Aneka details
                job.anekaDetails["host"] = this.txtAnekaHost.Text;
                job.anekaDetails["port"] = Regex.Match((string)this.numericAnekaPort.Value.ToString(), @"\d+").Value;
                job.anekaDetails["username"] = this.txtAnekaUsername.Text;
                job.anekaDetails["password"] = this.txtAnekaPassword.Text;

                // Set Excel details
                job.outputRange = outputRange;
                Trace.WriteLine("Job Configured");
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
        }


        public static void SetStatus(int status)
        {
            switch (status)
            {
                case 0:
                    frmSettings.lblNotification.ForeColor = System.Drawing.Color.Red;
                    frmSettings.lblNotification.Text = "Please fill all the fields before submitting task";
                    break;
                case 1:
                    frmSettings.lblNotification.ForeColor = System.Drawing.Color.Blue;
                    frmSettings.lblNotification.Text = "Preparing job...";
                    break;
                case 2:
                    frmSettings.lblNotification.ForeColor = System.Drawing.Color.Blue;
                    frmSettings.lblNotification.Text = "Running job...";
                    // Progressbar can be shown only after the job has been prepared
                    ToggleProgress(true);
                    break;
                case 3:
                    frmSettings.lblNotification.ForeColor = System.Drawing.Color.Green;
                    frmSettings.lblNotification.Text = "Job completed succesfully";
                    if (frmSettings.progressBarTask.Value == frmSettings.progressBarTask.Maximum)
                    {
                        // Wait 1 second for the progressbar animation 
                        // to finish loading completely
                        System.Threading.Thread.Sleep(1000);
                    }
                    ToggleProgress(false);
                    break;
                case 4:
                    frmSettings.lblNotification.ForeColor = System.Drawing.Color.Red;
                    frmSettings.lblNotification.Text = "Error Encountered. Check log for more information...";
                    ToggleProgress(false);
                    break;
                case 5:
                    frmSettings.lblNotification.ForeColor = System.Drawing.Color.Red;
                    frmSettings.lblNotification.Text = "Error Encountered. Could not connect to server...";
                    ToggleProgress(false);
                    break;
            }
        }

        public static void UpdateProgress()
        {
            frmSettings.progressBarTask.PerformStep();
        }

        public static void ToggleProgress(bool enable)
        {
            if (enable)
            {
                // Reset the progressbar
                frmSettings.progressBarTask.Visible = true;
                frmSettings.progressBarTask.Minimum = 1;
                // To display job preparation and communication as some part of progress
                // add total progressbar value  as one more than total tasks
                frmSettings.progressBarTask.Maximum = (job.numTasks * (frmSettings.dataGridTask.Rows.Count - 1)) + 1;
                frmSettings.progressBarTask.Step = 1;
                frmSettings.progressBarTask.Value = 2;

                // Disable the form and Run button
                frmSettings.tabSettings.Enabled = false;
                frmSettings.btnRun.Enabled = false;
            }
            else
            {
                // Once progress completed enable the forma
                // and display the Run button
                frmSettings.progressBarTask.Visible = false;
                frmSettings.tabSettings.Enabled = true;
                frmSettings.btnRun.Enabled = true;
            }
        }
    }
}