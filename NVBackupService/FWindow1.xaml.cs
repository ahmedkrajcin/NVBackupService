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
    /// Interaction logic for FWindow1.xaml
    /// </summary>
    public partial class FWindow1 : Window
    {
        FolderTask folderTask ;
        public FWindow1()
        {
            InitializeComponent();

            folderTask = ((FolderTask)((MainWindow)Application.Current.MainWindow).folderListBox.SelectedItem);

            DBFName.Text = ((FolderTask)((MainWindow)Application.Current.MainWindow).folderListBox.SelectedItem).DBFName;
            DBClear.Text = ((FolderTask)((MainWindow)Application.Current.MainWindow).folderListBox.SelectedItem).DBClear.ToString();
            FPath.Text = ((FolderTask)((MainWindow)Application.Current.MainWindow).folderListBox.SelectedItem).FPath;
            TaskActive.Text = ((FolderTask)((MainWindow)Application.Current.MainWindow).folderListBox.SelectedItem).TaskActive.ToString();
            TaskStart.Text = ((FolderTask)((MainWindow)Application.Current.MainWindow).folderListBox.SelectedItem).TaskStart;
            TaskEnd.Text = ((FolderTask)((MainWindow)Application.Current.MainWindow).folderListBox.SelectedItem).TaskEnd;
            TaskRepeat.Text = ((FolderTask)((MainWindow)Application.Current.MainWindow).folderListBox.SelectedItem).TaskRepeat.ToString();
            TaskLast.Text = ((FolderTask)((MainWindow)Application.Current.MainWindow).folderListBox.SelectedItem).TaskLast;


        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).FList.Remove(folderTask);
            ((MainWindow)Application.Current.MainWindow).backupListBox.ItemsSource = null;
            ((MainWindow)Application.Current.MainWindow).backupListBox.ItemsSource = ((MainWindow)Application.Current.MainWindow).FList;
            ((MainWindow)Application.Current.MainWindow).FList.Add(new FolderTask()
            {
                DBFName = DBFName.Text,
                DBClear = Int32.Parse(DBClear.Text),
                FPath = FPath.Text,
                Name = Name.Text,
                TaskActive = Convert.ToBoolean(TaskActive.Text),
                TaskStart = TaskStart.Text,
                TaskEnd = TaskEnd.Text,
                TaskRepeat = Int32.Parse(TaskRepeat.Text),
                TaskLast = TaskLast.Text
            });
            ((MainWindow)Application.Current.MainWindow).folderListBox.ItemsSource = null;
            ((MainWindow)Application.Current.MainWindow).folderListBox.ItemsSource = ((MainWindow)Application.Current.MainWindow).FList;
            this.Close();

        }
    }
}
