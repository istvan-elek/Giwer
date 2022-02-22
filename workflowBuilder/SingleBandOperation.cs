using System;
using Giwer.dataStock;
using System.Collections.Generic;

namespace Giwer.workflowBuilder
{
    public abstract class SingleBandOperation
    {
        protected GeoImageData imageData;
        protected GeoImageTools imageTools;
        protected byte[] inputBand, outputBand;

        public byte[] Input => inputBand;

        public byte[] Output => outputBand;

        public List<string> pars;

        public SingleBandOperation(GeoImageData imgData, int band, List<string> par)
        {
            this.imageData = imgData;
            this.imageTools = new GeoImageTools(imgData);
            this.inputBand = imageTools.getOneBandBytes(band);
        }

        public SingleBandOperation(byte[] byIn, GeoImageData gimda, List<string> par)
        {
            imageData = gimda;
            inputBand = byIn;
        }

        public abstract void Execute();
    }
}
