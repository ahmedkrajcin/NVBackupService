using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVBackupService
{
    public class FolderTask
    {
        public string DBFName { get; set; }
        public int DBClear { get; set; }
        public string FPath { get; set; }
        public string Name { get; set; }
        public bool TaskActive { get; set; }
        public string TaskStart { get; set; }
        public string TaskEnd { get; set; }
        public int TaskRepeat { get; set; }
        public string TaskLast { get; set; }
    }
}
