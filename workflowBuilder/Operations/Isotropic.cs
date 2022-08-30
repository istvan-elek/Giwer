using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    class IsotropicFilter : SingleBandOperation
    {
        public IsotropicFilter(GeoImageData image, int band, List<string> par)
           : base(image, band, par)
        {
        }

        public IsotropicFilter(byte[] inputBand, GeoImageData image, List<string> par)
            : base(inputBand, image, par)
        {
        }

        public override void Execute()
        {
            Filter Isotropic = new Filter();
            outputBand = Isotropic.Isotropic(inputBand, imageData.Ncols, imageData.Nrows);
        }
    }
}
