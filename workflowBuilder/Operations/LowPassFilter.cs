using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class LowPassFilter : SingleBandOperation
    {
        public int KernelLength { get; set; }

        public LowPassFilter(GeoImageData image, int band, List<string> pars) 
            : base(image, band, pars)
        {
            KernelLength = int.Parse(pars[0]);
        }

        public LowPassFilter(byte[] inputBand, GeoImageData image, List<string> pars)
            : base(inputBand, image, pars)
        {
            KernelLength = int.Parse(pars[0]);
        }

        public override void Execute()
        {
            Filter filt = new Filter();
            double[,] kernel = filt.highPassKernel(KernelLength);

            byte[] byteOrig = inputBand;
            byte[] byteSmoothed = filt.ConvolSingleBand(kernel, inputBand, imageData.Ncols, imageData.Nrows);
            outputBand = byteSmoothed;
        }
    }
}
