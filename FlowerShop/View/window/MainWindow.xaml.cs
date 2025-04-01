using FlowerShop.Model;
using FlowerShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

            (DataContext as MainWindowViewModel).LoadTables();

            //(DataContext as MainWindowViewModel).LoadSupply();
            //(DataContext as MainWindowViewModel).LoadProvider();

        }

        private void getButton_Click(object sender, RoutedEventArgs e)
        {
            LoadGif.Visibility = Visibility.Visible;
            (DataContext as MainWindowViewModel).LoadTables();
            LoadGif.Visibility = Visibility.Collapsed;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {

            if (TabControl2.SelectedItem.ToString().Contains("Товар"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    (DataContext as MainWindowViewModel).DeleteGood();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Поставка"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    (DataContext as MainWindowViewModel).DeleteGood();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Поставщик"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    (DataContext as MainWindowViewModel).DeleteGood();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Заказ"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    (DataContext as MainWindowViewModel).DeleteGood();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Детали заказа"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    (DataContext as MainWindowViewModel).DeleteGood();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Клиент"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    (DataContext as MainWindowViewModel).DeleteGood();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Город"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    (DataContext as MainWindowViewModel).DeleteGood();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Категории"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    (DataContext as MainWindowViewModel).DeleteGood();
                }
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (TabControl2.SelectedItem.ToString().Contains("Товар"))
            {
                AddOrEditGoodWindow addCustomerWindow = new AddOrEditGoodWindow(null);
                addCustomerWindow.Owner = this;
                addCustomerWindow.ShowDialog();
            }
            if (TabControl2.SelectedItem.ToString().Contains("Поставка"))
            {
                AddorEditSupplyWindow addWindow = new AddorEditSupplyWindow(null);
                addWindow.Owner = this;
                addWindow.ShowDialog();
            }
            if (TabControl2.SelectedItem.ToString().Contains("Поставщик"))
            {
                AddOrEditProviderWindow addWindow = new AddOrEditProviderWindow(null);
                addWindow.Owner = this;
                addWindow.ShowDialog();
            }
            if (TabControl2.SelectedItem.ToString().Contains("Заказ"))
            {
                AddOrEditOrderWindow addWindow = new AddOrEditOrderWindow(null);
                addWindow.Owner = this;
                addWindow.ShowDialog();
            }
            if (TabControl2.SelectedItem.ToString().Contains("Детали заказа"))
            {
                AddOrEditOrderDetailsWindow addWindow = new AddOrEditOrderDetailsWindow(null);
                addWindow.Owner = this;
                addWindow.ShowDialog();
            }
            if (TabControl2.SelectedItem.ToString().Contains("Клиент"))
            {
                AddOrEditCustomerWindow addWindow = new AddOrEditCustomerWindow(null);
                addWindow.Owner = this;
                addWindow.ShowDialog();
            }
            if (TabControl2.SelectedItem.ToString().Contains("Город"))
            {
                AddOrEditCityWindow addWindow = new AddOrEditCityWindow(null);
                addWindow.Owner = this;
                addWindow.ShowDialog();
            }
            if (TabControl2.SelectedItem.ToString().Contains("Категории"))
            {
                AddOrEditCategoryWindow addWindow = new AddOrEditCategoryWindow(null);
                addWindow.Owner = this;
                addWindow.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (TabControl2.SelectedItem.ToString().Contains("Товар"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    AddOrEditGoodWindow addCustomerWindow = new AddOrEditGoodWindow((DataContext as MainWindowViewModel).SelectedObject);
                    addCustomerWindow.Owner = this;
                    addCustomerWindow.ShowDialog();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Поставка"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    AddorEditSupplyWindow addWindow = new AddorEditSupplyWindow((DataContext as MainWindowViewModel).SelectedObject);
                    addWindow.Owner = this;
                    addWindow.ShowDialog();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Поставщик"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    AddOrEditProviderWindow addWindow = new AddOrEditProviderWindow((DataContext as MainWindowViewModel).SelectedObject);
                    addWindow.Owner = this;
                    addWindow.ShowDialog();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Заказ"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    AddOrEditOrderWindow addWindow = new AddOrEditOrderWindow((DataContext as MainWindowViewModel).SelectedObject);
                    addWindow.Owner = this;
                    addWindow.ShowDialog();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Детали заказа"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    AddOrEditOrderDetailsWindow addWindow = new AddOrEditOrderDetailsWindow((DataContext as MainWindowViewModel).SelectedObject);
                    addWindow.Owner = this;
                    addWindow.ShowDialog();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Клиент"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    AddOrEditCustomerWindow addWindow = new AddOrEditCustomerWindow((DataContext as MainWindowViewModel).SelectedObject);
                    addWindow.Owner = this;
                    addWindow.ShowDialog();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Город"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    AddOrEditCityWindow addWindow = new AddOrEditCityWindow((DataContext as MainWindowViewModel).SelectedObject);
                    addWindow.Owner = this;
                    addWindow.ShowDialog();
                }
            }
            if (TabControl2.SelectedItem.ToString().Contains("Категории"))
            {
                if ((DataContext as MainWindowViewModel).SelectedObject != null)
                {
                    AddOrEditCategoryWindow addWindow = new AddOrEditCategoryWindow((DataContext as MainWindowViewModel).SelectedObject);
                    addWindow.Owner = this;
                    addWindow.ShowDialog();
                }
            }
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ФИО: Трушин Максим Владимирович \n Группа: ИС-32 \n Предмет: УП.03 \n Тема: Цветочный магазин", 
                "Справка", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
        }
    }
}
