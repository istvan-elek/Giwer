using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace DataStockLibrary.Base.Data.Tiff
{
    internal class TiffParser : IHeaderParser
    {
        public ImageAttribute Parse(string fileName)
        {
            ImageAttribute imageAttribute = new();
            string[] exif = FileHelper.GetExifData(fileName);
            imageAttribute.Coordinate = ParseCoordinates(exif);
            foreach (string line in exif)
            {
                string l = line.ToLower();


                if (l.Contains("byte order")) { imageAttribute.ByteOrder = l.Split(';')[1]; }
                if (l.Contains("samples per pixel")) { imageAttribute.NBands = Convert.ToInt16(l.Split(';')[1]); }
                if (l.Contains("bits per sample"))
                {
                    string s2 = l.Split(';')[1].Trim();
                    if (s2.Split(' ') == null) { imageAttribute.NBits = Convert.ToInt16(l.Split(';')[1]); }
                    else { imageAttribute.NBits = Convert.ToInt16(s2.Split(' ')[0]); }

                }
                imageAttribute.BytesPerPixel = imageAttribute.NBands * imageAttribute.NBits / 8;

                if (l.Contains("image width")) { _nCols = Convert.ToInt16(l.Split(';')[1]); }
                if (l.Contains("image height")) { _nRows = Convert.ToInt16(l.Split(';')[1]); }
                

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
                            imageAttribute.LocationName = element.InnerText;
                            element = (XmlElement)doc.GetElementsByTagName("pitch")[0];
                            _camera_pitch = Convert.ToSingle(element.InnerText, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                if (l.Contains("yaw")) { _camera_yaw = Convert.ToSingle(l.Split(';')[1], CultureInfo.InvariantCulture); }
            }
            

            return imageAttribute;
        }

        private ImageCoordinate ParseCoordinates(string[] exif) {
            ImageCoordinate imageCoordinate = new();
            foreach (var line in exif)
            {
                string l = line.ToLower();
                if (l.Contains("gps latitude ref")) { imageCoordinate.GpsLatitudeRef = l.Split(';')[1]; }
                if (l.Contains("gps latitude") && !l.Contains("gps latitude ref"))
                {
                    string st = l.Split(';')[1].Trim();
                    st = st.Substring(0, st.Length - 1);
                    imageCoordinate.GpsLatittude = Utility.ConvertDegree2Decimal(st);
                    //_gpslatitude = Convert.ToDouble(l.Split(';')[1], CultureInfo.InvariantCulture);
                }
                if (l.Contains("gps longitude ref")) { imageCoordinate.GpsLongitudeRef = l.Split(';')[1]; }
                if (l.Contains("gps longitude") && !l.Contains("gps longitude ref"))
                {
                    string st = l.Split(';')[1].Trim();
                    imageCoordinate.GpsLongitude = Utility.ConvertDegree2Decimal(st);
                    //_gpslongitude = Convert.ToDouble(l.Split(';')[1].Split(' ')[0], CultureInfo.InvariantCulture); 
                }
                if (l.Contains("gps altitude ref")) { imageCoordinate.GpsAltitudeRef = l.Split(';')[1]; }
                if (l.Contains("gps altitude") && !l.Contains("gps altitude ref"))
                {
                    string s1 = l.Split(';')[1].Trim();
                    imageCoordinate.GpsAltitude = Convert.ToSingle(s1.Split(' ')[0].Trim(), CultureInfo.InvariantCulture);
                }
                if (l.Contains("relative altitude")) { imageCoordinate.RelativeAltitude = Convert.ToSingle(l.Split(';')[1], CultureInfo.InvariantCulture); }

                imageCoordinate.AbsoluteAltitude = imageCoordinate.GpsAltitude;

            }
            return imageCoordinate;
        }
    }
}
