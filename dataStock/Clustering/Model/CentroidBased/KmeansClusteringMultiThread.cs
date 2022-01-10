using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Management;

namespace Giwer.dataStock.Clustering.Model.CentroidBased
{
    class KmeansClusteringMultiThread : KmeansClustering
    {
        #region Constants
        public uint MaxProcessNum = 1;
        #endregion

        #region Constructors
        public KmeansClusteringMultiThread(
            uint maxIter,
            float changeThreshold,
            uint minClusterNum,
            uint maxClusterNum,
            float changeElbow)
            : base(maxIter, changeThreshold, minClusterNum, maxClusterNum, changeElbow)
        { }

        private KmeansClusteringMultiThread(
            byte[][] points,
            IProgress<ClusteringProgress> progress,
            int pointDim,
            uint maxIter,
            float changeThreshold,
            uint minClusterNum,
            uint maxClusterNum,
            float changeElbow)
            : this(maxIter, changeThreshold, minClusterNum, maxClusterNum, changeElbow)
        {
            _points = points;
            Progress = progress;
            PointDim = pointDim;
        }
        #endregion

        protected override byte[] ExecuteBody()
        {
            InitProcnum();

            var task = GetElbow();
            uint numberOfClusters = task.Result;

            InitEmptyKmeansClusters(numberOfClusters);
            AssignPointsToClusters();
            uint iter = 1;
            float prevSSE = float.MaxValue;
            float currentSSE = TotalSSE();
            while (iter <= MaxIter && (currentSSE / prevSSE) < ChangeThreshold)
            {
                prevSSE = currentSSE;
                UpdateCentroids();
                ReassignPointsToClusters();
                currentSSE = TotalSSE();
                CancellationToken.ThrowIfCancellationRequested();
                Progress.Report(ClusteringProgress.StepTaken((int)iter));
                ++iter;
            }
            System.Diagnostics.Debug.WriteLine("Final numberOfClusters: " + numberOfClusters + " with iterations: " + (iter - 1) +
                " and SSE = " + currentSSE);

            return GetResultInByteArray();
        }

        private void InitProcnum()
        {
            long PictureSizeInKB = (long)(_points.Length * PointDim) / 1024; // TODO: is this correct for images with Nbits other than 8? Originally: (_gImgData.Ncols * _gImgData.Nrows * _bandsToUse.Length * _gImgData.Nbits/8)/1024;

            System.Diagnostics.Debug.WriteLine("Number Of Logical Processors: {0}", Environment.ProcessorCount);

            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();
            Int64 TotalVisibleMemorySize = 0;
            Int64 FreePhysicalMemory = 0;
            foreach (ManagementObject result in results)
            {
                TotalVisibleMemorySize = Int64.Parse(result["TotalVisibleMemorySize"].ToString());
                FreePhysicalMemory = Int64.Parse(result["FreePhysicalMemory"].ToString());
                System.Diagnostics.Debug.WriteLine("Total Visible Memory: {0} GB", TotalVisibleMemorySize / 1024.0 / 1024.0);
                System.Diagnostics.Debug.WriteLine("Free Physical Memory: {0} GB", FreePhysicalMemory / 1024.0 / 1024.0);
                System.Diagnostics.Debug.WriteLine("Picture size: {0} GB", PictureSizeInKB / 1024.0 / 1024.0);
            }

            if (FreePhysicalMemory / (PictureSizeInKB * 50) > Environment.ProcessorCount - 1)
            {
                MaxProcessNum = (uint)Environment.ProcessorCount - 1;
            }
            else
            {
                MaxProcessNum = (uint)(FreePhysicalMemory / (PictureSizeInKB * 50));
            }
            System.Diagnostics.Debug.WriteLine("MaxprocessNum: " + MaxProcessNum);
        }


        private async Task<uint> GetElbow()
        {
            var currentClusteringTasks = new List<Task<KeyValuePair<uint, float>>>();
            for (uint i = MinClusterNum; i <= MaxClusterNum && i < MinClusterNum + MaxProcessNum; ++i)
            {
                currentClusteringTasks.Add(ClusteringAtGivenNumberAsync(i));
            }

            var sseValues = new SortedDictionary<uint, float>();
            uint nextClusternum = MinClusterNum + MaxProcessNum + 1;
            while (currentClusteringTasks.Count > 0)
            {
                CancellationToken.ThrowIfCancellationRequested();
                var finishedTask = await Task.WhenAny<KeyValuePair<uint, float>>(currentClusteringTasks);
                KeyValuePair<uint, float> Pair = await finishedTask;
                sseValues.Add(Pair.Key, Pair.Value);


                currentClusteringTasks.Remove(finishedTask);
                if (nextClusternum <= MaxClusterNum)
                {
                    currentClusteringTasks.Add(ClusteringAtGivenNumberAsync(nextClusternum));
                    ++nextClusternum;
                }
            }

            uint ret = MinClusterNum;
            bool found = false;
            float sse;
            float sseNext;
            float sseNextNext;
            if (sseValues.Count > 3)
            {
                while (!found && sseValues.TryGetValue(ret, out sse) && sseValues.TryGetValue(ret + 1, out sseNext) && sseValues.TryGetValue(ret + 2, out sseNextNext))
                {
                    found = Math.Abs(sse / sseNext - sseNext / sseNextNext) < Elbow;
                    ++ret;
                }
            }
            return ret;
        }


        private async Task<KeyValuePair<uint, float>> ClusteringAtGivenNumberAsync(uint numberOfClusters)
        {
            var clusteringTask = Task.Run(() =>
            {
                return new KeyValuePair<uint, float>(numberOfClusters, ClusteringAtGivenNumbera(numberOfClusters).ClusteringAtGivenNumber(numberOfClusters));
            });
            return await clusteringTask;
        }

        private KmeansClusteringMultiThread ClusteringAtGivenNumbera(uint numberOfClusters)
        {
            var pointsCopy = new byte[_points.Length][];
            _points.CopyTo(pointsCopy, 0);
            return new KmeansClusteringMultiThread(pointsCopy, Progress, PointDim, MaxIter, ChangeThreshold, numberOfClusters, numberOfClusters, Elbow);
        }



    }
}
