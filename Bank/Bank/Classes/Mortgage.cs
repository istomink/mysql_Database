using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Mortgage : TablesBD
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public int Percent { get; set; }
        public Contract Contract { get; set; }

        public Mortgage(int id, int sum, int percent, Contract contract)
        {
            Id = id;
            Sum = sum;
            Percent = percent;
            Contract = contract;
        }

        public string GetTableName()
        {
            return $"{Contract.Info}" + "\n" + $"Сумма - {Sum}, Процент - {Percent}\nИтого - {Sum + Sum * Percent / 100}";
        }

        public string GetHeadersName()
        {
            return $"{"Дата",-20}{"Сумма"}";
        }

        public string GetValues()
        {
            int SumP = Sum + (Sum * Percent / 100);
            int period = Contract.GetPeriod() * 12;
            int PaymentMonth = SumP / period;

            DateTime startDate = Contract.StartDate;
            string Print = "";
            for (int i = 0; i < period; i++)
            {
                Print += $"{startDate.ToShortDateString(),-20}{PaymentMonth}" + "\n";

                if (startDate.Month == 12)
                {
                    startDate = new DateTime(startDate.Year + 1, 1, startDate.Day);
                }
                else
                {
                    startDate = new DateTime(startDate.Year, startDate.Month + 1, startDate.Day);
                }
            }

            return Print;
        }
    }
}
