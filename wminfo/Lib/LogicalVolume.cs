using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class LogicalVolume
    {
        public string Description = "";
        public string MediaType = "";
        public string DriveType = "";
        public string Name = "";
        public string FileSystem = "";
        public int Size = 0;
        public int Used = 0;
        public int Free = 0;
        public string VolumeLabel = "";
        public string SerialNumber = "";
        public string MaxComponentLength = "";
        public string SuportDiskQuotas = "";
        public string SupportFilebasedCompression = "";
        public string Compressed = "";
        public string IsDirty = "";
        public string Path = "";
        public string User = "";

        public LogicalVolume()
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
