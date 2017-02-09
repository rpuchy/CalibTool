using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalibrationDocumentation
{
    class ModelID
    {

        public ModelID()
        {
            
        }

        public string RangeName { get; set; }
        public string VarName { get; set; }
        public int timestep { get; set; }
        public int order { get; set; }
        public List<double> ScenarioData { get; set; }
        public double LBound { get; set; }
        public double UBound { get; set; }
    }
}
