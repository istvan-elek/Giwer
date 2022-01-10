namespace Giwer.dataStock.Clustering.Model.Distance
{
    public interface IDistance
    {
        float Calculate(byte[] point1, byte[] point2);
    }
}
