using System.Diagnostics;

namespace Giwer.dataStock.Clustering.Model.Distance
{
    public class SquaredEuclideanDistance : IDistance
    {
        public float Calculate(byte[] point1, byte[] point2)
        {
            Debug.Assert(point1.Length == point2.Length);

            float res = 0.0F;
            for (int i = 0; i < point1.Length; i++)
            {
                int diff = point1[i] - point2[i];
                res += diff * diff;
            }
            return res;
        }
    }
}
