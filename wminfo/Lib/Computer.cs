using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class Computer
    {
        public List<OperatingSystem> OperatingSystems;

        public Computer()
        {
            OperatingSystems = new List<OperatingSystem>();
        }

        public string ToTxt()
        {
            string result = "";
            foreach(OperatingSystem os in OperatingSystems)
            {
                result += os.ToTxt();
            }

            return result;
        }
        public string ToCsv()
        {
            return "";
        }
    }
}
