using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Extension
{
    public static class DbSetExtension
    {
        public static IQueryable<Entity> ExecProcedure<Entity>(this DbSet<Entity> source, string sql, params SqlParameter[] parameters)
            where Entity : class
        {
            var execSql = "exec " + sql + " ";
            var execValues = string.Join(", ",
                parameters.Where(x => x.SqlValue != null).Select(x => x.ParameterName + " = " + "'" + x.SqlValue.ToString() + "'"));
            
            return source.FromSqlRaw(execSql + execValues);
        }
    }
}
