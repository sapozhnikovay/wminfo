using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class ServerRole
    {
        public int ID;
        public string Name;
        public int ParentID;

        public ServerRole()
        {
            ID = 0;
            Name = "";
            ParentID = 0;
        }

        public string ToTxt()
        {
            string result = "";
            result += "\n" + Name;
            result += "\n--------------------\n";
            result += "ID".PadRight(30) + " - " + ID.ToString() + "\n";
            result += "Name".PadRight(30) + " - " + Name.ToString() + "\n";
            result += "ParentID".PadRight(30) + " - " + ParentID.ToString() + "\n";
            return result;
        }
    }
}
