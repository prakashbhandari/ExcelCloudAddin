//Title        :  Job.cs
//Package      :  ExcelCloudAddIn
//Project      :  ExcelCloud
//Description  :  Job Class provides functionality to create job request and receive response
//Created on   :  June 5, 2016
//Author	   :  Prakash Bhandari

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
    /// <summary>
    /// Class Job: Holds the Job request attributes 
    /// prepares the job request string and sends it server.
    /// Once response is received for each task updates 
    /// the outputrange
    /// </summary>
    class Job
    {
        // Job attributes
        /// <summary>
        /// List of all the values in the user selected inputRange
        /// </summary>
        public List<string> inputDatas = new List<string>();
        /// <summary>
        /// List of all the executable task files
        /// </summary>
        public IDictionary<string, string> taskFiles = new Dictionary<string, string>();
        /// <summary>
        /// Job Execution type: required at server to prepare job arguments
        /// </summary>
        public string jobExecution = String.Empty;
        /// <summary>
        /// Number of tasks based on Job execution
        /// </summary>
        public int numTasks;
        /// <summary>
        /// Number of params based on Job execution
        /// </summary>
        public int numParams;

        // Server attributes
        public bool usingAneka;
        /// <summary>
        /// List of all the information host, port, library of server
        /// </summary>
        public IDictionary<string, string> serverDetails = new Dictionary<string, string>();

        // Aneka attributes
        /// <summary>
        /// List of all the attributes to connect to aneka master
        /// </summary>
        public IDictionary<string, string> anekaDetails = new Dictionary<string, string>();

        // Excel attributes
        /// <summary>
        /// Output cell range required to store output once received
        /// </summary>
        public Excel.Range outputRange;
        Excel.Range outputCell;
        /// <summary>
        /// Current worksheet
        /// </summary>
        Excel.Worksheet activeWorksheet = ((Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet);

        Thread asyncResponseThread;

        /// <summary>
        /// Connect to the server, send the job description,
        /// and listen for the response
        /// </summary>
        public void SubmitRequest()
        {
            AsyncConnection.sendDone = new ManualResetEvent(false);

            new AsyncConnection();
            AsyncConnection.StartClient(serverDetails["host"], Int32.Parse(serverDetails["port"]));
            AsyncConnection.connectDone.WaitOne();

            if(AsyncConnection.connectionStatus)
            {
                FrmSettings.SetStatus(2);
                // Send jobs to server
                string requestQuery = JsonConvert.SerializeObject(this);
                AsyncConnection.Send(requestQuery);
                AsyncConnection.sendDone.WaitOne();
                // Send task description sending completed
                AsyncConnection.Send("EOF");
                AsyncConnection.sendDone.WaitOne();

                asyncResponseThread = new Thread(new ThreadStart(this.ReceiveResponse));
                asyncResponseThread.Start();
            }
            else
            {
                FrmSettings.SetStatus(5);
            }   
        }

        /// <summary>
        /// Keep listening for reponse. Once reponse received update the
        /// Excel using the taskID number.
        /// </summary>
        private void ReceiveResponse()
        {
            while (true)
            {
                AsyncConnection.receiveDone = new ManualResetEvent(false);

                int taskID = 0;
                // Receive the result from the server
                AsyncConnection.Receive();
                AsyncConnection.receiveDone.WaitOne();

                // All data has been received, stop listening 
                if (AsyncConnection.response.Equals("EOF"))
                {
                    break;
                }
                // Error has occured at server. Update status and stop listening
                else if (AsyncConnection.response.IndexOf("Error encountered") > -1)
                {
                    FrmSettings.SetStatus(4);
                    break;
                }
                try
                {
                    // Output is received as Json string so parse it to Json Object
                    JObject responseObj = JObject.Parse(AsyncConnection.response);
                    // Grab the taskID and output from the received message
                    taskID = Convert.ToInt32(Regex.Match((string)responseObj["taskID"], @"\d+").Value);
                    string taskOutput = (string)responseObj["result"];

                    // Update the output to the Excel
                    outputCell = (Excel.Range)this.outputRange.Item[taskID];
                    outputCell.Value2 = taskOutput;

                    // Trigger progressbar update
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

            asyncResponseThread.Abort();
        }
    }
}