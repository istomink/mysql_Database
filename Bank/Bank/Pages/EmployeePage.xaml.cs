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
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();

            Table.ItemsSource = BD.GetEmployee();
            TableController.SetEmployee(Table);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow window = new AddEmployeeWindow();
            window.OnCloseWindow += Window_OnCloseWindow;
            window.Show();
        }

        private void Window_OnCloseWindow()
        {
            Table.Columns.Clear();
            Table.ItemsSource = BD.GetEmployee();
            TableController.SetEmployee(Table);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            new SaveReport<Employee>(BD.GetEmployee());
            MessageBox.Show("Успешно сохранено", "Успешно");

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = Table.SelectedItem as Employee;

            if (employee == null)
            {
                MessageBox.Show("Нобходимо выбрать сотрудника", "Предупреждение");
                return;
            }

            EditEmployeeWindow window = new EditEmployeeWindow(employee);
            window.OnCloseWindow += Window_OnCloseWindow;
            window.Show();
        }
    }
}
