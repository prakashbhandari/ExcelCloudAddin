using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aneka;
using Aneka.Entity;
using Aneka.Tasks;
using Aneka.Security;
using System.Threading;

namespace ExcelCloudAddIn
{
        [Serializable]
        public class Sum : ITask
        {
            public int a, b;
            public int result;
            public int taskID;
            public Sum(int a, int b) { this.a = a; this.b = b; }
            public void Execute()
            {
                result = a + b;
            }
        }
}
