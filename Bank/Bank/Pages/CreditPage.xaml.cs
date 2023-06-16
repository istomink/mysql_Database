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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bank
{

    public partial class CreditPage : Page
    {
        public CreditPage()
        {
            InitializeComponent();

            Table.ItemsSource = BD.GetCredit();
            TableController.SetCredit(Table);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCreditWindow window = new AddCreditWindow();
            window.OnCloseWindow += Window_OnCloseWindow;
            window.Show();
        }

        private void Window_OnCloseWindow()
        {
            Table.Columns.Clear();
            Table.ItemsSource = BD.GetCredit();
            TableController.SetCredit(Table);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Credit c = Table.SelectedItem as Credit;

            if (c == null)
            {
                MessageBox.Show("Нобходимо выбрать кредит", "Предупреждение");
                return;
            }

            new SaveReport<Credit>(new List<Credit>() { c });
            MessageBox.Show("Успешно сохранено", "Успешно");

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Credit c = Table.SelectedItem as Credit;

            if (c == null)
            {
                MessageBox.Show("Нобходимо выбрать кредит", "Предупреждение");
                return;
            }

            EditCreditWindow window = new EditCreditWindow(c);
            window.OnCloseWindow += Window_OnCloseWindow1;
            window.Show();
        }

        private void Window_OnCloseWindow1()
        {
            Table.Columns.Clear();
            Table.ItemsSource = BD.GetCredit();
            TableController.SetCredit(Table);
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            char[] symbols = new char[] { '+', '(', ')', '-', ' '};

            List<Credit> credits = BD.GetCredit().Where(c => c.Contract.Client.PhoneNumber.Filter(symbols) == SearchBox.Text.Filter(symbols)).ToList();

            if(credits.Count == 0)
            {
                MessageBox.Show("Ничего не найдено", "Поиск");
                Table.Columns.Clear();
                Table.ItemsSource = BD.GetCredit();
                TableController.SetCredit(Table);
                return;
            }
            

            Table.Columns.Clear();
            Table.ItemsSource = credits;
            TableController.SetCredit(Table);
        }
    }
}
