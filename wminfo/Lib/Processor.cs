using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class Processor
    {
        public string Name = "";
        public int CurrentClockSpeed = 0;
        public int MaxClockSpeed = 0;
        public int ExtClock = 0;
        public int Multiplier = 0;
        public string Description = "";
        public string Manufacturer = "";
        public string Status = "";
        public string SocketDesignation = "";
        public int L2CacheSize = 0;
        public int L3CacheSize = 0;
        public float CurrentVoltage = 0;
        public int UpgradeMethod = 0;
        public int NumberOfCores = 0;
        public int NumberOfLogicalProcessors = 0;
        public bool Multithreaded = false;

        public string ToTxt()
        {
            string result = "";
            result += "\n" + Description;
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
