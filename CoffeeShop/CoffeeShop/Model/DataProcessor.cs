using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    internal class DataProcessor
    {
        string strCon = "Data Source=LAPTOP-Q4FCEV17\\SQLEXPRESS;Initial Catalog=BTL_QLCOFFEE;Integrated Security=True;";
        SqlConnection sqlCon = null;

        public void OpenConnection()
        {
            sqlCon = new SqlConnection(strCon);
            if (sqlCon.State != System.Data.ConnectionState.Open)
            {
                sqlCon.Open();
            }
        }
        public void CloseConnection()
        {
            if (sqlCon.State != System.Data.ConnectionState.Closed)
            {
                sqlCon.Close();
                sqlCon.Dispose();
            }
        }

        public DataTable ReadData(string sqlString)
        {
            DataTable dataTable = new DataTable();
            OpenConnection();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlString,sqlCon);
            sqlDataAdapter.Fill(dataTable);
            CloseConnection();
            sqlDataAdapter.Dispose();
            return dataTable;
        }
        public void ChangeData(string sql)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlCon;
            sqlCommand.CommandText = sql;
            sqlCommand.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
