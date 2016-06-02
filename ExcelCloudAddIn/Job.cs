using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Aneka;
using Aneka.Tasks;
using Aneka.Entity;
using Aneka.Security;
using Aneka.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.IO;
using Aneka.Data.Entity;
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
        private static AutoResetEvent semaphore = null;
        private static AnekaApplication<AnekaTask, TaskManager> app = null;
        private static int failed;
        private static int completed;
        private static int total;

        // Excel attributes
        public Excel.Range outputRange;
        Excel.Range outputCell;
        Excel.Worksheet activeWorksheet = ((Excel.Worksheet)Globals.ThisAddIn.Application.ActiveSheet);

        public void SubmitJob()
        {
            if (this.usingAneka)
            {
                AnekaTask aTask = null;
                Configuration conf = null;
                try
                {
                    Logger.Start();
                    semaphore = new AutoResetEvent(false);
                    conf = Configuration.GetConfiguration();
                    conf.UseFileTransfer = true;
                    conf.Workspace = ".";
                    conf.SingleSubmission = false;
                    conf.ResubmitMode = ResubmitMode.AUTO;
                    conf.PollingTime = 1000;
                    string anekaUrl = "tcp://" + serverDetails["host"] + ":" + serverDetails["port"] + "/Aneka";
                    conf.SchedulerUri = new Uri(anekaUrl, UriKind.Absolute);
                    conf.UserCredential = new UserCredentials(serverDetails["username"], serverDetails["password"]);

                    app = new AnekaApplication<AnekaTask, TaskManager>(conf);
                    app.WorkUnitFailed += new EventHandler<WorkUnitEventArgs<AnekaTask>>(app_workUnitFailed);
                    app.WorkUnitFinished += new EventHandler<WorkUnitEventArgs<AnekaTask>>(app_workUnitFinished);
                    app.ApplicationFinished += new EventHandler<ApplicationEventArgs>(app_applicationFinished);

                    total = numTasks;
                    completed = 0;
                    failed = 0;

                    FrmSettings.SetStatus(2);
                    int taskId = 1;
                    foreach (KeyValuePair<string, string> taskFile in tasks)
                    {
                        app.AddSharedFile(taskFile.Key);
                        for (int i = 0; i < numTasks; i++)
                        {
                            args = String.Empty;
                            for (int j = 0; j < numParams; j++)
                            {
                                args += (jobExecution.Equals("Row based")) ? inputDatas[(i * numParams) + j] + " " : inputDatas[(j * numTasks) + i] + " ";
                            }

                            Debug.WriteLine("Running task:" + taskFile.Value);
                            TaskExecutor anekaExecutor = new TaskExecutor(taskFile.Value, args);

                            anekaExecutor.taskID = taskId;
                            aTask = new AnekaTask(anekaExecutor);

                            app.ExecuteWorkUnit(aTask);

                            taskId++;
                        }
                    }
                    Debug.WriteLine("Jobs Completed");
                }
                catch (NullReferenceException nre)
                {
                    Debug.WriteLine(nre.ToString());
                    FrmSettings.SetStatus(4);
                }
                catch (Exception e)
                {
                    IOUtil.DumpErrorReport(e, "Excel Cloud Addin - Aneka Error");
                    Debug.WriteLine(e.ToString());
                    FrmSettings.SetStatus(4);
                }
                finally
                {
                    Logger.Stop();
                }
            }
            else
            {
                new AddinService();
                AddinService.StartClient(serverDetails["host"], Int32.Parse(serverDetails["port"]));

                AddinService.sendDone = new ManualResetEvent(false);
                AddinService.receiveDone = new ManualResetEvent(false);

                FrmSettings.SetStatus(2);
                // Send jobs to server
                string requestQuery = JsonConvert.SerializeObject(this);
                AddinService.Send(requestQuery);
                AddinService.sendDone.WaitOne();
                // Send tasks sending completed
                AddinService.Send("EOF");
                AddinService.sendDone.WaitOne();

                while (true)
                {
                    // Receive the result from the server
                    AddinService.Receive();
                    AddinService.receiveDone.WaitOne();

                    if (AddinService.response.Equals("EOF"))
                    {
                        break;
                    }
                    try
                    {
                        JObject responseObj = JObject.Parse(AddinService.response);
                        int taskID = Convert.ToInt32(Regex.Match((string)responseObj["taskID"], @"\d+").Value);
                        string taskOutput = (string)responseObj["result"];

                        outputCell = (Excel.Range)this.outputRange.Item[taskID];
                        outputCell.Value2 = taskOutput;
                        FrmSettings.UpdateProgress();
                    }
                    catch (Newtonsoft.Json.JsonReaderException jre)
                    {
                        Debug.WriteLine("JsonReader Exception: " + jre.ToString());
                    }
                }

                // Display the task completion notification
                FrmSettings.SetStatus(3);

                // Release the socket
                AddinService.CloseConnection();
            }
        }

        private static void app_applicationFinished(object sender, ApplicationEventArgs e)
        {
            semaphore.Set();
            FrmSettings.SetStatus(3);
        }

        private static void app_workUnitAborted(object sender, WorkUnitEventArgs<AnekaTask> e)
        {
            Debug.WriteLine("WorkUnit Aborted");
        }

        private void app_workUnitFinished(object sender, WorkUnitEventArgs<AnekaTask> e)
        {
            Debug.WriteLine("WorkUnit Completed");
            completed = completed + 1;
            FrmSettings.UpdateProgress();
            if (completed == total)
            {
                app.StopExecution();
            }

            string taskOutput = ((TaskExecutor)e.WorkUnit.UserTask).result;
            int taskID = ((TaskExecutor)e.WorkUnit.UserTask).taskID;
            outputCell = (Excel.Range)this.outputRange.Item[taskID];
            outputCell.Value2 = taskOutput;
        }

        private static void app_workUnitFailed(object sender, WorkUnitEventArgs<AnekaTask> e)
        {
            Debug.WriteLine("WorkUnit Failed");
            total = total - 1;
            FrmSettings.UpdateProgress();
            if (completed == total)
            {
                app.StopExecution();
            }
            failed = failed + 1;
        }
    }
}