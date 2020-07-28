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
    /// Logika interakcji dla klasy ConfiramtionWindow.xaml
    /// </summary>
    public partial class ConfiramtionWindow : Window
    {
        public ConfiramtionWindow()
        {
            InitializeComponent();
        }

        private void OnOKClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void OnCancelClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
