using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roots
{
    public class AutostartManager
    {
        public static void Autostart(string workingDirectory)
        {
            WshShell shell = new WshShell();
            string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup\Roots.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "New shortcut for a Roots";
            shortcut.Hotkey = "";
            shortcut.TargetPath = workingDirectory + @"\Roots.exe";
            shortcut.WorkingDirectory = workingDirectory;
            shortcut.Save();
            IsAutostart();
        }

        public static void RemoveFromAutostart()
        {
            string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup\Roots.lnk";
            System.IO.File.Delete(shortcutAddress);
            IsAutostart();
        }

        public static bool IsAutostart()
        {
            string shortcutAddress = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup\Roots.lnk";
            return System.IO.File.Exists(shortcutAddress);
            
        }
    }
}
