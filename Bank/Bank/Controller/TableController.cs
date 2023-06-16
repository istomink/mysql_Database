using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Bank
{
    public class ColumnController
    {
        public object Header { get; set; }
        public string Property { get; set; }

        public ColumnController(object header, string property) 
        {
            Header = header;
            Property = property;
        }
    }

    public static class TableController
    {
        public static void SetColumns(DataGrid table, params ColumnController[] NameColumns)
        {
            table.AutoGenerateColumns = false;
            for (int i = 0; i < NameColumns.Length; i++)
            {
                table.Columns.Add(new DataGridTextColumn() { Header = NameColumns[i].Header, Binding = new Binding(NameColumns[i].Property) });
            }
        }

        public static void SetClient(DataGrid table)
        {
            SetColumns(table, new ColumnController("Фамилия", "LastName"),
                new ColumnController("Имя", "FirstName"),
                new ColumnController("Отчество", "Patronymic"),
                new ColumnController("Номер телефона", "PhoneNumber"),
                new ColumnController("Банковский счет", "BankAccount"),
                new ColumnController("Сумма на счету", "SumAccount"),
                new ColumnController("Адрес", "Address"));
        }

        public static void SetEmployee(DataGrid table)
        {
            SetColumns(table, new ColumnController("Фамилия", "LastName"),
                new ColumnController("Имя", "FirstName"),
                new ColumnController("Отчество", "Patronymic"),
                new ColumnController("Отдел", "Department"));
        }

        public static void SetCredit(DataGrid table)
        {
            SetColumns(table, new ColumnController("Клиент", "Contract.Client"),
                new ColumnController("Банковский счет", "Contract.Client.BankAccount"),
                new ColumnController("Сумма", "Sum"),
                new ColumnController("Процент", "Percent"),
                new ColumnController("Дата заключения", "Contract.GetStartDate"),
                new ColumnController("Дата окончания", "Contract.GetEndDate"));
        }

        public static void SetMortgage(DataGrid table)
        {
            SetColumns(table, new ColumnController("Клиент", "Contract.Client"),
                new ColumnController("Банковский счет", "Contract.Client.BankAccount"),
                new ColumnController("Сумма", "Sum"),
                new ColumnController("Процент", "Percent"),
                new ColumnController("Дата заключения", "Contract.GetStartDate"),
                new ColumnController("Дата окончания", "Contract.GetEndDate"));
        }

        public static void SetContract(DataGrid table)
        {
            SetColumns(table, new ColumnController("Информация", "Info"),
                new ColumnController("Клиент", "Client"),
                new ColumnController("Сотрудник", "Employee"),
                new ColumnController("Дата заключения", "GetStartDate"),
                new ColumnController("Дата окончания", "GetEndDate"));
        }

        public static void SetOperation(DataGrid table)
        {
            SetColumns(table, new ColumnController("Сумма", "Sum"),
                new ColumnController("Отправитель", "Sender_Client"),
                new ColumnController("Получатель", "Recipient_Client"),
                new ColumnController("Счет Отправителя", "Sender_Client.BankAccount"),
                new ColumnController("Счет Получателя", "Recipient_Client.BankAccount"),
                new ColumnController("Дата", "Date"));
        }
    }
}
