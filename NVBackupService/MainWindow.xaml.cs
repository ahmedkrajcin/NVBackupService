using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;

namespace NVBackupService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<BackupTask> bList = new List<BackupTask>();
        public List<FolderTask> fList = new List<FolderTask>();
        List<Log> logList;
        string  taskPath=@"C:\Users\user\Desktop\JUNIOR DEVELOPER TASK\TasksConfig.xml";
        string logPath = @"C:\Users\user\Desktop\JUNIOR DEVELOPER TASK\Logs";
        XElement xel = new XElement("TasksConfig");


        public List<BackupTask> BList
        {
            get
            {
                return bList;
            }

            set
            {
                bList = value;
            }
        }

        public List<FolderTask> FList
        {
            get
            {
                return fList;
            }

            set
            {
                fList = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();


            getTasks();

            getLogFiles();
           


           // doc.Save("D:\\build.xml");

            

            
        } 
        public void getTasks()
        {   //loading xml file
            XmlDocument doc = new XmlDocument();
            doc.Load(taskPath);
            XmlNodeList bNodeList = doc.GetElementsByTagName("BackupAndUploadTask");
            XmlNodeList fNodeList = doc.GetElementsByTagName("UploadFolderTask");
           

            foreach (XmlNode backup in bNodeList)
            {

                BList.Add(new BackupTask()
                {
                    DBFName = backup.SelectSingleNode("DropBoxFolderName").Attributes["Value"].Value,
                    DBClear = Int32.Parse(backup.SelectSingleNode("DropboxClear").Attributes["Value"].Value),
                    DType = backup.SelectSingleNode("DatabaseType").Attributes["Value"].Value,
                    SQLCString = backup.SelectSingleNode("SqlConnectionString").Attributes["Value"].Value,
                    SQLDName = backup.SelectSingleNode("SqlDatabaseName").Attributes["Value"].Value,
                    BFolder = backup.SelectSingleNode("BackupsFolder").Attributes["Value"].Value,
                    RFolder = backup.SelectSingleNode("RemoteFolder").Attributes["Value"].Value,
                    LFolder = backup.SelectSingleNode("LocalFolder").Attributes["Value"].Value,
                    BF1 = backup.SelectSingleNode("BackupFolder1").Attributes["Value"].Value,
                    BF2 = backup.SelectSingleNode("BackupFolder2").Attributes["Value"].Value,
                    CBFolder = Int32.Parse(backup.SelectSingleNode("ClearBackupsFolder").Attributes["Value"].Value),
                    CRFolder = Int32.Parse(backup.SelectSingleNode("ClearRemoteFolder").Attributes["Value"].Value),
                    CLFolder = Int32.Parse(backup.SelectSingleNode("ClearLocalFolder").Attributes["Value"].Value),
                    CBF1 = Int32.Parse(backup.SelectSingleNode("ClearBackupFolder1").Attributes["Value"].Value),
                    CBF2 = Int32.Parse(backup.SelectSingleNode("ClearBackupFolder2").Attributes["Value"].Value),
                    Name = backup.SelectSingleNode("Name").Attributes["Value"].Value,
                    TaskActive = Convert.ToBoolean(backup.SelectSingleNode("TaskActive").Attributes["Value"].Value),
                    TaskStart = backup.SelectSingleNode("TaskStart").Attributes["Value"].Value,
                    TaskEnd = backup.SelectSingleNode("TaskEnd").Attributes["Value"].Value,
                    TaskRepeat = Int32.Parse(backup.SelectSingleNode("TaskRepeat").Attributes["Value"].Value),
                    TaskLast = backup.SelectSingleNode("TaskLast").Attributes["Value"].Value
                });

                //textBox.Text = backup.SelectSingleNode("Name").Attributes["Value"].Value;   
                // SelectionChanged = "backupListBox_SelectionChanged"


            }
            backupListBox.ItemsSource = BList;

            foreach (XmlNode folder in fNodeList)
            {

                FList.Add(new FolderTask()
                {
                    DBFName = folder.SelectSingleNode("DropBoxFolderName").Attributes["Value"].Value,
                    DBClear = Int32.Parse(folder.SelectSingleNode("DropboxClear").Attributes["Value"].Value),
                    FPath = folder.SelectSingleNode("FolderPath").Attributes["Value"].Value,
                    Name = folder.SelectSingleNode("Name").Attributes["Value"].Value,
                    TaskActive = Convert.ToBoolean(folder.SelectSingleNode("TaskActive").Attributes["Value"].Value),
                    TaskStart = folder.SelectSingleNode("TaskStart").Attributes["Value"].Value,
                    TaskEnd = folder.SelectSingleNode("TaskEnd").Attributes["Value"].Value,
                    TaskRepeat = Int32.Parse(folder.SelectSingleNode("TaskRepeat").Attributes["Value"].Value),
                    TaskLast = folder.SelectSingleNode("TaskLast").Attributes["Value"].Value
                });

                //textBox.Text = folder.SelectSingleNode("Name").Attributes["Value"].Value;




            }
            folderListBox.ItemsSource = FList;

        }

        public void getLogFiles()
        {
            DirectoryInfo di = new DirectoryInfo(logPath);
            FileInfo[] files = di.GetFiles("*.log");
            logList = new List<Log>();
            foreach (FileInfo file in files) {
                logList.Add(new Log()
                {
                    Name = file.Name,
                    Path= file.FullName,
                    Data= System.IO.File.ReadAllText(file.FullName)


                });
            }

            logListBox.ItemsSource = logList;


        }

        private void bViewButton_Click(object sender, RoutedEventArgs e)
        {
            List<BackupTask> bItemList = new List<BackupTask>();
            bItemList.Add((BackupTask)backupListBox.SelectedItem);
            backupItemListView.ItemsSource = bItemList;

        }
        private void fViewButton_Click(object sender, RoutedEventArgs e)
        {
            List<FolderTask> fItemList = new List<FolderTask>();
            fItemList.Add((FolderTask)folderListBox.SelectedItem);
            folderItemListView.ItemsSource = fItemList;

        }

        private void fDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            
            FList.Remove((FolderTask)folderListBox.SelectedItem);

            folderListBox.ItemsSource = null;
            folderListBox.ItemsSource = FList;
            saveButton.Background = Brushes.Blue;

        }

        private void bDeleteButton_Click(object sender, RoutedEventArgs e)
        {
           
            BList.Remove((BackupTask)backupListBox.SelectedItem);

            backupListBox.ItemsSource = null;
            backupListBox.ItemsSource = BList;
            saveButton.Background = Brushes.Blue;


        }

        private void lViewButton_Click(object sender, RoutedEventArgs e)
        {
           

            Binding binding = new Binding();
            binding.Path = new PropertyPath("Data");
            binding.Source = ((Log)logListBox.SelectedItem);  // view model?

            BindingOperations.SetBinding(textBlock, TextBlock.TextProperty, binding);

        }

        private void backupAddbutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void folderAddbutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)

        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\user\Desktop\JUNIOR DEVELOPER TASK\TasksConfig1.xml");
            doc.RemoveAll();


            foreach (BackupTask btask in bList)
            {
                var newChild = new XElement("BackupAndUploadTask",
                                          new XElement("Name",
                                          new XAttribute("Value", btask.Name)),
                                          new XElement("Name",
                                          new XAttribute("Value", btask.Name)),
                                          new XElement("Name",
                                          new XAttribute("Value", btask.Name)),
                                          new XElement("Name",
                                          new XAttribute("Value", btask.Name)));
                xel.Add(newChild);
                
            }
            xel.Save(@"C:\Users\user\Desktop\JUNIOR DEVELOPER TASK\TasksConfig1.xml");
            saveButton.Background = Brushes.LightGray;

        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void bEditButton_Click(object sender, RoutedEventArgs e)
        {
           // ((BWindow)Application.Current.MainWindow).textBoxBW.Text = "Some text";

            
            BWindow win2 = new BWindow();
            win2.Show();
           //this.Close();
        }

        private void fEditButton_Click(object sender, RoutedEventArgs e)
        {
            FWindow1 win2 = new FWindow1();
            win2.Show();

        }
    }
   
    
}
