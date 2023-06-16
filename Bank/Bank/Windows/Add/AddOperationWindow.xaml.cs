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
    /// Логика взаимодействия для AddOrderClientWindow.xaml
    /// </summary>
    public partial class AddOperationWindow : Window
    {
        public event Action OnCloseWindow;

        public AddOperationWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            int sum = -1;
            string senderAccount = SenderAccountBox.Text;
            string account = AccountBox.Text;

            if (!int.TryParse(SumBox.Text, out sum))
            {
                MessageBox.Show("Данные введены некорректно", "Сумма");
                return;
            }
            if (senderAccount.Count() != 20)
            {
                MessageBox.Show("Счет не может быть короче или длиннее 20 символов", "Номер счета отправителя");
                return;
            }
            if (account.Count() != 20)
            {
                MessageBox.Show("Счет не может быть короче или длиннее 20 символов", "Номер счета получателя");
                return;
            }

            List<Client> clients = BD.GetClients();

            if(clients.Where(c => c.BankAccount == senderAccount).ToList().Count == 0)
            {
                MessageBox.Show($"Клиент с счетом {senderAccount} не найден", "Предупреждение");
                return;
            }
            if (clients.Where(c => c.BankAccount == account).ToList().Count == 0)
            {
                MessageBox.Show($"Клиент с счетом {account} не найден", "Предупреждение");
                return;
            }

            Client senderClient = clients.Where(c => c.BankAccount == senderAccount).ToList()[0];
            Client client = clients.Where(c => c.BankAccount == account).ToList()[0];

            if(senderClient.SumAccount < sum)
            {
                MessageBox.Show($"Сумма на счету меньше {sum}", "Ошибка!");
                return;
            }

            int id = 0;
            List<Operation> operations = BD.GetOperation();
            if (operations.Count == 0)
                id = 1;
            else
                id = operations.Max(c => c.Id) + 1;

            BD.Request($"INSERT Operation VALUE({id},{sum},{client.Id},'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', {senderClient.Id})");
            BD.Request($"UPDATE Client SET SumAccount={senderClient.SumAccount-sum} WHERE id={senderClient.Id}");
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
