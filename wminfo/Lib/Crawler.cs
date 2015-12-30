using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace wminfo.Lib
{
    static class Crawler
    {
        public static Computer GetInfo(string targetHost, string username, string password, string[] categories)
        { 
            Computer result = new Computer();
            if (targetHost == null) return null;
            ConnectionOptions options = new ConnectionOptions();
            if(username != null && password != null)
            {
                options.Username = username;
                options.Password = password;
            }
            ManagementScope scope = new ManagementScope("\\\\" + targetHost + "\\root\\CIMV2",options);
            scope.Connect();
            if (categories != null)
            {
                if (categories.Contains("os")) result.OperatingSystems = Get_OperatingSystems(scope);
                if (categories.Contains("software")) result.SoftwareProducts = Get_SoftwareProducts(scope);
                if (categories.Contains("cpu"))
                {
                    result.Processors = Get_Processors(scope);
                    result.CacheMemory = Get_CacheMemory(scope);
                }
                if (categories.Contains("ram")) result.Memory = Get_Memory(scope);
                if (categories.Contains("video")) result.VideoControllers = Get_VideoControllers(scope);
                if (categories.Contains("mb")) result.ComputerSystem = Get_ComputerSystem(scope);
                if (categories.Contains("storage"))
                {
                    result.HardDrives = Get_HardDrives(scope);
                    result.CDDrives = Get_CDDrives(scope);
                    result.LogicalVolumes = Get_LogicalVolumes(scope);
                }
                if (categories.Contains("devices")) result.PnPDevices = Get_PnPDevices(scope);
                if (categories.Contains("network")) result.NetworkAdapters = Get_NetworkAdapters(scope);
                if (categories.Contains("audio")) result.SoundDevices = Get_SoundDevices(scope);
                if (categories.Contains("monitor")) result.Monitors = Get_Monitors(scope);
                if (categories.Contains("hotfix")) result.OSHotfixes = Get_OSHotfixes(scope);
                if (categories.Contains("codecs")) result.Codecs = Get_Codecs(scope);
            }
            else
            {
                result.OperatingSystems = Get_OperatingSystems(scope);
                result.SoftwareProducts = Get_SoftwareProducts(scope);
                result.Processors = Get_Processors(scope);
                result.CacheMemory = Get_CacheMemory(scope);
                result.Memory = Get_Memory(scope);
                result.VideoControllers = Get_VideoControllers(scope);
                result.ComputerSystem = Get_ComputerSystem(scope);
                result.HardDrives = Get_HardDrives(scope);
                result.CDDrives = Get_CDDrives(scope);
                result.LogicalVolumes = Get_LogicalVolumes(scope);
                result.PnPDevices = Get_PnPDevices(scope);
                result.NetworkAdapters = Get_NetworkAdapters(scope);
                result.SoundDevices = Get_SoundDevices(scope);
                result.Monitors = Get_Monitors(scope);
                result.OSHotfixes = Get_OSHotfixes(scope);
                result.Codecs = Get_Codecs(scope);
            }
            return result;
        }

        static int GCD(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }

        public static List<OperatingSystem> Get_OperatingSystems(ManagementScope scope)
        {
            List<OperatingSystem> result = new List<OperatingSystem>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var os = new OperatingSystem();
                if(queryObj["CSDVersion"] != null) os.ServicePack = queryObj["CSDVersion"].ToString().Trim(' ');
                os.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                os.Version = queryObj["Version"].ToString().Trim(' ');
                os.Architecture = queryObj["OSArchitecture"].ToString().Trim(' ');
                os.RegisteredUser = queryObj["RegisteredUser"].ToString().Trim(' ');
                os.Organization = queryObj["Organization"].ToString().Trim(' ');
                os.CodeSet = queryObj["CodeSet"].ToString().Trim(' ');
                os.CountryCode = queryObj["CountryCode"].ToString().Trim(' ');
                os.CurrentTimeZone = queryObj["CurrentTimeZone"].ToString().Trim(' ');
                os.EncryptionLevel = queryObj["EncryptionLevel"].ToString().Trim(' ');
                os.ForegroundApplicationBoost = queryObj["ForegroundApplicationBoost"].ToString().Trim(' ');
                os.InstallDate = queryObj["InstallDate"].ToString().Trim(' ');
                os.LastBootupTime = queryObj["LastBootUpTime"].ToString().Trim(' ');
                os.LocalDateTime = queryObj["LocalDateTime"].ToString().Trim(' ');
                os.Locale = queryObj["Locale"].ToString().Trim(' ');
                os.OSLanguage = queryObj["OSLanguage"].ToString().Trim(' ');
                os.OSType = queryObj["OSType"].ToString().Trim(' ');
                os.ProductType = Convert.ToInt32(queryObj["ProductType"].ToString().Trim(' '));
                os.ProductID = queryObj["SerialNumber"].ToString().Trim(' ');
                os.SystemDrive = queryObj["SystemDrive"].ToString().Trim(' ');
                os.WindowsDirectory = queryObj["WindowsDirectory"].ToString().Trim(' ');
                os.SKU = queryObj["OperatingSystemSKU"].ToString().Trim(' ');
                os.ProductName = queryObj["Caption"].ToString().Trim(' ');
                result.Add(os);
            }

            return result;
        }

        public static List<SoftwareProduct> Get_SoftwareProducts (ManagementScope scope)
        {
            List<SoftwareProduct> result = new List<SoftwareProduct>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_Product");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var pr = new SoftwareProduct();
                if (queryObj["Version"] != null) pr.Version = queryObj["Version"].ToString().Trim(' ');
                if (queryObj["Vendor"] != null) pr.Vendor = queryObj["Vendor"].ToString().Trim(' ');
                if (queryObj["InstallLocation"] != null) pr.InstallLocation = queryObj["InstallLocation"].ToString().Trim(' ');
                if (queryObj["InstallSource"] != null) pr.InstallSource = queryObj["InstallSource"].ToString().Trim(' ');
                if (queryObj["InstallDate"] != null) pr.InstallDate = queryObj["InstallDate"].ToString().Trim(' ');
                if (queryObj["Name"] != null) pr.Name = queryObj["Name"].ToString().Trim(' ');
                if (queryObj["URLInfoAbout"] != null) pr.URLInfoAbout = queryObj["URLInfoAbout"].ToString().Trim(' ');
                result.Add(pr);
            }

            return result;
        }

        public static List<Processor> Get_Processors(ManagementScope scope)
        {
            List<Processor> result = new List<Processor>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_Processor");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var pr = new Processor();
                if (queryObj["CurrentClockSpeed"] != null) pr.CurrentClockSpeed = Convert.ToInt32(queryObj["CurrentClockSpeed"].ToString().Trim(' '));
                if (queryObj["MaxClockSpeed"] != null) pr.MaxClockSpeed = Convert.ToInt32(queryObj["MaxClockSpeed"].ToString().Trim(' '));
                if (queryObj["ExtClock"] != null) pr.ExtClock = Convert.ToInt32(queryObj["ExtClock"].ToString().Trim(' '));
                pr.Multiplier = pr.MaxClockSpeed / pr.ExtClock;
                if (queryObj["Description"] != null) pr.Description = queryObj["Description"].ToString().Trim(' ');
                if (queryObj["Manufacturer"] != null) pr.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["Status"] != null) pr.Status = queryObj["Status"].ToString().Trim(' ');
                if (queryObj["Name"] != null) pr.Name = queryObj["Name"].ToString().Trim(' ');
                if (queryObj["SocketDesignation"] != null) pr.SocketDesignation = queryObj["SocketDesignation"].ToString().Trim(' ');
                if (queryObj["L2CacheSize"] != null) pr.L2CacheSize = Convert.ToInt32(queryObj["L2CacheSize"].ToString().Trim(' '));
                if (queryObj["L3CacheSize"] != null) pr.L3CacheSize = Convert.ToInt32(queryObj["L3CacheSize"].ToString().Trim(' '));
                if (queryObj["CurrentVoltage"] != null) pr.CurrentVoltage = Convert.ToSingle(queryObj["CurrentVoltage"].ToString().Trim(' ')) / 10;
                if (queryObj["UpgradeMethod"] != null) pr.UpgradeMethod = Convert.ToInt32(queryObj["UpgradeMethod"].ToString().Trim(' '));
                if (queryObj["NumberOfCores"] != null) pr.NumberOfCores = Convert.ToInt32(queryObj["NumberOfCores"].ToString().Trim(' '));
                if (queryObj["NumberOfLogicalProcessors"] != null) pr.NumberOfLogicalProcessors = Convert.ToInt32(queryObj["NumberOfLogicalProcessors"].ToString().Trim(' '));
                if (pr.NumberOfCores < pr.NumberOfLogicalProcessors) pr.Multithreaded = true;
                result.Add(pr);
            }

            return result;
        }

        public static List<CacheMemory> Get_CacheMemory(ManagementScope scope)
        {
            List<CacheMemory> result = new List<CacheMemory>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_CacheMemory");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var pr = new CacheMemory();
                if (queryObj["InstalledSize"] != null) pr.Size = Convert.ToInt32(queryObj["InstalledSize"].ToString().Trim(' '));
                if (queryObj["CacheType"] != null) pr.Type = queryObj["CacheType"].ToString().Trim(' ');
                if (queryObj["Level"] != null) pr.Level = queryObj["Level"].ToString().Trim(' ');
                if (queryObj["Associativity"] != null) pr.Associativity = queryObj["Associativity"].ToString().Trim(' ');
                result.Add(pr);
            }

            return result;
        }

        public static Memory Get_Memory(ManagementScope scope)
        {
            Memory result = new Memory();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_PageFileUsage");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                if (queryObj["CurrentUsage"] != null) result.PagefileSizeActual = Convert.ToInt32(queryObj["CurrentUsage"].ToString().Trim(' '));
                if (queryObj["AllocatedBaseSize"] != null) result.PagefileSizeMaximum = Convert.ToInt32(queryObj["AllocatedBaseSize"].ToString().Trim(' '));
            }

            wmiquery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                if (queryObj["TotalVirtualMemorySize"] != null) result.VirtualMemorySize = Convert.ToInt32(queryObj["TotalVirtualMemorySize"].ToString().Trim(' ')) / 1024;
                if (queryObj["TotalVisibleMemorySize"] != null) result.TotalVisibleMemorySize = Convert.ToInt32(queryObj["TotalVisibleMemorySize"].ToString().Trim(' '))/1024;
                if (queryObj["FreePhysicalMemory"] != null) result.FreeMemorySize = Convert.ToInt32(queryObj["FreePhysicalMemory"].ToString().Trim(' '))/1024;
            }

            wmiquery = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                if (queryObj["TotalPhysicalMemory"] != null) result.PhysicalMemorySize = (int)(Convert.ToInt64(queryObj["TotalPhysicalMemory"].ToString().Trim(' '))/1024/1024); //Нужно переделать. Не точное число физической памяти.
            }

            result.MemoryLoadPercentage = 100 - (int)((float)((float)result.PhysicalMemorySize / (float)result.FreeMemorySize) * 10);
            
            wmiquery = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                MemoryModule mm = new MemoryModule();
                if (queryObj["Capacity"] != null) mm.Capacity = (int)(Convert.ToInt64(queryObj["Capacity"].ToString().Trim(' ')) / 1024 / 1024);
                if (queryObj["BankLabel"] != null) mm.BankLabel = queryObj["BankLabel"].ToString().Trim(' ');
                if (queryObj["Manufacturer"] != null) mm.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["InstallDate"] != null) mm.ManufactureDate = queryObj["InstallDate"].ToString().Trim(' ');
                if (queryObj["MemoryType"] != null) mm.MemoryType = queryObj["MemoryType"].ToString().Trim(' ');
                if (queryObj["FormFactor"] != null) mm.FormFactor = queryObj["FormFactor"].ToString().Trim(' ');
                if (queryObj["PartNumber"] != null) mm.PartNumber = queryObj["PartNumber"].ToString().Trim(' ');
                if (queryObj["SerialNumber"] != null) mm.SerialNumber = queryObj["SerialNumber"].ToString().Trim(' ');
                if (queryObj["Speed"] != null) mm.Speed = queryObj["Speed"].ToString().Trim(' ');
                result.MemoryModules.Add(mm);
            }


            return result;
        }

        public static List<VideoController> Get_VideoControllers(ManagementScope scope)
        {
            List<VideoController> result = new List<VideoController>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_VideoController");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var cp = new VideoController();
                if (queryObj["Availability"] != null) cp.Availability = queryObj["Availability"].ToString().Trim(' ');
                if (queryObj["AdapterRAM"] != null) cp.InstalledVideoRAM = queryObj["AdapterRAM"].ToString().Trim(' ');
                if (queryObj["AdapterDACType"] != null) cp.DACType = queryObj["AdapterDACType"].ToString().Trim(' ');
                if (queryObj["AdapterCompatibility"] != null) cp.AdapterFamily = queryObj["AdapterCompatibility"].ToString().Trim(' ');
                if (queryObj["Name"] != null) cp.AdapterName = queryObj["Name"].ToString().Trim(' ');
                if (queryObj["CurrentScanMode"] != null) cp.ScanMode = queryObj["CurrentScanMode"].ToString().Trim(' ');
                if (queryObj["VideoArchitecture"] != null) cp.VideoArchitecture = queryObj["VideoArchitecture"].ToString().Trim(' ');
                if (queryObj["VideoMemoryType"] != null) cp.VideoMemoryType = queryObj["VideoMemoryType"].ToString().Trim(' ');
                cp.CurrentVideoMode = queryObj["CurrentHorizontalResolution"].ToString().Trim(' ') + " x " + queryObj["CurrentVerticalResolution"].ToString().Trim(' ') + " x " + queryObj["CurrentBitsPerPixel"].ToString().Trim(' ') + "bpp x " + queryObj["CurrentRefreshRate"].ToString().Trim(' ') + " Hz";
                if (queryObj["InstalledDisplayDrivers"] != null) cp.DisplayDrivers = queryObj["InstalledDisplayDrivers"].ToString().Trim(' ');
                if (queryObj["DriverVersion"] != null) cp.DriverVersion = queryObj["DriverVersion"].ToString().Trim(' ');
                if (queryObj["DriverDate"] != null) cp.DriverDate = queryObj["DriverDate"].ToString().Trim(' ');
                result.Add(cp);
            }

            return result;
        }

        public static ComputerSystem Get_ComputerSystem(ManagementScope scope)
        {
            ComputerSystem result = new ComputerSystem();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_BIOS");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                if (queryObj["Name"] != null) result.BIOS.Name = queryObj["Name"].ToString().Trim(' ');
                if (queryObj["Manufacturer"] != null) result.BIOS.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["ReleaseDate"] != null) result.BIOS.ReleaseDate = queryObj["ReleaseDate"].ToString().Trim(' ');
                if (queryObj["SerialNumber"] != null) result.BIOS.SerialNumber = queryObj["SerialNumber"].ToString().Trim(' ');
                if (queryObj["SMBIOSBIOSVersion"] != null) result.BIOS.SMBIOSVersion = queryObj["SMBIOSBIOSVersion"].ToString().Trim(' ');
            }

            wmiquery = new ObjectQuery("SELECT * FROM Win32_ComputerSystemProduct");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                if (queryObj["Version"] != null) result.Model = queryObj["Version"].ToString().Trim(' ');
                if (queryObj["Vendor"] != null) result.Manufacturer = queryObj["Vendor"].ToString().Trim(' ');
                if (queryObj["UUID"] != null) result.UUID = queryObj["UUID"].ToString().Trim(' ');
                if (queryObj["Name"] != null) result.ProductNumber = queryObj["Name"].ToString().Trim(' ');
            }

            wmiquery = new ObjectQuery("SELECT * FROM Win32_SystemEnclosure");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                if (queryObj["ChassisTypes"] != null) result.Chassis.CaseType = ((ushort[])queryObj["ChassisTypes"])[0].ToString().Trim(' ');
                if (queryObj["Manufacturer"] != null) result.Chassis.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["SerialNumber"] != null) result.Chassis.SerialNumber = queryObj["SerialNumber"].ToString().Trim(' ');
                if (queryObj["SMBIOSAssetTag"] != null) result.Chassis.AssetTag = queryObj["SMBIOSAssetTag"].ToString().Trim(' ');
            }

            wmiquery = new ObjectQuery("SELECT * FROM Win32_BaseBoard");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                if (queryObj["Product"] != null) result.Motherboard.Name = queryObj["Product"].ToString().Trim(' ');
                if (queryObj["Manufacturer"] != null) result.Motherboard.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["SerialNumber"] != null) result.Motherboard.SerialNumber = queryObj["SerialNumber"].ToString().Trim(' ');
                if (queryObj["Version"] != null) result.Motherboard.Version = queryObj["Version"].ToString().Trim(' ');
            }

            wmiquery = new ObjectQuery("SELECT * FROM Win32_PortConnector");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                SystemPort p = new SystemPort();
                if (queryObj["ExternalReferenceDesignator"] != null) p.Name = queryObj["ExternalReferenceDesignator"].ToString().Trim(' ');
                if(p.Name == "")
                {
                    if (queryObj["InternalReferenceDesignator"] != null) p.Name = queryObj["InternalReferenceDesignator"].ToString().Trim(' ');
                }
                if (queryObj["PortType"] != null) p.PortType = queryObj["PortType"].ToString().Trim(' ');
                if (queryObj["ConnectorType"] != null) p.ConnectorType = ((ushort[])queryObj["ConnectorType"])[0].ToString().Trim(' ');
                result.SystemPorts.Add(p);
            }

            wmiquery = new ObjectQuery("SELECT * FROM Win32_SystemSlot");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                SystemSlot s = new SystemSlot();
                if (queryObj["SlotDesignation"] != null) s.SlotDesignation = queryObj["SlotDesignation"].ToString().Trim(' ');
                if (queryObj["CurrentUsage"] != null) s.Availability = queryObj["CurrentUsage"].ToString().Trim(' ');
                result.SystemSlots.Add(s);
            }

            return result;
        }

        public static List<HardDrive> Get_HardDrives(ManagementScope scope)
        {
            List<HardDrive> result = new List<HardDrive>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_DiskDrive");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var cp = new HardDrive();
                if (queryObj["Model"] != null) cp.Model = queryObj["Model"].ToString().Trim(' ');
                if (queryObj["InterfaceType"] != null) cp.InterfaceType = queryObj["InterfaceType"].ToString().Trim(' ');
                if (queryObj["MediaType"] != null) cp.MediaType = queryObj["MediaType"].ToString().Trim(' ');
                if (queryObj["Size"] != null) cp.Size = ((int)(Convert.ToInt64(queryObj["Size"].ToString().Trim(' ')) / 1000 / 1000 / 1000)).ToString();
                if (queryObj["SerialNumber"] != null) cp.SerialNumber = queryObj["SerialNumber"].ToString().Trim(' ');
                if (queryObj["FirmwareRevision"] != null) cp.FirmwareRevision = queryObj["FirmwareRevision"].ToString().Trim(' ');
                result.Add(cp);
            }

            return result;
        }

        public static List<CDDrive> Get_CDDrives(ManagementScope scope)
        {
            List<CDDrive> result = new List<CDDrive>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_CDROMDrive");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var cp = new CDDrive();
                if (queryObj["Name"] != null) cp.Model = queryObj["Name"].ToString().Trim(' ');
                if (queryObj["Drive"] != null) cp.DiskLetter = queryObj["Drive"].ToString().Trim(' ');
                if (queryObj["MediaType"] != null) cp.DriveType = queryObj["MediaType"].ToString().Trim(' ');
                if (queryObj["SerialNumber"] != null) cp.SerialNumber = queryObj["SerialNumber"].ToString().Trim(' ');
                result.Add(cp);
            }

            return result;
        }

        public static List<LogicalVolume> Get_LogicalVolumes(ManagementScope scope)
        {
            List<LogicalVolume> result = new List<LogicalVolume>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_LogicalDisk");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var cp = new LogicalVolume();
                if (queryObj["Description"] != null) cp.Description = queryObj["Description"].ToString().Trim(' ');
                if (queryObj["MediaType"] != null) cp.MediaType = queryObj["MediaType"].ToString().Trim(' ');
                if (queryObj["DriveType"] != null) cp.DriveType = queryObj["DriveType"].ToString().Trim(' ');
                if (queryObj["Name"] != null) cp.Name = queryObj["Name"].ToString().Trim(' ');
                if (queryObj["FileSystem"] != null) cp.FileSystem = queryObj["FileSystem"].ToString().Trim(' ');
                if (queryObj["Size"] != null) cp.Size = (int)(Convert.ToInt64(queryObj["Size"].ToString().Trim(' ')) / 1024 / 1024 / 1024);
                if (queryObj["FreeSpace"] != null) cp.Free = (int)(Convert.ToInt64(queryObj["FreeSpace"].ToString().Trim(' ')) / 1024 / 1024 / 1024);
                cp.Used = cp.Size - cp.Free;
                if (queryObj["VolumeName"] != null) cp.VolumeLabel = queryObj["VolumeName"].ToString().Trim(' ');
                if (queryObj["VolumeSerialNumber"] != null) cp.SerialNumber = queryObj["VolumeSerialNumber"].ToString().Trim(' ');
                if (queryObj["MaximumComponentLength"] != null) cp.MaxComponentLength = queryObj["MaximumComponentLength"].ToString().Trim(' ');
                if (queryObj["SupportsDiskQuotas"] != null) cp.SuportDiskQuotas = queryObj["SupportsDiskQuotas"].ToString().Trim(' ');
                if (queryObj["SupportsFileBasedCompression"] != null) cp.SupportFilebasedCompression = queryObj["SupportsFileBasedCompression"].ToString().Trim(' ');
                if (queryObj["Compressed"] != null) cp.Compressed = queryObj["Compressed"].ToString().Trim(' ');
                if (queryObj["ProviderName"] != null) cp.SerialNumber = queryObj["ProviderName"].ToString().Trim(' ');
                result.Add(cp);
            }

            return result;
        }

        public static List<PnPDevice> Get_PnPDevices(ManagementScope scope)
        {
            List<PnPDevice> result = new List<PnPDevice>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_PnPEntity");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var cp = new PnPDevice();
                if (queryObj["ClassGuid"] != null) cp.ClassGUID = queryObj["ClassGuid"].ToString().Trim(' ');
                if (queryObj["Manufacturer"] != null) cp.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["PnPDeviceID"] != null) cp.PnPDeviceID = queryObj["PnPDeviceID"].ToString().Trim(' ');
                if (queryObj["Name"] != null) cp.Name = queryObj["Name"].ToString().Trim(' ');
                if (queryObj["ConfigManagerErrorCode"] != null) cp.ErrorCode = queryObj["ConfigManagerErrorCode"].ToString().Trim(' ');
                result.Add(cp);
            }

            return result;
        }

        public static List<NetworkAdapter> Get_NetworkAdapters(ManagementScope scope)
        {
            List<NetworkAdapter> result = new List<NetworkAdapter>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_NetworkAdapter WHERE PhysicalAdapter = True");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var cp = new NetworkAdapter();
                if (queryObj["Name"] != null) cp.Name = queryObj["Name"].ToString().Trim(' ');
                if (queryObj["Manufacturer"] != null) cp.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["ConfigManagerErrorCode"] != null) cp.ErrorCode = queryObj["ConfigManagerErrorCode"].ToString().Trim(' ');
                if (queryObj["MACAddress"] != null) cp.MACAddress = queryObj["MACAddress"].ToString().Trim(' ');
                if (queryObj["AdapterType"] != null) cp.AdapterType = queryObj["AdapterType"].ToString().Trim(' ');
                if (queryObj["NetConnectionID"] != null) cp.NetConnectionID = queryObj["NetConnectionID"].ToString().Trim(' ');
                if (queryObj["NetConnectionStatus"] != null) cp.NetConnectionStatus = queryObj["NetConnectionStatus"].ToString().Trim(' ');
                if (queryObj["Speed"] != null) cp.Speed = queryObj["Speed"].ToString().Trim(' ');
                if (queryObj["Availability"] != null) cp.Availability = queryObj["Availability"].ToString().Trim(' ');
                var index = queryObj["DeviceID"];
                ObjectQuery wmiquery2 = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE Index = " + index);
                ManagementObjectSearcher searcher2 = new ManagementObjectSearcher(scope, wmiquery2);
                ManagementObjectCollection coll2 = searcher2.Get();
                foreach (ManagementObject queryObj2 in coll2)
                {
                    if (queryObj2["IPAddress"] != null) cp.IPAddress = string.Join(", ", ((string[])queryObj2["IPAddress"]));
                    if (queryObj2["IPSubnet"] != null) cp.IPSubnet = string.Join(", ", ((string[])queryObj2["IPSubnet"]));
                    if (queryObj2["DefaultIPGateway"] != null) cp.DefaultIPGateway = string.Join(", ", ((string[])queryObj2["DefaultIPGateway"]));
                    if (queryObj2["DNSServerSearchOrder"] != null) cp.DNSServerOrder = string.Join(", ",((string[])queryObj2["DNSServerSearchOrder"]));
                    if (queryObj2["DHCPEnabled"] != null) cp.DHCPEnabled = queryObj2["DHCPEnabled"].ToString().Trim(' ');
                    if (queryObj2["DHCPServer"] != null) cp.DHCPServerName = queryObj2["DHCPServer"].ToString().Trim(' ');
                    if (queryObj2["DNSDomain"] != null) cp.DNSDomain = queryObj2["DNSDomain"].ToString().Trim(' ');
                    if (queryObj2["DNSHostName"] != null) cp.DNSHostName = queryObj2["DNSHostName"].ToString().Trim(' ');
                    if (queryObj2["TcpipNetbiosOptions"] != null) cp.NetBIOSParameters = queryObj2["TcpipNetbiosOptions"].ToString().Trim(' ');
                    if (queryObj2["IPFilterSecurityEnabled"] != null) cp.IPFilterEnabled = queryObj2["IPFilterSecurityEnabled"].ToString().Trim(' ');
                }
                result.Add(cp);
            }

            return result;
        }

        public static List<SoundDevice> Get_SoundDevices(ManagementScope scope)
        {
            List<SoundDevice> result = new List<SoundDevice>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_SoundDevice");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var cp = new SoundDevice();
                if (queryObj["Name"] != null) cp.Name = queryObj["Name"].ToString().Trim(' ');
                if (queryObj["Manufacturer"] != null) cp.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["ConfigManagerErrorCode"] != null) cp.ErrorCode = queryObj["ConfigManagerErrorCode"].ToString().Trim(' ');
                result.Add(cp);
            }

            return result;
        }

        public static List<Monitor> Get_Monitors(ManagementScope scope)
        {
            List<Monitor> result = new List<Monitor>();
            
            //Get monitor value
            string softwareRegLoc = @"SYSTEM\CurrentControlSet\Enum\DISPLAY";

            ManagementClass registry = new ManagementClass(scope, new ManagementPath("StdRegProv"), null);
            ManagementBaseObject inParams = registry.GetMethodParameters("EnumKey");
            inParams["hDefKey"] = 0x80000002;//HKEY_LOCAL_MACHINE
            inParams["sSubKeyName"] = softwareRegLoc;

            // Read Registry Key Names 
            ManagementBaseObject outParams = registry.InvokeMethod("EnumKey", inParams, null);
            string[] monitorIDs = outParams["sNames"] as string[];

            foreach (string subKeyName in monitorIDs)
            {
                Monitor mon = new Monitor();
                mon.MonitorID = subKeyName;
                inParams = registry.GetMethodParameters("GetStringValue");
                inParams["hDefKey"] = 0x80000002;//HKEY_LOCAL_MACHINE
                inParams["sSubKeyName"] = softwareRegLoc + @"\" + subKeyName;
                // Read Registry Value 
                outParams = registry.InvokeMethod("EnumKey", inParams, null);
                string[] pnpIDs = outParams["sNames"] as string[];
                foreach (string pnpID in pnpIDs)
                {
                    inParams = registry.GetMethodParameters("GetStringValue");
                    inParams["hDefKey"] = 0x80000002;//HKEY_LOCAL_MACHINE
                    inParams["sSubKeyName"] = softwareRegLoc + @"\" + subKeyName + "\\" + pnpID;
                    // Read Registry Value 
                    outParams = registry.InvokeMethod("EnumKey", inParams, null);
                    string[] controls = outParams["sNames"] as string[];
                    if (controls.Contains("Control"))
                    {
                        inParams = registry.GetMethodParameters("GetBinaryValue");
                        inParams["hDefKey"] = 0x80000002;//HKEY_LOCAL_MACHINE
                        inParams["sSubKeyName"] = softwareRegLoc + @"\" + subKeyName + "\\" + pnpID + "\\Device Parameters";
                        inParams["sValueName"] = "EDID";
                        // Read Registry Value 
                        outParams = registry.InvokeMethod("GetBinaryValue", inParams, null);

                        if (outParams.Properties["uValue"].Value != null)
                        {
                            byte[] bObj = (byte[])outParams.Properties["uValue"].Value;
                            if (bObj != null)
                            {
                                //Get the 4 Vesa descriptor blocks
                                string[] sDescriptor = new string[4];
                                Encoding ANSI = Encoding.GetEncoding(1252);
                                sDescriptor[0] = ANSI.GetString(bObj, 0x5A, 18);
                                sDescriptor[1] = ANSI.GetString(bObj, 0x6C, 18);
                                //Detect right section in EDID. Serial number and model section might be swapped
                                if(bObj[93] == 255) //Serial number section start flag
                                {
                                    mon.SerialNumber = sDescriptor[0].Substring(5).Replace(@"\0\0\0y\0", "").Trim();
                                }
                                else
                                {
                                    mon.Model = sDescriptor[0].Substring(5).Replace(@"\0\0\0y\0", "").Trim();
                                }
                                if (bObj[111] == 252) //Model section start flag
                                {
                                    mon.Model = sDescriptor[1].Substring(5).Replace(@"\0\0\0y\0", "").Trim();
                                }
                                else
                                {
                                    mon.SerialNumber = sDescriptor[1].Substring(5).Replace(@"\0\0\0y\0", "").Trim();
                                }
                                // Get Manufacturer
                                byte[] data2 = { bObj[09], bObj[08] };
                                short word = BitConverter.ToInt16(data2, 0);
                                short first = (short)(word >> 10);
                                short third = (short)(word & (short)31);
                                short second = (short)((word >> 5) & (short)31);
                                byte[] name_data = { (byte)(first + 0x40), (byte)(second + 0x40), (byte)(third + 0x40) };
                                string tmpval = "";
                                mon.dict.TryGetValue(ANSI.GetString(name_data, 0, 3), out tmpval);
                                mon.Manufacturer = tmpval;
                                // Get other parameters
                                byte type_data = (byte)(bObj[20] >> 7);
                                if (type_data == 1) { mon.VideoInputType = "Digital"; } else { mon.VideoInputType = "Analog"; };
                                byte[] hordata = { bObj[56], (byte)(bObj[58] >> 4) };
                                short hor = BitConverter.ToInt16(hordata, 0);
                                byte[] verdata = { bObj[59], (byte)(bObj[61] >> 4) };
                                short ver = BitConverter.ToInt16(verdata, 0);
                                mon.MaxResolution = hor.ToString() + " x " + ver.ToString();
                                int inches = (int)Math.Ceiling((Math.Sqrt((bObj[21] * bObj[21]) + (bObj[22] * bObj[22])) / 2.54));
                                mon.Dimensions = bObj[21] + "cm x " + bObj[22] + "cm (" + inches + "\")";
                                mon.Gamma = 1 + ((double)bObj[23] / 100);
                                mon.ManufactureDate = (1990 + bObj[17]) + " / " + bObj[16] + " week";
                                int w = bObj[21];
                                int h = bObj[22];
                                mon.AspectRatio = string.Format("{0}:{1}", hor / GCD(hor, ver), ver / GCD(hor, ver));

                                result.Add(mon);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static List<OSHotfix> Get_OSHotfixes(ManagementScope scope)
        {
            List<OSHotfix> result = new List<OSHotfix>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_QuickFixEngineering");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var pr = new OSHotfix();
                if (queryObj["HotFixID"] != null) pr.HotfixID = queryObj["HotFixID"].ToString().Trim(' ');
                if (queryObj["Description"] != null) pr.Description = queryObj["Description"].ToString().Trim(' ');
                if (queryObj["Caption"] != null) pr.Caption = queryObj["Caption"].ToString().Trim(' ');
                if (queryObj["InstalledBy"] != null) pr.InstalledBy = queryObj["InstalledBy"].ToString().Trim(' ');
                if (queryObj["InstalledOn"] != null) pr.InstalledOn = queryObj["InstalledOn"].ToString().Trim(' ');
                result.Add(pr);
            }

            return result;
        }

        public static List<Codec> Get_Codecs(ManagementScope scope)
        {
            List<Codec> result = new List<Codec>();

            ObjectQuery wmiquery = new ObjectQuery("SELECT * FROM Win32_CodecFile");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, wmiquery);
            ManagementObjectCollection coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                var pr = new Codec();
                if (queryObj["FileName"] != null && queryObj["Extension"] != null) pr.Name = queryObj["FileName"].ToString().Trim(' ') + "." + queryObj["Extension"].ToString().Trim(' ');
                if (queryObj["Group"] != null) pr.Group = queryObj["Group"].ToString().Trim(' ');
                if (queryObj["Manufacturer"] != null) pr.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["Description"] != null) pr.Description = queryObj["Description"].ToString().Trim(' ');
                if (queryObj["Version"] != null) pr.Version = queryObj["Version"].ToString().Trim(' ');
                if (queryObj["InstallDate"] != null) pr.InstallDate = queryObj["InstallDate"].ToString().Trim(' ');
                if (queryObj["LastModified"] != null) pr.Modified = queryObj["LastModified"].ToString().Trim(' ');
                if (queryObj["LastAccessed"] != null) pr.LastAccessed = queryObj["LastAccessed"].ToString().Trim(' ');
                result.Add(pr);
            }

            return result;
        }
    }
}
