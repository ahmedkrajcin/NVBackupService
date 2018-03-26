using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NVBackupService
{
    /// <summary>
    /// Interaction logic for AddBWindow.xaml
    /// </summary>
    public partial class AddBWindow : Window
    {
        public AddBWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).BList.Add(new BackupTask()
            {
                DBFName = DBFName.Text,
                DBClear = Int32.Parse(DBClear.Text),
                DType = DType.Text,
                SQLCString = SQLCString.Text,
                SQLDName = SQLDName.Text,
                BFolder = BFolder.Text,
                RFolder = BFolder.Text,
                LFolder = BFolder.Text,
                BF1 = "",
                BF2 = "",
                CBFolder = Int32.Parse(CBFolder.Text),
                CRFolder = Int32.Parse(CRFolder.Text),
                CLFolder = Int32.Parse(CLFolder.Text),
                CBF1 = Int32.Parse(CBF1.Text),
                CBF2 = Int32.Parse(CBF2.Text),
                Name = Name.Text,
                TaskActive = Convert.ToBoolean(TaskActive.Text),
                TaskStart = TaskStart.Text,
                TaskEnd = TaskEnd.Text,
                TaskRepeat = Int32.Parse(TaskRepeat.Text),
                TaskLast = TaskLast.Text
            });
            ((MainWindow)Application.Current.MainWindow).backupListBox.ItemsSource = null;
            ((MainWindow)Application.Current.MainWindow).backupListBox.ItemsSource = ((MainWindow)Application.Current.MainWindow).BList;
            this.Close();
        }
    }
}
