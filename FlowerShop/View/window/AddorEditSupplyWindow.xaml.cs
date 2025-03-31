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
        private Supply isNew;
        public AddorEditSupplyWindow(Supply editSupply)
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();

            (DataContext as MainWindowViewModel).NewSupply = editSupply;

            isNew = editSupply;

            if (isNew == null)
            {
                (DataContext as MainWindowViewModel).NewSupply = new Supply();
            }

        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == null)
            {
                var result = (DataContext as MainWindowViewModel).AddSupply();

                if (result)
                {
                    MessageBox.Show("Запись сохранена!", "Управление товарами", MessageBoxButton.OK);
                    ((this.Owner as MainWindow).DataContext as MainWindowViewModel).LoadSupply();
                    this.Close();
                }
            }
            else
            {
                var result = (DataContext as MainWindowViewModel).EditSupply();

                if (result)
                {
                    MessageBox.Show("Запись сохранена!", "Управление товарами", MessageBoxButton.OK);
                    ((this.Owner as MainWindow).DataContext as MainWindowViewModel).LoadSupply();
                    this.Close();
                }
            }
        }
    }
}
