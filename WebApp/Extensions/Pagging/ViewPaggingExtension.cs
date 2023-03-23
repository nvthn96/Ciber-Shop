using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApp.Extension.Pagging
{
    public static class ViewPaggingExtension
    {
        public static IEnumerable<SqlParameter> GetPaggingParameters<T>(this ViewPagging<T> pagging) where T : class
        {
            var parameters = new List<SqlParameter>() {
                new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@SearchColumn", SqlValue = pagging.SearchColumn },
                new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@SearchText", SqlValue = pagging.SearchText },
                new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@SortColumn", SqlValue = pagging.SortColumn },
                new SqlParameter { SqlDbType = SqlDbType.NVarChar, ParameterName = "@SortDir", SqlValue = pagging.SortDir },
                new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@Skip", SqlValue = pagging.Skip },
                new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@Take", SqlValue = pagging.Take },
                new SqlParameter { SqlDbType = SqlDbType.Int, ParameterName = "@Total", SqlValue = 0, Direction = ParameterDirection.Output },
            };

            return parameters;
        }
    }
}
