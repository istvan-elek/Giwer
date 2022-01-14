using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class LaplaceFilter : SingleBandOperation
    {
        public LaplaceFilter(GeoImageData image, int band)
            : base(image, band)
        {
        }

        public override void Execute()
        {
            Filter LaplFilt = new Filter();
            outputBand = LaplFilt.LaplaceOneBand(inputBand, imageData.Ncols, imageData.Nrows);
        }
    }
}
