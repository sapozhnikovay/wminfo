using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class VideoController
    {
        public string AdapterName = "";
        public string AdapterFamily = "";
        public string VideoProcessor = "";
        public string ChipsetCodename = "";
        public string InstalledVideoRAM = "";
        public string VideoMemoryType = "";
        public string VideocardName = "";
        public string VideoBus = "";
        public string CurrentVideoMode = "";
        public string DisplayDrivers = "";
        public string DriverManufacturer = "";
        public string DriverVersion = "";
        public string DriverDate = "";
        public string VideoBIOSVersion = "";
        public string ProcessorClockSpeed = "";
        public string MemoryClock = "";
        public string MemoryBusWidth = "";
        public string NUmberOfUnifiedShaders = "";
        public string DACType = "";
        public string ScanMode = "";
        public string Availability = "";
        public string NumberOfROPs = "";
        public string nVIdiaSLIStatus = "";
        public string GeometryClock = "";
        public string VideoArchitecture = "";

        public VideoController()
        {

        }

        public string ToTxt()
        {
            string result = "";
            result += "\n" + AdapterName;
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
