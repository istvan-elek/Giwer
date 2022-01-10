using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class NDVI : MultibandOperation
    {

        public NDVI(GeoImageData image, int band) 
            : base(image, band)
        {
        }

        public override void Execute()
        {
            //Filter GaussFilt = new Filter();
            //double[,] kernel = GaussFilt.lowPassKernelGauss(KernelLength);
            //outputBand = GaussFilt.ConvolSingleBand(kernel, inputBand, imageData.Ncols, imageData.Nrows);
        }
    }
}
