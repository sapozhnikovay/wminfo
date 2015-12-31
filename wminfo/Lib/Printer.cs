using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class Printer
    {
        public string Name = "";
        public bool Default = false;
        public bool Bidirectional = false;
        public int HorizontalResolution = 0;
        public int VerticalResolution = 0;
        public bool Network = false;
        public string PortName = "";
        public int PrinterStatus = 0;
        public string PrintProcessor = "";
        public string Server = "";
        public string ShareName = "";
        public bool Published = false;
        public bool Shared = false;

        public Printer() { }

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
