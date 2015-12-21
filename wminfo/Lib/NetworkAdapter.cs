using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class NetworkAdapter
    {
        public string Name = "";
        public string Manufacturer = "";
        public string ManufacturerByMAC = "";
        public string MACAddress = "";
        public string AdapterType = "";
        public string NetConnectionID = "";
        public string NetConnectionStatus = "";
        public string Speed = "";
        public string IPAddress = "";
        public string IPSubnet = "";
        public string DefaultIPGateway = "";
        public string DNSServerOrder = "";
        public string DHCPEnabled = "";
        public string DHCPServerName = "";
        public string DNSDomain = "";
        public string DNSHostName = "";
        public string NetBIOSParameters = "";
        public string IPFilterEnabled = "";
        public string Availability = "";
        public string ErrorCode = "";

        public NetworkAdapter()
        {

        }

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
