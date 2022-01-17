using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStockLibrary.Base.Data
{
    public record struct ImageSize
    {
        public int NCols { get; set; }
        public int NRows { get; set; }
        public double XDimension { get; set; } 
        public double YDimension { get; set; }
        public double ULXMap { get; set; }
        public double ULYMap { get; set; } 
        public double LRXMap { get; set; }
        public double LRYMap { get; set; } 
        public double XLLCenter { get; set; }  
        public double YLLCenter { get; set; }  
        public double CellSize { get; set; }

        public void AdjustValues() {
            if (CellSize != 0) { 
                XDimension = CellSize;
                YDimension = XDimension; }
            if (CellSize == 0 && XDimension == YDimension) CellSize = XDimension;
            if (LRXMap == 0 && LRYMap == 0) { LRXMap = ULXMap + NCols * XDimension; ULXMap = ULYMap + NRows * YDimension; }
            if (XLLCenter != 0 && YLLCenter != 0)
            {
                ULXMap = XLLCenter - (NCols * XDimension) / 2F;
                LRXMap = XLLCenter + (NCols * XDimension) / 2F;
                ULXMap = YLLCenter - (NRows * YDimension) / 2F;
                ULXMap = YLLCenter + (NRows * YDimension) / 2F;
            }
        }
    }
}
