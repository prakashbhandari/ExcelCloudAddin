using System;
using System.Collections.Generic;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace ExcelCloudAddIn
{
    class Job
    {
        // Job attributes
        public List<string> inputDatas = new List<string>();
        public IDictionary<string, string> tasks = new Dictionary<string, string>();
        public string jobExecution = String.Empty;
        public int numTasks;
        public int numParams;

        string args = String.Empty;

        // Server attributes
        public bool usingAneka;
        public IDictionary<string, string> serverDetails = new Dictionary<string, string>();

        // Aneka attributes
        public IDictionary<string, string> anekaDetails = new Dictionary<string, string>();

        // Excel attributes
        public Excel.Range outputRange;
        Excel.Range outputCell;
        Excel.Worksheet activeWorksheet = ((Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet);

        public void SubmitJob()
        {
            AsyncConnection.sendDone = new ManualResetEvent(false);

            new AsyncConnection();
            AsyncConnection.StartClient(serverDetails["host"], Int32.Parse(serverDetails["port"]));
            AsyncConnection.connectDone.WaitOne();

            FrmSettings.SetStatus(2);
            // Send jobs to server
            string requestQuery = JsonConvert.SerializeObject(this);
            AsyncConnection.Send(requestQuery);
            AsyncConnection.sendDone.WaitOne();
            // Send tasks sending completed
            AsyncConnection.Send("EOF");
            AsyncConnection.sendDone.WaitOne();

            while (true)
            {
                AsyncConnection.receiveDone = new ManualResetEvent(false);

                int taskID = 0;
                // Receive the result from the server
                AsyncConnection.Receive();
                AsyncConnection.receiveDone.WaitOne();

                if (AsyncConnection.response.Equals("EOF"))
                {
                    break;
                }
                try
                {
                    JObject responseObj = JObject.Parse(AsyncConnection.response);
                    taskID = Convert.ToInt32(Regex.Match((string)responseObj["taskID"], @"\d+").Value);
                    string taskOutput = (string)responseObj["result"];

                    outputCell = (Excel.Range)this.outputRange.Item[taskID];
                    outputCell.Value2 = taskOutput;
                    FrmSettings.UpdateProgress();
                }
                catch (JsonReaderException jre)
                {
                    Debug.WriteLine("JsonReader Exception: " + jre.ToString());
                }
            }

            // Display the task completion notification
            FrmSettings.SetStatus(3);

            // Release the socket
            AsyncConnection.CloseConnection();
        }
    }
}