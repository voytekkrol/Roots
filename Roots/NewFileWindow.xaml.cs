using Roots.DataAccesLayer;
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

namespace Roots
{
    /// <summary>
    /// Logika interakcji dla klasy NewFileWindow.xaml
    /// </summary>
    public partial class NewFileWindow : Window
    {
        private MainWindow mainWindow;

        public MainWindow MainWindow
        {
            get { return mainWindow; }
            set { mainWindow = value; }
        }

        private static string filePath;

        public static string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private string folderPath;

        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        public string NewFileName
        {
            get { return (string)GetValue(NewFileNameProperty); }
            set { SetValue(NewFileNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewFileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewFileNameProperty =
            DependencyProperty.Register("NewFileName", typeof(string), typeof(NewFileWindow), new PropertyMetadata(null));


        public NewFileWindow(MainWindow mainWindow)
        {

            MainWindow = mainWindow;

            InitializeComponent();

            FolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (NewFileName != null)
            {
                FilePath = System.IO.Path.Combine(FolderPath, (NewFileName + ".db"));
                MainWindow.FilePath = FilePath;
                DataAccess.ReadDatabase(FilePath);
            }

            Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
