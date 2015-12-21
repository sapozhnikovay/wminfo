using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    /// <summary>
    /// Represents physical memory device - RAM module
    /// </summary>
    class MemoryModule
    {
        public int Capacity = 0;
        public string Manufacturer = "";
        public string FormFactor = "";
        public string MemoryType = "";
        public string Speed = "";
        public string SerialNumber = "";
        public string PartNumber = "";
        public string ManufactureDate = "";
        public string BankLabel = "";

        public MemoryModule()
        {

        }

        public string ToTxt()
        {
            string result = "";
            result += "\nMemory module";
            result += "\n".PadRight(60, '-') + "\n";
            result += "Capacity".PadRight(30) + " - " + Capacity.ToString() + " MB\n";
            result += "Manufacturer".PadRight(30) + " - " + Manufacturer.ToString() + "\n";
            result += "Module type".PadRight(30) + " - " + FormFactor.ToString() + "\n";
            result += "Memory type".PadRight(30) + " - " + MemoryType.ToString() + "\n";
            result += "Speed".PadRight(30) + " - " + Speed.ToString() + "\n";
            result += "Part number".PadRight(30) + " - " + PartNumber.ToString() + "\n";
            result += "Serial number".PadRight(30) + " - " + SerialNumber.ToString() + "\n";
            result += "Manufacture date".PadRight(30) + " - " + ManufactureDate.ToString() + "\n";
            result += "Bank label".PadRight(30) + " - " + BankLabel.ToString() + "\n";

            return result;
        }
    }
}
