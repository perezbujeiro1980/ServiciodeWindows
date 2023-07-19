using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Windows.Forms;

public class Dat
{
  

    public Dat()
	{
        
    }
  

    public string getConn()         

    {
        string connectionString = "Data Source=RYAP021BUE;Initial Catalog=Ax2k9ArgRayPro;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();        
        return connection.State.ToString();
    }


    //public static DataTable GetDataTableFromMSSQL(string connectionString, string query)
    //{
            
         
    //    using (SqlConnection connection = new SqlConnection(connectionString))
    //    {
    //        connection.Open();

    //        using (SqlCommand command = new SqlCommand(query, connection))
    //        {
    //            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    //            {
    //                DataTable dataTable = new DataTable();
    //                adapter.Fill(dataTable);
    //                connection.Close();
    //                return dataTable;
    //            }
    //        }
    //    }
    //}



    //public static string ConvertDataTableToJson(DataTable dataTable)
    //{
    //    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
    //    foreach (DataRow dataRow in dataTable.Rows)
    //    {
    //        Dictionary<string, object> row = new Dictionary<string, object>();
    //        foreach (DataColumn column in dataTable.Columns)
    //        {
    //            row[column.ColumnName] = dataRow[column];
    //        }
    //        rows.Add(row);
    //    }
    //    return JsonConvert.SerializeObject(rows);
    //}


    //public string getJSON()
    //{
    //    //   DataTable dataTable = GetDataTableFromMSSQL(connectionString, "select * FROM InventSubBatch_MPH");

    //    //DataTable dataTable = GetDataTableFromMSSQL(connectionString, "select s.INVENTSUBBATCHID," +
    //    //    "s.ITEMID, i.ITEMNAME, s.PDSDISPOSITIONCODE, " +
    //    //    "s.INVENTBATCHID,l.PRODDATE,l.EXPDATE," +
    //    //    "im.unitid" +
    //    //    "from InventSubBatch_MPH s" +
    //    //    "inner join INVENTTABLE i on i.ITEMID=s.ITEMID" +
    //    //    "inner join INVENTBATCH l on s.ITEMID=l.ITEMID " +
    //    //    "and s.INVENTBATCHID=l.INVENTBATCHID" +
    //    //    "inner join INVENTTABLEMODULE im on im.ITEMID=i.ITEMID" +
    //    //    "where s.DATAAREAID='070' and l.DATAAREAID='070' and i.DATAAREAID='070'" +
    //    //    "and im.DATAAREAID='070' and im.MODULETYPE=0" +
    //    //    "order by s.INVENTSUBBATCHID");
    //    //  string json = ConvertDataTableToJson(dataTable);
    //    //   return (json);
    //    //   return dataTable.ToString();

    //}

}
