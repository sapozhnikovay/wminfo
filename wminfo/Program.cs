using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

            Console.ReadKey();
            return 0;
        }

        static void DisplayHelp()
        {
            // TODO: Add help display
            Console.WriteLine("Usage: wminfo [OPTIONS]...");
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
            //TODO: Display application version
            Console.WriteLine("wminfo "+ Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        static void ParseArguments(string[] args)
        {
            for(int i=0;i<args.Length;i++)
            {
                switch (args[i])
                {
                    case "--help":
                        DisplayHelp();
                        break;
                    case "--version":
                        DisplayVersion();
                        break;
                    case "-i":
                        inFile = args[i + 1];
                        break;
                    case "-o":
                        outFile = args[i + 1];
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
