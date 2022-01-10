using System;

namespace Giwer.dataStock.Clustering.Model
{
    public class ClusteringProgressEventArgs : EventArgs
    {
        public uint CurrentProgress { get; set; }

        public ClusteringProgressEventArgs(uint currentProgress)
        {
            CurrentProgress = currentProgress;
        }
    }
}