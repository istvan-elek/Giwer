using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class Histogram : SingleBandOperation
    {

        public Histogram(GeoImageData image, int band, List<string> par)
    : base(image, band, par)
        {

        }

        public Histogram(byte[] inputBand, GeoImageData image, List<string> par)
            : base(inputBand, image, par)
        {

        }

        public override void Execute()
        {
            Histogram3 hist = new Histogram3();
            outputBand = hist.HistogramEqualization(inputBand);
        }
    }
}
