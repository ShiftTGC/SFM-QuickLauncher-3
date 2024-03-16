using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM_Location_Retriever
{
    /// <summary>
    /// "Stole" the idea from RexTheCapt https://github.com/RexTheCapt
    /// </summary>
    internal class StaticVars
    {
        /// <summary>
        /// Directory path to user local appdata directory.
        /// </summary>
        private static string AppDataLocal => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        /// <summary>
        /// Root directory for config files.
        /// </summary>
        public static string ConfigRoot => Path.Combine(AppDataLocal, "ShiftTGC\\SFM-Quicklancher-3");
        /// <summary>
        /// Direct file path to config file.
        /// </summary>
        public static string ConfigFileLocation => Path.Combine(ConfigRoot, "settings.json");

    }
}
