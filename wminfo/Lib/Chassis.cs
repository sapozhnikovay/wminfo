using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class Chassis
    {
        public string Manufacturer = "";
        public string CaseType = "";
        public string SerialNumber = "";
        public string AssetTag = "";

        public Chassis()
        {

        }

        public string ToTxt()
        {
            string result = "";
            result += "\nChassis";
            result += "\n".PadRight(60, '-') + "\n";
            result += "Manufacturer".PadRight(30) + " - " + Manufacturer.ToString() + "\n";
            result += "Case type".PadRight(30) + " - " + CaseType.ToString() + "\n";
            result += "Serial number".PadRight(30) + " - " + SerialNumber.ToString() + "\n";
            result += "Asset tag".PadRight(30) + " - " + AssetTag.ToString() + "\n";

            return result;
        }
    }
}
