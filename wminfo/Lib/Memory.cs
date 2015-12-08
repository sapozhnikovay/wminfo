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
    }
}
