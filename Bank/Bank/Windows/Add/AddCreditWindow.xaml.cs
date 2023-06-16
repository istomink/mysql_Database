using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Логика взаимодействия для AddManufactureWindow.xaml
    /// </summary>
    public partial class AddCreditWindow : Window
    {
        public event Action OnCloseWindow;

        public AddCreditWindow()
        {
            InitializeComponent();

            ClientBox.ItemsSource = BD.GetClients();
            EmployeeBox.ItemsSource = BD.GetEmployee().Where(i => i.Department.Id == 1).ToList();

            DateBox.ItemsSource = new int[] { 1,2,3,4,5,10,15,20,25,30 };
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            int sum = -1;
            int percent = -1;
            int date = -1;
            Client client = ClientBox.SelectedItem as Client;
            Employee employee = EmployeeBox.SelectedItem as Employee;

            if (!int.TryParse(SumBox.Text, out sum))
            {
                MessageBox.Show("Данные введены некорректно", "Сумма");
                return;
            }
            if (!int.TryParse(PercentBox.Text, out percent))
            {
                MessageBox.Show("Данные введены некорректно", "Процент");
                return;
            }
            if (!int.TryParse(DateBox.Text, out date))
            {
                MessageBox.Show("Данные введены некорректно", "Срок");
                return;
            }
            if(client == null)
            {
                MessageBox.Show("Заполните поле", "Клиент");
            }
            if (employee == null)
            {
                MessageBox.Show("Заполните поле", "Сотрудник");
            }

            int id = 0;
            List<Contract> contracts = BD.GetContract();
            if (contracts.Count == 0)
                id = 1;
            else
                id = contracts.Max(c => c.Id) + 1;

            DateTime Today = DateTime.Now;

            BD.Request($"INSERT Contract VALUE({id},'Дог. Кредит ({id}) - {client}','{Today.ToString("yyyy-MM-dd")}','{new DateTime(Today.Year+date,Today.Month,Today.Day).ToString("yyyy-MM-dd")}',{employee.Id}, {client.Id})");
            BD.Request($"INSERT Credit VALUE({id},{sum},{percent},{id})");
            BD.Request($"UPDATE Client SET SumAccount={client.SumAccount+sum} WHERE id={client.Id}");

            MessageBox.Show("Успешно сохранено", "Успешно");

            CloseWindow();
        }

        private void CloseWindow()
        {
            OnCloseWindow?.Invoke();
            this.Close();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
