using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace catalog
{
    public class MicaSense
    {
        /// <summary>
        /// MicaSense image alignment with ECC.
        /// </summary>
        /// <remarks>
        /// The ECC image alignment algorithm introduced in OpenCV 3 is based on a 2008 paper titled
        /// Parametric Image Alignment using Enhanced Correlation Coefficient Maximization
        /// by Georgios D. Evangelidis and Emmanouil Z. Psarakis.
        /// They propose using a new similarity measure called Enhanced Correlation Coefficient (ECC)
        /// for estimating the parameters of the motion model.
        /// </remarks>
        /// <see cref="http://xanthippi.ceid.upatras.gr/people/evangelidis/george_files/PAMI_2008.pdf"/>
        /// <param name="imagePaths">Path of the input image bands.</param>
        /// <param name="outputFolder">Path of the aligned output images.</param>
        /// <param name="refIndex">Reference channel index to align to.</param>
        /// <param name="warpMode">Motion model.</param>
        /// <param name="numberOfIterations">Stopping criteria for the algorithm.</param>
        /// <param name="terminationEps">Stopping criteria for the algorithm.</param>
        /// <param name="mergedFileName">Filename of the combined output of all channels. (Leave empty to skip creation.)</param>
        /// <exception cref="ArgumentOutOfRangeException">nameof(refIndex), Reference channel index too large or negative.</exception>
        public static void Align(string[] imagePaths, string outputFolder,
            int refIndex = 0,
            MotionType warpMode = MotionType.Affine,
            int numberOfIterations = 1000 /*2500*/,
            double terminationEps = 1e-6 /*1e-9*/,
            string mergedFileName = null)
        {
            if (refIndex >= imagePaths.Length || refIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(refIndex),
                    "Reference channel index too large or negative.");

            // Read multiple grayscale images
            Mat[] images = new Mat[imagePaths.Length];
            VectorOfMat channels = new VectorOfMat();
            for (int i = 0; i < imagePaths.Length; ++i)
            {
                images[i] = CvInvoke.Imread(imagePaths[i], ImreadModes.Grayscale);
                channels.Push(images[i]);
            }

            // Merge the three channels into one color image
            Mat imageColor = new Mat();
            CvInvoke.Merge(channels, imageColor);

            // Set space for warp matrices.
            VectorOfMat warpMatrices = new VectorOfMat();

            // Set the warp matrix to identity.
            for (int i = 0; i < imagePaths.Length; ++i)
            {
                if (warpMode == MotionType.Homography)
                    warpMatrices.Push(Mat.Eye(3, 3, DepthType.Cv32F, 1));
                else
                    warpMatrices.Push(Mat.Eye(2, 3, DepthType.Cv32F, 1));
            }

            // Set the stopping criteria for the algorithm.
            MCvTermCriteria criteria = new MCvTermCriteria(numberOfIterations, terminationEps);

            // Initializing cropping boundaries
            int cropStartX = 0;
            int cropStartY = 0;
            int cropEndX = channels[refIndex].Width;
            int cropEndY = channels[refIndex].Height;

            // Calculate aligned dimensions for all channels
            for (int i = 0; i < channels.Size; i++)
            {
                Debug.WriteLine($"Calculating aligned dimensions for band {i + 1}");

                double cc = CvInvoke.FindTransformECC(
                    GetGradient(channels[refIndex]),
                    GetGradient(channels[i]),
                    warpMatrices[i],
                    warpMode,
                    criteria
                );

                if (i == refIndex)
                    continue;

                // Update cropping boundaries
                PointF p1 = TransformPoint(new PointF(0, 0), warpMatrices[i], warpMode);
                PointF p2 = TransformPoint(new PointF(0, channels[i].Height), warpMatrices[i], warpMode);
                PointF p3 = TransformPoint(new PointF(channels[i].Width, 0), warpMatrices[i], warpMode);
                PointF p4 = TransformPoint(new PointF(channels[i].Width, channels[i].Height), warpMatrices[i], warpMode);

                cropStartX = (int)Math.Ceiling(Math.Max(cropStartX, p1.X));
                cropStartX = (int)Math.Ceiling(Math.Max(cropStartX, p2.X));
                cropStartY = (int)Math.Ceiling(Math.Max(cropStartY, p1.Y));
                cropStartY = (int)Math.Ceiling(Math.Max(cropStartY, p3.Y));
                cropEndX = (int)Math.Floor(Math.Min(cropEndX, p3.X));
                cropEndX = (int)Math.Floor(Math.Min(cropEndX, p4.X));
                cropEndY = (int)Math.Floor(Math.Min(cropEndY, p2.Y));
                cropEndY = (int)Math.Floor(Math.Min(cropEndY, p4.Y));
            }
            Debug.WriteLine($"Aligned dimensions: ({cropStartX};{cropStartY}) - ({cropEndX};{cropEndY})");

            // Set aligned size for channels.
            Size alignedSize = new Size(cropEndX - cropStartX - 1, cropEndY - cropStartY - 1);

            // Set space for aligned image.
            VectorOfMat alignedChannels = new VectorOfMat();
            for (int i = 0; i < channels.Size; i++)
            {
                alignedChannels.Push(new Mat(alignedSize, DepthType.Cv8U, 1));
            }

            // Warp all channels to the reference channel
            for (int i = 0; i < channels.Size; i++)
            {
                Debug.WriteLine($"Warpping band {i + 1}");

                if (warpMode == MotionType.Homography)
                {
                    // Use Perspective warp when the transformation is a Homography
                    CvInvoke.WarpPerspective(channels[i], alignedChannels[i], warpMatrices[i], alignedSize,
                        Inter.Linear, Warp.InverseMap);
                }
                else
                {
                    // Use Affine warp when the transformation is not a Homography
                    CvInvoke.WarpAffine(channels[i], alignedChannels[i], warpMatrices[i], alignedSize,
                        Inter.Linear, Warp.InverseMap);
                }
            }

            // Save the output
            for (int i = 0; i < imagePaths.Length; ++i)
            {
                string fileName = Path.GetFileNameWithoutExtension(imagePaths[i]) + "_aligned" + Path.GetExtension(imagePaths[i]);
                string outputPath = Path.Combine(outputFolder, fileName);
                CvInvoke.Imwrite(outputPath, alignedChannels[i]);
            }

            // Merge the aligned channels
            if (!String.IsNullOrEmpty(mergedFileName))
            {
                string outputPath = Path.Combine(outputFolder, mergedFileName);
                Mat imageAligned = new Mat();
                CvInvoke.Merge(alignedChannels, imageAligned);
                CvInvoke.Imwrite(outputPath, imageAligned);
            }
        }

        /// <summary>
        /// Applies the given transformation to a coordinate.
        /// </summary>
        /// <param name="point">Coordinate to be transformed.</param>
        /// <param name="warpMat">Transformation matrix.</param>
        /// <param name="warpMode">Motion model.</param>
        /// <returns>Transformed coordinate.</returns>
        private static PointF TransformPoint(PointF point, Mat warpMat, MotionType warpMode)
        {
            Matrix<float> warpMatrix;
            if (warpMode == MotionType.Homography)
                warpMatrix = new Matrix<float>(3, 3);
            else
                warpMatrix = new Matrix<float>(2, 3);

            warpMat.ConvertTo(warpMatrix, DepthType.Cv32F);

            Matrix<float> pointMatrix = new Matrix<float>(new float[] { point.X, point.Y, 1 });
            Matrix<float> transformedMatrix = warpMatrix * pointMatrix;
            return new PointF(transformedMatrix[0, 0], transformedMatrix[1, 0]);
        }

        /// <summary>
        /// Calculates the approximation of the image gradient.
        /// </summary>
        /// <param name="srcGray">Source image.</param>
        /// <param name="scale">Scale of the Sobel operator.</param>
        /// <param name="delta">Delta of the Sobel operator.</param>
        /// <param name="kernelSize">Kernel size of the Sobel operator.</param>
        /// <returns>Mat.</returns>
        private static Mat GetGradient(Mat srcGray, int scale = 1, int delta = 0, int kernelSize = 5)
        {
            Mat gradX = new Mat();
            Mat gradY = new Mat();
            Mat absGradX = new Mat();
            Mat absGradY = new Mat();
            DepthType ddepth = DepthType.Cv32F;

            // Calculate the x and y gradients using Sobel operator
            CvInvoke.Sobel(srcGray, gradX, ddepth, 1, 0, kernelSize, scale, delta, BorderType.Default);
            CvInvoke.ConvertScaleAbs(gradX, absGradX, scale, delta);

            CvInvoke.Sobel(srcGray, gradY, ddepth, 0, 1, kernelSize, scale, delta, BorderType.Default);
            CvInvoke.ConvertScaleAbs(gradY, absGradY, scale, delta);

            // Combine the two gradients
            Mat grad = new Mat();
            CvInvoke.AddWeighted(absGradX, 0.5, absGradY, 0.5, 0, grad);

            return grad;
        }
    }
}
