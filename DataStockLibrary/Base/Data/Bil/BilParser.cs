using System;
using System.Collections.Generic;
using System.Text;

namespace DataStockLibrary.Base.Data.Bil
{
    internal class BilParser : IHeaderParser
    {
        public ImageAttribute Parse(string fileName)
        {
            ImageAttribute imageAttribute = new ImageAttribute();
            using (FileStream fs = new(Path.ChangeExtension(fileName, ".hdr"), FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new(fs);
                string line;
                while (!sr.EndOfStream)
                {
                    line = System.Text.RegularExpressions.Regex.Replace(sr.ReadLine(), @"\s{2,}", " "); // multi space are removed and substitute with one space " "
                    getBILParams(line, imageAttribute);
                }
                if (imageAttribute.BytesPerPixel == 0) imageAttribute.BytesPerPixel = (imageAttribute.NBits / 8) * imageAttribute.NBands;

                imageAttribute.Stride = 4 * ((imageAttribute.Size.NCols * imageAttribute.BytesPerPixel + 3) / 4);  //* _nBands;                
            }
            return imageAttribute;
        }

        private void getBILParams(string line, ImageAttribute imageAttribute)  //parsing bil parameters from the given bil file
        {
            double xDim = 0, yDim = 0, ulxmap = 0, ulymap = 0, lrxmap = 0, lrymap = 0, xllcenter = 0, yllcenter = 0, cellsize = 0;
            int nCols = 0, nRows = 0;

            if (line.ToLower().Contains("byteorder")) { imageAttribute.ByteOrder = line.Split(' ')[1]; }
            if (line.ToLower().Contains("layout")) { imageAttribute.Layout = line.Split(' ')[1]; }
            if (imageAttribute.Layout == "layout") { imageAttribute.DataType = "ENVI BIL"; }
            if (imageAttribute.Layout == "" || imageAttribute.Layout == "bil") { imageAttribute.DataType = "ESRI BIL"; }
            if (line.ToLower().Contains("datatype")) { imageAttribute.DataType = line.Split(' ')[1]; }
            if (line.ToLower().Contains("nbits")) { imageAttribute.NBits = Convert.ToInt16(line.Split(' ')[1]); }
            if (line.ToLower().Contains("xdim")) { xDim = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ydim")) { yDim = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ncols")) { nCols = Convert.ToInt32(line.Split(' ')[1]); }
            if (line.ToLower().Contains("nrows")) { nRows = Convert.ToInt32(line.Split(' ')[1]); }
            if (line.ToLower().Contains("nbands")) { imageAttribute.NBands = Convert.ToInt16(line.Split(' ')[1]); }
            if (line.ToLower().Contains("ulxmap")) { ulxmap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ulymap")) { ulymap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("lrxmap")) { lrxmap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("lrymap")) { lrymap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.Substring(0, 1) == "#") { imageAttribute.Comment = line; }
            if (line.ToLower().Contains("xllcenter")) { xllcenter = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("yllcenter")) { yllcenter = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("cellsize")) { cellsize = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }

            ImageSize imageSize = new ImageSize
            {
                XDimension = xDim,
                YDimension = yDim,
                NCols = nCols,
                NRows = nRows,
                ULXMap = ulxmap,
                ULYMap = ulymap,
                LRXMap = lrxmap,
                LRYMap = lrymap,
                XLLCenter = xllcenter,
                YLLCenter = yllcenter,
                CellSize = cellsize
            };
            imageSize.AdjustValues();
            imageAttribute.Size = imageSize;
        }
    }
}
