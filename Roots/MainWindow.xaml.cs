﻿using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Roots.DataAccesLayer;
using System.Windows.Input;

namespace Roots
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string workingDirectory;

        public string WorkingDirectory
        {
            get { return workingDirectory; }
            set { workingDirectory = value; }
        }

        private static string filePath;

        public static string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public bool ExistInWindowsAutostart
        {
            get { return (bool)GetValue(ExistInWindowsAutostartProperty); }
            set { SetValue(ExistInWindowsAutostartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExistInWindowsAutostart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExistInWindowsAutostartProperty =
            DependencyProperty.Register("ExistInWindowsAutostart", typeof(bool), typeof(MainWindow), new PropertyMetadata(null));


        public bool NotExistWindowsAutostart
        {
            get { return (bool)GetValue(NotExistWindowsAutostartProperty); }
            set { SetValue(NotExistWindowsAutostartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NotExistWindowsAutostart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NotExistWindowsAutostartProperty =
            DependencyProperty.Register("NotExistWindowsAutostart", typeof(bool), typeof(MainWindow), new PropertyMetadata(null));


        public Branch SelectedMember
        {
            get { return (Branch)GetValue(SelectedMemberProperty); }
            set { SetValue(SelectedMemberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedMember.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedMemberProperty =
            DependencyProperty.Register("SelectedMember", typeof(Branch), typeof(MainWindow), new PropertyMetadata(null));

        public List<Branch> FamilyMemberList
        {
            get { return (List<Branch>)GetValue(FamilyMemberListProperty); }
            set { SetValue(FamilyMemberListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for familyMemberList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FamilyMemberListProperty =
            DependencyProperty.Register("FamilyMemberList", typeof(List<Branch>), typeof(MainWindow), new PropertyMetadata(null));

        public MainWindow()
        {
            
            FamilyMemberList = new List<Branch>();
            FilePath = DataAccess.GetFilePath();

            WorkingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            IsExistInWindowsAutostart();
            InitializeComponent();
            FamilyMemberList = DataAccess.ReadDatabase(FilePath);
            MessageBox.Show(ActualAnniversarysMessage());
        }

        private void NewFileClicked(object sender, RoutedEventArgs e)
        {
            
            NewFileWindow newFileWindow = new NewFileWindow(this);

            newFileWindow.ShowDialog();
        }
        private void OpenFileClicked(object sender, RoutedEventArgs e)
        {
            var openfileDialog = new OpenFileDialog
            {
                Filter = "Database documents (.db) | *.db"
            };

            var dialogResult = openfileDialog.ShowDialog();
            if (dialogResult == true)
            {
                FilePath = openfileDialog.FileName;
                FamilyMemberList = DataAccess.ReadDatabase(FilePath);
            }
        }
        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowNewBranchWindowClicked(object sender, RoutedEventArgs e)
        {
            NewBranchWindow newBranchWindow = new NewBranchWindow();

            newBranchWindow.ShowDialog();

            FamilyMemberList = DataAccess.ReadDatabase(FilePath);
        }

        private void UpdateSelectedBranchWindowClicked(object sender, RoutedEventArgs e)
        {
            SelectedBranchWindow selectedBranchWindow = new SelectedBranchWindow(SelectedMember);

            selectedBranchWindow.ShowDialog();

            FamilyMemberList = DataAccess.ReadDatabase(FilePath);
        }

        private void DeleteSelectedBrancClicked(object sender, RoutedEventArgs e)
        {

            var confiramtionWindow = new ConfiramtionWindow();
            bool confirmationResult = (bool)confiramtionWindow.ShowDialog();

            DataAccess.DeleteFromDatabase(SelectedMember, confirmationResult, FilePath);
            SelectedMember = FamilyMemberList.First<Branch>();
            confiramtionWindow.Close();
            FamilyMemberList = DataAccess.ReadDatabase(FilePath);
        }

        private string ActualAnniversarysMessage()
        {
            return AnniverseryMessageManager.ShowAnniversary(FamilyMemberList);
        }

        private void CreateShortcutOnDesktop(object sender, RoutedEventArgs e)
        {
            ShortcutManager.CreateShortCutOnDesktop(WorkingDirectory);
        }

        private void StartWithWindowsAutostart(object sender, RoutedEventArgs e)
        {
            AutostartManager.Autostart(WorkingDirectory);
        }

        private void DeleteFromWindowsAutostart(object sender, RoutedEventArgs e)
        {
            AutostartManager.RemoveFromAutostart();
        }

        private void IsExistInWindowsAutostart()
        {
            ExistInWindowsAutostart = AutostartManager.IsAutostart();
            NotExistWindowsAutostart = !ExistInWindowsAutostart;
        }
    }
}
