using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace Giwer.micasense
{
    public class Transform
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
        /// <param name="outputPath">Path of the aligned multi-band image.</param>
        /// <param name="refIndex">Reference channel index to align to.</param>
        /// <param name="warpMode">Motion model.</param>
        /// <param name="numberOfIterations">Stopping criteria for the algorithm.</param>
        /// <param name="terminationEps">Stopping criteria for the algorithm.</param>
        /// <exception cref="ArgumentOutOfRangeException">nameof(refIndex), Reference channel index too large or negative.</exception>
        public static void Align(string[] imagePaths, string outputPath,
            int refIndex = 0,
            MotionType warpMode = MotionType.Affine,
            int numberOfIterations = 2500,
            double terminationEps = 1e-9)
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

            // Set space for aligned image.
            VectorOfMat alignedChannels = new VectorOfMat();
            for (int i = 0; i < channels.Size; i++)
            {
                // All channels will be aligned to the reference channel
                if (i != refIndex)
                    alignedChannels.Push(new Mat(channels[refIndex].Size, DepthType.Cv8U, 1));
                else
                    alignedChannels.Push(channels[refIndex].Clone());
            }

            // Set space for warp matrix.
            Mat warpMatrix;

            // Set the warp matrix to identity.
            if (warpMode == MotionType.Homography)
                warpMatrix = Mat.Eye(3, 3, DepthType.Cv32F, 1);
            else
                warpMatrix = Mat.Eye(2, 3, DepthType.Cv32F, 1);

            // Set the stopping criteria for the algorithm.
            MCvTermCriteria criteria = new MCvTermCriteria(numberOfIterations, terminationEps);

            // Warp all channels to the reference channel
            for (int i = 0; i < channels.Size; i++)
            {
                Console.WriteLine("Wrapping band " + (i + 1));

                if (i == refIndex)
                    continue;

                double cc = CvInvoke.FindTransformECC(
                    GetGradient(channels[refIndex]),
                    GetGradient(channels[i]),
                    warpMatrix,
                    warpMode,
                    criteria
                );

                if (warpMode == MotionType.Homography)
                    // Use Perspective warp when the transformation is a Homography
                    CvInvoke.WarpPerspective(channels[i], alignedChannels[i], warpMatrix,
                        alignedChannels[refIndex].Size,
                        Inter.Linear, Warp.InverseMap);
                else
                    // Use Affine warp when the transformation is not a Homography
                    CvInvoke.WarpAffine(channels[i], alignedChannels[i], warpMatrix, alignedChannels[refIndex].Size,
                        Inter.Linear, Warp.InverseMap);
            }

            // Merge the aligned channels
            Mat imageAligned = new Mat();
            CvInvoke.Merge(alignedChannels, imageAligned);

            // Save final output
            CvInvoke.Imwrite(outputPath, imageAligned);
          
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
