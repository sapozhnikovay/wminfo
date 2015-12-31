using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class EnvironmentVariable
    {
        public string Name = "";
        public string Value = "";
        public bool isSystem = false;

        public EnvironmentVariable() { }

        public string ToTxt()
        {
            string result = "";
            result += Name.ToString().PadRight(30) + " - " + Value.ToString() + "\n";
            return result;
        }
    }
}
