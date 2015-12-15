using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class ComputerSystem
    {
        public string Model = "";
        public string Manufacturer = "";
        public string UUID = "";
        public string ProductNumber = "";
        public Chassis Chassis;
        public BIOS BIOS;
        public Motherboard Motherboard;

        public ComputerSystem()
        {
            BIOS = new BIOS();
            Chassis = new Chassis();
            Motherboard = new Motherboard();
        }
    }
}
