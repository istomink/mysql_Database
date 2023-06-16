using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Employee : TablesBD
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public Department Department { get; set; }
        public Employee(int id, string lastName, string firstName, string patronymic, Department department)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
            Department = department;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName[0] + ". " + Patronymic[0] + ".";
        }

        public string GetTableName()
        {
            return "Сотрудники";
        }

        public string GetHeadersName()
        {
            return $"{"Фамилия",-20}{"Имя",-20}{"Отчество",-20}{"Отдел"}";
        }

        public string GetValues()
        {
            return $"{LastName,-20}{FirstName,-20}{Patronymic,-20}{Department}";
        }
    }
}
