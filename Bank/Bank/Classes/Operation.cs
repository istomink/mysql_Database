using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Operation : TablesBD
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public Client Recipient_Client { get; set; }
        public DateTime Date { get; set; }
        public Client Sender_Client { get; set; }
        public Operation(int id, int sum, Client recipient_Client, DateTime date, Client sender_Client) 
        {
            Id = id;
            Sum = sum;
            Recipient_Client = recipient_Client;
            Sender_Client = sender_Client;
            Date = date;
        }

        public string GetTableName()
        {
            return "Транзакции";
        }

        public string GetHeadersName()
        {
            return $"{"Сумма",-20}{"Отправитель",-20}{"Счет Отправителя", -30}{"Получатель",-20}{"Счет Получателя",-30}{"Дата транзакции"}";
        }

        public string GetValues()
        {
            return $"{Sum,-20}{Sender_Client,-20}{Sender_Client.BankAccount,-30}{Recipient_Client,-20}{Recipient_Client.BankAccount,-30}{Date.ToString("yyyy-MM-dd HH:mm:ss")}";
        }
    }
}
