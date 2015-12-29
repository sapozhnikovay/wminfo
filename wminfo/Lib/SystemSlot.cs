using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class SystemSlot
    {
        public string SlotDesignation = "";
        public string Availability = "";

        public SystemSlot()
        {

        }

        public string ToTxt()
        {
            string result = "";
            result += SlotDesignation + " (" + Availability + ")\n";
            return result;
        }
    }
}
