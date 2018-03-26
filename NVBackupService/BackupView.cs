using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVBackupService
{
    public sealed class BackupViewModel
    {
        public ObservableCollection<BackupTask> BTasks { get; private set; }
        

        public BackupViewModel()
        {
            BTasks = new ObservableCollection<BackupTask>();
        }
    }
    public sealed class FolderViewModel
    {
        public ObservableCollection<BackupTask> FTasks { get; private set; }

        public FolderViewModel()
        {
            FTasks = new ObservableCollection<BackupTask>();
        }
    }
}
