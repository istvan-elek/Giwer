using System;
using System.Collections.Generic;
using System.Text;

namespace DataStockLibrary.Base.Data
{
    public record struct ImageAttribute
    {
        public string Time { get; set; }
        public string Date { get; set; }
        public int Samples { get; set; }
        public int Lines { get; set; }
        public string DataType { get; set; }
        public string SensorType { get; set; }
        public string InterLeave { get; set; } 
        public string DefaultBands { get; set; }   
        public int Stride { get; set; } 
        public int NBands { get; set; }    
        public int BytesPerPixel { get; set; } 
        public int NBits { get; set; }
        public string ByteOrder { get; set; }  
        public string Layout { get; set; } 
        public string Compression { get; set; }   
        public string LocationName { get; set; }
        public string Comment { get; set; }
        public ImageSize Size { get; set; } = new ImageSize();
        public ImageCoordinate Coordinate { get; set; } = new ImageCoordinate();
        public ImageCamera Camera { get; set; } = new ImageCamera();
        public ImageWavelength WaveLength { get; set; } = new ImageWavelength();
    }
}
