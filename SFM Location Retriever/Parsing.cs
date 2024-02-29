using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFM_Location_Retriever
{
    public class Parsing
    {

        /// <summary>
        /// Goes through and checks if the paths actually exists, removes them if they don't. (Could be an external drive with a Steam library has disconected or something)
        /// </summary>
        /// <param name="steamGameDirs"></param>
        /// <returns></returns>
        public static List<string> RemoveInvalidPaths(List<string> steamGameDirs)
        {
            List<int> indexList = new List<int>();
            int index = 0;
            foreach (string steamGameDir in steamGameDirs)
            {
                Console.Write(steamGameDir);
                if (Directory.Exists(steamGameDir))
                {
                    Console.WriteLine("  //Is real");
                }
                else
                {
                    Console.WriteLine("  //Doesn't exist");
                    indexList.Add(index);
                }
                index++;
            }

            //Stolen from https://stackoverflow.com/a/9908607
            foreach (int index2 in indexList.OrderByDescending(v => v))
            {
                Console.WriteLine($"Removing: {steamGameDirs[index2]}");
                steamGameDirs.RemoveAt(index2);
            }
            return steamGameDirs;

        }

        /// <summary>
        /// Finds the location(s) of the Source Filmmaker folder(s) from the Steam Library path(s) with unecesary debug text printed to the console. Fun clutter imo.
        /// </summary>
        /// <param name="steamGameDirs">Contains all Steam Library Paths</param>
        /// <returns></returns>
        public static List<string> FindSFM(List<string> steamGameDirs)
        {
            List<string> sourceFilmmakerPaths = new List<string>();

            foreach (var steamGameDir in steamGameDirs)
            {
                Console.Write(steamGameDir);
                if (Directory.Exists(steamGameDir + "SourceFilmmaker"))
                {
                    Console.WriteLine("SourceFilmmaker     //IT IS HEEEERE! WOOOOOOO!");
                    sourceFilmmakerPaths.Add(steamGameDir + "SourceFilmmaker");
                }
                else
                {
                    Console.WriteLine("[N/A]     //No SFM");
                }

            }
            return sourceFilmmakerPaths;
        }
    }
}
