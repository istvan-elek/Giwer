using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace catalog
{
    class MatchBands
    {
        List<string> fileNames = new List<string>();
        string curDir;
        int offset=250;
        int cropMargin;
        int per;
        public MatchBands(int crop, string curD, List<string> fNames)
        {
            curDir = curD;
            List<string> dif = new List<string>();
            cropMargin = crop;
            foreach(string item in fNames)
            {
                fileNames.Add(curDir + "\\" + item);
            }
            for (int i = 1; i < fNames.Count; i++)
            {
                computeDiffs(fileNames[0], fileNames[i]);
            }         
        }

        public MatchBands() { }

        void computeDiffs(string fname1, string fname2)
        {
            byte[,] image1;
            byte[,] image2;
            image1 = ClipImage(fname1); // cliped image1 is a part of original image, new size = original size - cropMargin
            image2 = ClipImage(fname2);// cliped image2 is a part of original image, new size = original size - cropMargin
            int imw = image1.GetLength(0); // new image width
            int imh = image1.GetLength(1);  //new image height
            offset = 50;
            int halfOffset = offset / 2; // offset is a part of image with size offset*offset
            per = offset * offset;
            //Random rnd = new Random();
            //Point startpoint = new Point(rnd.Next(offset, imw - offset), rnd.Next(offset, imh - offset));
            Point startpoint = new Point(imw /2, imh /2);
            List<Int32> lstDif = new List<Int32>();
            List<string> lstInd = new List<string>();

            for (int i = -halfOffset; i < halfOffset; i++)
            {
                for (int j = -halfOffset; j < halfOffset; j++)
                {
                    lstDif.Add(substract(image1, image2, halfOffset, startpoint, new Point(startpoint.X + i, startpoint.Y + j)));
                    lstInd.Add(i + ";" + j);
                }
            }
            Int32 min=0;
            string minindex = "";
            getMin(lstDif, lstInd, out min, out minindex);
        }

        Int32 substract (byte[,] im1, byte[,] im2, int halfOffset, Point startpoint, Point shiftpoint)
        {
            Int32 d = 0;
            for (int kx = -halfOffset; kx < halfOffset; kx++)
            {
                for (int ky = -halfOffset; ky < halfOffset; ky++)
                {
                    d += Math.Abs(im1[startpoint.X + kx, startpoint.Y + ky] - im2[shiftpoint.X + kx, shiftpoint.Y + ky]);
                }
            }
            return d;
        }

        void getMin(List<int> lstDif, List<string> lstInd, out int min, out string minIndex)
        {
            min = 1000000000;
            minIndex = "";
            for (int ind = 0; ind < lstDif.Count; ind++)
            {
                if (lstDif[ind] < min)
                {
                    min = lstDif[ind];
                    minIndex = lstInd[ind];
                }
            }
        }

        public byte[,] ClipImage(string fname)
        {
            Bitmap bmpIn = new Bitmap(fname);
            Int32 newsizex = bmpIn.Width - 2*cropMargin;
            Int32 newsizey = bmpIn.Height - 2*cropMargin;
            int imstartx = cropMargin;
            int imstarty = cropMargin;
            byte[,] byOut = new byte[newsizex, newsizey];
            Int32 endy = newsizey + imstarty;
            Int32 endx = newsizex + imstartx;
            for (Int32 i = imstarty; i < endy; i++)
            {
                for (Int32 j = imstartx; j < endx; j++)
                {
                    Color c = bmpIn.GetPixel(j - imstartx, i - imstarty);
                    byOut[j - imstartx, i - imstarty]=c.G;
                }
            }
            return byOut;
        }
    }
}
