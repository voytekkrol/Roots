﻿using System;
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
    /// Logika interakcji dla klasy NewBranchWindow.xaml
    /// </summary>
    public partial class NewBranchWindow : Window
    {


        public Branch NewBranch
        {
            get { return (Branch)GetValue(NewBranchProperty); }
            set { SetValue(NewBranchProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewBranch.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewBranchProperty =
            DependencyProperty.Register("NewBranch", typeof(Branch), typeof(NewBranchWindow), new PropertyMetadata(null));



        public NewBranchWindow()
        {
            NewBranch = new Branch();

            InitializeComponent();

        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.FilePath != null)
            {
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(MainWindow.FilePath))
                {
                    connection.CreateTable<Branch>();
                    connection.Insert(NewBranch);
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
