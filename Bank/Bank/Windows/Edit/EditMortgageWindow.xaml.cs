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
    /// Логика взаимодействия для EditContractsForSalesWindow.xaml
    /// </summary>
    public partial class EditMortgageWindow : Window
    {
        public event Action OnCloseWindow;
        Mortgage Mortgage;

        public EditMortgageWindow(Mortgage mortgage)
        {
            InitializeComponent();

            Mortgage = mortgage;
            SumBox.Text = mortgage.Sum.ToString();
        }

        private void CloseWindow()
        {
            OnCloseWindow?.Invoke();
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            int sum = -1;


            if (!int.TryParse(SumBox.Text, out sum))
            {
                MessageBox.Show("Данные введены некорректно", "Сума");
                return;
            }

            BD.Request($"UPDATE Mortgage SET Sum={sum} WHERE id={Mortgage.Id}");

            MessageBox.Show("Успешно сохранено", "Успешно");

            CloseWindow();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете согласие на удаление?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
            BD.Request($"DELETE FROM Mortgage WHERE id={Mortgage.Id}");
            BD.Request($"DELETE FROM Contract WHERE id={Mortgage.Id}");
            MessageBox.Show("Успешно удалено", "Успешно");

            CloseWindow();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
