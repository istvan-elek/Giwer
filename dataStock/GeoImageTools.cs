using BitMiracle.LibTiff.Classic;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Giwer.dataStock
{
    public class GeoImageTools
    {
        /* load image
         * convert one band bytes to bitmap
         * convert byte array to bitmap
         * convert bitmap to byte array
         * create grayscale image from one band
         * grayscale conversion from an RGB image
         * load one band data to byte array
         * get red band
         * get green band
         * get blue band
         * convert image to giwer format
         * read/write giwer data file 
         * thresholding
         * combine two images
         * vectorize
         * compute image average and standard deviation
         * Resampling
         */

        GeoImageData gida = new GeoImageData();
        public enum OperationType { Plus, Minus, Exor };

        public GeoImageTools(GeoImageData gimDa)
        {
            gida = gimDa;
        }
        public GeoImageTools() { }


        public void saveAll2GiwerFormat(string GiwerDataFolder)  // save  giwer data to a binary file
        {
            //string newDirName = GiwerDataFolder + "\\" + Path.GetFileNameWithoutExtension(gida.FileName) + "\\";
            //System.IO.Directory.CreateDirectory(newDirName);
            //string destinationFile = GiwerDataFolder + "\\" + Path.GetFileNameWithoutExtension(gida.FileName) + ".gwh";
            //saveHeader2Giwer(destinationFile);

            //// ha a bil egy spot képet tartalmaz, akkor a sávok sorrendje fordított (1,2,3), mint a Landsatnél (3,2,1). Csakhogy erről nem informál a header fájl, vagyis nem tudni, hogy landsat vagy spot képről van szó. Persze a user tudja, de mivel nincs a headerben, így gáz van.

            //for (int i = 0; i < gida.Nbands; i++)
            //{
            //    byte[] curBand = getOneBandBytes(i);
            //    if (gida.FileType == GeoImageData.fTypes.BIL || gida.FileType == GeoImageData.fTypes.ENVI)
            //    {
            //        int j = i;
            //        convertByteArray2GiwerFormat(curBand, newDirName + "\\" + j + ".gwr");
            //    }
            //    if (gida.FileType == GeoImageData.fTypes.TIF || gida.FileType == GeoImageData.fTypes.JPG)
            //    {
            //        int j = gida.Nbands - i - 1;
            //        convertByteArray2GiwerFormat(curBand, newDirName + "\\" + j + ".gwr");
            //    }
            //}
        }

        [UserAttr("u")]
        public void saveOneBandResultAsGiwerFormat(string fName, byte[] curBand, string desc)
        {
            string newDirName = Path.GetDirectoryName(fName) + "\\" + Path.GetFileNameWithoutExtension(fName);
            System.IO.Directory.CreateDirectory(newDirName);
            gida.Nbands = 1;
            gida.Comment = desc;
            convertByteArray2GiwerFormat(curBand, newDirName + "\\0" + ".gwr");
            saveHeader2Giwer(fName);

        }



        public void saveHeader2Giwer(string destFname) // save giwer header to its header file
        {
            Type type = typeof(GeoImageData);
            int NumberOfRecords = type.GetProperties().Length;
            string[] hdr = new string[NumberOfRecords];
            int k = 0;
            foreach (var prop in gida.GetType().GetProperties())
            {
                if (prop.Name.ToLower() != "wavelength")
                {
                    hdr[k] = prop.Name + ";" + prop.GetValue(gida);
                    k += 1;
                }
                //hdr[k] = "wavelength;";
                string hdrs = "Wavelength;";
                foreach (string item in gida.Wavelength)
                {
                    hdrs += item + ",";
                }
                hdr[k] = hdrs.Substring(0, hdrs.Length - 1);
            }
            File.WriteAllLines(destFname, hdr);
        }

        [UserAttr("u")]
        public void convertByteArray2GiwerFormat(byte[] byIn, string filName)
        {
            if (byIn == null) return;
            using (System.IO.FileStream fs = new System.IO.FileStream(filName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write))
            {
                using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                {
                    foreach (byte item in byIn)
                    {
                        bw.Write(item);
                    }
                    bw.Flush();
                }
            }
        }

        [UserAttr("u")]
        public void saveGivenBand2GiwerFormat(string dirName, byte[] curBand, int index, string desc)
        {
            if (!Directory.Exists(dirName)) Directory.CreateDirectory(dirName);
            convertByteArray2GiwerFormat(curBand, dirName + "\\" + index + ".gwr");
        }

        public Bitmap convertOneBandBytesto8bitBitmap(byte[] byIn)  //this routine converts values of one band, which stored in a byte array (ByIn). It comes from getOneBandBytes (whichBand) routine.
        {
            PixelFormat pf = PixelFormat.Format8bppIndexed;
            Bitmap b = new Bitmap(gida.Ncols, gida.Nrows, pf);
            ColorPalette ncp = b.Palette;
            for (int i = 0; i < 256; i++)
                ncp.Entries[i] = Color.FromArgb(i, i, i);
            b.Palette = ncp;
            Rectangle BoundsRect = new Rectangle(0, 0, gida.Ncols, gida.Nrows);
            BitmapData bdata = b.LockBits(BoundsRect, ImageLockMode.ReadOnly, pf);
            Int32 ind = 0;
            int res = (gida.Ncols) % 4;

            byte[] byOut = new byte[(bdata.Stride * b.Height)]; //new byte[(gida.Ncols+res) * b.Height];
            b.UnlockBits(bdata);
            for (int i = 0; i < gida.Nrows; i++)
            {
                ind += res;
                for (int j = 0; j < gida.Ncols; j++)
                {
                    byte bi = byIn[i * gida.Ncols + j];
                    byOut[ind] = bi;
                    ind++;
                }
            }
            b = ByteArrayTo8bitBitmap(byOut, gida.Ncols, gida.Nrows);
            return b;
        }

        //static int GetStride(int width, PixelFormat pxFormat)
        //{
        //    //float bitsPerPixel = System.Drawing.Image.GetPixelFormatSize(format);
        //    int bitsPerPixel = ((int)pxFormat >> 8) & 0xFF;
        //    //Number of bits used to store the image data per line (only the valid data)
        //    int validBitsPerLine = width * bitsPerPixel;
        //    //4 bytes for every int32 (32 bits)
        //    int stride = ((validBitsPerLine + 31) / 32) * 4;
        //    return stride;
        //}


        public Bitmap convertOneBandBytesto24bitBitmap(byte[] byIn, int imWidth, int imHeight)  //this routine converts values of one band, which stored in a byte array (ByIn). It comes from getOneBandBytes (whichBand) routine.
        {
            Bitmap bmp = new Bitmap(imWidth, imHeight, PixelFormat.Format24bppRgb);
            int res = (imWidth) % 4;
            //if (res == 1) res = 3;
            Math.DivRem(4 - res, 4, out res);
            //int res = (imWidth) % 4;
            Int32 stride = (imWidth + res) * 3;
            byte[] byOut = new byte[stride * imHeight];
            Int32 ind = 0;
            for (int i = 0; i < imHeight; i++)
            {

                for (int j = 0; j < imWidth; j++)
                {
                    byte b = byIn[i * imWidth + j];
                    for (int k = 0; k < 3; k++)
                    {
                        byOut[ind] = b;
                        ind++;
                    }
                }
                ind += res;
            }
            bmp = ByteArrayToBitmap(byOut, imWidth, imHeight);
            return bmp;
        }

        public Bitmap convertOneBandBytesto8bitBitmap(byte[] byIn, int imwidth, int imheight, Int32[] cp)   //convert byte array to bitmap
        {
            PixelFormat pf = PixelFormat.Format8bppIndexed;
            Bitmap b = new Bitmap(imwidth, imheight, pf);
            ColorPalette ncp = b.Palette;
            for (int i = 0; i < 256; i++)
            {
                ncp.Entries[i] = Color.FromArgb(ColorTranslator.FromWin32(cp[i]).A, ColorTranslator.FromWin32(cp[i]).R, ColorTranslator.FromWin32(cp[i]).G, ColorTranslator.FromWin32(cp[i]).B);
            }
            b.Palette = ncp;
            Rectangle BoundsRect = new Rectangle(0, 0, imwidth, imheight);
            BitmapData bmpData = b.LockBits(BoundsRect, ImageLockMode.WriteOnly, b.PixelFormat);
            IntPtr ptr = bmpData.Scan0;
            //int bitsPerPixel = ((int)pf >> 8) & 0xFF;
            //int validBitsPerLine = imwidth * bitsPerPixel;
            //int stride = ((validBitsPerLine + 31) / 32) * 4;
            //int stride = GetStride(imwidth, PixelFormat.Format8bppIndexed);
            //int bytes = bmpData.Stride * b.Height;
            int res = (imwidth) % 4;
            //if (res == 1) res = 3;
            Math.DivRem(4 - res, 4, out res);
            //res = 4 - res;
            Int32 stride = bmpData.Stride;  //imwidth + res;
            byte[] byOut = new byte[stride * imheight];
            Int32 ind = 0;
            for (int i = 0; i < imheight; i++)
            {
                for (int j = 0; j < imwidth; j++)
                {
                    byte bi = byIn[i * imwidth + j];
                    byOut[ind] = bi;
                    ind++;
                }
                ind += res;
            }
            System.Runtime.InteropServices.Marshal.Copy(byOut, 0, ptr, byOut.Length);
            b.UnlockBits(bmpData);
            return b;
        }

        public byte[] convertDDM2ByteArrayforDisplay(dtm dm, GeoImageData gd)
        {
            byte[] byOut = new byte[gd.Ncols * gd.Nrows];
            Int32 ind = 0;
            float elevdiff = dm.ElevMax - dm.ElevMin;

            for (int i = 0; i < gd.Nrows; i++)
            {
                for (int j = 0; j < gd.Ncols; j++)
                {
                    float val = 255F * ((dm.dem[j, i] - dm.ElevMin) / elevdiff);
                    byOut[ind] = (byte)val;
                    ind++;
                }
            }
            return byOut;
        }


        [UserAttr("u")]
        public byte[] getOneBandBytes(int whichBand) // get the desired band content from a bil, ENVI, tif, jpg file to byte array
        {
            int numBytes = gida.Nbits / 8;
            byte[] byteOut;
            try
            {
                byteOut = new byte[gida.Ncols * gida.Nrows]; // * numBytes
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Memory overflow. Too big image");
                return null;
            }

            if (gida.FileType == GeoImageData.fTypes.BIL || gida.FileType == GeoImageData.fTypes.BSQ || gida.FileType == GeoImageData.fTypes.ENVI)  // if data file type is BIL, BSQ or ENVI
            {
                if (gida.Interleave == "BSQ" || gida.FileType == GeoImageData.fTypes.BSQ)  // if data interleave is BSQ
                {
                    using (FileStream fs = new FileStream(gida.FileName, FileMode.Open, FileAccess.Read))
                    {
                        BinaryReader br = new BinaryReader(fs);
                        if ((gida.Nbits == 8))
                        {
                            Int64 ind = 0;
                            Int64 startPos = 0;
                            startPos = (Int64)((whichBand) * gida.Ncols * gida.Nrows);
                            fs.Position = startPos;
                            for (int i = 0; i < gida.Nrows; i++)
                            {
                                for (int j = 0; j < gida.Ncols; j++)
                                {
                                    byteOut[ind] = br.ReadByte();
                                    ind++;
                                }
                            }
                        }
                        if ((gida.Nbits == 16))
                        {
                            int offs = 0;
                            Int64 ind = 0;
                            Int64 startPos = offs;
                            startPos = (Int64)((whichBand) * gida.Ncols * gida.Nrows) * numBytes;
                            fs.Position = startPos;
                            for (int i = 0; i < gida.Nrows; i++)
                            {
                                for (int j = 0; j < gida.Ncols; j++)
                                {
                                    Int32 b = br.ReadUInt16();
                                    byteOut[ind] = Convert.ToByte(b / 256);
                                    ind++;
                                }
                            }
                        }
                    }
                }
                else  // if data interleave is BIL or ENVI
                {
                    using (FileStream fs = new FileStream(gida.FileName, FileMode.Open, FileAccess.Read))
                    {
                        BinaryReader br = new BinaryReader(fs);
                        if ((gida.Nbits == 8))
                        {
                            Int64 ind = 0;
                            Int64 startPos = 0;
                            for (int i = 0; i < gida.Nrows; i++)
                            {
                                startPos = (Int64)((gida.Nbands * i + whichBand) * gida.Ncols);
                                fs.Position = startPos;
                                for (int j = 0; j < gida.Ncols; j++)
                                {
                                    byteOut[ind] = br.ReadByte();
                                    ind++;
                                }
                            }
                        }
                        if ((gida.Nbits == 16))
                        {
                            int offs = 0;
                            Int64 ind = 0;
                            Int64 startPos = offs;
                            for (int i = 0; i < gida.Nrows; i++)
                            {
                                startPos = (Int64)((gida.Nbands * i + whichBand) * gida.Ncols) * numBytes;
                                fs.Position = startPos;
                                for (int j = 0; j < gida.Ncols; j++)
                                {
                                    Int32 b = br.ReadUInt16();
                                    byteOut[ind] = Convert.ToByte(b / 256);
                                    ind++;
                                }
                            }
                        }
                    }
                    //if (gida.Nbits==12)
                    //{
                    //    int offs = 0;
                    //    Int64 ind = 0;
                    //    Int64 startPos = offs;
                    //    for (int i = 0; i < gida.Nrows; i++)
                    //    {
                    //        startPos = (Int64)((gida.Nbands * i + whichBand) * gida.Ncols) * numBytes;
                    //        fs.Position = startPos;
                    //        for (int j = 0; j < gida.Ncols; j++)
                    //        {
                    //            Int32 b = br.ReadByte();
                    //            byteOut[ind] = Convert.ToByte(b / 16);
                    //            ind++;
                    //        }
                    //    }
                    //}
                }
            }

            if (gida.FileType == GeoImageData.fTypes.GWH)   // if data is in a GWR file
            {
                string gwrFile = Path.GetDirectoryName(gida.FileName) + "\\" + Path.GetFileNameWithoutExtension(gida.FileName) + "\\" + whichBand + ".gwr";
                byteOut = File.ReadAllBytes(gwrFile);
            }

            if (gida.FileType == GeoImageData.fTypes.TIF)   // if data is in a TIF file
            {
                //byteOut = getOneBandBytesFromStreem(whichBand);
                if (gida.Nbands == 3 && gida.Nbits == 8)  // if the image has 24 bit color depth
                {
                    byteOut = getOneBandtoByteArrayFromBitmap(new Bitmap(gida.FileName), whichBand);
                }
                if (gida.Nbands == 1 && gida.Nbits == 8)  // if data has grayscale color (8 bits, 1 band)
                {
                    byteOut = getOneBandBytesFromStream(whichBand);  // if the TIF file has more than 3 bands
                }
                else
                {
                    byteOut = getOneBandBytesFromStream(whichBand);  // if the TIF file has more than 3 bands and Nbits is 16 
                }
            }

            if (gida.FileType == GeoImageData.fTypes.JPG)   // if data is in a JPG file
                if (gida.Nbands == 3 && gida.Nbits == 8)  // if the image has 24 bit color depth
                {
                    byteOut = getOneBandtoByteArrayFromBitmap(new Bitmap(gida.FileName), whichBand);
                }
                else
                {
                    //byteOut = getOneBandBytesFromStreem(whichBand); // if the JPG file has more than 3 bands
                    byteOut = getOneBandtoByteArrayFromBitmap(new Bitmap(gida.FileName), whichBand);
                }

            if (gida.FileType == GeoImageData.fTypes.DDM) //------------------
            {
                if (gida.Nbits == 16)
                {
                    dtm ddm = new dtm();
                    ddm.FileName = gida.FileName;
                    byteOut = getOneBandtoByteArrayFromBitmap(ddm.demBitmap, whichBand);
                }
            }
            return byteOut;
        }

        [UserAttr("u")]
        public byte[] getOneBandBytesFromStream(int whichBand)   // getting the selected band (whichband) from a fileStream to a byte array
        {
            int numByte = gida.Nbits / 8;
            byte[] byIn = new byte[gida.Ncols * gida.Nrows * gida.Nbands]; // * numByte
            byte[] byOut = new byte[gida.Ncols * gida.Nrows]; // * numByte
            using (Tiff image = Tiff.Open(gida.FileName, "r"))
            {
                int stride = image.ScanlineSize();
                byte[] scanline = new byte[stride];
                switch (gida.Nbits)
                {
                    case 8:
                        for (Int32 i = 0; i < gida.Nrows; i++)
                        {
                            image.ReadScanline(scanline, i);
                            for (Int32 j = 0; j < gida.Ncols; j++)
                            {
                                Int32 k = j * gida.Nbands + whichBand;
                                byOut[i * gida.Ncols + j] = scanline[k];
                            }
                        }
                        return byOut;
                    case 16:
                        for (Int32 i = 0; i < gida.Nrows; i++)
                        {
                            image.ReadScanline(scanline, i);
                            for (Int32 j = 0; j < gida.Ncols; j++)
                            {
                                Int32 k = (j * gida.Nbands + whichBand) * numByte;
                                int newByte = (int)((scanline[k] | scanline[k + 1] << 8) / 256);
                                byOut[i * gida.Ncols + j] = (byte)newByte;
                            }
                        }
                        return byOut;
                    case 12: // ez még nem működik
                        int offs = 0;
                        Int64 ind = 0;
                        Int64 startPos = offs;
                        for (int i = 0; i < gida.Nrows; i++)
                        {
                            startPos = (Int64)((gida.Nbands * i + whichBand) * gida.Ncols) * numByte;
                            //fs.Position = startPos;
                            for (int j = 0; j < gida.Ncols; j++)
                            {
                                //Int32 b = br.ReadByte();
                                //byOut[ind] = Convert.ToByte(b / 16);
                                ind++;
                            }
                        }

                        return byOut;
                }
                return null;
            }
        }

        [UserAttr("u")]
        public byte[] getOneBandtoByteArrayFromBitmap(Bitmap img, int band)  // get the desired band content from a bitmap to byte array
        {
            byte[] byIn = BitmapToByteArray(img);
            BitmapData bdata = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, img.PixelFormat);
            img.UnlockBits(bdata);
            Int64 length = (Int64)(gida.Ncols * gida.Nrows);//  (Int64)(bdata.Stride * gida.Nrows) *****+++++++++++++++++++!!!!!!!
            byte[] byOut = new byte[length];
            Int64 ind = 0;
            Int64 indOut = 0;
            int offs = 2;
            if (img.PixelFormat == PixelFormat.Format8bppIndexed) offs = 0;
            for (int i = 0; i < gida.Nrows; i++)
            {
                for (int j = 0; j < gida.Ncols; j++)
                {
                    ind = i * bdata.Stride + j * gida.BytesPerPixel;
                    int col = byIn[ind + offs - band];
                    byOut[indOut] = (byte)col;
                    indOut += 1;
                }
            }
            return byOut;
        }

        public byte[] BitmapToByteArray(Bitmap img) // convert bitmap to a byte array 
        {
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, img.PixelFormat);
            int pixelbytes = Image.GetPixelFormatSize(img.PixelFormat) / 8;
            IntPtr ptr = bmpData.Scan0;
            Int32 psize = bmpData.Stride * bmpData.Height;
            //Int32 psize = gida.Ncols * bmpData.Height;
            byte[] byOut = new byte[psize];
            System.Runtime.InteropServices.Marshal.Copy(ptr, byOut, 0, psize);
            img.UnlockBits(bmpData);
            return byOut;
        }

        public Bitmap ByteArrayToBitmap(byte[] byteIn, int imwidth, int imheight)   //convert byte array to bitmap
        {
            Bitmap picOut = new Bitmap(imwidth, imheight, PixelFormat.Format24bppRgb);
            BitmapData bmpData = picOut.LockBits(new Rectangle(0, 0, imwidth, imheight), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmpData.Scan0;
            Int32 psize = bmpData.Stride * imheight;
            System.Runtime.InteropServices.Marshal.Copy(byteIn, 0, ptr, psize);
            picOut.UnlockBits(bmpData);
            return picOut;
        }

        public Bitmap ByteArrayTo8bitBitmap(byte[] byteIn, int imwidth, int imheight)   //convert byte array to bitmap
        {
            Bitmap picOut = new Bitmap(imwidth, imheight, PixelFormat.Format8bppIndexed);
            BitmapData bmpData = picOut.LockBits(new Rectangle(0, 0, imwidth, imheight), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            IntPtr ptr = bmpData.Scan0;
            Int32 psize = bmpData.Stride * imheight;
            System.Runtime.InteropServices.Marshal.Copy(byteIn, 0, ptr, psize);
            picOut.UnlockBits(bmpData);
            return picOut;
        }



        //public Bitmap ByteArrayToBitmap(byte[] byteIn, int imwidth, int imheight,PixelFormat pf)   //convert byte array to bitmap
        //{
        //    var b = new Bitmap(imwidth, imheight, pf);
        //    ColorPalette ncp = b.Palette;
        //    for (int i = 0; i < 256; i++)
        //        ncp.Entries[i] = Color.FromArgb(i, i, i);
        //    b.Palette = ncp;
        //    var BoundsRect = new Rectangle(0, 0, imwidth, imheight);
        //    BitmapData bmpData = b.LockBits(BoundsRect, ImageLockMode.WriteOnly, b.PixelFormat);
        //    IntPtr ptr = bmpData.Scan0;
        //    int bytes = bmpData.Stride * b.Height;
        //    var rgbValues = new byte[bytes];
        //    rgbValues = byteIn;
        //    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
        //    b.UnlockBits(bmpData);
        //    return b;
        //}

        #region image format conversion
        public void convertImageFromTif2Jpg(string tifFileName)  // convert a tif bitmap to a jpg bitmap (24 bpp)
        {
            string fn = Path.GetDirectoryName(tifFileName) + "\\" + Path.GetFileNameWithoutExtension(tifFileName) + "_24b.jpg";
            Bitmap bmp = new Bitmap(tifFileName);
            bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Dispose();
            GC.Collect();
        }

        public void convertImageFromTif48ToTif24(string tifFileName)
        {
            string fn = Path.GetDirectoryName(tifFileName) + "\\" + Path.GetFileNameWithoutExtension(tifFileName) + "_24b.tif";
            Bitmap img = new Bitmap(tifFileName);
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Tiff);
            }
            img.Dispose();
            bmp.Dispose();
        }

        public void convertImageFromJpg48ToJpg24(string jpgFileName)
        {
            string fn = Path.GetDirectoryName(jpgFileName) + "\\" + Path.GetFileNameWithoutExtension(jpgFileName) + "_24b.jpg";
            Bitmap img = new Bitmap(jpgFileName);
            var bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            img.Dispose();
            bmp.Dispose();
        }

        public void convertImageFromJpg2Tif(string jpgFileName)   // convert a jpg bitmap to a tif bitmap (24 bpp)
        {
            string fn = Path.GetDirectoryName(jpgFileName) + "\\" + Path.GetFileNameWithoutExtension(jpgFileName) + "_24b.tif";
            Bitmap bmp = new Bitmap(jpgFileName);
            bmp.Save(fn, System.Drawing.Imaging.ImageFormat.Tiff);
            bmp.Dispose();
            GC.Collect();
        }
        #endregion

        #region grescale and color inversion and getting an rgb band from an image file
        public byte[] InvertColor(byte[] byIn)
        {
            byte[] byOut = new byte[byIn.Length];
            for (Int32 i = 0; i < byIn.Length; i++)
            {
                byOut[i] = (byte)(255 - byIn[i]);
            }
            return byOut;
        }

        // convert image to grayscale from byte arrays of the R,G,B bands
        public byte[] GrayscaleConversion(byte[] byInR, byte[] byInG, byte[] byInB)
        {
            byte[] byGray = new byte[byInR.Length];
            for (Int32 i = 0; i < byGray.Length; i++)
            {
                byGray[i] = Convert.ToByte((byInB[i] + byInG[i] + byInR[i]) / 3F);
            }
            return byGray;
        }

        public Bitmap getAnRGBBand(int whichBand)
        {
            string gwrFile = Path.GetDirectoryName(gida.FileName) + "\\" + Path.GetFileNameWithoutExtension(gida.FileName) + "\\" + whichBand + ".gwr";
            byte[] byIn = File.ReadAllBytes(gwrFile);
            Bitmap bmp = new Bitmap(gida.Ncols, gida.Nrows, PixelFormat.Format24bppRgb);
            int res = (gida.Ncols) % 4;
            int Stride = (gida.Ncols + res) * 3;
            byte[] byOut = new byte[Stride * gida.Nrows];
            Int32 ind = 0;
            byte redb = 0;
            byte greenb = 0;
            byte blueb = 0;
            for (int i = 0; i < gida.Nrows; i++)
            {
                for (int j = 0; j < gida.Ncols; j++)
                {
                    if (whichBand == 0) { redb = byIn[i * gida.Ncols + j]; greenb = 0; blueb = 0; }
                    if (whichBand == 1) { greenb = byIn[i * gida.Ncols + j]; redb = 0; blueb = 0; }
                    if (whichBand == 2) { blueb = byIn[i * gida.Ncols + j]; redb = 0; greenb = 0; }
                    byOut[ind] = blueb;
                    ind++;
                    byOut[ind] = greenb;
                    ind++;
                    byOut[ind] = redb;
                    ind++;
                }
                ind += res;
            }
            GeoImageTools imgTools = new GeoImageTools(gida);
            bmp = imgTools.ByteArrayToBitmap(byOut, gida.Ncols, gida.Nrows);
            return bmp;
        }
        #endregion

        [UserAttr("u")]
        public byte[] readGwrFile(string fName)
        {
            byte[] byteIn = System.IO.File.ReadAllBytes(fName);
            return byteIn;
        }

        [UserAttr("u")]
        public byte[] combine2Images(OperationType mode, byte[] b1, byte[] b2)
        {
            byte[] bOut = new byte[b1.Length];
            switch (mode)
            {
                case OperationType.Plus:
                    for (int i = 0; i < b1.Length; i++)
                    {
                        bOut[i] = (byte)(Convert.ToSingle(b1[i]) / 2F + Convert.ToSingle(b2[i]) / 2F);
                    }
                    break;
                case OperationType.Minus:
                    for (int i = 0; i < b1.Length; i++)
                    {
                        bOut[i] = (byte)Math.Abs((Convert.ToSingle(b1[i]) / 2F - Convert.ToSingle(b2[i]) / 2F));
                    }
                    break;
                case OperationType.Exor:
                    for (int i = 0; i < b1.Length; i++)
                    {
                        if (b2[i] == 0) { bOut[i] = b1[i]; }
                        else { bOut[i] = b2[i]; }
                    }
                    break;
                default:
                    return null;
            }
            return bOut;
        }

        #region save routines
        [UserAttr("u")]
        public void save2BILformat(string fileName)
        {
            saveBILHeaderFile(Path.ChangeExtension(fileName, ".hdr"));
            saveBILbinaryFile(fileName);
        }

        [UserAttr("u")]
        public void save2BSQformat(string fileName)
        {
            saveBSQHeaderFile(Path.ChangeExtension(fileName, ".hdr"));
            saveBSQbinaryFile(fileName);
        }

        void saveBILHeaderFile(string fname)
        {
            string header = "";
            header = "#ARC/INFO BIL file" + Environment.NewLine;
            header += "nbands " + gida.Nbands + Environment.NewLine;
            header += "nbits " + gida.Nbits + Environment.NewLine;
            header += "ncols " + gida.Ncols + Environment.NewLine;
            header += "nrows " + gida.Nrows + Environment.NewLine;
            header += "xdim " + gida.Xdim + Environment.NewLine;
            header += "ydim " + gida.Ydim + Environment.NewLine;
            header += "ulxmap " + gida.Ulxmap.ToString().Replace(',', '.') + Environment.NewLine;
            header += "ulymap " + gida.Ulymap.ToString().Replace(',', '.') + Environment.NewLine;
            string head = "# This file contains drone image parameters which are not compatible with bil header data" + Environment.NewLine;
            foreach (var prop in gida.GetType().GetProperties())
            {
                string val = prop.GetValue(gida).ToString();
                head += prop.Name + " " + val + Environment.NewLine;
            }
            File.WriteAllText(Path.ChangeExtension(fname, ".dat"), head);

            using (FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(header);
                    sw.Flush();
                }
            }
        }

        void saveBILbinaryFile(string fname)
        {
            using (FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                Int64 pos = 0;
                Int64 count = gida.Nbands * gida.Nrows * gida.Ncols;
                for (Int64 i = 0; i < count; i++) { bw.Write(0); }

                for (int iBand = 0; iBand < gida.Nbands; iBand++)
                {
                    byte[] band = getOneBandBytes(iBand);
                    for (Int32 iRow = 0; iRow < gida.Nrows; iRow++)
                    {
                        pos = iRow * gida.Ncols * gida.Nbands + iBand * gida.Ncols;
                        fs.Position = pos;
                        for (Int32 iCol = 0; iCol < gida.Ncols; iCol++)
                        {
                            bw.Write(band[iCol + iRow * gida.Ncols]);
                        }
                    }
                }
                bw.Flush();
            }
        }

        void saveBSQHeaderFile(string fname)
        {
            string header = "";
            header = "#ARC/INFO BIL file" + Environment.NewLine;
            header += "nbands " + gida.Nbands + Environment.NewLine;
            header += "nbits " + gida.Nbits + Environment.NewLine;
            header += "ncols " + gida.Ncols + Environment.NewLine;
            header += "nrows " + gida.Nrows + Environment.NewLine;
            header += "xdim " + gida.Xdim + Environment.NewLine;
            header += "ydim " + gida.Ydim + Environment.NewLine;
            header += "ulxmap " + gida.Ulxmap.ToString().Replace(',', '.') + Environment.NewLine;
            header += "ulymap " + gida.Ulymap.ToString().Replace(',', '.') + Environment.NewLine;
            string head = "# This file contains drone image parameters which are not compatible with bil header data" + Environment.NewLine;
            foreach (var prop in gida.GetType().GetProperties())
            {
                string val = prop.GetValue(gida).ToString();
                head += prop.Name + " " + val + Environment.NewLine;
            }
            File.WriteAllText(Path.ChangeExtension(fname, ".dat"), head);

            using (FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(header);
                    sw.Flush();
                }
            }
        }

        void saveBSQbinaryFile(string fname)
        {
            using (FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                Int64 pos = 0;
                Int64 count = gida.Nbands * gida.Nrows * gida.Ncols;
                for (Int64 i = 0; i < count; i++) { bw.Write(0); }

                for (int iBand = 0; iBand < gida.Nbands; iBand++)
                {
                    byte[] band = getOneBandBytes(iBand);
                    pos = (Int64)((iBand) * gida.Ncols * gida.Nrows);
                    fs.Position = pos;
                    for (Int32 iRow = 0; iRow < gida.Nrows; iRow++)
                    {
                        for (Int32 iCol = 0; iCol < gida.Ncols; iCol++)
                        {
                            bw.Write(band[iCol + iRow * gida.Ncols]);
                        }
                    }
                }
                bw.Flush();
            }
        }
        #endregion
        [UserAttr("u")]
        public void displayBandOnNewForm(int whichBand, GeoImageData gimd, byte[] byIn, Int32[] colp)
        {
            if (byIn != null)
            {
                System.Windows.Forms.Form frmImageDisplay = new System.Windows.Forms.Form();
                ImageWindow imwindow = new ImageWindow();
                int wd = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 3;
                int hgt = wd * gimd.Nrows / gimd.Ncols + (frmImageDisplay.Height - frmImageDisplay.ClientSize.Height);
                frmImageDisplay.Size = new Size(wd, hgt);
                frmImageDisplay.Controls.Add(imwindow);
                frmImageDisplay.Text = Path.GetFileName(gimd.FileName) + " -> Band_" + whichBand;
                frmImageDisplay.Icon = new System.Drawing.Icon(System.Windows.Forms.Application.StartupPath + "\\monitor.ico");
                imwindow.Dock = System.Windows.Forms.DockStyle.Fill;
                imwindow.DrawImage(gimd, byIn, colp);
                frmImageDisplay.Show();
            }
            else System.Windows.Forms.MessageBox.Show("There is no image to display");
        }
    }
}
