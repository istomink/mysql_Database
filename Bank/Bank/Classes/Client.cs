using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Client : TablesBD
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string BankAccount { get; set; }
        public int SumAccount { get; set; }

        public Client(int id, string lastName, string firstName, string patronymic, string phoneNumber, string address, string bankAccount, int sumAccount)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            Address = address;
            BankAccount = bankAccount;
            SumAccount = sumAccount;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName[0] + ". " + Patronymic[0] + ".";
        }

        public string GetTableName()
        {
            return "Клиенты";
        }

        public string GetHeadersName()
        {
            return $"{"Фамилия", -20}{"Имя",-20}{"Отчество",-20}{"Номер телефона",-20}{"Банк. счет",-30}{"Сумма", -15}{"Адрес",-20}";
        }

        public string GetValues()
        {
            return $"{LastName,-20}{FirstName,-20}{Patronymic,-20}{PhoneNumber,-20}{BankAccount,-30}{SumAccount,-15}{Address,-20}";
        }
    }
}
