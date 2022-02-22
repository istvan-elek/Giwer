using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catalog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MicaSense.Align(
            //    new string[]
            //    {
            //        @"E:\Spatial\giwer\micasense\IMG_0196_1.tif",
            //        @"E:\Spatial\giwer\micasense\IMG_0196_2.tif",
            //        @"E:\Spatial\giwer\micasense\IMG_0196_3.tif",
            //        @"E:\Spatial\giwer\micasense\IMG_0196_4.tif"
            //    },
            //    @"E:\Spatial\giwer\micasense\");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
