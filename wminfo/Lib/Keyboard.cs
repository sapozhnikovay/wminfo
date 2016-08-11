using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class Keyboard
    {
        public string Name;
        public string Manufacturer;
        public string Layout;
        public int NumberOfFunctionKeys;

        public Keyboard()
        {
            Name = "";
            Manufacturer = "";
            Layout = "";
            NumberOfFunctionKeys = 0;
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
