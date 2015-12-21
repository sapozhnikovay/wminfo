using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class Motherboard
    {
        public string Manufacturer = "";
        public string Name = "";
        public string SerialNumber = "";
        public string Version = "";

        public Motherboard()
        {

        }

        public string ToTxt()
        {
            string result = "";
            result += "\nMotherboard";
            result += "\n".PadRight(60, '-') + "\n";
            result += "Product name".PadRight(30) + " - " + Name.ToString() + "\n";
            result += "Manufacturer".PadRight(30) + " - " + Manufacturer.ToString() + "\n";            
            result += "Serial number".PadRight(30) + " - " + SerialNumber.ToString() + "\n";
            result += "Version".PadRight(30) + " - " + Version.ToString() + "\n";

            return result;
        }
    }
}
