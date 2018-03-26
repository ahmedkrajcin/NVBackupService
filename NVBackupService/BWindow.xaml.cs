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
    /// Interaction logic for BWindow.xaml
    /// </summary>
    public partial class BWindow : Window

        
           
    {     BackupTask backupTask ;
       
        public BWindow()
        {
            InitializeComponent();
           
        backupTask=((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem);

            DBFName.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).DBFName;
            DBClear.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).DBClear.ToString();
            DType.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).DType;
            SQLCString.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).SQLCString;
            SQLDName.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).SQLDName;
            BFolder.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).BFolder;
            RFolder.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).RFolder;
            LFolder.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).LFolder;
            BF1.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).BF1;
            BF2.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).BF2;
            CBFolder.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).CBFolder.ToString();
            CRFolder.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).CRFolder.ToString();
            CLFolder.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).CLFolder.ToString();
            CBF1.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).CBF1.ToString();
            CBF2.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).CBF2.ToString();
            Name.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).Name;

            TaskActive.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).TaskActive.ToString();
            TaskStart.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).TaskStart;
            TaskEnd.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).TaskEnd;
            TaskRepeat.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).TaskRepeat.ToString();
            TaskLast.Text = ((BackupTask)((MainWindow)Application.Current.MainWindow).backupListBox.SelectedItem).TaskLast;


        }

       

        private void saveButton_Click_1(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).BList.Remove(backupTask);
            ((MainWindow)Application.Current.MainWindow).backupListBox.ItemsSource = null;
            ((MainWindow)Application.Current.MainWindow).backupItemListView.ItemsSource = null;

            ((MainWindow)Application.Current.MainWindow).backupListBox.ItemsSource = ((MainWindow)Application.Current.MainWindow).BList;
            ((MainWindow)Application.Current.MainWindow).BList.Add(new BackupTask()
            {
                DBFName = DBFName.Text,
                DBClear = Int32.Parse(DBClear.Text),
                DType = DType.Text,
                SQLCString = SQLCString.Text,
                SQLDName = SQLDName.Text,
                BFolder = BFolder.Text,
                RFolder = RFolder.Text,
                LFolder = LFolder.Text,
                BF1 = BF1.Text,
                BF2 = BF2.Text,
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
