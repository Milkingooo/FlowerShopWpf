﻿using FlowerShop.Model;
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
    /// Логика взаимодействия для AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        private Good isNew;
        public AddCustomerWindow(Good editGood)
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
            
            (DataContext as MainWindowViewModel).NewGood = editGood;

            isNew = editGood;

            if (isNew == null)
            {
                (DataContext as MainWindowViewModel).NewGood = new Good();
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (isNew == null)
            {
                var result = (DataContext as MainWindowViewModel).AddGood();

                if (result)
                {
                    MessageBox.Show("Запись сохранена!", "Управление товарами", MessageBoxButton.OK);
                    ((this.Owner as MainWindow).DataContext as MainWindowViewModel).LoadGood();
                    this.Close();
                }
            }
            else
            {
                var result = (DataContext as MainWindowViewModel).EditGood();

                if (result)
                {
                    MessageBox.Show("Запись сохранена!", "Управление товарами", MessageBoxButton.OK);
                    ((this.Owner as MainWindow).DataContext as MainWindowViewModel).LoadGood();
                    this.Close();
                }
            }
           
        }
    }
}
