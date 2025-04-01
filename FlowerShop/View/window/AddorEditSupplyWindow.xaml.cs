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
    /// Логика взаимодействия для AddorEditSupplyWindow.xaml
    /// </summary>
    public partial class AddorEditSupplyWindow : Window
    {
        public AddorEditSupplyWindow(Supply editSupply)
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

            if (editSupply != null)
            {
                (DataContext as MainWindowViewModel).NewSupply = editSupply;
            }
            else
            {
                DataContext = new MainWindowViewModel();
                (DataContext as MainWindowViewModel).NewSupply.DateSupply = DateTime.Now;
            }

        }

        private async void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbIdP.Text) && !string.IsNullOrEmpty(tbIdG.Text) && !string.IsNullOrEmpty(quant.Text) && datePick.SelectedDate != null)
            {
                var result = await (DataContext as MainWindowViewModel).AddOrEditSupply();

                if (result)
                {
                    MessageBox.Show("Запись сохранена!", "Управление товарами", MessageBoxButton.OK);
                    ((this.Owner as MainWindow).DataContext as MainWindowViewModel).LoadTables();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
