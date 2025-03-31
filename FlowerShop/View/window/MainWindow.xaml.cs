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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var customCursor = new Cursor("D:\\Ам Ням\\FlowerShop\\FlowerShop\\Assets\\Cursors\\flower.cur");
            Mouse.OverrideCursor = customCursor;
           
            DataContext = new MainWindowViewModel();

            (DataContext as MainWindowViewModel).LoadGood();
            (DataContext as MainWindowViewModel).LoadSupply();
        }

        private void getButton_Click(object sender, RoutedEventArgs e)
        {

            if (TabControl.SelectedItem.ToString().Contains("Товар"))
            {
                (DataContext as MainWindowViewModel).LoadGood();
            }

            if (TabControl.SelectedItem.ToString().Contains("Поставка"))
            {
                (DataContext as MainWindowViewModel).LoadSupply();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

            if (TabControl.SelectedItem.ToString().Contains("Товар"))
            {
                if ((DataContext as MainWindowViewModel).SelectedGood != null)
                {
                    (DataContext as MainWindowViewModel).DeleteGood();
                }
            }
            if (TabControl.SelectedItem.ToString().Contains("Поставка"))
            {
                if ((DataContext as MainWindowViewModel).SelectedSupply != null)
                {
                    (DataContext as MainWindowViewModel).DeleteSupply();
                }
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (TabControl.SelectedItem.ToString().Contains("Товар"))
            {
                AddCustomerWindow addCustomerWindow = new AddCustomerWindow(null);
                addCustomerWindow.Owner = this;
                addCustomerWindow.ShowDialog();
            }
            if (TabControl.SelectedItem.ToString().Contains("Поставка"))
            {
                AddorEditSupplyWindow addWindow = new AddorEditSupplyWindow(null);
                addWindow.Owner = this;
                addWindow.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (TabControl.SelectedItem.ToString().Contains("Товар"))
            {
                if ((DataContext as MainWindowViewModel).SelectedGood != null)
                {
                    AddCustomerWindow addCustomerWindow = new AddCustomerWindow((DataContext as MainWindowViewModel).SelectedGood);
                    addCustomerWindow.Owner = this;
                    addCustomerWindow.ShowDialog();
                }
            }
            if (TabControl.SelectedItem.ToString().Contains("Поставка"))
            {
                if ((DataContext as MainWindowViewModel).SelectedSupply != null)
                {
                    AddorEditSupplyWindow addWindow = new AddorEditSupplyWindow((DataContext as MainWindowViewModel).SelectedSupply);
                    addWindow.Owner = this;
                    addWindow.ShowDialog();
                }
            }
        }
    }
}
