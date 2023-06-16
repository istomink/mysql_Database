using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Contract
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Client Client { get; set; }
        public Employee Employee { get; set; }

        public string GetStartDate => StartDate.ToString("yyyy-MM-dd");
        public string GetEndDate => EndDate.ToString("yyyy-MM-dd");

        public Contract(int id, string info, DateTime startDate, DateTime endDate, Client client, Employee employee) 
        {
            Id = id;
            Info = info;
            StartDate = startDate;
            EndDate = endDate;
            Client = client;
            Employee = employee;
        }

        public int GetPeriod()
        {
            return EndDate.Year - StartDate.Year;
        }

        public override string ToString()
        {
            return Info;
        }
    }
}
