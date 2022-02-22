using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class LaplaceFilter : SingleBandOperation
    {
        public LaplaceFilter(GeoImageData image, int band, List<string> par)
            : base(image, band, par)
        {
        }

        public LaplaceFilter(byte[] inputBand, GeoImageData image, List<string> par)
            : base(inputBand, image, par)
        {
        }

        public override void Execute()
        {
            Filter LaplFilt = new Filter();
            outputBand = LaplFilt.LaplaceOneBand(inputBand, imageData.Ncols, imageData.Nrows);
        }
    }
}
