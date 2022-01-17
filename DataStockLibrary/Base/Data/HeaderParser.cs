using System;
using System.Collections.Generic;
using System.Text;

namespace DataStockLibrary.Base.Data
{
    internal interface IHeaderParser
    {
        ImageAttribute Parse(string fileName);
    }
}
