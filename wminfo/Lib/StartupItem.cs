using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class StartupItem
    {
        public string Name = "";
        public string Location = "";
        public string Command = "";
        public string User = "";

        public StartupItem() { }

        public string ToTxt()
        {
            string result = "";
            result += Name.ToString().PadRight(30) + " - " + Command.ToString() + "\n";
            return result;
        }
    }
}
