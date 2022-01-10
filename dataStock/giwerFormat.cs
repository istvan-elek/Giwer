using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Giwer
{
    class giwerFormat
    {
        /*  This class contains giwer format converting methods:
         * convert to giwer format from a byte array
         * convert to giwer format from a bitmap
         * delete a giwer file
         * rename a giwer file
         */

        private string _fileName;
        public string FileName
        {
        get { return _fileName; }
        set { _fileName = value; }
        }

        public giwerFormat(string fName)
        {
            _fileName = fName;
        }
        //public void convert2GiwerFormat(byte[] byIn)
        //{
        //    using (FileStream fs = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.Write))
        //    {
        //        using (BinaryWriter bw = new BinaryWriter(fs))
        //        {
        //            foreach(byte item in byIn)
        //            {
        //                bw.Write(item);
        //            }
        //            bw.Flush();
        //        }
        //    }
        //}


    }
}
