using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Aneka;
using Aneka.Tasks;
using Aneka.Entity;
using Aneka.Security;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace ExcelCloudAddIn
{
    class Job
    {
        // Job attributes
        public List<string> inputDatas = new List<string>();
        public List<string> tasks = new List<string>();
        public string inputType = String.Empty;
        public string jobExecution = String.Empty;
        public int numRows;
        public int numColumns;

        int numTasks;
        int numParams;
        string args = String.Empty;

        // Server attributes
        public bool usingAneka;
        public IDictionary<string, string> serverDetails = new Dictionary<string, string>();

        // Aneka attributes
        static AutoResetEvent semaphore = null;
        static AnekaApplication<AnekaTask, TaskManager> app = null;
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

                    numTasks = (jobExecution.Equals("Row based")) ? numRows : numColumns;
                    numParams = (jobExecution.Equals("Row based")) ? numColumns : numRows;

                    total = numTasks;
                    completed = 0;
                    failed = 0;

                    foreach (string task in tasks)
                    {
                        for (int i = 0; i < numTasks; i++)
                        {
                            args = String.Empty;
                            for (int j = 0; j < numParams; j++)
                            {
                                args += (jobExecution.Equals("Row based")) ? inputDatas[(i * numParams) + j] + " " : inputDatas[(j * numParams) + i] + " ";
                            }
                            Trace.WriteLine("Submitting task: " + task + "\nTask Count: " + numTasks + "\nParams: " + numParams + "\nArgs: "+args);
                            AnekaExecutor anekaExecutor = new AnekaExecutor(task, args);
                            // TaskID must start from 1 not 0.
                            anekaExecutor.taskID = i + 1;
                            aTask = new AnekaTask(anekaExecutor);
                            app.ExecuteWorkUnit(aTask);
                            Debug.WriteLine(task + " " + args);
                        }
                    }
                    semaphore.WaitOne();
                    Trace.WriteLine("Jobs Completed");
                }
                catch (Exception e)
                {
                    IOUtil.DumpErrorReport(e, "Excel Cloud Addin - Aneka Error");
                    Debug.WriteLine(e.ToString());
                }
                finally
                {
                    Logger.Stop();
                }
            }
        }

        private static void app_applicationFinished(object sender, ApplicationEventArgs e)
        {
            semaphore.Set();
        }

        private static void app_workUnitAborted(object sender, WorkUnitEventArgs<AnekaTask> e)
        {
            Trace.WriteLine("WorkUnit Aborted");
        }

        private void app_workUnitFinished(object sender, WorkUnitEventArgs<AnekaTask> e)
        {
            string taskOutput = ((AnekaExecutor)e.WorkUnit.UserTask).result;
            int taskID = ((AnekaExecutor)e.WorkUnit.UserTask).taskID;
            Trace.WriteLine("WorkUnit Finished with result: " + taskOutput);

            outputCell = (Excel.Range)this.outputRange.Item[taskID];
            outputCell.Value2 = taskOutput;

            completed = completed + 1;
            if (completed == total)
            {
                app.StopExecution();
            }
        }

        private static void app_workUnitFailed(object sender, WorkUnitEventArgs<AnekaTask> e)
        {
            Trace.WriteLine("WorkUnit Failed");
            total = total - 1;
            if (completed == total)
            {
                app.StopExecution();
            }
            failed = failed + 1;
        }
    }
}
