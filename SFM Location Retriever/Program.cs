﻿using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace SFM_Location_Retriever
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool configExists = CheckConfigFile();

            Logo(); //Displays Logo

            Console.ReadKey();

            Console.WriteLine("\nThere will be a check to see if SFM is already discovered added later\n");

            //Initiates a bunch of variables
            List<string> sourceFilmmakerPaths = new List<string>();
            List<string> steamGameDirs = new List<string>();

            steamGameDirs.Add("This is a test removal number"); //Gets removed during "SearchSteam"
            
            steamGameDirs = Search.SearchSteam(); //Retrieves the paths of libraries

            steamGameDirs.Add("This is a test removal number 2"); //Debugging purposes. Lets me verify the remover works as it is intended to do

            sourceFilmmakerPaths = Parsing.FindSFM(Parsing.RemoveInvalidPaths(steamGameDirs));


            switch (sourceFilmmakerPaths.Count())
            {
                case <=0:
                    Console.WriteLine("No Source Filmmaker folders has been found");
                    break; //Literally as well at this time

                case >1:
                    //Write code to ask user which SFM to use

                    break;

                case 1:
                    Console.WriteLine("SFM selected:");
                    Console.WriteLine(sourceFilmmakerPaths[0] + "\\game\\sfm.exe");
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool CheckConfigFile() //There is supposedly a better way to make/deal with configuratins etc, buuuuut, this seems easier
        {
            string appDataLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string configFileLocation = "ShiftTGC\\SFM-Quicklancher-3\\settings.config";



            return false;
        }

        static void Logo()
        {
            Console.WriteLine("                                ||  Service Statuses");
            Console.WriteLine("    //////////////////////////  ||  Steam Store Page:");
            Console.WriteLine("   // SFM Quick-Launcher 3 //   ||  <Testing Ping...>");
            Console.WriteLine("  //v3.0//////By: ShiftTGC//    ||  Online/Offline:");
            Console.WriteLine("  (Now with a auto-finder!)     ||  <Waiting on Ping>");
            Console.WriteLine("                                ||");
            Console.WriteLine("=======================================================================");
        }

        /// <summary>
        /// An easy way to use Steam URI to run Steam stuff
        /// </summary>
        /// <param name="URI">Can also be URLs, but is intended for URIs</param>
        static void launch(string URI)
        {
            var url = URI;
            var psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            Process.Start(psi);
        }
    }

}