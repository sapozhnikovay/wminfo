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

            if(categories.Contains("os")) result.OperatingSystems = Get_OperatingSystems(scope);
            if (categories.Contains("software")) result.SoftwareProducts = Get_SoftwareProducts(scope);
            if (categories.Contains("processor")) result.Processors = Get_Processors(scope);
            if (categories.Contains("cachememory")) result.CacheMemory = Get_CacheMemory(scope);
            if (categories.Contains("ram")) result.Memory = Get_Memory(scope);
            if (categories.Contains("video")) result.VideoControllers = Get_VideoControllers(scope);

            return result;
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
                result.PagefileSizeActual = Convert.ToInt32(queryObj["CurrentUsage"].ToString().Trim(' '));
                result.PagefileSizeMaximum = Convert.ToInt32(queryObj["AllocatedBaseSize"].ToString().Trim(' '));
            }

            wmiquery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                result.VirtualMemorySize = Convert.ToInt32(queryObj["TotalVirtualMemorySize"].ToString().Trim(' '));
                result.TotalVisibleMemorySize = Convert.ToInt32(queryObj["TotalVisibleMemorySize"].ToString().Trim(' '))/1024;
                result.FreeMemorySize = Convert.ToInt32(queryObj["FreePhysicalMemory"].ToString().Trim(' '))/1024;
            }

            wmiquery = new ObjectQuery("SELECT * FROM Win32_ComputerSystem");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                result.PhysicalMemorySize = (int)(Convert.ToInt64(queryObj["TotalPhysicalMemory"].ToString().Trim(' '))/1024/1024); //Нужно переделать. Не точное число физической памяти.
            }

            result.MemoryLoadPercentage = (int)((float)((float)result.PhysicalMemorySize / (float)result.FreeMemorySize) * 10);
            
            wmiquery = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");
            searcher = new ManagementObjectSearcher(scope, wmiquery);
            coll = searcher.Get();
            foreach (ManagementObject queryObj in coll)
            {
                MemoryModule mm = new MemoryModule();
                mm.Capacity = (int)(Convert.ToInt64(queryObj["Capacity"].ToString().Trim(' ')) / 1024 / 1024);
                mm.BankLabel = queryObj["BankLabel"].ToString().Trim(' ');
                mm.Manufacturer = queryObj["Manufacturer"].ToString().Trim(' ');
                if (queryObj["InstallDate"] != null) mm.ManufactureDate = queryObj["InstallDate"].ToString().Trim(' ');
                mm.MemoryType = queryObj["MemoryType"].ToString().Trim(' ');
                mm.FormFactor = queryObj["FormFactor"].ToString().Trim(' ');
                mm.PartNumber = queryObj["PartNumber"].ToString().Trim(' ');
                mm.SerialNumber = queryObj["SerialNumber"].ToString().Trim(' ');
                mm.Speed = queryObj["Speed"].ToString().Trim(' ');
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
                cp.Availability = queryObj["Availability"].ToString().Trim(' ');
                cp.InstalledVideoRAM = queryObj["AdapterRAM"].ToString().Trim(' ');
                cp.DACType = queryObj["AdapterDACType"].ToString().Trim(' ');
                cp.AdapterFamily = queryObj["AdapterCompatibility"].ToString().Trim(' ');
                cp.AdapterName = queryObj["Name"].ToString().Trim(' ');
                cp.ScanMode = queryObj["CurrentScanMode"].ToString().Trim(' ');
                cp.VideoArchitecture = queryObj["VideoArchitecture"].ToString().Trim(' ');
                cp.VideoMemoryType = queryObj["VideoMemoryType"].ToString().Trim(' ');
                cp.CurrentVideoMode = queryObj["CurrentHorizontalResolution"].ToString().Trim(' ') + " x " + queryObj["CurrentVerticalResolution"].ToString().Trim(' ') + " x " + queryObj["CurrentBitsPerPixel"].ToString().Trim(' ') + "bpp x " + queryObj["CurrentRefreshRate"].ToString().Trim(' ') + " Hz";
                cp.DisplayDrivers = queryObj["InstalledDisplayDrivers"].ToString().Trim(' ');
                cp.DriverVersion = queryObj["DriverVersion"].ToString().Trim(' ');
                cp.DriverDate = queryObj["DriverDate"].ToString().Trim(' ');
                result.Add(cp);
            }

            return result;
        }
    }
}
