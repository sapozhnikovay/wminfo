using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class PointingDevice
    {
        public string Name;
        public string Manufacturer;
        public string DeviceInterface;
        public string PointingType;
        public int NumberOfButtons;

        public PointingDevice()
        {
            Name = "";
            Manufacturer = "";
            DeviceInterface = "";
            PointingType = "";
            NumberOfButtons = 0;
        }

        public string ToTxt()
        {
            string result = "";

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
