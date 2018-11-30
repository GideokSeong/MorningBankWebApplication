using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorningBank.DataLayer
{
    public interface IDataAccess
    {
        object GetSingleAnswer(string sql, List<DbParameter> PList, DbConnection conn = null, DbTransaction sqtr = null, bool bTransaction = false);
        DataTable GetManyRowsCols(string sql, List<DbParameter> PList, DbConnection conn = null, DbTransaction sqtr = null, bool bTransaction = false);
        int InsertUpdateDelete(string sql, List<DbParameter> PList, DbConnection conn = null, DbTransaction sqtr = null, bool bTransaction = false);

    }
}
