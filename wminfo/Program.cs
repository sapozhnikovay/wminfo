using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace wminfo
{
    class Program
    {
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
            Console.WriteLine("  --help\tdisplay this help and exit");
            Console.WriteLine("  --version\toutput version information and exit");
        }

        static void DisplayVersion()
        {
            //TODO: Display application version
            Console.WriteLine("wminfo "+ Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        static void ParseArguments(string[] args)
        {
            foreach(string arg in args)
            {
                switch (arg)
                {
                    case "-h":
                        DisplayHelp();
                        break;
                    case "--help":
                        DisplayHelp();
                        break;
                    case "--version":
                        DisplayVersion();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
