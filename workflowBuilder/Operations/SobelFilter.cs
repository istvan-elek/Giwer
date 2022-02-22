using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class SobelFilter : SingleBandOperation
    {
        public SobelFilter(GeoImageData image, int band, List<string> par)
            : base(image, band, par)
        {
        }

        public SobelFilter(byte[] inputBand, GeoImageData image, List<string> par)
            : base(inputBand, image, par)
        {
        }

        public override void Execute()
        {
            Filter Sobel = new Filter();
            outputBand = Sobel.LaplaceOneBand(inputBand, imageData.Ncols, imageData.Nrows);
        }
    }
}
