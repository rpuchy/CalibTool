using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationDocumentation
{
    class DataMap
    {

        public DataMap()
        {
            
        }

        public string File { get; set; }
        public string xPath { get; set; }
        public string Value { get; set; }
        public int decimals { get; set; }
        public string overwrite { get; set; }
        public string vformat { get; set; }
    }

    
}
