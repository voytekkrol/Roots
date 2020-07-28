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
    /// Logika interakcji dla klasy SelectedBranchWindow.xaml
    /// </summary>
    public partial class SelectedBranchWindow : Window
    {


        public Branch UpdatedBranch
        {
            get { return (Branch)GetValue(UpdatedBranchProperty); }
            set { SetValue(UpdatedBranchProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdatedBranch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdatedBranchProperty =
            DependencyProperty.Register("UpdatedBranch", typeof(Branch), typeof(SelectedBranchWindow), new PropertyMetadata(null));


        public SelectedBranchWindow(Branch updatedBranch)
        {
            UpdatedBranch = updatedBranch;

            InitializeComponent();
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.FilePath != null)
            {
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(MainWindow.FilePath))
                {
                    connection.CreateTable<Branch>();
                    connection.Update(UpdatedBranch);
                }
            }

            Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
