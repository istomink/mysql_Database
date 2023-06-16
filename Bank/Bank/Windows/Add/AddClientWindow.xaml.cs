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
    /// Логика взаимодействия для ClientAddWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public event Action OnCloseWindow;
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string lastName = LastNameBox.Text;
            string firstName = FirstNameBox.Text;
            string patronymic = PatronymicBox.Text;
            string bankAccount = BankAccountBox.Text;
            string phone = PhoneBox.Text;
            string address = AddressBox.Text;

            if(lastName == "")
            {
                MessageBox.Show("Заполните поле", "Фамилия");
                return;
            }
            if (firstName == "")
            {
                MessageBox.Show("Заполните поле", "Имя");
                return;
            }
            if (bankAccount.Count() != 20)
            {
                MessageBox.Show("Счет не может быть короче или длиннее 20 символов", "Банк. счет");
                return;
            }
            if (phone.Count() < 8 || phone.Count() > 16)
            {
                MessageBox.Show("Номер телефона не может быть короче 8 или длиннее 16 символов", "Номер телефона");
                return;
            }
            if (address == "")
            {
                MessageBox.Show("Заполните поле", "Адрес");
                return;
            }

            int id = 0;
            List<Client> clients = BD.GetClients();
            if (clients.Count == 0)
                id = 1;
            else
                id = clients.Max(c => c.Id) + 1;

            BD.Request($"INSERT Client VALUE({id},'{lastName}','{firstName}','{patronymic}','{phone}','{address}','{bankAccount}', {0})");

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
