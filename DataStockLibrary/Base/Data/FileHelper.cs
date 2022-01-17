using System.Diagnostics;
using static DataStockLibrary.Base.Data.GeoImageData;

namespace DataStockLibrary.Base.Data
{
    internal static class FileHelper
    {

        private static readonly Dictionary<string, GeoImageType> supportedExtensions = new Dictionary<string, GeoImageType>()
        {
            {".GWH", GeoImageType.GWH }, {".BIL", GeoImageType.BIL },
            {".BSQ", GeoImageType.BSQ }, {".CUE", GeoImageType.BSQ},
            {".TIF", GeoImageType.TIF }, { ".TIFF", GeoImageType.TIF},
            {".JPG", GeoImageType.JPG }, {".JPEG", GeoImageType.JPG }, {".JPE", GeoImageType.JPG },
            {".ENVI", GeoImageType.ENVI }, {".DDM", GeoImageType.DDM }
        };

        public static GeoImageType GetImageType(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToUpper();
            return !supportedExtensions.TryGetValue(extension, out _) ? GeoImageType.UNKOWN : supportedExtensions[fileName];
        }

        public static GeoImageType GetImageType(string fileName, string text, GeoImageType imageType)
        {
            if (File.ReadAllText(fileName).Contains(text))
            {
                return imageType;
            }
            return GetImageType(fileName);
        }

        public static string[] GetExifData(string file)
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
    }
}
