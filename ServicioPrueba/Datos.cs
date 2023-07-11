using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ServicioPrueba
{
    class Datos
    {
        public class Program
        {
            public static void Main()
            {
                string connectionString = "Data Source=NombreInstancia;Initial Catalog=NombreBaseDatos;Integrated Security=True";
                
                DataTable dataTable = GetDataTableFromMSSQL(connectionString, "SELECT * FROM prueba");
                string json = ConvertDataTableToJson(dataTable);
                Console.WriteLine(json);
            }

            public static DataTable GetDataTableFromMSSQL(string connectionString, string query)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            connection.Close();
                            return dataTable;
                        }
                    }


                }
            }

            public static string ConvertDataTableToJson(DataTable dataTable)
            {
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        row[column.ColumnName] = dataRow[column];
                    }
                    rows.Add(row);
                }
                return JsonConvert.SerializeObject(rows);
            }
        }

    }
}
