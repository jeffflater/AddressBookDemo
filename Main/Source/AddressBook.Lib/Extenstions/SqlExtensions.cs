using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AddressBook.Lib.Extenstions
{
    public static class SqlExtensions
    {
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
                    //handle sql exception, possible syntax error
                }
                catch (Exception ex)
                {
                    //hanlde expection, possible db connection error
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
