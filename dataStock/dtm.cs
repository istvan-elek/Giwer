using System;
using System.Drawing;
using System.IO;

namespace Giwer.dataStock
{
    public class dtm
    {

//public properties
        private string _secName;
        public string SectionName 
        {
            get { return _secName;}
        }

        private string _spatialSystem;
        public string SpatialSystem 
        {
            get {return _spatialSystem ;}
        }

        private int _nrow;
        public int nRow 
        {
            get { return _nrow;} 
        }

        private int _ncol;
        public int nCol 
        {
            get {return _ncol ;} 
        }

        private int _gridsize;
        public int gridSize 
        {
            get { return _gridsize; }
        }

        private float _xmin;
        public float Xmin 
        {
            get { return _xmin;} 
        }

        private float _xmax;
        public float Xmax 
        {
            get { return _xmax; }
        }

        private float _ymin;
        public float Ymin 
        {
            get { return _ymin; }
        }

        private float _ymax;
        public float Ymax 
        {
            get { return _ymax; }
        }

        float _elevmin;
        public float ElevMin
        {
            get { return _elevmin; }
        }

        float _elevmax;
        public float ElevMax
        {
            get { return _elevmax; }
        }

        private string _filename;
        public string FileName 
        {
            get { return _filename;}

            set 
            {
                _filename=value;
                readParameters(Path.ChangeExtension(_filename,"hdr"));
                readDDM();
            } 
        }

        private float[,] _dem;
        public float[,] dem
        {
            get { return _dem; }
        }
        
        private Bitmap _demBitmap;
        public Bitmap demBitmap
        {
            get { return _demBitmap; }
        }


        private void readDDM()
        {
            _demBitmap = new Bitmap(_ncol,_nrow,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            _dem = new float[_ncol, _nrow];

            using (FileStream fs = new FileStream(_filename, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                float min = 255F;
                float max = 0F;
                for (int i = 0; i < _nrow; i++) // min max search
                {
                    for (int j = 0; j < _ncol; j++ )
                    {
                        int b = br.ReadInt16();
                        _dem[j, i] = b;
                        if (b < min) { min = b; }
                        if (b > max) { max = b; }
                    }
                }
                _elevmin = min;
                _elevmax = max;
                float minmax=max-min;
                fs.Position = 0;               
                for (int i = 0; i < _nrow; i++)  //convert to 0 - 255 interval
                {
                    for (int j = 0; j < _ncol; j++)
                    {
                        float b = br.ReadInt16();
                        int c = (int)((b - min) / minmax * 255F);
                        Color col=Color.FromArgb(c,c,c);
                        _demBitmap.SetPixel(j, i, col);
                    }
                }
            }
        }



        private void readParameters(string fname)
        {
            string[] s = File.ReadAllLines(Path.ChangeExtension(fname, "hdr"));

            _secName = s[0];
            _spatialSystem = s[1];
            _gridsize = Convert.ToInt16(s[12]);

            _nrow = Convert.ToInt16(s[10].Split(' ')[0]);
            _ncol = Convert.ToInt16(s[10].Split(' ')[1]);

            string xmn = (s[2].Split(' ')[0]).Replace('.',',');
            _xmin = Convert.ToSingle(xmn);
            string ymn = s[2].Split(' ')[1].Replace('.', ',');
            _ymin = Convert.ToSingle(ymn);

            string xmx = (s[4].Split(' ')[0]).Replace('.', ',');
            _xmax = Convert.ToSingle(xmx);
            string ymx = s[4].Split(' ')[1].Replace('.', ',');
            _ymax = Convert.ToSingle(ymx);
        }
    }
}
