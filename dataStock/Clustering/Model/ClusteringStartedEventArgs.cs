using System;

namespace Giwer.dataStock.Clustering.Model
{
    public class ClusteringStartedEventArgs : EventArgs
    {
        public uint MaxProgress { get; set; }

        public ClusteringStartedEventArgs(uint maxProgress)
        {
            MaxProgress = maxProgress;
        }
    }
}