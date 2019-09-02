using System.Collections.Generic;
using System.Data;

namespace AutoLotDAL.BulkImport
{
    interface IMyDataReader<T> : IDataReader
    {
        List<T> Records { get; set; }
    }
}
