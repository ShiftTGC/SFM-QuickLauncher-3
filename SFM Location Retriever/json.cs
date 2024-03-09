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
    public class JsonTest
    {
        public static void test()
        {
            var deserialized = new SourceFilmmaker();

            deserialized.LaunchArguments = new LaunchArguments();
            deserialized.LaunchArguments.Arguments = new List<string>();
            deserialized.Locations = new List<string>();

            deserialized.LaunchArguments.Arguments.Add("@sfm.exe");
            deserialized.LaunchArguments.Arguments.Add("@sfm.exe -sfm_resolution 2160 -w 3840 -h 2160");
            deserialized.LaunchArguments.Arguments.Add("-open usermod");
            deserialized.LaunchArguments.Arguments.Add("<your custom launch-args here. Add as many as you want.>");

            deserialized.Locations.Add(@"M:\Tools\Steam\steamapps\common\SourceFilmmaker\game\sfm.exe");
            deserialized.Locations.Add(@"C:\Stuff\Neigh\Steam\steamapps\common\SourceFilmmaker\game\sfm.exe");
            deserialized.Locations.Add("Test3");
            deserialized.Locations.Add("Test7");

            deserialized.Selected = 1;



            Console.WriteLine(deserialized.Selected);
            Console.WriteLine(deserialized.Locations[deserialized.Selected]);

            var serialized = JsonSerializer.Serialize(deserialized);

            Console.WriteLine(serialized);

            Console.ReadLine();

        }

        public class SourceFilmmaker
        {
            public List<string> Locations { get; set; }

            public int Selected { get; set; }

            public LaunchArguments LaunchArguments { get; set; }
        }

        public class LaunchArguments
        {
            public List<string> Arguments { get; set; }
        }
    }

}

/*What information is needed to load/save:
 * SFM Location(s)
 * Default SFM Selected
 * Default launch Arguments
 * Look for "-open" and use the "<string>" behind it as what folder to open
 */