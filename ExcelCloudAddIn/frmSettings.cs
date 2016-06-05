//Title        :  FrmSettings.cs
//Package      :  ExcelCloudAddIn
//Project      :  ExcelCloud
//Description  :  Excel Cloud Addin User Interaction Form
//Created on   :  June 5, 2016
//Author	   :  Prakash Bhandari

using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ExcelCloudAddIn
{
    /// <summary>
    /// Partial Class FrmSettings: Displays a user control
    /// form where user can define jobs by interacting 
    /// with excel spreadsheet
    /// </summary>
    public partial class FrmSettings : UserControl
    {
        /// <summary>
        /// Cell Range from where the input
        /// parameter will be read
        /// </summary>
        Excel.Range inputRange;
        /// <summary>
        /// Cell Range where the output of
        /// the execution will be stored
        /// </summary>
        Excel.Range outputRange;

        /// <summary>
        /// Instance of FrmSettings to provide
        /// access to the SetStatus method from
        /// other class
        /// </summary>
        private static FrmSettings frmSettings = null;
        /// <summary>
        /// Open File Dialog to choose executable task
        /// </summary>
        private static OpenFileDialog ofd = new OpenFileDialog();
        /// <summary>
        /// Empty instance of job class
        /// </summary>
        private static Job job;

        public FrmSettings()
        {
            InitializeComponent();
            frmSettings = this;
        }

        /// <summary>
        /// On click of select input cells
        /// assign selected cells to inputRange
        /// and display the selected cells in
        /// readable format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectInputCells_Click(object sender, EventArgs e)
        {
            inputRange = Globals.ThisAddIn.Application.Selection as Excel.Range;
            if (inputRange != null)
            {
                this.txtInputCells.Text = inputRange.Address;
            }
        }

        /// <summary>
        /// On clcik on select out cells
        /// assign selected cells to outputRange
        /// and display the selected cells in
        /// readable format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectOutputCells_Click(object sender, EventArgs e)
        {
            outputRange = Globals.ThisAddIn.Application.Selection as Excel.Range;
            if (outputRange != null)
            {
                this.txtOutputCells.Text = outputRange.Address;
            }
        }

        /// <summary>
        /// open file dialog to select executable file
        /// once selected display the name and full path
        /// of file in the tasklist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.dataGridTask.Rows.Add(ofd.SafeFileName, ofd.FileName);
                this.txtLibraryDir.Text = ofd.FileName.Replace(ofd.SafeFileName, "");
            }
        }

        /// <summary>
        /// Remove the task from task list if Remove
        /// button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Toggle enabled status of AnekaGroupbox
        /// based on the checked attribute of the 
        /// the aneka checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAneka_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBoxAneka.Enabled = this.checkBoxAneka.Checked;
        }

        /// <summary>
        /// Validate the form and prepare and 
        /// submit request on clicking Run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            this.lblNotification.Text = "";

            if (IsFrmValid())
            {
                job = new Job();
                PrepareJobRequest();
                job.SubmitRequest();
            }
        }

        /// <summary>
        /// Validate if all the form fields 
        /// are correctly entered, set status
        /// to display proper notification if 
        /// required
        /// </summary>
        /// <returns>Returns true is form is valid else false</returns>
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

        /// <summary>
        /// Prepares the job by assigning values to all the
        /// relevant attributes based on the form submission
        /// </summary>
        public void PrepareJobRequest()
        {
            try
            {
                SetStatus(1);
                // Set Job details
                Excel.Range inputParam;
                // Add all the data sequentially from the input cells to
                // the inputDatas list. Replace null with 0.
                for (int i = 1; i <= inputRange.Count; i++)
                {
                    inputParam = (Excel.Range)inputRange.Item[i];
                    job.inputDatas.Add(inputParam.Value2 == null ? "0" : inputParam.Value2.ToString());
                }

                // Add all the executable tasks to the taskFiles list
                foreach (DataGridViewRow dr in this.dataGridTask.Rows)
                {
                    if (dr.Cells["taskPath"].Value != null)
                    {
                        job.taskFiles[dr.Cells["taskName"].Value.ToString()] = dr.Cells["taskPath"].Value.ToString();
                    }
                }
                job.jobExecution = this.comboJobExecution.Text;

                // Set number of tasks to number of rows if Job execution is Row based
                // else number of columns
                job.numTasks = (this.comboJobExecution.Text.Equals("Row based")) ? inputRange.Rows.Count : inputRange.Columns.Count;
                // Set number of parameter for tasks to be number of columns if Job execution
                // is Row based else number of rows
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
                Debug.WriteLine("Job Configured");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// Set the notification and toggle progressbar
        /// based on the status code received
        /// </summary>
        /// <param name="status">Status code: 0 to 5</param>
        public static void SetStatus(int status, string message = "")
        {
            switch (status)
            {
                case 0:
                    frmSettings.lblNotification.ForeColor = System.Drawing.Color.Red;
                    frmSettings.lblNotification.Text = "Please complete all fields before submitting job.";
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
                    if(frmSettings.lblNotification.InvokeRequired)
                    {
                        int val = 0;
                        int max = 0;
                        frmSettings.lblNotification.Invoke(new MethodInvoker(delegate { frmSettings.lblNotification.ForeColor = System.Drawing.Color.Green; }));
                        frmSettings.lblNotification.Invoke(new MethodInvoker(delegate { frmSettings.lblNotification.Text = "Job completed succesfully."; }));
                        frmSettings.progressBarTask.Invoke(new MethodInvoker(delegate { val = frmSettings.progressBarTask.Value; }));
                        frmSettings.progressBarTask.Invoke(new MethodInvoker(delegate { max = frmSettings.progressBarTask.Maximum; }));


                        if (val == max)
                        {
                            // Wait 1 second for the progressbar animation 
                            // to finish loading completely 
                            System.Threading.Thread.Sleep(1000);
                        }
                        ToggleProgress(false);
                    }
                    else
                    {
                        frmSettings.lblNotification.ForeColor = System.Drawing.Color.Green;
                        frmSettings.lblNotification.Text = "Job completed succesfully.";
                        if (frmSettings.progressBarTask.Value == frmSettings.progressBarTask.Maximum)
                        {
                            // Wait 1 second for the progressbar animation 
                            // to finish loading completely 
                            System.Threading.Thread.Sleep(1000);
                        }
                        ToggleProgress(false);
                    }
                    break;
                case 4:
                    if (frmSettings.lblNotification.InvokeRequired)
                    {
                        frmSettings.lblNotification.Invoke(new MethodInvoker(delegate { frmSettings.lblNotification.ForeColor = System.Drawing.Color.Red; }));

                        frmSettings.lblNotification.Invoke(new MethodInvoker(delegate
                        {
                            frmSettings.lblNotification.Text = (!message.Equals("")) ? message : "Error encountered - Check server log for more information.";
                        }));
                    }
                    else
                    {
                        frmSettings.lblNotification.ForeColor = System.Drawing.Color.Red;
                        frmSettings.lblNotification.Text = (!message.Equals("")) ? message : "Error encountered - Check server log for more information.";
                    }
                    ToggleProgress(false);
                    break;
                case 5:
                    frmSettings.lblNotification.ForeColor = System.Drawing.Color.Red;
                    frmSettings.lblNotification.Text = "Error encountered - Could not connect to server.";
                    ToggleProgress(false);
                    break;
            }
        }

        /// <summary>
        /// Step the progressbar by 1 whenever any update is received.
        /// </summary>
        public static void UpdateProgress()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (frmSettings.progressBarTask.InvokeRequired)
            {
                frmSettings.progressBarTask.Invoke(new MethodInvoker(delegate { frmSettings.progressBarTask.PerformStep(); }));
            }
            else
            {
                frmSettings.progressBarTask.PerformStep();
            }
        }

        /// <summary>
        /// Display or hide progress bar and enable/disable form.
        /// </summary>
        /// <param name="enable">Boolean: true to enable progress and disable form,
        /// false to hide progressbar and enable form</param>
        private static void ToggleProgress(bool enable)
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
                // Start progress bar at value 2 as some work is done in preparing and
                // communicating task to server
                frmSettings.progressBarTask.Value = 2;

                // Disable the form and Run button
                frmSettings.tabSettings.Enabled = false;
                frmSettings.btnRun.Enabled = false;
            }
            else
            {
                if (frmSettings.progressBarTask.InvokeRequired)
                {
                    frmSettings.progressBarTask.Invoke(new MethodInvoker(delegate { frmSettings.progressBarTask.Visible = false; }));
                    frmSettings.tabSettings.Invoke(new MethodInvoker(delegate { frmSettings.tabSettings.Enabled = true; }));
                    frmSettings.btnRun.Invoke(new MethodInvoker(delegate { frmSettings.btnRun.Enabled = true; }));
                }
                else
                {
                    // Once progress completed enable the form
                    // and display the Run button
                    frmSettings.progressBarTask.Visible = false;
                    frmSettings.tabSettings.Enabled = true;
                    frmSettings.btnRun.Enabled = true;
                }   
            }
        }
    }
}