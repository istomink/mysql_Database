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
    /// Логика взаимодействия для EditSellerWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public event Action OnCloseWindow;
        Employee Employee;
        public EditEmployeeWindow(Employee employee)
        {
            InitializeComponent();

            Employee = employee;
            LastNameBox.Text = employee.LastName;
            FirstNameBox.Text = employee.FirstName;
            PatronymicBox.Text = employee.Patronymic;
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

            BD.Request($"UPDATE Employee SET LastName='{lastName}', FirstName='{firstName}', Patronymic='{patronymic}' WHERE id={Employee.Id}");

            MessageBox.Show("Успешно сохранено", "Успешно");

            CloseWindow();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете согласие на удаление?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
            BD.Request($"DELETE FROM Employee WHERE id={Employee.Id}");
            MessageBox.Show("Успешно удалено", "Успешно");

            CloseWindow();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
