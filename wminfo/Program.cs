using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
    class Program
    {
        private static string inFile;
        private static string outFile;
        private static string target;
        private static string username;
        private static string password;
        private static string format = "txt";

        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                
                return 1;
            }
            else
            {
                ParseArguments(args);
            }

            var computer = Crawler.GetInfo(target, username, password);
            Export(computer, format, outFile);

            Console.WriteLine("\n\nPress any key to quit...");
            Console.ReadKey();
            return 0;
        }

        static void DisplayHelp()
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

        static void DisplayVersion()
        {
            Console.WriteLine("wminfo "+ Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        static void ParseArguments(string[] args)
        {
            if (!args[0].ToString().StartsWith("-"))
            {
                target = args[0].ToString();
            }
            else
            {
                ErrorExit("ERROR: Target computer name or ip-address not defined.");
            }
            for(int i=1;i<args.Length;i++)
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

        static void ErrorExit(string message)
        {
            Console.WriteLine(message);
            Environment.Exit(1);
        }

        static void Export(Computer data, string format, string outfile)
        {
            string outstr = "";
            switch (format)
            {
                case "txt":
                    outstr = data.ToTxt();
                    break;
                case "csv":
                    outstr = data.ToCsv();
                    break;
            }
            if(outfile != null)
            {
                // output to file
            }
            else
            {
                Console.WriteLine(outstr);
                // print to screen
            }
        }
    }
}
