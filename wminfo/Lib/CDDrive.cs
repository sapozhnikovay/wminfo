using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class CDDrive
    {
        public string Model = "";
        public string DiskLetter = "";
        public string DriveType = "";
        public string ReadSupport = "";
        public string SerialNumber = "";
        public string WriteSupport = "";
        public string Revision = "";

        public CDDrive()
        {

        }

        public string ToTxt()
        {
            string result = "";
            result += "\n" + Model;
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
