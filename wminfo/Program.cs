using System;
using System.Linq;
using System.Reflection;
using wminfo.Lib;

/*Application options
--help                  display help
--version               display version
--domain [LDAP string]  Base search string for domain computer accounts ex: CN=Computers,DC=domain,DC=local
--summary               Collect and display only summary information
--category [category]   Collect information only by categories [CPU,Audio,RAM,HDD,Video,Peripherals,Printers,OS,Software]
-i [infile.txt]         File with names of IP-addresses for query
-l [login]              Login for WMI access.
-p [password]           Password for WMI acccess
-o [outfile.txt]        Output file
-f [csv/xml/txt]        Output format
*/

namespace wminfo
{
    internal class Program
    {
        private static string[] categories;
        private static string format = "txt";
        private static string inFile;
        private static string outFile;
        private static string password;
        private static string target;
        private static string username;
        private static void DisplayHelp()
        {
            // TODO: Add help display
            Console.WriteLine("Usage: wminfo [TARGET] [OPTIONS]...");
            Console.WriteLine("Get information about local or remote computer via WMI.");
            Console.WriteLine("Query information from local computer and display summary on screeen if no options specified.\n");
            Console.WriteLine("  --help\t\t\tdisplay this help and exit");
            Console.WriteLine("  --version\t\t\toutput version information and exit");
            Console.WriteLine("  --domain \"LDAP string\"\tbase search string for domain computer accounts\n\t\t\t\tex: CN=Computers,DC=domain,DC=local");
            Console.WriteLine("  --summary\t\t\tcollect and display only summary information");
            Console.WriteLine("  --category \"category\"\t\tcollect information only by categories:\n\t\t\t\t[CPU,Audio,RAM,HDD,Video,Peripherals,Printers,\n\t\t\t\tOS,Software]");
            Console.WriteLine("  -i \"infile.txt\"\t\tfile with names of IP-addresses for query");
            Console.WriteLine("  -o \"outfile.txt\"\t\toutput file");
            Console.WriteLine("  -f \"csv/xml/txt\"\t\toutput format");
            Console.WriteLine("  -l \"domain\\login\"\t\tlogin for WMI access");
            Console.WriteLine("  -p \"password\"\t\t\tpassword for WMI access");
        }

        private static void DisplayVersion()
        {
            Console.WriteLine("wminfo " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        /// <summary>
        /// Errors the exit.
        /// </summary>
        /// <param name="message">The message.</param>
        private static void ErrorExit(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }

        private static void Export(Computer data, string format, string outfile, string[] categories)
        {
            string outstr = "";
            switch (format)
            {
                case "txt":
                    outstr = ExportTxt(data, categories);
                    break;

                case "csv":
                    //outstr = data.ToCsv();
                    break;
            }
            if (outfile != null)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(outfile);
                file.WriteLine(outstr.Replace("\n", "\r\n"));

                file.Close();
            }
            else
            {
                Console.WriteLine(outstr);
                // print to screen
            }
        }

        private static string ExportTxt(Computer data, string[] categories)
        {
            string result = "Inventory report for " + target;
            bool all = false;

            if(categories == null)
            {
                all = true;
                categories = new string[] {};
            }

            if (categories.Contains("os") || all) {
                result += "\n\nOperating system\n--------------------\n\n";
                foreach (Lib.OperatingSystem os in data.OperatingSystems)
                {
                    result += os.ToTxt();
                }
            }
            if (categories.Contains("mb") || all)
            {
                result += "\n\nSystem details\n--------------------\n";
                result += data.ComputerSystem.ToTxt();
            }

            if (categories.Contains("software") || all)
            {
                result += "\n\nSoftware Products\n--------------------\n";
                foreach (SoftwareProduct item in data.SoftwareProducts)
                {
                    result += item.ToTxt();
                }
            }

            if (categories.Contains("cpu") || all)
            {
                result += "\n\nProcessor\n--------------------\n";
                foreach (Processor item in data.Processors)
                {
                    result += item.ToTxt();
                }
            }

            if (categories.Contains("ram") || all)
            {
                result += "\n\nSystem memory\n--------------------\n";
                result += data.Memory.ToTxt();
            }

            if (categories.Contains("video") || all)
            {
                result += "\n\nVideo controllers\n--------------------\n";
                foreach (VideoController item in data.VideoControllers)
                {
                    result += item.ToTxt();
                }
            }

            if (categories.Contains("monitor") || all)
            {
                result += "\n\nMonitors\n--------------------\n";
                foreach (Monitor item in data.Monitors)
                {
                    result += item.ToTxt();
                }
            }

            if (categories.Contains("audio") || all)
            {
                result += "\n\nSound devices\n--------------------\n";
                foreach (SoundDevice item in data.SoundDevices)
                {
                    result += item.ToTxt();
                }
            }

            if (categories.Contains("devices") || all)
            {
                result += "\n\nDevices\n--------------------\n";
                foreach (PnPDevice item in data.PnPDevices)
                {
                    result += item.ToTxt();
                }
            }

            if (categories.Contains("network") || all)
            {
                result += "\n\nNetwork adapters\n--------------------\n";
                foreach (NetworkAdapter item in data.NetworkAdapters)
                {
                    result += item.ToTxt();
                }
            }

            if (categories.Contains("storage") || all)
            {
                result += "\n\nStorage details\n--------------------\n";
                result += "\nPhysical disks\n--------------------\n";
                foreach (HardDrive item in data.HardDrives)
                {
                    result += item.ToTxt();
                }
                foreach (CDDrive item in data.CDDrives)
                {
                    result += item.ToTxt();
                }
                result += "\nLogical disks\n--------------------\n";
                foreach (LogicalVolume item in data.LogicalVolumes)
                {
                    result += item.ToTxt();
                }
            }

            return result;
        }

        private static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                DisplayHelp();
                return 1;
            }
            else
            {
                ParseArguments(args);
            }

            var computer = Crawler.GetInfo(target, username, password, categories);
            Export(computer, format, outFile, categories);

            Console.WriteLine("\n\nPress any key to quit...");
            Console.ReadKey();
            return 0;
        }
        /// <summary>
        /// Parses the arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void ParseArguments(string[] args)
        {
            if (!args[0].ToString().StartsWith("-"))
            {
                target = args[0].ToString();
            }
            else
            {
                ErrorExit("ERROR: Target computer name or ip-address not defined.");
            }
            for (int i = 1; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--help":
                        DisplayHelp();
                        ErrorExit("");
                        break;

                    case "--version":
                        DisplayVersion();
                        ErrorExit("");
                        break;

                    case "--category":
                        ParseCategories(args[i + 1]);
                        break;
                    //TODO: Add filepath check for correctness
                    case "-i":
                        inFile = args[i + 1];
                        break;

                    case "-o":
                        outFile = args[i + 1];
                        break;

                    case "-l":
                        username = args[i + 1];
                        break;

                    case "-p":
                        password = args[i + 1];
                        break;

                    case "-f":
                        format = args[i + 1];
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Parses the categories.
        /// </summary>
        /// <param name="arg">The argument.</param>
        private static void ParseCategories(string arg)
        {
            arg = arg.Trim('"');
            categories = arg.Split(',');
            for (int i = 0; i < categories.Count(); i++)
            {
                categories[i] = categories[i].Trim(' ').ToLower();
            }
        }
    }
}