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
    public partial class ClientsPage : Page
    {
        public ClientsPage()
        {
            InitializeComponent();

            Table.ItemsSource = BD.GetClients();
            TableController.SetClient(Table);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow window = new AddClientWindow();
            window.OnCloseWindow += Window_OnCloseWindow;
            window.Show();
        }

        private void Window_OnCloseWindow()
        {
            Table.Columns.Clear();
            Table.ItemsSource = BD.GetClients();
            TableController.SetClient(Table);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            new SaveReport<Client>(BD.GetClients());
            MessageBox.Show("Успешно сохранено", "Успешно");

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Client client = Table.SelectedItem as Client;

            if (client == null)
            {
                MessageBox.Show("Нобходимо выбрать клиента", "Предупреждение");
                return;
            }

            EditClientWindow window = new EditClientWindow(client);
            window.OnCloseWindow += Window_OnCloseWindow;
            window.Show();
        }
    }
}
