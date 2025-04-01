using FlowerShop.Model;
using FlowerShop.ViewModel;
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

namespace FlowerShop.View.window
{
    /// <summary>
    /// Логика взаимодействия для AddOrEditOrderDetailsWindow.xaml
    /// </summary>
    public partial class AddOrEditOrderDetailsWindow : Window
    {
        public AddOrEditOrderDetailsWindow(OrderDetails ordDet)
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            if (ordDet != null)
            {
                (DataContext as MainWindowViewModel).NewOrderDetails = ordDet;
            }
            else
            {
                DataContext = new MainWindowViewModel();
            }
        }
        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var result = await (DataContext as MainWindowViewModel).AddOrEditOrderDetails();

            if (result)
            {
                MessageBox.Show("Запись сохранена!", "Управление деталями заказа", MessageBoxButton.OK);
                ((this.Owner as MainWindow).DataContext as MainWindowViewModel).LoadTables();
                this.Close();
            }

        }
    }
}
