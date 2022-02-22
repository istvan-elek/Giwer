using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giwer.dataStock;

namespace Giwer.workflowBuilder
{
    public abstract class MultiBandOperation
    {
        protected GeoImageData imageData;
        protected GeoImageTools imageTools;
        protected IList<byte[]> inputBands;
        protected byte[] outputBand;

        public IList<byte[]> Input => inputBands;

        public byte[] Output => outputBand;

        public MultiBandOperation(GeoImageData imageData, int[] bands)
        {
            this.imageData = imageData;
            this.imageTools = new GeoImageTools(imageData);
            this.inputBands = new List<byte[]>();

            foreach (int band in bands)
            {
                this.inputBands.Add(imageTools.getOneBandBytes(band));
            }
        }

        public abstract void Execute();
    }
}
