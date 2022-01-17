using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStockLibrary.Base.Data
{
    public record struct ImageCoordinate
    {
        public string CoordinateSystem { get; set; }
        public double GpsLatittude { get; set; }   
        public double GpsLongitude { get; set; }   
        public string GpsLatitudeRef { get; set; } 
        public string GpsLongitudeRef { get; set; }
        public Single GpsAltitude { get; set; }    
        public string GpsAltitudeRef { get; set; } 
        public float AbsoluteAltitude { get; set; }    
        public float RelativeAltitude { get; set; }    

    }
}
