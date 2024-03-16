using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SFM_Location_Retriever
{
    /// <summary>
    /// This is made to make it easier to plan and execute my ideas. Figure out what the intended things to happen should be and make it easier to implement those spesific ideas.
    /// </summary>
    internal class Blueprint
    {
        public static void FirstTimeStartup()
        {
            Program.Logo();
            Console.WriteLine("Blueprint: First-Time Startup");
            Console.WriteLine(
                "This is a blueprint on what should happen when you start the program for the first time on your machine.\n" +
                "This will go through the different steps one at a time on what will happen.\n" +
                "Please click a button to proceed.");
            Console.ReadKey();
            Console.Clear();

            Program.Logo();

            Console.WriteLine("Scanning for config...");


            Console.WriteLine("\n\n========================================================================\n" +
                "The program will always look for a config file.\n" +
                "The config file will always be located at:\n" +
                 $"\"{StaticVars.ConfigFileLocation}\" (At least on this computer)\n\n" +
                 "" +
                 "At this point, three things can happen;\n" +
                 "1. The config exists and it passes a verification check.\n" +
                 "2. The config exists but is incompatible/wrong.\n" +
                 "3. The config file doesn't exist.\n\n" +
                 "" +
                 "If 2 happens, a backup of the config file will be made and the user gets notified, followed by the same action as what would happen if 3 was the case.\n" +
                 "With 3, a config file with defaults will be made and a automatic search for (default) Source Filmmaker will be made using Steam's Library Paths.\n" +
                 "Please click a button to proceed.");
            Console.ReadKey();
            Console.Clear();

            Program.Logo();
            Console.WriteLine("SFM.exe not found, please find the SFM executable\n" +
                "(A File Explorer \"Selection\" window will open up in ~5 seconds)\n+n");

            //Will make this more functional and expensive down the line. Likely will make development take longer time, buuuut, not like someone else will actually want to use this. Maybe yoink the Steam Library Search thingy, but other than that, I don't see why anyone would want to use my code anyhow. I usually just make niech things. Hell, this entire program could have been two shortcut files. "SFM-Edit" and "SFM-Render".
            Console.WriteLine("\n\n========================================================================\n" +
            "In the offchance It is not found, a system shall be in place to let you select any exe as SFM.\n" +
            "If some checks fails, a warning will pop up saying the program doesn't recognise the exe as SFM, where they get to choose \"cancel\", \"retry\" or \"It's non-standard/I know what I am doing\"\n" +
            "Then it will continue as normal.");
            MessageBox.Show("(this pop-up is after a failure) In this example, a invalid selection has happened. In this spesific case, any button will be treated as \"ignore\"", "test",MessageBoxButtons.AbortRetryIgnore,MessageBoxIcon.Warning);


        }
    }
}
