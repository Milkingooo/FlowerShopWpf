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
    /// Логика взаимодействия для AddOrEditOrderWindow.xaml
    /// </summary>
    public partial class AddOrEditOrderWindow : Window
    {
        public AddOrEditOrderWindow(Orders order)
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

            if (order != null)
            {
                (DataContext as MainWindowViewModel).NewOrder = order;
            }
            else
            {
                DataContext = new MainWindowViewModel();
            }
        }
        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var result = await (DataContext as MainWindowViewModel).AddOrEditOrder();

            if (result)
            {
                MessageBox.Show("Запись сохранена!", "Управление заказами", MessageBoxButton.OK);
                ((this.Owner as MainWindow).DataContext as MainWindowViewModel).LoadTables();
                this.Close();
            }

        }
    }
}
