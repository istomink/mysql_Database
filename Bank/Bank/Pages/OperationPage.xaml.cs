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
    /// Логика взаимодействия для ContractsForSalesPage.xaml
    /// </summary>
    public partial class OperationPage : Page
    {
        public OperationPage()
        {
            InitializeComponent();

            Table.ItemsSource = BD.GetOperation();
            TableController.SetOperation(Table);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOperationWindow window = new AddOperationWindow();
            window.OnCloseWindow += Window_OnCloseWindow;
            window.Show();
        }

        private void Window_OnCloseWindow()
        {
            Table.Columns.Clear();
            Table.ItemsSource = BD.GetOperation();
            TableController.SetOperation(Table);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            new SaveReport<Operation>(BD.GetOperation());
            MessageBox.Show("Успешно сохранено", "Успешно");

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Operation operation = Table.SelectedItem as Operation;

            if (operation == null)
            {
                MessageBox.Show("Нобходимо выбрать операцию", "Предупреждение");
                return;
            }

            EditOperationWindow window = new EditOperationWindow(operation);
            window.OnCloseWindow += Window_OnCloseWindow;
            window.Show();
        }
    }
}
