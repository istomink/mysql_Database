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
    /// Логика взаимодействия для EditClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        public event Action OnCloseWindow;
        Client Client;

        public EditClientWindow(Client client)
        {
            InitializeComponent();

            Client = client;
            LastNameBox.Text = client.LastName;
            FirstNameBox.Text = client.FirstName;
            PatronymicBox.Text = client.Patronymic;
            PhoneBox.Text = client.PhoneNumber;
            AddressBox.Text = client.Address;
            BankAccountBox.Text = client.BankAccount;
            SumAccountBox.Text = client.SumAccount.ToString();
        }

        private void CloseWindow()
        {
            OnCloseWindow?.Invoke();
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string lastName = LastNameBox.Text;
            string firstName = FirstNameBox.Text;
            string patronymic = PatronymicBox.Text;
            string bankAccount = BankAccountBox.Text;
            string phone = PhoneBox.Text;
            string address = AddressBox.Text;
            int sum = -1;

            if (lastName == "")
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
            if(!int.TryParse(SumAccountBox.Text, out sum))
            {
                MessageBox.Show("Данные введены некорректно", "Сумма");
                return;
            }

            BD.Request($"UPDATE Client SET LastName='{lastName}', FirstName='{firstName}', Patronymic='{patronymic}', PhoneNumber='{phone}', Address='{address}', BankAccount='{bankAccount}', SumAccount={sum} WHERE id={Client.Id}");

            MessageBox.Show("Успешно сохранено", "Успешно");

            CloseWindow();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете согласие на удаление?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
            BD.Request($"DELETE FROM Client WHERE id={Client.Id}");

            MessageBox.Show("Успешно удалено", "Успешно");

            CloseWindow();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
