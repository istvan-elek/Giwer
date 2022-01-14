using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class PrewittFilter : SingleBandOperation
    {
        public PrewittFilter(GeoImageData image, int band)
            : base(image, band)
        {
        }

        public override void Execute()
        {
            Filter Prewitt = new Filter();
            outputBand = Prewitt.LaplaceOneBand(inputBand, imageData.Ncols, imageData.Nrows);
        }
    }
}
