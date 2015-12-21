using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class BIOS
    {
        public string Name = "";
        public string Manufacturer = "";
        public string ReleaseDate = "";
        public string SMBIOSVersion = "";
        public string SerialNumber = "";

        public BIOS()
        {

        }

        public string ToTxt()
        {
            string result = "";
            result += "\nBIOS information";
            result += "\n".PadRight(60, '-') + "\n";
            result += "Name".PadRight(30) + " - " + Name.ToString() + "\n";
            result += "Manufacturer".PadRight(30) + " - " + Manufacturer.ToString() + "\n";
            result += "Release date".PadRight(30) + " - " + ReleaseDate.ToString() + "\n";
            result += "SMBIOS version".PadRight(30) + " - " + SMBIOSVersion.ToString() + "\n";
            result += "Serial number".PadRight(30) + " - " + SerialNumber.ToString() + "\n";

            return result;
        }
    }
}
