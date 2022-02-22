using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder.Operations
{
    public class SaveResult : SingleBandOperation
    {
        byte[] byteIn;

        public string AppendText { get; set; }

        public SaveResult(GeoImageData image, int band, List<string> par) : base(image, band, par)
        {
            byteIn = inputBand;
        }

        public void saveResultAs(string appendText)
        {

        }
        public override void Execute()
        {

        }
    }
}
