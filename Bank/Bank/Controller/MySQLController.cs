using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Bank
{
    public class MySQLController
    {
        private MySqlConnection sqlConnection;
        private MySqlCommand sqlCommand;
        private string Connect = "host=localhost;port=3306;user=root;password=Gor140403;database=BankBD";

        public MySQLController()
        {
            sqlConnection = new MySqlConnection(Connect);
            sqlCommand = sqlConnection.CreateCommand();
        }

        public MySqlDataReader SELECT(string command)
        {
            Open();
            sqlCommand.CommandText = command;
            return sqlCommand.ExecuteReader();
        }

        public void Request(string command)
        {
            Open();
            sqlCommand.CommandText = command;
            sqlCommand.ExecuteNonQuery();
            Close();
        }

        public void Open()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void Close() 
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }
    }
}
