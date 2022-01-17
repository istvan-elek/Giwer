using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStockLibrary.Base
{
    internal class Utility
    {
        public static double ConvertDegree2Decimal(string inSt)
        {
            string[] outSt = inSt.Split(' ');
            int deg = Convert.ToInt16(outSt[0]); //.Substring(0, outSt[0].Length - 1));
            int min = Convert.ToInt16(outSt[2].Substring(0, outSt[2].Length - 1), CultureInfo.InvariantCulture);
            Single sec = Convert.ToSingle(outSt[3].Substring(0, outSt[3].Length - 1), CultureInfo.InvariantCulture);
            double coord = deg + Convert.ToDouble(min) / 60D + Convert.ToDouble(sec) / 3600D;
            return coord;
        }
    }
}
