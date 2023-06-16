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
    /// Логика взаимодействия для EditManufactureWindow.xaml
    /// </summary>
    public partial class EditCreditWindow : Window
    {
        public event Action OnCloseWindow;
        Credit Credit;

        public EditCreditWindow(Credit credit)
        {
            InitializeComponent();

            Credit = credit;
            SumBox.Text = credit.Sum.ToString();
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
            
            BD.Request($"UPDATE Credit SET Sum={sum} WHERE id={Credit.Id}");

            MessageBox.Show("Успешно сохранено", "Успешно");

            CloseWindow();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете согласие на удаление?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
            BD.Request($"DELETE FROM Credit WHERE id={Credit.Id}");
            BD.Request($"DELETE FROM Contract WHERE id={Credit.Id}");
            MessageBox.Show("Успешно удалено", "Успешно");

            CloseWindow();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
