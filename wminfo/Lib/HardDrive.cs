using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class HardDrive
    {
        public string Model = "";
        public string InterfaceType = "";
        public string MediaType = "";
        public string Size = "";
        public string SerialNumber = "";
        public string FirmwareRevision = "";
        public string NCQSupport = "";
        public string TRIMSupport = "";
        public string SMARTFeatures = "";
        public string SMARTData = "";

        public HardDrive()
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
