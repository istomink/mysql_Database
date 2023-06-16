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

    public partial class EditOperationWindow : Window
    {
        public event Action OnCloseWindow;
        Operation Operation;

        public EditOperationWindow(Operation operation)
        {
            InitializeComponent();

            Operation = operation;
        }

        private void CloseWindow()
        {
            OnCloseWindow?.Invoke();
            this.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы подтверждаете согласие на удаление?", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
            BD.Request($"DELETE FROM Operation WHERE id={Operation.Id}");
            MessageBox.Show("Успешно удалено", "Успешно");

            CloseWindow();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow();
        }
    }
}
