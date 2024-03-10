using Microsoft.Win32;
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

            //JsonTest.test();

            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86));


            //Console.ReadKey();

            Console.WriteLine("\nThere will be a check to see if SFM is already discovered added later\n");

            //Initiates a bunch of variables
            List<string> sourceFilmmakerPaths = new List<string>();
            List<string> steamGameDirs = new List<string>();

            steamGameDirs.Add("This is a test removal number"); //Gets removed during "SearchSteam"
            
            steamGameDirs = Search.SearchSteam(); //Retrieves the paths of libraries

            steamGameDirs.Add("This is a test removal number 2"); //Debugging purposes. Lets me verify the remover works as it is intended to do

            sourceFilmmakerPaths = Parsing.FindSFM(Parsing.RemoveInvalidPaths(steamGameDirs));

            //Maybe implement something like this? https://youtu.be/qAWhGEPMlS8?si=cWatlNE7Y4vj1YMk
            switch (sourceFilmmakerPaths.Count())
            {
                case <=0:
                    Console.WriteLine("No Source Filmmaker folders has been found");
                    break; //Literally as well at this time

                case >1:
                    //Write code to ask user which SFM to use

                    Console.WriteLine("There are Multiple Paths found:");
                    foreach (string path in sourceFilmmakerPaths) {Console.WriteLine(path);}

                    //Having added a M.2 from Shift-PornServer to Shift-Station, after adding the PornServer path to Station Steam client, this is now a confirmed thing that can actually happen.
                    //I am very happy. Also, the names are "device names", not actual function names. I just like to think any network it may get connected to, a IT person will go "...Really?..."

                    break;

                case 1:
                    Console.WriteLine("SFM selected:");
                    Console.WriteLine(sourceFilmmakerPaths[0] + "\\game\\sfm.exe");
                    break;
            }
        }

        /// <summary>
        /// Checks and makes sure the path in the config file actually exists and goes to a SFM executable.
        /// </summary>
        /// <returns></returns>
        private static bool CheckConfigFile()
        {
            //There is supposedly a better way to make/deal with configuratins etc, buuuuut, this seems easier
            //Yes there is a way, USE JSON YOU LAZY BASTARD!!!!!! - Rex
            //I ALREADY ADDED IT YOU DOOF! - Shift

            // TODO:
            //REMINDER TO SELF!
            //Allow user to select a non-default SFM.exe file.
            //You never know if they have some modded exe similar to Skyrim/Fallout's Script Extender.

            //Print out the config file location.
            Console.WriteLine(StaticVars.ConfigFileLocation);


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
            Console.WriteLine("========================================================================");
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


/*
 * QuickSettings idea:
 * 1/2+
 * Arg1 - select exe2 - force steam online mode
 * 2*2-
 * Arg2 - default exe2 - force steam offline mode
 * 
 */

/* make sure to check if file exists and if it does but fails to deserialize, back it up and regenerate a default one
 * 
 */