using System;
using System.Diagnostics;
using Aneka.Tasks;
using System.Text.RegularExpressions;

namespace ExcelCloudAddIn
{
    [Serializable]
    public class AnekaExecutor : ITask
    {
        /// <summary>
        /// Gets, sets the task ID for each execution
        /// </summary>
        public int taskID { get; set; }

        private String task, args;
        public string result;

        public AnekaExecutor(String task, String args) { this.task = task; this.args = args; }

        public void Execute()
        {
            try
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = task,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                proc.Start();
                while (!proc.StandardOutput.EndOfStream)
                {
                    result = proc.StandardOutput.ReadLine();
                    Trace.WriteLine(result);
                }
                while (proc.StandardError.EndOfStream)
                {
                    string line = proc.StandardError.ReadLine();
                    Trace.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
    }
}
