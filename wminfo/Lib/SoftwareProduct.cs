using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class SoftwareProduct
    {
        public string Vendor = "";
        public string Version = "";
        public string InstallLocation = "";
        public string InstallSource = "";
        public string InstallDate = "";
        public string UninstallString = "";
        public string Name = "";
        public string URLInfoAbout = "";

        public override string ToString()
        {
            return base.ToString();
        }

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
