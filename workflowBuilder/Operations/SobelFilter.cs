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
        public SobelFilter(GeoImageData image, int band)
            : base(image, band)
        {
        }

        public override void Execute()
        {
            Filter Sobel = new Filter();
            outputBand = Sobel.LaplaceOneBand(inputBand, imageData.Ncols, imageData.Nrows);
        }
    }
}
