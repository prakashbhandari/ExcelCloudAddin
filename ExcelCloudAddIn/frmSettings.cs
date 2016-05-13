using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;

namespace ExcelCloudAddIn
{
    public partial class frmSettings : UserControl
    {
        Excel.Range inputRange;
        Excel.Range outputRange;
        OpenFileDialog ofd = new OpenFileDialog();
        Job request;

        public frmSettings()
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

        private void checkBoxAneka_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAneka.Checked == true)
            {
                this.txtAnekaMaster.Enabled = true;
                this.numericAnekaServicePort.Enabled = true;
                this.txtAnekaUsername.Enabled = true;
                this.txtAnekaPassword.Enabled = true;
            }
            else
            {
                this.txtAnekaMaster.Enabled = false;
                this.numericAnekaServicePort.Enabled = false;
                this.txtAnekaUsername.Enabled = false;
                this.txtAnekaPassword.Enabled = false;
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
            if (this.txtInputCells.Text.Equals("") || this.txtOutputCells.Text.Equals("") || this.txtServer.Text.Equals("") || this.numericPort.Value.ToString().Equals(""))
            {
                this.setNotification(0);
            }
            else
            {
                this.configureJob();
                this.setNotification(1);

                String requestQuery = JsonConvert.SerializeObject(request);
                Globals.ThisAddIn.SubmitTask(this.txtServer.Text, Decimal.ToInt32(this.numericPort.Value), requestQuery);
            }
        }

        public void configureJob()
        {
            request = new Job();
            // Set Job details for the request
            Excel.Range inputParam;
            for (int i = 1; i <= inputRange.Count; i++)
            {
                inputParam = (Excel.Range)inputRange.Item[i];
                request.inputData.Add(inputParam.Value2 == null ? "0" : inputParam.Value2.ToString());
            }

            foreach (DataGridViewRow dr in this.dataGridTask.Rows)
            {
                if (dr.Cells["taskPath"].Value != null)
                {
                    request.task.Add(dr.Cells["taskPath"].Value.ToString());
                }
            }
            request.inputType = this.inputType.Text;
            request.jobExecution = this.jobExecution.Text;

            // Set Server details for the request
            request.libraryDir = this.txtLibraryDir.Text;
            // Aneka Details
            request.usingAneka = this.checkBoxAneka.Checked;
            if (this.checkBoxAneka.Checked == true)
            {
                request.anekaDetails["host"] = this.txtAnekaMaster.Text;
                request.anekaDetails["port"] = this.numericAnekaServicePort.Value.ToString();
                request.anekaDetails["username"] = this.txtAnekaUsername.Text;
                request.anekaDetails["password"] = this.txtAnekaPassword.Text;
            }
        }

        public void setNotification(int status)
        {
            switch (status)
            {
                // Error in form
                case 0:
                    this.lblNotification.ForeColor = System.Drawing.Color.Red;
                    this.lblNotification.Text = "Please fill all the fields before submitting task";
                    break;
                // Task submitted
                case 1:
                    this.lblNotification.ForeColor = System.Drawing.Color.Green;
                    this.lblNotification.Text = "Submitting task to server...";
                    break;
                // Task completed successfully
                case 2:
                    this.lblNotification.ForeColor = System.Drawing.Color.Blue;
                    this.lblNotification.Text = "Task completed succesfully";
                    break;
            }
        }
    }
}
