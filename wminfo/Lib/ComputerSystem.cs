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
        public List<SystemPort> SystemPorts;
        public List<SystemSlot> SystemSlots;
        public Chassis Chassis;
        public BIOS BIOS;
        public Motherboard Motherboard;

        public ComputerSystem()
        {
            BIOS = new BIOS();
            Chassis = new Chassis();
            Motherboard = new Motherboard();
            SystemPorts = new List<SystemPort>();
            SystemSlots = new List<SystemSlot>();
        }

        public string ToTxt()
        {
            string result = "";
            result += "\nComputer system";
            result += "\n".PadRight(60, '-') + "\n";
            result += "Model".PadRight(30) + " - " + Model.ToString() + "\n";
            result += "Manufacturer".PadRight(30) + " - " + Manufacturer.ToString() + "\n";
            result += "UUID".PadRight(30) + " - " + UUID.ToString() + "\n";
            result += "Product number".PadRight(30) + " - " + ProductNumber.ToString() + "\n";

            result += Chassis.ToTxt();
            result += Motherboard.ToTxt();
            result += BIOS.ToTxt();

            result += "\nSystem ports";
            result += "\n".PadRight(60, '-') + "\n";
            foreach (SystemPort port in SystemPorts)
            {
                result += port.ToTxt();
            }

            result += "\nSystem slots";
            result += "\n".PadRight(60, '-') + "\n";
            foreach (SystemSlot slot in SystemSlots)
            {
                result += slot.ToTxt();
            }

            return result;
        }
    }
}
