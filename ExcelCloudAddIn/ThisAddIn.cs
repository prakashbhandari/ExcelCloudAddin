using System;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace ExcelCloudAddIn
{
    public partial class ThisAddIn
    {
        private FrmSettings addInSettings;
        private Microsoft.Office.Tools.CustomTaskPane addInSettingsPane;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            addInSettings = new FrmSettings();
            addInSettingsPane = this.CustomTaskPanes.Add(addInSettings, "Cloud AddIn Settings");
            addInSettingsPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight;
            addInSettingsPane.Width = addInSettings.Size.Width + 330;
            addInSettingsPane.Visible = true;
            addInSettingsPane.VisibleChanged += new EventHandler(addInSettings_VisibleChanged);
        }

        private void addInSettings_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons.ManageTaskPaneRibbon.toggleExcelCloud.Checked = addInSettingsPane.Visible;
        }

        public Microsoft.Office.Tools.CustomTaskPane TaskPane
        {
            get
            {
                return addInSettingsPane;
            }
        }

        public void SubmitTask(String requestQuery)
        {
            /*new AsyncConnection();
            AsyncConnection.StartClient(host, port);

            AsyncConnection.sendDone = new ManualResetEvent(false);
            AsyncConnection.receiveDone = new ManualResetEvent(false);

            // Send parameters to the Aneka Server
            AsyncConnection.Send(requestQuery);
            AsyncConnection.sendDone.WaitOne();
            // Send tasks sending completed
            AsyncConnection.Send("EOF");
            AsyncConnection.sendDone.WaitOne();

            // Write the response to the cell in excel
            Excel.Worksheet activeWorksheet = ((Excel.Worksheet)Application.ActiveSheet);
            while (true)
            {
                // Receive the result from the server
                AsyncConnection.Receive();
                AsyncConnection.receiveDone.WaitOne();

                if (AsyncConnection.response == "EOF")
                {
                    break;
                }
                try
                {
                    JObject responseObj = JObject.Parse(AsyncConnection.response);
                    int taskID = Convert.ToInt32(Regex.Match((string)responseObj["taskID"], @"\d+").Value);
                    string value = (string)responseObj["result"];

                    outputCell = (Excel.Range)outputCells.Item[taskID];

                    Excel.Range outputRange = activeWorksheet.get_Range(outputCell.Address);
                    outputRange.Value2 = value;
                }
                catch (Newtonsoft.Json.JsonReaderException jre)
                {
                    Console.WriteLine("JsonReader Exception: " + jre.ToString());
                }
            }

            // Display the task completion notification
            addInSettings.setNotification(2);

            // Release the socket
            AsyncConnection.CloseConnection();*/
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
