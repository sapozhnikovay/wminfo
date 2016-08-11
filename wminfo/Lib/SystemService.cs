using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class SystemService
    {
        public string Name = "";
        public string Description = "";
        public string Path = "";
        public string StartupType = "";
        public string Status = "";
        public string LogOnAs = "";
        public string ServiceType = "";

        public SystemService() { }

        public string ToTxt()
        {
            string result = "";
            result += "\n" + Name;
            result += "\n--------------------\n";

            foreach (var propertyInfo in this.GetType().GetFields())
            {
                string name = propertyInfo.Name.PadRight(30);
                string value = propertyInfo.GetValue(this).ToString();
                result += name + " - " + value + "\n";
            }

            return result;
        }
    }
}
