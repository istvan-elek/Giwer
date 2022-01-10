using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class HighPassFilter : SingleBandOperation
    {
        public int KernelLength { get; set; }

        public HighPassFilter(GeoImageData image, int band) 
            : base(image, band)
        {
        }

        public override void Execute()
        {
            Filter filt = new Filter();
            double[,] kernel = filt.highPassKernel(KernelLength);

            byte[] byteOrig = inputBand;
            byte[] byteSmoothed = filt.ConvolSingleBand(kernel, inputBand, imageData.Ncols, imageData.Nrows);
            outputBand = imageTools.combine2Images(GeoImageTools.OperationType.Minus, byteOrig, byteSmoothed);
        }
    }
}
