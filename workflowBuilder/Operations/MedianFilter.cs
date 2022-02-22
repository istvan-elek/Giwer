using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class MedianFilter : SingleBandOperation
    {
        public int KernelLength { get; set; }

        public MedianFilter(GeoImageData image, int band, List<string> par) 
            : base(image, band, par)
        {
            KernelLength = int.Parse( par[0]);
        }

        public MedianFilter(byte[] inputBand, GeoImageData image, List<string> par)
            : base(inputBand, image, par)
        {
            KernelLength = int.Parse(par[0]);
        }

        public override void Execute()
        {
            Filter mediFilt = new Filter();
            outputBand = mediFilt.MedianFilterOneBand(inputBand, KernelLength, imageData.Ncols, imageData.Nrows);
        }
    }
}
