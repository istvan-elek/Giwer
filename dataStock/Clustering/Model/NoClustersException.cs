using System;

namespace Giwer.dataStock.Clustering.Model
{
    public class NoClustersException : Exception
    {
        public NoClustersException()
        {
        }

        public NoClustersException(string message)
            : base(message)
        {
        }

        public NoClustersException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

