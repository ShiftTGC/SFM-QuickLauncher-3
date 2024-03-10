using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SFM_Location_Retriever
{
    //This is to let me play around and 
    internal class JsonTest
    {
        public static void test()
        {
            var deserialized = new SourceFilmmaker();

            deserialized.LaunchArguments.Arguments.Add("<your custom launch-args here. Add as many as you want.>");

            deserialized.Locations.Add(@"M:\Tools\Steam\steamapps\common\SourceFilmmaker\game\sfm.exe");
            deserialized.Locations.Add(@"C:\Stuff\Neigh\Steam\steamapps\common\SourceFilmmaker\game\sfm.exe");
            deserialized.Locations.Add("Test3");
            deserialized.Locations.Add("Test7");



            Console.WriteLine(deserialized.Selected);
            Console.WriteLine(deserialized.Locations[deserialized.Selected]);

            var options = new JsonSerializerOptions { WriteIndented = true };
            string serialized = JsonSerializer.Serialize(deserialized, options);

            Console.WriteLine(serialized);
            File.WriteAllText("config.json", serialized);

            Console.WriteLine(File.ReadAllText("config.json"));


            var dester2 = JsonSerializer.Deserialize<SourceFilmmaker>(serialized);

            Console.WriteLine(dester2.Selected);
            Console.WriteLine(dester2.Locations[dester2.Selected]);


            Console.ReadLine();

        }

        public static void test2()
        {
            string rawJson = File.ReadAllText("config.json");

            SourceFilmmaker config = JsonSerializer.Deserialize<SourceFilmmaker>(rawJson) ?? new SourceFilmmaker();
            Console.WriteLine(config.Selected);
            foreach (var item in config.LaunchArguments.Arguments)
            {
                Console.WriteLine(item);
            }

            // config.LaunchArguments.Arguments.Add("gay");
           // config.LaunchArguments.Arguments.Remove("gay");

            var options = new JsonSerializerOptions { WriteIndented = true };
            string test = JsonSerializer.Serialize(config, options);

            File.WriteAllText("config.json", test);
        }

        public class SourceFilmmaker
        {
            public List<string> Locations { get; set; }

            public int Selected { get; set; }

            public LaunchArguments LaunchArguments { get; set; }
            public SourceFilmmaker()
            {   //Special thanks to RexTheCapt for helping me on how to add defaults
                Locations = new();
                LaunchArguments = new LaunchArguments();
                LaunchArguments.Arguments.Add("@sfm.exe");
                LaunchArguments.Arguments.Add("@sfm.exe -sfm_resolution 2160 -w 3840 -h 2160");
                LaunchArguments.Arguments.Add("-open usermod");
                Selected = 0; //index based. 0 is 1, 1 is 2, 2 is 3, etc etc. If you are looking through this, you should already know this.
                //Selected is the selected SFM location
                Locations.Add(@$"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)}\Steam\steamapps\common\SourceFilmmaker\game\sfm.exe");
            }
        }

        public class LaunchArguments
        {
            public List<string> Arguments { get; set; }
            public LaunchArguments()
            {
                Arguments = new List<string>();
            }
        }
    }

}

/*What information is needed to load/save:
 * SFM Location(s)
 * Default SFM Selected
 * Default launch Arguments
 * Look for "-open" and use the "<string>" behind it as what folder to open
 */