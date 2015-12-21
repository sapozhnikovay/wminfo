using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wminfo.Lib
{
    class SystemPort
    {
        public string PortType = "";
        public string ConnectorType = "";
        public string Name = "";

        public SystemPort()
        {

        }

        public string ToTxt()
        {
            string result = "";
            result += Name + "(" + PortType + " / " + ConnectorType + ")\n";
            return result;
        }
    }
}
