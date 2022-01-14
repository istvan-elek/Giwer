using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class Thresholding : SingleBandOperation
    {
        public int threshold { get; set; }

        public Thresholding(GeoImageData image, int band)
            : base(image, band)
        {
        }

        public override void Execute()
        {
            Filter Threshold = new Filter();
            outputBand = Threshold.Thresholding(inputBand, imageData.Ncols, imageData.Nrows, threshold);
        }
    }
}
