using System.Data;
using System.Data.SqlClient;

namespace CoreWebAPI.Helpers
{
    public class SqlHelper
    {
        private SqlConnection _conn;
        
        public SqlHelper(SqlConnection conn)
        {
            _conn = conn;
        }
        
        public DataTable LoadDataTable(string sql)
        {
            return LoadDataTable(sql, CommandType.Text, null);
        }

        public DataTable LoadDataTable(string sql, SqlParameter param)
        {
            return LoadDataTable(sql, CommandType.Text, param);
        }

        public DataTable LoadDataTable(string cmdText, CommandType type)
        {
            return LoadDataTable(cmdText, type, null);
        }

        public DataTable LoadDataTable(string cmdText, CommandType type, params SqlParameter[] parameters)
        {
            SqlDataReader rdr = null;
            DataTable table = new DataTable();
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand(cmdText, _conn);
                cmd.CommandType = type;
                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }
                rdr = cmd.ExecuteReader();
                table.Load(rdr);
            }
            catch { throw; }
            finally
            {
                if (rdr != null) rdr.Close();
                if (_conn != null) _conn.Close();
            }
            return table;
        }

        
    }
}
