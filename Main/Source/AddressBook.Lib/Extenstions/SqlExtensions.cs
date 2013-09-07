using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using log4net;

namespace AddressBook.Lib.Extenstions
{
    public static class SqlExtensions
    {
        public static List<T> QueryTransaction<T>(string sql)
        {
            var result = new List<T>();
            var connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            var command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                result = AutoMapper.Mapper.DynamicMap<IDataReader, List<T>>(reader);
            }
            catch (Exception ex)
            {
                //TODO: log exception
            }
            finally
            {
                connection.Close();
            }
            
            return result;
        }

        public static void CommitTransaction(string sql)
        {
            var connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            var command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                var result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //TODO: log exception
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
