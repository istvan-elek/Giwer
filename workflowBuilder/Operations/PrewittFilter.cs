using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class PrewittFilter : SingleBandOperation
    {
        public PrewittFilter(GeoImageData image, int band, List<string> par)
            : base(image, band, par)
        {
        }

        public PrewittFilter(byte[] inputBand, GeoImageData image, List<string> par)
            : base(inputBand, image, par)
        {
        }

        public override void Execute()
        {
            Filter Prewitt = new Filter();
            outputBand = Prewitt.LaplaceOneBand(inputBand, imageData.Ncols, imageData.Nrows);
        }
    }
}
