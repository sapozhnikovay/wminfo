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

        public Processor() { 
}

        public string ToTxt()
        {
            string result = "";
            result += "\n" + Name;
            result += "\n".PadRight(60,'-')+"\n";
            result += "Current clock speed".PadRight(30) + " - " + CurrentClockSpeed.ToString() + " Mhz\n";
            result += "Maximum clock speed".PadRight(30) + " - " + MaxClockSpeed.ToString() + " Mhz\n";
            result += "External clock".PadRight(30) + " - " + ExtClock.ToString() + " Mhz\n";
            result += "Manufacturer".PadRight(30) + " - " + Manufacturer.ToString() + "\n";
            result += "Socket designation".PadRight(30) + " - " + SocketDesignation.ToString() + "\n";
            result += "Core voltage".PadRight(30) + " - " + CurrentVoltage.ToString() + " volts\n";
            result += "Number of cores".PadRight(30) + " - " + NumberOfCores.ToString() + "\n";
            result += "Logical processors".PadRight(30) + " - " + NumberOfLogicalProcessors.ToString() + "\n";
            result += "Multithreaded".PadRight(30) + " - " + Multithreaded.ToString() + "\n";
            result += "L2 Cache".PadRight(30) + " - " + L2CacheSize.ToString() + " KB\n";
            result += "L3 Cache".PadRight(30) + " - " + L3CacheSize.ToString() + " KB\n";

            return result;
        }
    }
}
