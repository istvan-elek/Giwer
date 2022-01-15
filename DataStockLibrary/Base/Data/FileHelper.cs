using static DataStockLibrary.Base.Data.GeoImageData;

namespace DataStockLibrary.Base.Data
{
    internal static class FileHelper
    {

        private static readonly Dictionary<string, GeoImageType> extensions = new Dictionary<string, GeoImageType>()
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
            return !extensions.TryGetValue(extension, out _) ? GeoImageType.UNKOWN : extensions[fileName];
        }

        public static GeoImageType GetImageType(string fileName, string text, GeoImageType imageType)
        {
            if (File.ReadAllText(fileName).Contains(text))
            {
                return imageType;
            }
            return GetImageType(fileName);
        }
    }
}
