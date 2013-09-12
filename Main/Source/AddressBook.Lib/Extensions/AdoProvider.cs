using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AddressBook.Lib.Properties;
using AutoMapper;

namespace AddressBook.Lib.Extensions
{
    /// <summary>
    ///     ADO.NET Provider
    ///     This is used to query and commit sql transactions
    /// </summary>
    public static class AdoProvider
    {
        /// <summary>
        ///     Executes SQL statement and returns a result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> QueryTransaction<T>(string sql)
        {
            var result = new List<T>();
            var connection = new SqlConnection(Settings.Default.ConnectionString);
            var command = new SqlCommand(sql, connection);

            try
            {
                //Open connection
                connection.Open();
                //Execute SQL statement
                SqlDataReader reader = command.ExecuteReader();
                //AutoMap using AutoMapper to map the reader object to a defined class
                result = Mapper.DynamicMap<IDataReader, List<T>>(reader);
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
        ///     Executes a SQL statement and does not return a result
        /// </summary>
        /// <param name="sql"></param>
        public static void CommitTransaction(string sql)
        {
            var connection = new SqlConnection(Settings.Default.ConnectionString);
            var command = new SqlCommand(sql, connection);

            try
            {
                //Open connection
                connection.Open();
                int result = command.ExecuteNonQuery();
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