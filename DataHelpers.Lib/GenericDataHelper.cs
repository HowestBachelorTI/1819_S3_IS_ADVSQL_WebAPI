using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataHelpers.Lib
{
    public abstract class GenericDataHelper<T>
    {
        protected SqlHelper _sqlHelper;
        public GenericDataHelper(SqlHelper sqlhelper)
        {
            _sqlHelper = sqlhelper;
        }
        public abstract T ConvertToEntity(DataRow row);

        public List<T> ConvertToList(DataTable table)
        {
            List<T> list = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                T t = ConvertToEntity(row);
                list.Add(t);
            }
            return list;
        }

        public List<T> ConvertToList(string sql)
        {
            return ConvertToList(sql, CommandType.Text, null);
        }

        public List<T> ConvertToList(string sql, CommandType type)
        {
            return ConvertToList(sql, type, null);
        }

        public List<T> ConvertToList(string sql, params SqlParameter[] parameters)
        {
            return ConvertToList(sql, CommandType.Text, parameters);
        }

        public List<T> ConvertToList(string sql, CommandType type, params SqlParameter[] parameters)
        {
            DataTable table = _sqlHelper.LoadDataTable(sql, type, parameters);
            return ConvertToList(table);
        }

        public T ConvertToEntity(string sql)
        {
            return ConvertToEntity(sql, CommandType.Text, null);
        }

        public T ConvertToEntity(string sql, CommandType type)
        {
            return ConvertToEntity(sql, type, null);
        }

        public T ConvertToEntity(string sql, params SqlParameter[] parameters)
        {
            return ConvertToEntity(sql, CommandType.Text, parameters);
        }

        public T ConvertToEntity(string sql, CommandType type, params SqlParameter[] parameters)
        {
            List<T> entities = ConvertToList(sql, type, parameters);
            if (entities.Count > 0) return entities[0];
            return default(T);
        }
    }
}
