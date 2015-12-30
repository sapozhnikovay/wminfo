using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class Codec
    {
        public string Name = "";
        public string Group = "";
        public string Manufacturer = "";
        public string Description = "";
        public string Version = "";
        public string Modified = "";
        public string InstallDate = "";
        public string LastAccessed = "";

        public Codec()
        {

        }

        public string ToTxt()
        {
            string result = "";
            result += "\n" + Name;
            result += "\n--------------------\n";
            result += "Manufacturer".PadRight(30) + " - " + Manufacturer.ToString() + "\n";
            if(Description != "") result += "Description".PadRight(30) + " - " + Description.ToString() + "\n";
            result += "Version".PadRight(30) + " - " + Version.ToString() + "\n";
            result += "Modified".PadRight(30) + " - " + Modified.ToString() + "\n";
            result += "Install date".PadRight(30) + " - " + InstallDate.ToString() + "\n";
            result += "Last accessed".PadRight(30) + " - " + LastAccessed.ToString() + "\n";
            return result;
        }
    }
}
