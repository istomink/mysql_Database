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
    /// <summary>
    /// Логика взаимодействия для ProviderPage.xaml
    /// </summary>
    public partial class MortgagePage : Page
    {
        public MortgagePage()
        {
            InitializeComponent();

            Table.ItemsSource = BD.GetMortgage();
            TableController.SetMortgage(Table);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddMortgageWindow window = new AddMortgageWindow();
            window.OnCloseWindow += Window_OnCloseWindow;
            window.Show();
        }

        private void Window_OnCloseWindow()
        {
            Table.Columns.Clear();
            Table.ItemsSource = BD.GetMortgage();
            TableController.SetMortgage(Table);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Mortgage mortgage = Table.SelectedItem as Mortgage;

            if (mortgage == null)
            {
                MessageBox.Show("Нобходимо выбрать ипотеку", "Предупреждение");
                return;
            }

            new SaveReport<Mortgage>(new List<Mortgage>() { mortgage });
            MessageBox.Show("Успешно сохранено", "Успешно");

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Mortgage mortgage = Table.SelectedItem as Mortgage;

            if (mortgage == null)
            {
                MessageBox.Show("Нобходимо выбрать ипотеку", "Предупреждение");
                return;
            }

            EditMortgageWindow window = new EditMortgageWindow(mortgage);
            window.OnCloseWindow += Window_OnCloseWindow;
            window.Show();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            char[] symbols = new char[] { '+', '(', ')', '-', ' ' };

            List<Mortgage> mortgage = BD.GetMortgage().Where(c => c.Contract.Client.PhoneNumber.Filter(symbols) == SearchBox.Text.Filter(symbols)).ToList();

            if (mortgage.Count == 0)
            {
                MessageBox.Show("Ничего не найдено", "Поиск");
                Table.Columns.Clear();
                Table.ItemsSource = BD.GetMortgage();
                TableController.SetMortgage(Table);
                return;
            }


            Table.Columns.Clear();
            Table.ItemsSource = mortgage;
            TableController.SetMortgage(Table);
        }
    }
}
