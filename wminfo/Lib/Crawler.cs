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
        public static Computer GetInfo(string targetHost, string username, string password)
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

            result.OperatingSystems = Get_OperatingSystems(scope);

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
    }
}
