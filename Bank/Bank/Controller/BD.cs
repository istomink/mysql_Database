using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public static class BD
    {
        public static List<Client> GetClients()
        {
            MySQLController sQLController = new MySQLController();

            string command = $"SELECT * FROM Client";

            MySqlDataReader reader = sQLController.SELECT(command);

            List<Client> list = new List<Client>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string lastName = reader.GetString(1);
                string firstName = reader.GetString(2);
                string patronymic = reader.GetString(3);
                string phoneNumber = reader.GetString(4);
                string address = reader.GetString(5);
                string bankAccount = reader.GetString(6);
                int sumAccount = reader.GetInt32(7);

                list.Add(new Client(id, lastName, firstName, patronymic, phoneNumber, address, bankAccount, sumAccount));
            }
            sQLController.Close();

            return list;
        }

        public static List<Employee> GetEmployee()
        {
            MySQLController sQLController = new MySQLController();

            string command = $"SELECT * FROM Employee";

            MySqlDataReader reader = sQLController.SELECT(command);

            List<Employee> list = new List<Employee>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string lastName = reader.GetString(2);
                string firstName = reader.GetString(1);
                string patronymic = reader.GetString(3);
                int idD = reader.GetInt32(4);
                Department department = BD.GetDepartment().Where(d => d.Id == idD).ToList()[0];

                list.Add(new Employee(id, lastName, firstName, patronymic, department));
            }
            sQLController.Close();

            return list;
        }

        public static List<Contract> GetContract()
        {
            MySQLController sQLController = new MySQLController();

            string command = $"SELECT * FROM Contract";

            MySqlDataReader reader = sQLController.SELECT(command);

            List<Contract> list = new List<Contract>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string info = reader.GetString(1);
                DateTime startDate = reader.GetDateTime(2);
                DateTime endDate = reader.GetDateTime(3);
                int idEmployee = reader.GetInt32(4);
                int idCleint = reader.GetInt32(5);

                Client client = GetClients().Where(c => c.Id == idCleint).ToList()[0];
                Employee employee = GetEmployee().Where(c => c.Id == idEmployee).ToList()[0];

                list.Add(new Contract(id, info, startDate, endDate, client, employee));
            }
            sQLController.Close();

            return list;
        }

        public static List<Credit> GetCredit()
        {
            MySQLController sQLController = new MySQLController();

            string command = $"SELECT * FROM Credit";

            MySqlDataReader reader = sQLController.SELECT(command);

            List<Credit> list = new List<Credit>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int sum = reader.GetInt32(1);
                int precent = reader.GetInt32(2);
                int idContract = reader.GetInt32(3);

                Contract contract = GetContract().Where(c => c.Id == idContract).ToList()[0];

                list.Add(new Credit(id, sum, precent, contract));
            }
            sQLController.Close();

            return list;
        }

        public static List<Mortgage> GetMortgage()
        {
            MySQLController sQLController = new MySQLController();

            string command = $"SELECT * FROM Mortgage";

            MySqlDataReader reader = sQLController.SELECT(command);

            List<Mortgage> list = new List<Mortgage>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int sum = reader.GetInt32(1);
                int precent = reader.GetInt32(2);
                int idContract = reader.GetInt32(3);

                Contract contract = GetContract().Where(c => c.Id == idContract).ToList()[0];

                list.Add(new Mortgage(id, sum, precent, contract));
            }
            sQLController.Close();

            return list;
        }

        public static List<Department> GetDepartment()
        {
            MySQLController sQLController = new MySQLController();

            string command = $"SELECT * FROM Department";

            MySqlDataReader reader = sQLController.SELECT(command);

            List<Department> list = new List<Department>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);

                list.Add(new Department(id, name));
            }
            sQLController.Close();
            return list;
        }

        public static List<Operation> GetOperation()
        {
            MySQLController sQLController = new MySQLController();

            string command = $"SELECT * FROM Operation";

            MySqlDataReader reader = sQLController.SELECT(command);

            List<Operation> list = new List<Operation>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                int sum = reader.GetInt32(1);
                int Recipient_ClientID = reader.GetInt32(2);
                DateTime date = reader.GetDateTime(3);
                int ClientID = reader.GetInt32(4);

                Client recipient_Client = GetClients().Where(c => c.Id == Recipient_ClientID).ToList()[0];
                Client client = GetClients().Where(c => c.Id == ClientID).ToList()[0];

                list.Add(new Operation(id, sum, recipient_Client, date, client));
            }
            sQLController.Close();

            return list;
        }

        public static void Request(string command)
        {
            MySQLController sQLController = new MySQLController();

            sQLController.Request(command);
        }
    }
}
