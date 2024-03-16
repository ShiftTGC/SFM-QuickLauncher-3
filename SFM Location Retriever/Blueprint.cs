using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SFM_Location_Retriever
{
    /// <summary>
    /// This is made to make it easier to plan and execute my ideas. Figure out what the intended things to happen should be and make it easier to implement those spesific ideas.
    /// </summary>
    internal class Blueprint
    {

        public static void FirstTimeStartupFailSFM()
        {

            Console.WriteLine(Thread.CurrentThread.GetApartmentState().ToString());
            Console.ReadKey();

            Program.Logo();
            Console.WriteLine("Blueprint: First-Time Startup (SFM not found)");
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
            Console.WriteLine("SFM.exe not found, please find SFM.exe or the executable you wish to use\n" +
                "(A File Explorer \"Selection\" window will open up in ~3 seconds)\n\n");

            Console.WriteLine("\n\n========================================================================\n" +
            "In this spesific case, config file was not found and therefore we move on to looking for Source Filmmaker through normal means.\n" +
            "Additionally in this spesific case, SFM was not able to be found, so the user then gets prompted to find the SFM.exe");

            OpenFileDialog example = new OpenFileDialog();
            example.Filter = "Default SFM (SFM.exe)|SFM.exe|Custom Executable (*.exe)|*.exe|All files (*.*)|*.*";
            example.Title = "SFM Selector";
            example.Multiselect = false;
            example.CheckFileExists = true;
            //Thread.Sleep(3000);
            MessageBox.Show(
                "(Read Console Window First)\n" +
                "Had this been a case of incompatible config file however, this window would say a backup was made and where.\n" +
                "Feel free to click cancel.Selecting a exe file or otherwise will do nothing.",
                "Notice:",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            example.ShowDialog();

            //Will make this more functional and expensive down the line. Likely will make development take longer time, buuuut, not like someone else will actually want to use this. Maybe yoink the Steam Library Search thingy, but other than that, I don't see why anyone would want to use my code anyhow. I usually just make niech things. Hell, this entire program could have been two shortcut files. "SFM-Edit" and "SFM-Render".
            Console.WriteLine("\n\n" +
            "In the offchance It is not found, a system shall be in place to let you select any exe as SFM.\n" +
            "If some checks fails, a warning will pop up saying the program doesn't recognise the exe as SFM, where they get to choose \"cancel\", \"retry\" or \"It's non-standard/I know what I am doing\"\n" +
            "Then it will continue as normal.");
            MessageBox.Show( //I feel it would be better to make it a "Title, Description, Type, Buttons to include" order, buuut, I should probably get used to the standard instead of making it custom
                "Oops! After a quick check, this doesn't adhear to certain SFM standards!\n" +
                "If you know for a fact the exe you selected is what you desire as your \"Source Filmmaker executable\", please click \"ignore\"\n" +
                "Otherwise, click \"retry\" to select something else (non-functional for thid demo. Abort doesn't work either)", //Description
                "Test Box", //Title of the Message Box
                MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Warning);

            Console.ReadKey();
            Console.Clear();

            Program.Logo();
            Console.WriteLine("Custom Source Filmmaker has been selected.\n");

            Console.WriteLine("\n\n========================================================================\n" +
            "This concludes the first-time setup with a complete system failure, aka, the user haven't installed SFM properly or decide to use this as some other program's quick-launcher.");

            Console.ReadKey();
            Console.Clear();
        }
        public static void FirstTimeStartupSingle()
        {

            Console.WriteLine(Thread.CurrentThread.GetApartmentState().ToString());
            Console.ReadKey();

            Program.Logo();
            Console.WriteLine("Blueprint: First-Time Startup (only 1 SFM)");
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
            Console.WriteLine(
                "First-Time setup instructions:\n" +
                "You will only see this once!\n" +
                "\n" +
                "Shortcuts:\n" +
                "1. (Default) Runs SFM in editing/plain mode (normally, no extra arguments).\n" +
                "2. (Default) Runs SFM in render-mode (4K mode).\n" +
                "3. (Default) Opens usermod folder (doesn't run SFM).\n" +
                "\n" +
                "+. Ensures it is ran in \"Steam Online\"mode.\n" +
                "-. Ensures it is ran in \"Steam Offline\" mode.\n" +
                "If none above is present, it will run depedent on if a ping to Steam's store page URL pings back or not.\n" +
                "\n" +
                "x*y. Selects shortcut \"x\" and uses SFM location nr. \"y\" for this session.\n" +
                "x/y. Selects shortcut \"x\" and uses SFM location nr. \"y\" as a new default." +
                "\n" +
                "If you want to modify default shortcuts, please go to the config:\n" +
               $"{StaticVars.ConfigFileLocation}\n" +
                "Modify/add json compatible lines to make your own shortcuts\n" +
                "\n" +
                "Press any key to continue");

            Console.WriteLine("\n\n========================================================================\n" +
            "In this spesific case, a single SFM location was found and therefore nothing special will happen.\n" +
            "Continuing will make a config file with basic settings. It will get checked to make sure it looks good.\n" +
            "Then you will get sent to the normal quick-launcher screen, whatever that ends up being...");

            Console.ReadKey();
        }

        public static void FirstTimeStartupMulti()
        {

            Console.WriteLine(Thread.CurrentThread.GetApartmentState().ToString());
            Console.ReadKey();

            Program.Logo();
            Console.WriteLine("Blueprint: First-Time Startup (Multiple SFMs)");
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
            Console.WriteLine(
                "Warning! Multiple SFM executables discovered:\n" +
               @"[1] M:\Tools\Steam\steamapps\common\SourceFilmmaker\game\sfm.exe" + "\n" +
               @"[2] C:\Stuff\Neigh\Steam\steamapps\common\SourceFilmmaker\game\sfm.exe" + "\n" +
               "\n" +
               "Which SFM shall be the default? [INTS ONLY, 1-2]\n" + //Dynamic up to 9
               "(Default SFM can be changed later. Setting custom SFM to default must be chosen later through config file.)");
            Console.Write("Default is: [ _ ]");
            Console.CursorLeft = 14;
            try { int defaultIndexSFM = Int32.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("That wasn't a INT... Moving on."); }
            Console.WriteLine("\n\n========================================================================\n" +
            "In case of multiple detected installs, you will get to choose the default to use.");
            Console.ReadKey();
            Console.Clear();

            Program.Logo();
            Console.WriteLine(
                "First-Time setup instructions:\n" +
                "You will only see this once!\n" +
                "\n" +
                "Shortcuts:\n" +
                "1. (Default) Runs SFM in editing/plain mode (normally, no extra arguments).\n" +
                "2. (Default) Runs SFM in render-mode (4K mode).\n" +
                "3. (Default) Opens usermod folder (doesn't run SFM).\n" +
                "\n" +
                "+. Ensures it is ran in \"Steam Online\"mode.\n" +
                "-. Ensures it is ran in \"Steam Offline\" mode.\n" +
                "If none above is present, it will run depedent on if a ping to Steam's store page URL pings back or not.\n" +
                "\n" +
                "x*y. Selects shortcut \"x\" and uses SFM location nr. \"y\" for this session.\n" +
                "x/y. Selects shortcut \"x\" and uses SFM location nr. \"y\" as a new default." +
                "\n" +
                "If you want to modify default shortcuts, please go to the config:\n" +
               $"{StaticVars.ConfigFileLocation}\n" +
                "Modify/add json compatible lines to make your own shortcuts\n" +
                "\n" +
                "Press any key to continue");

            Console.WriteLine("\n\n========================================================================\n" +
            "In this spesific case, a single SFM location was found and therefore nothing special will happen.\n" +
            "Continuing will make a config file with basic settings. It will get checked to make sure it looks good.\n" +
            "Then you will get sent to the normal quick-launcher screen, whatever that ends up being...");

            Console.ReadKey();
            }


    }
}
