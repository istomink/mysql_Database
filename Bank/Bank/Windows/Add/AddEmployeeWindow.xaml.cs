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
    /// Логика взаимодействия для AddSellerWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public event Action OnCloseWindow;

        public AddEmployeeWindow()
        {
            InitializeComponent();

            DepartmentBox.ItemsSource = BD.GetDepartment();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string lastName = LastNameBox.Text;
            string firstName = FirstNameBox.Text;
            string patronymic = PatronymicBox.Text;
            Department department = DepartmentBox.SelectedItem as Department;

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
            if (department == null)
            {
                MessageBox.Show("Заполните поле", "Отдел");
                return;
            }

            int id = 0;
            List<Employee> employees = BD.GetEmployee();
            if (employees.Count == 0)
                id = 1;
            else
                id = employees.Max(c => c.Id) + 1;

            BD.Request($"INSERT Employee VALUE({id},'{lastName}','{firstName}','{patronymic}', {department.Id})");

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
