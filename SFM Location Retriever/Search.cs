using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SFM_Location_Retriever
{
    internal class Search
    {

        /// <summary>
        /// Stolen from https://stackoverflow.com/a/54886330 and modified to work for what I needed
        /// </summary>
        /// <returns></returns>
        public static List<string> SearchSteam()
        {
            List<string> steamGameDirs = new List<string>();
            steamGameDirs.Clear();
            string steam32 = "SOFTWARE\\VALVE\\";
            string steam64 = "SOFTWARE\\Wow6432Node\\Valve\\";
            string steam32path;
            string steam64path;
            string config32path;
            string config64path;
            RegistryKey? key32 = Registry.LocalMachine.OpenSubKey(steam32);
            RegistryKey? key64 = Registry.LocalMachine.OpenSubKey(steam64);
            if (key64.ToString() == null || key64.ToString() == "") //Checks if it is a 32-bit or 64-bit System
            {
                foreach (string k32subKey in key32.GetSubKeyNames())
                {
                    using (RegistryKey subKey = key32.OpenSubKey(k32subKey))
                    {
                        try { steam32path = subKey.GetValue("InstallPath").ToString(); }
                        catch { return steamGameDirs; }
                        config32path = steam32path + "/steamapps/libraryfolders.vdf";
                        string driveRegex = @"[A-Z]:\\";
                        if (File.Exists(config32path))
                        {
                            string[] configLines = File.ReadAllLines(config32path);
                            foreach (var item in configLines)
                            {
                                Console.WriteLine("32:  " + item + "    //Enjoy the debug text I forgot to disable");
                                Match match = Regex.Match(item, driveRegex);
                                if (item != string.Empty && match.Success)
                                {
                                    string matched = match.ToString();
                                    string item2 = item.Substring(item.IndexOf(matched));
                                    item2 = item2.Replace("\\\\", "\\");
                                    item2 = item2.Replace("\"", "\\steamapps\\common\\");
                                    steamGameDirs.Add(item2);
                                    steamGameDirs.Add("This is a test removal number 2"); //Debugging purposes. Lets me verify the remover works as it is intended to do
                                    Console.WriteLine($"{matched} {item2}   //Library folder");
                                }
                            }
                        }
                    }
                }
                return steamGameDirs;
            }
            foreach (string k64subKey in key64.GetSubKeyNames())
            {
                using (RegistryKey subKey = key64.OpenSubKey(k64subKey))
                {
                    try { steam64path = subKey.GetValue("InstallPath").ToString(); }
                    catch { return steamGameDirs; }
                    config64path = steam64path + "/steamapps/libraryfolders.vdf";
                    string driveRegex = @"[A-Z]:\\";
                    if (File.Exists(config64path))
                    {
                        string[] configLines = File.ReadAllLines(config64path);
                        foreach (var item in configLines)
                        {
                            Console.WriteLine("64:  " + item + "     //Enjoy the debug text I forgot to disable");
                            Match match = Regex.Match(item, driveRegex);
                            if (item != string.Empty && match.Success)
                            {
                                string matched = match.ToString();
                                string item2 = item.Substring(item.IndexOf(matched));
                                item2 = item2.Replace("\\\\", "\\");
                                item2 = item2.Replace("\"", "\\steamapps\\common\\");
                                steamGameDirs.Add(item2);
                                steamGameDirs.Add("This is a test removal number 2"); //Debugging purposes. Lets me verify the remover works as it is intended to do
                                Console.WriteLine($"{matched} {item2}   //Library folder");

                            }
                        }
                    }
                }
            }
            return steamGameDirs;
        }
    }


}
