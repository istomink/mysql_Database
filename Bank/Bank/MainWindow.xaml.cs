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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PageController.AddPage(MainPage);
            PageController.OnChangedPage += PageController_OnChangedPage;

        }

        private void PageController_OnChangedPage(Page page)
        {
            this.Content = page;
        }

        private void ClientBtn_Click(object sender, RoutedEventArgs e)
        {
            PageController.AddPage(new ClientsPage());
        }

        private void EmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            PageController.AddPage(new EmployeePage());
        }

        private void CreditBtn_Click(object sender, RoutedEventArgs e)
        {
            PageController.AddPage(new CreditPage());
        }

        private void MortgageBtn_Click(object sender, RoutedEventArgs e)
        {
            PageController.AddPage(new MortgagePage());
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            PageController.AddPage(new OperationPage());
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
