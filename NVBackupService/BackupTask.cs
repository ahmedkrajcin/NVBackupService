using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVBackupService
{
    public class BackupTask 
    {
        public string DBFName { get; set; }
        public int DBClear { get; set; }
        public string DType { get; set; }
        public string SQLCString { get; set; }
        public string SQLDName { get; set; }
        public string BFolder { get; set; }
        public string RFolder { get; set; }
        public string LFolder { get; set; }
        public string BF1 { get; set; }
        public string BF2 { get; set; }
        public int CBFolder { get; set; }
        public int CRFolder { get; set; }
        public int CLFolder { get; set; }
        public int CBF1 { get; set; }
        public int CBF2 { get; set; }
        public string Name { get; set; }
        public bool TaskActive { get; set; }
        public string TaskStart { get; set; }
        public string TaskEnd { get; set; }
        public int TaskRepeat { get; set; }
        public string TaskLast { get; set; }

        
    }
}
