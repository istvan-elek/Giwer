using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Xml;
using BitMiracle.LibTiff.Classic;
using OSGeo.GDAL;
using OSGeo.OSR;

namespace Giwer.dataStock
{
    public class GeoImageData
    {
        /* *****************************************************
         * parse bil header
         * parse tif header
         * parse jpg header
         * parse giwer header
         * set up file style
         * convert input header data to giwer's header data
         * save giwer's header to a file
         * save source data to giwer format
         * get one band bytes from tif
         * get one band bytes from jpg
         * convert a byte array to bitmap
         * convert bitmap to byte array
         * convert bitmap from Tif to Jpg
         * convert bitmap from Jpg to Tif
         *******************************************************/

        public enum fTypes {GWH, BIL, BSQ, TIF, JPG, ENVI, DDM, UNKOWN }; // allowed file formats


        // properties -------------------------------------------------------------------
        #region properties
        string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                    _fileName = value;
                    setUpFileType();
                    parseHeader();
                    computeStride();
                    if (_fileType == fTypes.BIL || _fileType == fTypes.ENVI) { _bytesPerPixel = (_nBits / 8) * _nBands; } 
            }
        }

        fTypes _fileType;
        public fTypes FileType
        {
            get { return _fileType; }
        }

        string _time;
        public string Time
        {
            get { return _time; }
        }

        string _date;
        public string Date
        {
            get { return _date; }
        }

        Int32 _nCols;
        public Int32 Ncols
        {
            get { return _nCols; }
            set { _nCols = value; }
        }

        Int32 _nRows;
        public Int32 Nrows
        {
            get { return _nRows; }
            set { _nRows = value; }
        }

        Int32 _samples;
        public Int32 Samples
        {
            get { return _samples; }
        }

        Int32 _lines;
        public Int32 Lines
        {
            get { return _lines; }
        }

        string _dataType;
        public string DataType
        {
            get { return _dataType; }
        }

        string _sensor_type;
        public string Sensor_type
        {
            get { return _sensor_type; }
        }

        string _interleave;
        public string Interleave
        {
            get { return _interleave; }
        }

        string _defaultBands;
        public string DefaultBands
        {
            get { return _defaultBands; }
        }


        Int64 _stride;
        public Int64 Stride
        {
            get { return _stride; }
        }

        int _nBands;
        public int Nbands
        {
            get { return _nBands; }
            set { _nBands = value; }
        }

        int _bytesPerPixel;
        public int BytesPerPixel
        {
            get { return _bytesPerPixel; }
            set 
            { 
                _bytesPerPixel = value; 
            }
        }

        int _nBits;
        public int Nbits
        {
            get { return _nBits; }
            set 
            { 
                _nBits = value; 
                if (BytesPerPixel==0) _bytesPerPixel = (_nBits/8) * _nBands; 
            }
        }

        string _byteorder;
        public string ByteOrder
        {
            get { return _byteorder; }
        }

        double _xdim;
        public double Xdim
        {
            get { return _xdim; }
        }

        double _ydim;
        public double Ydim
        {
            get { return _ydim; }
        }

        double _cellsize;
        public double CellSize
        { get { return _cellsize; } }

        double _ulxmap;
        public double Ulxmap
        {
            get { return _ulxmap; }
        }

        double _ulymap;
        public double Ulymap
        {
            get { return _ulymap; }
        }

        double _lrxmap;
        public double Lrxmap
        {
            get { return _lrxmap; }
        }

        double _lrymap;
        public double Lrymap
        {
            get { return _lrymap; }
        }

        double _xllcenter;
        public double XllCenter
        { get { return _xllcenter; } }

        double _yllcenter;
        public double YllCenter
        { get { return _yllcenter; } }


        string _layout = "";
        public string Layout
        {
            get { return _layout; }
            set { _layout = value; }
        }

        string _compression = "";
        public string Compression
        { get { return _compression; } }

        string _coordSystem = "";
        public string CoordSystem
        {
            get { return _coordSystem; }
            set { _coordSystem = value; }
        }

        double _gpslatitude;
        public double GPSLatitude
        { get { return _gpslatitude; } }

        string _gpslatitudeRef;
        public string GPSLatitudeRef
        { get { return _gpslatitudeRef; } }

        double _gpslongitude;
        public double GPSLongitude
        { get { return _gpslongitude; } }

        string _gpslongitudeRef;
        public string GPSLongitudeRef
        { get { return _gpslongitudeRef; } }

        Single _gpsaltitude;
        public Single GPSAltitude
        { get { return _gpsaltitude; } }

        string _gpsaltitudeRef;
        public string GPSAltitudeRef
        { get { return _gpsaltitudeRef; } }


        float _camera_pitch; // hosszdőlés (előre hátra)
        public float Camera_pitch
        {
            get { return _camera_pitch; }
        }

        float _camera_yaw; // kitérés (az északi ránytól)
        public float Camera_yaw
        {
            get { return _camera_yaw; }
        }

        float _camera_roll; // jobba balra dőlés
        public float Camera_roll
        {
            get { return _camera_roll; }
        }

        float _absolute_altitude;
        public float Absolute_altitude
        {
            get { return _absolute_altitude; }
        }

        float _relative_altitude;
        public float Relative_altitude
        {
            get { return _relative_altitude; }
        }

        string _locationName = "";
        public string LocationName
        {
            get { return _locationName; }
            set { _locationName = value; }
        }

        string _comment = "";
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        string[] _wavelenght;
        public string[] Wavelength
        {
            get { return _wavelenght; }
        }

        string _wavelenght_units;
        public string Wavelength_units
        {
            get { return _wavelenght_units; }
        }
        #endregion 

        public GeoImageData() { } // the current file name is needed for set _fileName property

        #region functions and methods
        // functions and methods  -------------------------------------------------------------
        void setUpFileType()  // set _fileType which is just read
        {
            switch(Path.GetExtension(_fileName).ToUpper())
            {
                case ".BIL":
                    _fileType = fTypes.BIL;
                    _comment = "This is an ESRI BIL file";
                    string fn = Path.ChangeExtension( _fileName, "hdr");
                    if (File.ReadAllText(fn).Contains("ENVI")) { _fileType = fTypes.ENVI; _comment = "This is an ENVI file"; }
                    return;
                case ".BSQ":
                    _fileType = fTypes.BSQ;
                    _comment = "This is a BSQ file";
                    string fnm = Path.ChangeExtension(_fileName, "hdr");
                    if (File.ReadAllText(fnm).Contains("ENVI")) { _fileType = fTypes.ENVI; _comment = "This is a BSQ file"; }
                    return;
                case ".CUE":
                    _fileType = fTypes.BSQ;
                    _comment = "This is a Cue file";
                    string fnn = Path.ChangeExtension(_fileName, "hdr");
                    if (File.ReadAllText(fnn).Contains("ENVI")) { _fileType = fTypes.ENVI; _comment = "This is a Cue file"; }
                    return;
                case ".TIF":
                    _fileType = fTypes.TIF;
                    _comment = "No comment";
                    return;
                case ".JPG":
                    _fileType = fTypes.JPG;
                    _comment = "No comment";
                    return;
                case ".GWH":
                    _fileType = fTypes.GWH;
                    _comment = "No comment";
                    return;
                case ".DDM":
                    _fileType = fTypes.DDM;
                    _comment = "No comment";
                    return;
                default:
                    _fileType = fTypes.UNKOWN;
                    _comment = "This is an UNKNOWN format";
                    return;
            }
        }
        #region Parse functions
        void parseHeader()  // parse header content from any image format which is supported by Giwer
        {
            switch (_fileType)
            {
                case fTypes.BIL:
                    resetImageParameters();
                    parseBILHeader();
                    return;
                case fTypes.BSQ:
                    resetImageParameters();
                    parseBILHeader();
                    return;
                case fTypes.ENVI:
                    resetImageParameters();
                    parseEnviHeader();
                    return;
                case fTypes.TIF:
                    resetImageParameters();
                    parseTifParams();
                    //parseGeoTifParams();
                    return;
                case fTypes.JPG:
                    resetImageParameters();
                    parseJPGParams();
                    return;
                case fTypes.DDM:
                    resetImageParameters();
                    parseDDMParams();
                    return;
                case fTypes.GWH:
                    resetImageParameters();
                    parseGiwerHeader();
                    return;
                default:
                    resetImageParameters();
                    return;
            }
        }

        #region Parse ddm header
        void parseDDMParams()
        {
            string[] s = File.ReadAllLines(Path.ChangeExtension(_fileName, "hdr"));

            _comment = "This is a DTM file in Hungarian DDM format";
            _coordSystem = s[1];
            _dataType = "Hungarian DTM";
            _cellsize = Convert.ToInt16(s[12]);
            _nRows = Convert.ToInt16(s[10].Split(' ')[0]);
            _nCols = Convert.ToInt16(s[10].Split(' ')[1]);
            _nBits = 16;
            _nBands = 1;
            _bytesPerPixel = 2;
            string xmn = (s[2].Split(' ')[0]).Replace('.', ',');
            _ulxmap = Convert.ToSingle(xmn);
            string ymn = s[2].Split(' ')[1].Replace('.', ',');
            _ulymap = Convert.ToSingle(ymn);
            _fileType = fTypes.DDM;
            if (_cellsize != 0) _xdim = _cellsize; _ydim = _cellsize;
        }
        #endregion

        #region Parse envi header
        public void parseEnviHeader() // reads and parses envi file header
        {
            using (FileStream fs = new FileStream(Path.ChangeExtension(_fileName, "hdr"), FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                string line;
                while (!sr.EndOfStream)
                {
                    string ln = sr.ReadLine();  //.Replace('=', ' ');
                    line = System.Text.RegularExpressions.Regex.Replace(ln, @"\s{2,}", " "); // multi space are removed and substitute with one space " "
                    getEnviParams(line);
                }
            }
            string[] s = this.Wavelength;
            //if (_nBits==0)  _nBits = 32; 
            _bytesPerPixel = (_nBits / 8) * _nBands;
            //int res = (_nCols) % 4;
            _stride = 4 * ((_nCols * _bytesPerPixel + 3) / 4);  //* _nBands;
        }

        void getEnviParams(string line)  //parsing envi bil parameters from the given bil file
        {
            if (line.ToLower().Contains("byte order")) { _byteorder = line.Split('=')[1]; }
            if (line.ToLower().Contains("data type"))
            {
                _dataType = line.Split('=')[1].Trim();
                if (_dataType == "12") { _nBits = 16; }
            }
            if (line.ToLower().Contains("nbits")) { _nBits = Convert.ToInt16(line.Split('=')[1]); }
            if (line.ToLower().Contains("xdim")) { _xdim = Convert.ToDouble(line.Split('=')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ydim")) { _ydim = Convert.ToDouble(line.Split('=')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("samples")) { _samples = Convert.ToInt32(line.Split('=')[1]); _nCols = _samples; }
            if (line.ToLower().Contains("lines")) { _lines = Convert.ToInt32(line.Split('=')[1]); _nRows = _lines; }
            if (line.ToLower().Contains("bands") && !line.ToLower().Contains("default")) { _nBands = Convert.ToInt16(line.Split('=')[1]); }
            if (line.ToLower().Contains("description")) { _comment = line.Split('=')[1]; }
            if (line.ToLower().Contains("default bands")) { _defaultBands = (line.Split('{')[1].Split('}')[0]).Trim(); }
            if (line.ToLower().Contains("ulxmap")) { _ulxmap = Convert.ToDouble(line.Split('=')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ulymap")) { _ulymap = Convert.ToDouble(line.Split('=')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.Contains("#") || line == "") { _comment = line; }
            if (line.ToLower().Contains("xllcenter")) { _xllcenter = Convert.ToDouble(line.Split('=')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("yllcenter")) { _yllcenter = Convert.ToDouble(line.Split('=')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("cellsize")) { _cellsize = Convert.ToDouble(line.Split('=')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("interleave")) { _interleave = line.Split('=')[1].Trim(); }
            if (line.ToLower().Contains("layout")) { _layout = line.Split('=')[1]; }
            if (line.ToLower().Contains("sensor type")) { _sensor_type = line.Split('=')[1]; }
            if (line.ToLower().Contains("date")) { string s = (line.Split(':')[1]); _date = s.Substring(0, s.Length - 1).Trim(','); }
            if (line.ToLower().Contains("time"))
            {
                int ind = line.IndexOf(':');
                string ss = line.Substring(ind).Trim().Trim(':').Trim(',');
                _time = ss;
            }

            if (line.ToLower().Contains("wavelength") && !line.ToLower().Contains("wavelength units") && !line.ToLower().Contains("wavelength,")) 
            { 
                _wavelenght = new string[this.Nbands];
                string sline = (line.Split('=')[1]).Trim('}').Trim(); //.Trim('{');
                _wavelenght = sline.Substring(1).Split(','); 
            }
            if (line.ToLower().Contains("wavelength units")) _wavelenght_units = line.Split('=')[1];
        }
        #endregion

        #region Parse bil header
        public void parseBILHeader() // parse bil header content from the given bil file (bil extension needed)
        {
            using (FileStream fs = new FileStream(Path.ChangeExtension(_fileName, ".hdr"), FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                string line;
                while (!sr.EndOfStream)
                {
                    line = System.Text.RegularExpressions.Regex.Replace(sr.ReadLine(), @"\s{2,}", " "); // multi space are removed and substitute with one space " "
                    getBILParams(line);
                }
                if (_bytesPerPixel == 0) _bytesPerPixel = (_nBits / 8) * _nBands;

                if (_cellsize != 0) { _xdim = _cellsize; _ydim = _xdim; }
                if (_cellsize == 0 && _xdim == _ydim) _cellsize = _xdim;
                if (_lrxmap ==0 && Lrymap==0) { _lrxmap = _ulxmap + _nCols * _xdim; _lrymap = _ulymap + _nRows * _ydim; }
                if (_xllcenter != 0 && _yllcenter != 0)
                {
                    _ulxmap = _xllcenter - (_nCols * _xdim) / 2F;
                    _lrxmap = _xllcenter + (_nCols * _xdim) / 2F;
                    _ulymap = _yllcenter - (_nRows * _ydim) / 2F;
                    _lrymap = _yllcenter + (_nRows * _ydim) / 2F;
                }
                //int res = (_nCols) % 4;
                _stride = 4 * ((_nCols * _bytesPerPixel + 3) / 4);  //* _nBands;                
            }
        }

        void getBILParams(string line)  //parsing bil parameters from the given bil file
        {
            if (line.ToLower().Contains("byteorder")) { _byteorder = line.Split(' ')[1]; }
            if (line.ToLower().Contains("layout")) { _layout = line.Split(' ')[1]; }
            if (_layout == "layout") { _dataType = "ENVI BIL"; }
            if (_layout == "" || _layout=="bil") { _dataType = "ESRI BIL"; }
            if (line.ToLower().Contains("datatype")) { _dataType = line.Split(' ')[1]; }
            if (line.ToLower().Contains("nbits")) { _nBits = Convert.ToInt16(line.Split(' ')[1]); }
            if (line.ToLower().Contains("xdim")) { _xdim = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ydim")) { _ydim = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ncols")) { _nCols = Convert.ToInt32(line.Split(' ')[1]); }
            if (line.ToLower().Contains("nrows")) { _nRows = Convert.ToInt32(line.Split(' ')[1]); }
            if (line.ToLower().Contains("nbands")) { _nBands = Convert.ToInt16(line.Split(' ')[1]); }
            if (line.ToLower().Contains("ulxmap")) { _ulxmap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ulymap")) { _ulymap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("lrxmap")) { _lrxmap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("lrymap")) { _lrymap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.Substring(0, 1) == "#") { _comment = line; }
            if (line.ToLower().Contains("xllcenter")) { _xllcenter = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("yllcenter")) { _yllcenter = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("cellsize")) { _cellsize = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
        }
        #endregion

        #region Parse tiff parameters (active)
        void parseTifParams()
        {
            string[] exif = getExifData(_fileName);
            foreach(string line in exif)
            {
                string l = line.ToLower();
                if (l.Contains("gps latitude ref")) { _gpslatitudeRef = l.Split(';')[1]; }
                if (l.Contains("gps latitude") && !l.Contains("gps latitude ref")) 
                {
                    string st = l.Split(';')[1].Trim();
                    st = st.Substring(0, st.Length - 1);
                    _gpslatitude = convertDegree2Decimal(st);
                    //_gpslatitude = Convert.ToDouble(l.Split(';')[1], CultureInfo.InvariantCulture);
                }
                if (l.Contains("gps longitude ref")) { _gpslongitudeRef = l.Split(';')[1]; }
                if (l.Contains("gps longitude") && !l.Contains("gps longitude ref")) 
                {
                    string st = l.Split(';')[1].Trim();
                    _gpslongitude = convertDegree2Decimal(st);
                    //_gpslongitude = Convert.ToDouble(l.Split(';')[1].Split(' ')[0], CultureInfo.InvariantCulture); 
                }
                if (l.Contains("gps altitude ref")) { _gpsaltitudeRef = l.Split(';')[1]; }
                if (l.Contains("gps altitude") && !l.Contains("gps altitude ref")) 
                {
                    string s1 = l.Split(';')[1].Trim();
                    _gpsaltitude = Convert.ToSingle(s1.Split(' ')[0].Trim(), CultureInfo.InvariantCulture); 
                }
                _absolute_altitude = _gpsaltitude;
                if (l.Contains("byte order")) { _byteorder = l.Split(';')[1]; }
                if (l.Contains("image width")) { _nCols = Convert.ToInt16(l.Split(';')[1]); }
                if (l.Contains("image height")) { _nRows = Convert.ToInt16(l.Split(';')[1]); }
                if (l.Contains("samples per pixel")) { _nBands = Convert.ToInt16(l.Split(';')[1]); }
                if (l.Contains("bits per sample")) 
                {
                    string s2 = l.Split(';')[1].Trim();
                    if (s2.Split(' ') == null) { _nBits = Convert.ToInt16(l.Split(';')[1]); }
                    else { _nBits = Convert.ToInt16(s2.Split(' ')[0]); }
                     
                }

                if (l.Contains("pitch") && !l.Contains("<pitch>")) { _camera_pitch = Convert.ToSingle(l.Split(';')[1], CultureInfo.InvariantCulture); }
                else
                {
                    var doc = new XmlDocument();
                    if (l.IndexOf('<') != -1)
                    {
                        try
                        {
                            doc.LoadXml(l.Substring(l.IndexOf('<')));
                            var element = (XmlElement)doc.GetElementsByTagName("location_name")[0];
                            _locationName = element.InnerText;
                            element = (XmlElement)doc.GetElementsByTagName("pitch")[0];
                            _camera_pitch = Convert.ToSingle(element.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                if (l.Contains("yaw")) { _camera_yaw = Convert.ToSingle(l.Split(';')[1], CultureInfo.InvariantCulture); }
                if (l.Contains("relative altitude")) { _relative_altitude = Convert.ToSingle(l.Split(';')[1], CultureInfo.InvariantCulture); }
            }
            _bytesPerPixel = _nBands * _nBits / 8;
        }
        #endregion

        #region Parse tif parameters (no active)
        void parseGeoTifParams()  // for 24 bits images only
        {
            Tiff tf = BitMiracle.LibTiff.Classic.Tiff.Open(_fileName,"r");
            FieldValue[] val = tf.GetField(TiffTag.IMAGEWIDTH);
            if (val != null) { _nCols = val[0].ToInt(); }
            val = tf.GetField(TiffTag.IMAGELENGTH);
            if (val != null) { _nRows = val[0].ToInt(); }
            int res = (_nCols) % 4;
            _stride = (_nCols + res) *_nBands;
            val = tf.GetField(TiffTag.BITSPERSAMPLE);
            if (val != null) { _nBits = val[0].ToInt(); }
            val = tf.GetField(TiffTag.SAMPLESPERPIXEL);
            if (val != null)
            {
                _nBands = val[0].ToInt();
                _bytesPerPixel = _nBands * (_nBits/8);
            }
            _dataType = "TIF";
            val = tf.GetField(TiffTag.COMPRESSION);
            
            if (val != null) { _compression = val[0].ToString(); }          
            val = tf.GetField(TiffTag.CELLWIDTH);
            if (val != null) { _xdim = val[0].ToInt(); }
            val = tf.GetField(TiffTag.CELLLENGTH);
            if (val != null) { _ydim = val[0].ToInt(); }
            string[] exif = getExifData(_fileName);
            //var doc = new XmlDocument();
            foreach (string item in exif)
            {
                //if (item.ToLower().Contains("image description"))
                //{
                //    if (item.IndexOf('<') != -1)
                //    {
                //        doc.LoadXml(item.Substring(item.IndexOf('<')));
                //        var element = (XmlElement)doc.GetElementsByTagName("Location_name")[0];
                //        _locationName = element.InnerText;
                //        element = (XmlElement)doc.GetElementsByTagName("Longitude")[0];
                //        _gpslongitude = Convert.ToDouble(element.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                //        element = (XmlElement)doc.GetElementsByTagName("Latitude")[0];
                //        _gpslatitude = Convert.ToDouble(element.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                //        element = (XmlElement)doc.GetElementsByTagName("Height")[0];
                //        _gpsaltitude = Convert.ToSingle(element.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                //    }
                //}
                //else
                {
                    string st = "";
                    if (item.Contains("GPS Longitude") && !item.Contains("GPS Longitude Ref"))
                    {
                        st = item.Split(';')[1].Trim();
                        st = st.Substring(0, st.Length - 1);
                        _gpslongitude = convertDegree2Decimal(st);
                    }

                    if (item.Contains("GPS Longitude Ref"))
                    {
                        st = item.Split(';')[1].Trim();
                        //st = st.Substring(0, st.Length);
                        _gpslongitudeRef = st;
                    }

                    if (item.Contains("GPS Latitude") && !item.Contains("GPS Latitude Ref"))
                    {
                        st = item.Split(';')[1].Trim();
                        st = st.Substring(0, st.Length - 1);
                        _gpslatitude = convertDegree2Decimal(st);
                    }

                    if (item.Contains("GPS Latitude Ref"))
                    {
                        st = item.Split(';')[1].Trim();
                        //st = st.Substring(0, st.Length - 1);
                        _gpslatitudeRef = st;
                    }

                    if (item.Contains("GPS Altitude") && !item.Contains("GPS Altitude Ref"))
                    {
                        st = item.Split(';')[1].Trim();
                        string st2 = st.Split(' ')[0];
                        _gpsaltitude = Convert.ToSingle(st2,System.Globalization.CultureInfo.InvariantCulture);
                    }
                    if (item.Contains("GPS Altitude Ref"))
                    {
                        st = item.Split(';')[1].Trim();
                        //st = st.Substring(0, st.Length - 1);
                        _gpsaltitudeRef = st;
                    }

                }
            }
            GdalConfiguration.ConfigureGdal();
            Gdal.AllRegister();
            Dataset ds = Gdal.Open(_fileName, Access.GA_ReadOnly);
            _coordSystem = parseProjectionData(ds);
            parseCornerData(ds);
            foreach (string item in exif)
            {
                if (item.ToLower().Contains("locationname"))
                {
                    int iStart = item.ToLower().LastIndexOf("<locationame>");
                    int iLength = item.ToLower().LastIndexOf("</locationame>") - iStart;
                    _locationName = item.Substring(iStart, iLength);
                }
            }

            tf.Dispose();
        }
        #endregion

        #region Parse projection and corner data
        string parseProjectionData(Dataset ds)
        {
            List<string> Proj = new List<string>();
            string projection = ds.GetProjection();
            SpatialReference sr = new SpatialReference(projection);
            string projpars = "";
            if (projection != "")
            {
                sr.ExportToProj4(out projpars);
                //sr.ExportToPrettyWkt(out prettywkt, 0);
            }
            return projpars;
        }

        double[] parseCornerData(Dataset _dataset)
        {
            double[] geotransform = new double[6];
            double[] corners = new double[6];
            _dataset.GetGeoTransform(geotransform);
            var ulX = geotransform[0];
            var ulY = geotransform[3];
            var xRes = geotransform[1];
            var yRes = geotransform[5];
            var lrX = ulX + _dataset.RasterXSize * xRes;
            var lrY = ulY + _dataset.RasterYSize * yRes;
            corners[0] = ulX;
            _ulxmap = ulX;
            corners[1] = ulY;
            _ulymap = ulY;
            corners[2] = lrX;
            _lrxmap = lrX;
            corners[3] = lrY;
            _lrymap = lrY;
            corners[4] = xRes;
            _xdim = xRes;
            corners[5] = yRes;
            _ydim = yRes;
            return corners;
        }
        #endregion

        #region Parse jpg parameters
        void parseJPGParams() // for 24or 8 bits images only
        {
            Bitmap bmpJpg = new Bitmap(_fileName);
            BitmapData bitmapdataJPG = bmpJpg.LockBits(new Rectangle(0, 0, bmpJpg.Width, bmpJpg.Height), ImageLockMode.ReadOnly, bmpJpg.PixelFormat);
            _nRows = bmpJpg.Height;
            _nCols = bmpJpg.Width;
            _stride = bitmapdataJPG.Stride;
            bmpJpg.UnlockBits(bitmapdataJPG);

            if (bitmapdataJPG.PixelFormat == PixelFormat.Format24bppRgb)
            {
                _nBands = 3;
                _bytesPerPixel = 3;
                _nBits = 8;
                _dataType = "JPG";
            }
            if (bitmapdataJPG.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                _nBands = 1;
                _bytesPerPixel = 1;
                _nBits = 8;
                _dataType = "JPG";
            }
            if (bitmapdataJPG.PixelFormat == PixelFormat.Format16bppGrayScale)  // ??????????????????????
            {
                _nBands = 1;
                _bytesPerPixel = 2;
                _nBits = 16;
                _dataType = "JPG";
            }
            bmpJpg.Dispose();
            string[] exif = getExifData(_fileName);
            foreach (string itm in exif)
            {
                string item = itm.ToLower();
                string st = "";

                if (item.Contains("exif byte order"))
                {
                    st = item.Split(';')[1].Trim();
                    //st = st.Substring(0, st.Length);
                    _byteorder = st;
                }

                if (item.Contains("gps longitude") && !item.Contains("gps longitude ref"))
                { 
                    st = item.Split(';')[1].Trim();
                    st = st.Substring(0, st.Length-1);                    
                    _gpslongitude=convertDegree2Decimal(st);
                }

                if (item.Contains("gps longitude ref"))
                {
                    st = item.Split(';')[1].Trim();
                    //st = st.Substring(0, st.Length);
                    _gpslongitudeRef = st;
                }

                if (item.Contains("gps latitude") && !item.Contains("gps latitude ref"))
                {
                    st = item.Split(';')[1].Trim();
                    st = st.Substring(0, st.Length - 1);
                    _gpslatitude = convertDegree2Decimal(st);
                }

                if (item.Contains("gps latitude ref"))
                {
                    st = item.Split(';')[1].Trim();
                    //st = st.Substring(0, st.Length - 1);
                    _gpslatitudeRef = st;
                }

                if (item.Contains("gps altitude") && !item.Contains("gps altitude ref"))
                {
                    st = item.Split(';')[1].Trim();
                    string st2 = st.Split(' ')[0];
                    _gpsaltitude = Convert.ToSingle(st2, CultureInfo.InvariantCulture);
                }
                if (item.Contains("gps altitude ref"))
                {
                    st = item.Split(';')[1].Trim();
                    //st = st.Substring(0, st.Length - 1);
                    _gpsaltitudeRef = st;
                }
                if (item.Contains("camera yaw"))
                {
                    st = item.Split(';')[1].Trim();
                    //st = st.Substring(0, st.Length - 1);
                    _camera_yaw = Convert.ToSingle(st, CultureInfo.InvariantCulture);
                }
                if (item.Contains("camera pitch"))
                {
                    st = item.Split(';')[1].Trim();
                    //st = st.Substring(0, st.Length - 1);
                    _camera_pitch = Convert.ToSingle(st, CultureInfo.InvariantCulture);
                }
                if (item.Contains("relative altitude"))
                {
                    st = item.Split(';')[1].Trim();
                    //st = st.Substring(0, st.Length - 1);
                    _relative_altitude = Convert.ToSingle(st, CultureInfo.InvariantCulture);
                }

                _absolute_altitude = _gpsaltitude;
            }
        }
        #endregion
        double convertDegree2Decimal(string inSt)
        {
            string[] outSt = inSt.Split(' ');
            int deg = Convert.ToInt16(outSt[0]); //.Substring(0, outSt[0].Length - 1));
            int min = Convert.ToInt16(outSt[2].Substring(0, outSt[2].Length - 1), CultureInfo.InvariantCulture);
            Single sec = Convert.ToSingle(outSt[3].Substring(0, outSt[3].Length-1), CultureInfo.InvariantCulture);
            double coord = deg + Convert.ToDouble(min) / 60D + Convert.ToDouble(sec)/3600D;
            return coord;
        }

        void parseDDMHeader()
        {
            resetImageParameters();
            parseDDMParams();
        }
        #region Parse Giwer header
        void parseGiwerHeader() // parse giwer header
        {
            string[] hdr = System.IO.File.ReadAllLines(_fileName);
            foreach (string line in hdr)
            {
                string ln = line.ToLower();
                //if (line.ToLower().Contains("filename")) { _fileName = line.Split(';')[1]; }

                if (ln.Contains("ncols")) { _nCols = Convert.ToInt16(ln.Split(';')[1]); }
                if (ln.Contains("nrows")) { _nRows = Convert.ToInt16(ln.Split(';')[1]); }
                if (line.ToLower().Contains("samples")) 
                { 
                    _samples = Convert.ToInt32(line.Split(';')[1]); 
                    if (Samples !=0) _nCols = _samples; 
                }
                if (line.ToLower().Contains("lines")) 
                { _lines = Convert.ToInt32(line.Split(';')[1]); 
                    if(Lines !=0) _nRows = _lines; 
                }
                if (ln.Contains("datatype")) { _dataType = ln.Split(';')[1]; }
                if (ln.Contains("defaultbands")) { _defaultBands = ln.Split(';')[1]; }
                if (ln.Contains("stride")) { _stride = Convert.ToInt32(ln.Split(';')[1]); }
                if (ln.Contains("nbands")) { _nBands = Convert.ToInt16(ln.Split(';')[1]); }
                if (ln.Contains("bytesperpixel")) { _bytesPerPixel = Convert.ToInt16(ln.Split(';')[1]); }
                if (ln.Contains("nbits")) { _nBits = Convert.ToInt16(ln.Split(';')[1]); }
                if (ln.Contains("byteorder")) _byteorder = ln.Split(';')[1];
                if (ln.Contains("xdim")) { _xdim = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("ydim")) { _ydim = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("cellsize")) { _cellsize = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("ulxmap")) { _ulxmap = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("ulymap")) { _ulymap = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("lrxmap")) { _lrxmap = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("lrymap")) { _lrymap = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("xllcenter")) { _xllcenter = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("yllcenter")) { _yllcenter = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("layout")) { _layout = ln.Split(';')[1]; }
                if (ln.Contains("compression")) { _compression = ln.Split(';')[1]; }
                if (ln.Contains("coordsys")) { _coordSystem = line.Split(';')[1]; }
                if (ln.Contains("gpslatituderef")) { _gpslatitudeRef = line.Split(';')[1]; }
                if (ln.Contains("gpslongituderef")) { _gpslongitudeRef = line.Split(';')[1]; }
                if (ln.Contains("gpsaltituderef")) { _gpsaltitudeRef = (line.Split(';')[1]); }
                if (ln.Contains("gpslatitude") && !ln.Contains("gpslatituderef")) { _gpslatitude = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("gpslongitude") && !ln.Contains("gpslongituderef")) { _gpslongitude = Convert.ToDouble(ln.Split(';')[1]); }
                if (ln.Contains("gpsaltitude") && !ln.Contains("gpsaltituderef")) { _gpsaltitude = Convert.ToSingle(ln.Split(';')[1]); }
                if (ln.Contains("locationname")) _locationName = line.Split(';')[1];
                if (ln.Contains("camera_pitch")) _camera_pitch = Convert.ToSingle(line.Split(';')[1]);
                if (ln.Contains("camera_yaw")) _camera_yaw = Convert.ToSingle(line.Split(';')[1]);
                if (ln.Contains("camera_roll")) _camera_roll = Convert.ToSingle(line.Split(';')[1]);
                if (ln.Contains("absolute_altitude")) _absolute_altitude = Convert.ToSingle(line.Split(';')[1]);
                if (ln.Contains("relative_altitude")) _relative_altitude = Convert.ToSingle(line.Split(';')[1]);
                if (line.ToLower().Contains("comment")) { _comment = line.Split(';')[1]; }
                if (line.ToLower().Contains("interleave")) { _interleave = line.Split(';')[1].Trim(); }
                //if (line.ToLower().Contains("layout")) { _layout = line.Split('=')[1]; }
                if (line.ToLower().Contains("sensor_type")) { _sensor_type = line.Split(';')[1]; }
                if (line.ToLower().Contains("date")) { string s = (line.Split(';')[1]); _date = s.Substring(0, s.Length).Trim(','); }
                if (line.ToLower().Contains("time"))
                {
                    int ind = line.IndexOf(';');
                    string ss = line.Substring(ind).Trim().Trim(':').Trim(',');
                    _time = ss;
                }
                if (line.ToLower().Contains("wavelength_units")) _wavelenght_units = line.Split(';')[1];
                if (line.ToLower().Contains("wavelength;"))
                {
                    _wavelenght = new string[this.Nbands];
                    string sline = line.Split(';')[1];
                    _wavelenght = sline.Split(',');
                }

            }
        }
        #endregion
        #endregion

        //public string[] getExifData(string file)
        //{
        //    var directories = ImageMetadataReader.ReadMetadata(file);
        //    List<string> Tags = new List<string>();
        //    for (int k = 0; k < directories.Count; k++)
        //    {
        //        for (int i = 0; i < directories[k].TagCount; i++)
        //        {
        //            Tags.Add(directories[k].Tags[i].Name + "; " + directories[k].Tags[i].Description);
        //        }
        //    }
        //    return Tags.ToArray();
        //}
        public string[] getExifData(string file)
        {
            //string fname = Path.GetFileNameWithoutExtension(this.FileName) + ".exif";
            string dir = AppDomain.CurrentDomain.BaseDirectory.ToString();
            Process proc = new Process();
            proc.StartInfo.FileName = dir + "exiftool.exe"; // + " > " + dir + fname;
            proc.StartInfo.Arguments = file;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            string ex = proc.StandardOutput.ReadToEnd();
            string[] exi = ex.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            List<string> l = new List<string>();
            for (int i = 0; i < exi.Length; i++)
            {
                if (exi[i] != "") l.Add(exi[i].Split(':')[0].Trim() + ";" + exi[i].Split(':')[1]);
            }
            string[] exif = l.ToArray();
            return exif;
        }

        void computeStride()
        {
            //int bitsPerPixel = ((int)format & 0xff00) >> 8;
            //int bitsPerPixel = System.Drawing.Image.GetPixelFormatSize(format);
            //bytesPerPixel = (bitsPerPixel + 7) / 8;
            //stride = 4 * ((width * bytesPerPixel + 3) / 4);
            //_bytesPerPixel = (_nBits + 7) / 8;
            //_stride = 4 * (_nCols * _bytesPerPixel + 3) / 4;
            int res = (_nCols) % 4;
            _stride = (_nCols+res) * _nBands;
        }

        void resetImageParameters()
        {
            this._dataType = "";
            this._byteorder = "";
            this._bytesPerPixel = 0;
            this._cellsize = 0;
            this._comment = "";
            this._compression = "NONE";
            this._dataType = null;
            this._defaultBands = "NONE";
            this._layout = "";
            this._interleave = "";
            this._sensor_type = "";
            this._lines = 0;
            this._nBands = 0;
            this._nBits = 0;
            this._nCols = 0;
            this._nRows = 0;
            this._samples = 0;
            this._stride = 0;
            this._ulxmap = 0;
            this._ulymap = 0;
            this._lrxmap = 0;
            this._lrymap = 0;
            this._xdim = 0;
            this._xllcenter = 0;
            this._ydim = 0;
            this._yllcenter = 0;
            this._coordSystem = "Unknown";
            this._camera_yaw = 0;
            this._camera_pitch = 0;
        }
        #endregion functions and methods
    }
}
