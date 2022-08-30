using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class Thresholding : SingleBandOperation
    {
        public int Threshold { get; set; }

        public Thresholding(GeoImageData image, int band, List<string> par) 
            : base(image, band, par)
        {
            Threshold = int.Parse(par[0]);
        }

        public Thresholding(byte[] inputBand, GeoImageData image, List<string> par)
            : base(inputBand, image, par)
        {
            Threshold = int.Parse(par[0]);
        }

        public override void Execute()
        {
            Filter filter = new Filter();
            outputBand = filter.Thresholding(inputBand, imageData.Ncols, imageData.Nrows, Threshold);
        }
    }
}
