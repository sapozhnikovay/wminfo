using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    /// <summary>
    /// Computer memory configuration
    /// </summary>
    class Memory
    {
        /// <summary>
        /// The physical memory size
        /// </summary>
        public int PhysicalMemorySize;
        public int TotalVisibleMemorySize;
        public int PagefileSizeActual;
        public int PagefileSizeMaximum;
        public int VirtualMemorySize;
        public int FreeMemorySize;
        public int MemoryLoadPercentage;
        public List<MemoryModule> MemoryModules;

        public Memory()
        {
            MemoryModules = new List<MemoryModule>();
        }

        public string ToTxt()
        {
            string result = "";
            result += "\nGeneral information";
            result += "\n".PadRight(60, '-') + "\n";
            result += "Physical memory".PadRight(30) + " - " + PhysicalMemorySize.ToString() + " MB\n";
            result += "Memory visible to OS".PadRight(30) + " - " + TotalVisibleMemorySize.ToString() + " MB\n";
            result += "Paging files (actual on disk)".PadRight(30) + " - " + PagefileSizeActual.ToString() + " MB\n";
            result += "Paging files (maximum size)".PadRight(30) + " - " + PagefileSizeMaximum.ToString() + " MB\n";
            result += "Virtual memory".PadRight(30) + " - " + VirtualMemorySize.ToString() + " MB\n";
            result += "Free".PadRight(30) + " - " + FreeMemorySize.ToString() + " MB\n";
            result += "Load".PadRight(30) + " - " + MemoryLoadPercentage.ToString() + "%\n";
            result += "\nMemory modules";
            result += "\n".PadRight(60, '-') + "\n";
            foreach (MemoryModule module in MemoryModules)
            {
                result += module.ToTxt();
            }

            return result;
        }
    }
}
