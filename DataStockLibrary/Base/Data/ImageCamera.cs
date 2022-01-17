using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStockLibrary.Base.Data
{
    public record struct ImageCamera
    {
        public float Pitch { get; set; }
        public float Yaw { get; set; } 
        public float Roll { get; set; }

    }
}
