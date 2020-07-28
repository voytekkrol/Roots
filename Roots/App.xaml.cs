using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Roots
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string databaseName = "ListOfMembersDatabases.db";
        public static string folderPath = Environment.CurrentDirectory;
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}
