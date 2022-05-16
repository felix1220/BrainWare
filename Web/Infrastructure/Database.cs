using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure
{
    using System.Data.Common;
    using System.Data.SqlClient;

    public class Database
    {
        private readonly SqlConnection _connection;

        public Database()
        {
            // var connectionString = "Data Source=LOCALHOST;Initial Catalog=BrainWare;Integrated Security=SSPI";
            //var mdf = @"C:\Brainshark\interview\BrainWare\Web\App_Data\BrainWare.mdf";
            var connectionString = $"Data Source=LT-3KKNXF2\\MSSQLSERVER01;Initial Catalog=BrainWAre;Integrated Security=SSPI;";

            _connection = new SqlConnection(connectionString);

            _connection.Open();
        }

        public DbDataReader ExecuteReader(string query)
        {
           

            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteReader();
        }

        public int ExecuteNonQuery(string query)
        {
            var sqlQuery = new SqlCommand(query, _connection);

            return sqlQuery.ExecuteNonQuery();
        }

        public void CLoseConnection()
        {
            _connection.Close();
        }


    }
}