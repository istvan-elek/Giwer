using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStockLibrary.Base.Data
{
    public record struct ImageWavelength
    {
        public string[] WaveLength { get; set; }
        public string Units { get; set; }
    }
}
