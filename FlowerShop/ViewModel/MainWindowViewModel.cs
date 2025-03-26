using FlowerShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlowerShop.ViewModel
{
    public class MainWindowViewModel : BVM
    {
        private string _name;
        private string _phone;
        private string _email;
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        private Customer _newCustomer;

        public string Name
        {
            get => _name;
            set => SetPropertyChanged(ref _name, value, nameof(Name));
        }

        public string Phone
        {
            get => _phone;
            set => SetPropertyChanged(ref _phone, value, nameof(Phone));
        }

        public string Email
        {
            get => _email;
            set => SetPropertyChanged(ref _email, value, nameof(Email));
        }

        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => SetPropertyChanged(ref _customers, value, nameof(Customers));
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetPropertyChanged(ref _selectedCustomer, value, nameof(SelectedCustomer));
        }

        public Customer NewCustomer
        {
            get => _newCustomer;
            set => SetPropertyChanged(ref _newCustomer, value, nameof(NewCustomer));
        }

        public MainWindowViewModel()
        {
            Customers = new ObservableCollection<Customer>();
            NewCustomer = new Customer();
        }

        public void LoadCustomers()
        {
            Customers.Clear();
            using(var context = new FlowerShopEntities())
            {
                var temp = context.Customer.ToList();

                foreach (var customer in temp)
                {
                    Customers.Add(customer);
                }
            }
        }

        public void DeleteCustomer()
        {
            try
            {
                using(var context = new FlowerShopEntities())
                {
                    var findEntity = context.Customer.FirstOrDefault(s => s.Id == SelectedCustomer.Id);
                    if (findEntity == null) return;
                    var result = context.Customer.Remove(findEntity);
                    context.SaveChanges();

                    LoadCustomers();
                }
            }
            catch
            (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool AddCustomer()
        {
            using (var context = new FlowerShopEntities())
            {
                var newStudent = context.Customer.Add(NewCustomer);
                context.SaveChanges();
                return true;
            }
        }
    }
}
