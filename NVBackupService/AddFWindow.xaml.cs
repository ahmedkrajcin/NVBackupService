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
    /// Interaction logic for AddFWindow.xaml
    /// </summary>
    public partial class AddFWindow : Window
    {
        public AddFWindow()
        {   
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
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
