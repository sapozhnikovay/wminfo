using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class OptionalFeature
    {
        public string Name;
        public string Caption;
        public int InstallState;

        public OptionalFeature()
        {
            Name = "";
            Caption = "";
            InstallState = 0;
        }

        public string ToTxt()
        {
            string result = "";
            result += "\n" + Name;
            result += "\n--------------------\n";
            result += "Name".PadRight(30) + " - " + Name.ToString() + "\n";
            result += "Caption".PadRight(30) + " - " + Caption.ToString() + "\n";
            result += "InstallState".PadRight(30) + " - " + InstallState.ToString() + "\n";
            return result;
        }
    }
}
