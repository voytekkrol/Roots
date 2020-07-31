using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roots
{
    public class ShortcutManager
    {
        public static void CreateShortCutOnDesktop(string workingDirectory)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\Roots.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "New shortcut for a Roots";
            shortcut.Hotkey = "";
            shortcut.TargetPath = workingDirectory + @"\Roots.exe";
            shortcut.WorkingDirectory = workingDirectory;
            shortcut.Save();
        }
    }
}
