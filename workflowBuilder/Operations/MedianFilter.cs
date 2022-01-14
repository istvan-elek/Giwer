using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class MedianFilter : SingleBandOperation
    {
        public int KernelLength { get; set; }

        public MedianFilter(GeoImageData image, int band)
            : base(image, band)
        {
        }

        public override void Execute()
        {
            Filter mediFilt = new Filter();
            outputBand = mediFilt.MedianFilterOneBand(inputBand, KernelLength, imageData.Ncols, imageData.Nrows);
        }
    }
}
