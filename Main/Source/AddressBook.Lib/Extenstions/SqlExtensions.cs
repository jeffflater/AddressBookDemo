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
    /// <summary>
    /// SQL Extensions - ADO.NET
    /// </summary>
    public static class SqlExtensions
    {
        /// <summary>
        /// Executes SQL statement and returns a result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> QueryTransaction<T>(string sql)
        {
            var result = new List<T>();
            var connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            var command = new SqlCommand(sql, connection);

            try
            {
                //Open connection
                connection.Open();
                //Execute SQL statement
                var reader = command.ExecuteReader();
                //AutoMap using AutoMapper to map the reader object to a defined class
                result = AutoMapper.Mapper.DynamicMap<IDataReader, List<T>>(reader);
            }
            catch (Exception ex)
            {
                //TODO: log exception
            }
            finally
            {
                //Close SQL connection
                connection.Close();
            }
            
            return result;
        }

        /// <summary>
        /// Executes a SQL statement and does not return a result
        /// </summary>
        /// <param name="sql"></param>
        public static void CommitTransaction(string sql)
        {
            var connection = new SqlConnection(Properties.Settings.Default.ConnectionString);
            var command = new SqlCommand(sql, connection);

            try
            {
                //Open connection
                connection.Open();
                var result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //TODO: log exception
            }
            finally
            {
                //Close Connection
                connection.Close();
            }
            //TODO: Ehance method to return number of rows affected and if transaction was successfull or not.
        }
    }
}
