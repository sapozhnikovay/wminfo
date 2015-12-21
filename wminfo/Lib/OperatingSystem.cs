using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class OperatingSystem
    {
        public string ServicePack; //+
        public string Manufacturer; //+
        public string Version; //+
        public string Architecture; //+
        public string RegisteredUser; //+
        public string Organization; //+
        public string CodeSet; //+
        public string CountryCode; //+
        public string StandartTimeZone = "";
        public string CurrentTimeZone; //+
        public bool DSTAutoadjust = false; // автопереход на летнее время
        public bool DSTInEffect = false; // летнее время активно?
        public string EncryptionLevel; //+
        public string ForegroundApplicationBoost; //+
        public string InstallDate; //+
        public string LastBootupTime; // +время последней загрузки
        public string LocalDateTime; // +локальное время 
        public string Locale; //+
        public string OSLanguage; //+
        public string OSType; //+ тип операционной системы
        public int ProductType; //+ 1-Workstation, 2-DC, 3-Server
        public string ProductID; //+
        public string ProductKey = ""; // ключ продукта
        public string Suite = "";
        public string SystemDrive; //+
        public string WindowsDirectory; //+
        public string SKU; //+ складской номер, артикул
        public string SupplyChannel = "";
        public string ProductName; //+
        public string ProductDescription = "";
        public string LicenseStatus = "";
        public string InternetExplorerVersion = "";
        public string DirectXVersion = "";

        public override string ToString()
        {
            return base.ToString();
        }

        public string ToTxt()
        {
            string result = "";
            result += "Operating System\n--------------------\n";

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
