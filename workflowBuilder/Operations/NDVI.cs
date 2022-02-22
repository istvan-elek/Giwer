using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class NDVI : MultiBandOperation
    {

        public NDVI(GeoImageData image, int[] bands)
            : base(image, bands)
        {
        }

        public NDVI(GeoImageData image, int nirBand, int redBand)
            : base(image, new int[] {nirBand, redBand})
        {
        }

        public override void Execute()
        {
            GeoMultiBandMethods multiBandMethods = new GeoMultiBandMethods();
            outputBand = multiBandMethods.NDVI(inputBands[0], inputBands[1]);
        }
    }
}
