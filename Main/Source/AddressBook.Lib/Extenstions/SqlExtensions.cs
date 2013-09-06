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
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static DataTable QueryDatabase(string sql)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                DataTable datatable = new DataTable();

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    datatable.Load(reader);
                }
                catch (SqlException ex)
                {
                    log.Error(ex.Message, ex);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                }
                finally
                {
                    connection.Close();
                }

                return datatable;
            }
        }
    }
}
