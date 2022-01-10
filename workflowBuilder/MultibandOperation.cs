using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder
{
    public abstract class MultibandOperation
    {
        protected GeoImageData imageData;
        protected GeoImageTools imageTools;
        protected byte[] inputBand, outputBand;

        public byte[] Input => inputBand;

        public byte[] Output => outputBand;

        public MultibandOperation(GeoImageData imageData, int band)
        {
            this.imageData = imageData;
            this.imageTools = new GeoImageTools(imageData);
            this.inputBand = imageTools.getOneBandBytes(band);
        }

        public abstract void Execute();
    }
}
