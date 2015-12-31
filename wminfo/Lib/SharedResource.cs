using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class SharedResource
    {
        public string Name = "";
        public uint Type = 0;
        public string Caption = "";
        public string Path = "";

        public SharedResource() { }

        public string ToTxt()
        {
            string result = "";
            result += "\n" + Name;
            result += "\n--------------------\n";
            result += "Caption".PadRight(30) + " - " + Caption.ToString() + "\n";
            result += "Path".PadRight(30) + " - " + Path.ToString() + "\n";
            result += "Type".PadRight(30) + " - " + Type.ToString() + "\n";
            return result;
        }
    }
}
