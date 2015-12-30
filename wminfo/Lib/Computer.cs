using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    /// <summary>
    /// 
    /// </summary>
    class Computer
    {
        public List<OperatingSystem> OperatingSystems;
        public List<SoftwareProduct> SoftwareProducts;
        public List<Processor> Processors;
        public List<CacheMemory> CacheMemory;
        public Memory Memory;
        public List<VideoController> VideoControllers;
        public ComputerSystem ComputerSystem;
        public List<HardDrive> HardDrives;
        public List<CDDrive> CDDrives;
        public List<LogicalVolume> LogicalVolumes;
        public List<PnPDevice> PnPDevices;
        public List<NetworkAdapter> NetworkAdapters;
        public List<SoundDevice> SoundDevices;
        public List<Monitor> Monitors;
        public List<OSHotfix> OSHotfixes;
        public List<Codec> Codecs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Computer" /> class.
        /// </summary>
        public Computer()
        {
            OperatingSystems = new List<OperatingSystem>();
            SoftwareProducts = new List<SoftwareProduct>();
            Processors = new List<Processor>();
            CacheMemory = new List<CacheMemory>();
            VideoControllers = new List<VideoController>();
            HardDrives = new List<HardDrive>();
            CDDrives = new List<CDDrive>();
            LogicalVolumes = new List<LogicalVolume>();
            PnPDevices = new List<PnPDevice>();
            NetworkAdapters = new List<NetworkAdapter>();
            SoundDevices = new List<SoundDevice>();
            Monitors = new List<Monitor>();
            OSHotfixes = new List<OSHotfix>();
            Codecs = new List<Codec>();
        }

        public string ToTxt()
        {
            string result = "";
            result += "Processors\n--------------------\n";
            foreach (Processor item in Processors)
            {
                result += item.ToTxt();
            }
            result += "\nSystem details\n--------------------\n";
            result += ComputerSystem.ToTxt();
            result += "\n\nOperating system\n--------------------\n\n";
            foreach (OperatingSystem os in OperatingSystems)
            {
                result += os.ToTxt();
            }
            result += "Software Products\n--------------------\n\n";
            foreach (SoftwareProduct item in SoftwareProducts)
            {
                result += item.ToTxt();
            }

            return result;
        }
        public string ToCsv()
        {
            return "";
        }
    }
}
