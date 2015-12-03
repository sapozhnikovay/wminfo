using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class Computer
    {
        public List<OperatingSystem> OperatingSystems;
        public List<SoftwareProduct> SoftwareProducts;
        public List<Processor> Processors;
        public List<CacheMemory> CacheMemory;

        public Computer()
        {
            OperatingSystems = new List<OperatingSystem>();
            SoftwareProducts = new List<SoftwareProduct>();
            Processors = new List<Processor>();
            CacheMemory = new List<CacheMemory>();
        }

        public string ToTxt()
        {
            string result = "";
            result += "Processors\n--------------------\n\n";
            foreach (Processor item in Processors)
            {
                result += item.ToTxt();
            }
            result += "Operating system\n--------------------\n\n";
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
