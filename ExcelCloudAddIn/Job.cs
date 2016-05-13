using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExcelCloudAddIn
{
    class Job
    {
        // Job details
        public List<String> inputData = new List<string>();
        public List<String> task = new List<string>();
        public String inputType;
        public String jobExecution;

        // Server details
        public String libraryDir;

        // Aneka details
        public Boolean usingAneka;
        public IDictionary<String, String> anekaDetails = new Dictionary<String, String>();

        private static int failed;
        private static int completed;
        private static int total;
        static AutoResetEvent semaphore = null;
        //static AnekaApplication<AnekaTask, TaskManager> app = null;
    }
}
