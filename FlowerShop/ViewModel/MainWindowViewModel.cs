using FlowerShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FlowerShop.ViewModel
{
    public class MainWindowViewModel : BVM
    {
        private ObservableCollection<Good> _goods;
        private ObservableCollection<Supply> _supplies;
        private ObservableCollection<Provider> _providers;
        private ObservableCollection<Orders> _orders;
        private ObservableCollection<OrderDetails> _orderDetails;
        private ObservableCollection<Customer> _customers;
        private ObservableCollection<City> _cities;
        private ObservableCollection<Category> _categories;

        private dynamic _selectedObject;
        private int _count;

        ////Good
        //private string _name;
        //private string _price;
        //private string _quantity;
        //private string _idCategory;
        private Good _selectedGood;
        private Good _newGood;

        //Supply
        //private string _idProvider;
        //private string _idGood;
        //private string _quantitySupply;
        //private DateTime _dateSupply;
        private Supply _selctedSupply;
        private Supply _newSupply;

        //Provider
        //private int _idCity;
        //private string _phone;
        //private string _email;
        private Provider _newProvider;
        private Provider _selectedProvider;

        //Orders
        //private int _idCustomer;
        //private int _totalPrice;
        //private DateTime _orderDate;
        private Orders _newOrder;
        private Orders _selectedOrder;

        //OrdersDetails
        //private int _idOrder;
        private OrderDetails _newOrderDetails;
        private OrderDetails _selectedOrderDetails;

        //Customer
        //private string _password;
        private Customer _selectedCustomer;
        private Customer _newCustomer;

        //City
        private City _newCity;
        private City _selectedCity;

        //Category
        private Category _newCategory;
        private Category _selectedCategory;

        public dynamic SelectedObject
        {
            get => _selectedObject;
            set => SetPropertyChanged(ref _selectedObject, value, nameof(SelectedObject));
        }

        public int Count
        {
            get => _count;
            set => SetPropertyChanged(ref _count, value, nameof(Count));
        }

        //good 1
        //public string Name
        //{
        //    get => _name;
        //    set => SetPropertyChanged(ref _name, value, nameof(Name));
        //}
        //public string Price
        //{
        //    get => _price;
        //    set => SetPropertyChanged(ref _price, value, nameof(Price));
        //}
        //public string Quantity
        //{
        //    get => _quantity;
        //    set => SetPropertyChanged(ref _quantity, value, nameof(Quantity));
        //}
        //public string Idcategory
        //{
        //    get => _idCategory;
        //    set => SetPropertyChanged(ref _idCategory, value, nameof(Idcategory));
        //}

        ////supply 2
        //public string IdProvider
        //{
        //    get => _idProvider;
        //    set => SetPropertyChanged(ref _idProvider, value, nameof(IdProvider));
        //}
        //public string IdGood
        //{
        //    get => _idGood;
        //    set => SetPropertyChanged(ref _idGood, value, nameof(IdGood));
        //}
        //public DateTime DateSupply
        //{
        //    get => _dateSupply;
        //    set => SetPropertyChanged(ref _dateSupply, value, nameof(DateSupply));
        //}

        ////Provider 3
        //public int IdCity
        //{
        //    get => _idCity;
        //    set => SetPropertyChanged(ref _idCity, value, nameof(IdCity));
        //}
        //public string Phone
        //{
        //    get => _phone;
        //    set => SetPropertyChanged(ref _phone, value, nameof(Phone));
        //}
        //public string Email
        //{
        //    get => _email;
        //    set => SetPropertyChanged(ref _email, value, nameof(Email));
        //}

        ////Order 4
        //public int IdCustomer
        //{
        //    get => _idCustomer;
        //    set => SetPropertyChanged(ref _idCustomer, value, nameof(IdCustomer));
        //}
        //public int TotalPrice
        //{
        //    get => _totalPrice;
        //    set => SetPropertyChanged(ref _totalPrice, value, nameof(TotalPrice));
        //}
        //public DateTime OrderDate
        //{
        //    get => _orderDate;
        //    set => SetPropertyChanged(ref _orderDate, value, nameof(OrderDate));
        //}

        ////OrdersDetails 5
        //public int IdOrder
        //{
        //    get => _idOrder;
        //    set => SetPropertyChanged(ref _idOrder, value, nameof(IdOrder));
        //}

        ////Customers 6
        //public string Password
        //{
        //    get => _password;
        //    set => SetPropertyChanged(ref _password, value, nameof(Password));
        //}

        //ObservableCollection
        public ObservableCollection<Good> Goods
        {
            get => _goods;
            set => SetPropertyChanged(ref _goods, value, nameof(Goods));
        }
        public ObservableCollection<Supply> Supplies
        {
            get => _supplies;
            set => SetPropertyChanged(ref _supplies, value, nameof(Supplies));
        }
        public ObservableCollection<Provider> Providers
        {
            get => _providers;
            set => SetPropertyChanged(ref _providers, value, nameof(Providers));
        }
        public ObservableCollection<Orders> Orders
        {
            get => _orders;
            set => SetPropertyChanged(ref _orders, value, nameof(Orders));
        }
        public ObservableCollection<OrderDetails> OrderDetails
        {
            get => _orderDetails;
            set => SetPropertyChanged(ref _orderDetails, value, nameof(OrderDetails));
        }
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set => SetPropertyChanged(ref _customers, value, nameof(Customers));
        }
        public ObservableCollection<City> Cities
        {
            get => _cities;
            set => SetPropertyChanged(ref _cities, value, nameof(Cities));
        }
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set => SetPropertyChanged(ref _categories, value, nameof(Categories));
        }

        //Selected
        public Good SelectedGood
        {
            get => _selectedGood;
            set => SetPropertyChanged(ref _selectedGood, value, nameof(SelectedGood));
        }
        public Supply SelectedSupply
        {
            get => _selctedSupply;
            set => SetPropertyChanged(ref _selctedSupply, value, nameof(SelectedSupply));
        }
        public Provider SelectedProvider
        {
            get => _selectedProvider;
            set => SetPropertyChanged(ref _selectedProvider, value, nameof(SelectedProvider));
        }
        public Orders SelectedOrder
        {
            get => _selectedOrder;
            set => SetPropertyChanged(ref _selectedOrder, value, nameof(SelectedOrder));
        }
        public OrderDetails SelectedOrderDetails
        {
            get => _selectedOrderDetails;
            set => SetPropertyChanged(ref _selectedOrderDetails, value, nameof(SelectedOrderDetails));
        }
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetPropertyChanged(ref _selectedCustomer, value, nameof(SelectedCustomer));
        }
        public City SelectedCity
        {
            get => _selectedCity;
            set => SetPropertyChanged(ref _selectedCity, value, nameof(SelectedCity));
        }
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set => SetPropertyChanged(ref _selectedCategory, value, nameof(SelectedCategory));
        }
        //New
        public Good NewGood
        {
            get => _newGood;
            set => SetPropertyChanged(ref _newGood, value, nameof(NewGood));
        }
        public Supply NewSupply
        {
            get => _newSupply;
            set => SetPropertyChanged(ref _newSupply, value, nameof(NewSupply));
        }
        public Provider NewProvider
        {
            get => _newProvider;
            set => SetPropertyChanged(ref _newProvider, value, nameof(NewProvider));
        }
        public Orders NewOrder
        {
            get => _newOrder;
            set => SetPropertyChanged(ref _newOrder, value, nameof(NewOrder));
        }
        public OrderDetails NewOrderDetails
        {
            get => _newOrderDetails;
            set => SetPropertyChanged(ref _newOrderDetails, value, nameof(NewOrderDetails));
        }
        public Customer NewCustomer
        {
            get => _newCustomer;
            set => SetPropertyChanged(ref _newCustomer, value, nameof(NewCustomer));
        }
        public City NewCity
        {
            get => _newCity;
            set => SetPropertyChanged(ref _newCity, value, nameof(NewCity));
        }
        public Category NewCategory
        {
            get => _newCategory;
            set => SetPropertyChanged(ref _newCategory, value, nameof(NewCategory));
        }

        //Other
        public MainWindowViewModel()
        {
            Goods = new ObservableCollection<Good>();
            Supplies = new ObservableCollection<Supply>();
            Providers = new ObservableCollection<Provider>();
            Orders = new ObservableCollection<Orders>();
            OrderDetails = new ObservableCollection<OrderDetails>();
            Customers = new ObservableCollection<Customer>();
            Cities = new ObservableCollection<City>();
            Categories = new ObservableCollection<Category>();

            NewGood = new Good();
            NewSupply = new Supply();
            NewProvider = new Provider();
            NewOrder = new Orders();
            NewOrderDetails = new OrderDetails();
            NewCustomer = new Customer();
            NewCity = new City();
            NewCategory = new Category();
        }
        public MainWindowViewModel(Good good)
        {
            Goods = new ObservableCollection<Good>();
            NewGood = good;
        }

        public async void LoadTables()
        {
            try
            {
                Goods.Clear();
                Providers.Clear();
                Supplies.Clear();
                Orders.Clear();
                OrderDetails.Clear();
                Customers.Clear();
                Cities.Clear();
                Categories.Clear();

                using (var context = new FlowerShopEntities())
                {
                    var temp = await context.Good.ToListAsync();
                    Count++;
                    var temp1 = await context.Provider.ToListAsync();
                    Count++;
                    var temp2 = await context.Supply.ToListAsync();
                    Count++;
                    var temp3 = await context.Orders.ToListAsync();
                    Count++;
                    var temp4 = await context.OrderDetails.ToListAsync();
                    Count++;
                    var temp5 = await context.Customer.ToListAsync();
                    Count++;
                    var temp6 = await context.City.ToListAsync();
                    Count++;
                    var temp7 = await context.Category.ToListAsync();
                    Count = 0;

                    foreach (var good in temp)
                    {
                        Goods.Add(good);
                    }

                    foreach (var prov in temp1)
                    {
                        Providers.Add(prov);
                    }

                    foreach (var sup in temp2)
                    {
                        Supplies.Add(sup);
                    }

                    foreach (var order in temp3)
                    {
                        Orders.Add(order);
                    }

                    foreach (var orderDet in temp4)
                    {
                        OrderDetails.Add(orderDet);
                    }

                    foreach (var cust in temp5)
                    {
                        Customers.Add(cust);
                    }

                    foreach (var city in temp6)
                    {
                        Cities.Add(city);
                    }

                    foreach (var cat in temp7)
                    {
                        Categories.Add(cat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных! Проверте подлкючение к БД.");
            }
        }

        //Delete
        public async void DeleteGood()
        {
            try
            {
                MessageBoxResult result1;
                result1 = MessageBox.Show("Вы действительно хотите удалить объект?", "Удаление объекта", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result1 == MessageBoxResult.OK)
                {
                    using (var context = new FlowerShopEntities())
                    {
                        if (SelectedObject is Good selGood)
                        {
                            var findEntity = await context.Good.FirstOrDefaultAsync(s => s.Id == selGood.Id);
                            if (findEntity == null) return;
                            var result = context.Good.Remove(findEntity);

                        }
                        else if (SelectedObject is Supply sup)
                        {
                            var findEntity = await context.Supply.FirstOrDefaultAsync(s => s.Id == sup.Id);
                            if (findEntity == null) return;
                            var result = context.Supply.Remove(findEntity);
                        }
                        else if (SelectedObject is Provider prov)
                        {
                            var findEntity = await context.Provider.FirstOrDefaultAsync(s => s.Id == prov.Id);
                            if (findEntity == null) return;
                            var result = context.Provider.Remove(findEntity);
                        }
                        else if (SelectedObject is Orders ord)
                        {
                            var findEntity = await context.Orders.FirstOrDefaultAsync(s => s.Id == ord.Id);
                            if (findEntity == null) return;
                            var result = context.Orders.Remove(findEntity);
                        }
                        else if (SelectedObject is OrderDetails ordDet)
                        {
                            var findEntity = await context.OrderDetails.FirstOrDefaultAsync(s => s.Id == ordDet.Id);
                            if (findEntity == null) return;
                            var result = context.OrderDetails.Remove(findEntity);
                        }
                        else if (SelectedObject is Customer cust)
                        {
                            var findEntity = await context.Customer.FirstOrDefaultAsync(s => s.Id == cust.Id);
                            if (findEntity == null) return;
                            var result = context.Customer.Remove(findEntity);
                        }
                        else if (SelectedObject is City city)
                        {
                            var findEntity = await context.City.FirstOrDefaultAsync(s => s.Id == city.Id);
                            if (findEntity == null) return;
                            var result = context.City.Remove(findEntity);
                        }
                        else if (SelectedObject is Category cat)
                        {
                            var findEntity = await context.Category.FirstOrDefaultAsync(s => s.Id == cat.Id);
                            if (findEntity == null) return;
                            var result = context.Category.Remove(findEntity);
                        }

                        context.SaveChanges();
                        LoadTables();
                    }
                }
            }
            catch
            (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Add
        public async Task<bool> AddOrEditGood()
        {
            try
            {
                using (var context = new FlowerShopEntities())
                {
                    var findEntity = await context.Good.FirstOrDefaultAsync(s => s.Id == NewGood.Id);
                    if (findEntity != null)
                    {
                        findEntity.Name = NewGood.Name;
                        findEntity.Price = NewGood.Price;
                        findEntity.Quantity = NewGood.Quantity;
                        findEntity.IdCategory = NewGood.IdCategory;
                    }
                    else
                    {
                        var newGood = context.Good.Add(NewGood);
                    }

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public async Task<bool> AddOrEditSupply()
        {
            try
            {
                using (var context = new FlowerShopEntities())
                {
                    var findEntity = await context.Supply.FirstOrDefaultAsync(s => s.Id == NewSupply.Id);
                    if (findEntity != null)
                    {
                        findEntity.IdProvider = NewSupply.IdProvider;
                        findEntity.IdGood = NewSupply.IdGood;
                        findEntity.DateSupply = NewSupply.DateSupply;
                    }
                    else
                    {
                        var newSupply = context.Supply.Add(NewSupply);
                    }

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public async Task<bool> AddOrEditProvider()
        {
            try
            {
                using (var context = new FlowerShopEntities())
                {
                    var findEntity = await context.Provider.FirstOrDefaultAsync(s => s.Id == NewProvider.Id);
                    if (findEntity != null)
                    {
                        findEntity.Name = NewProvider.Name;
                        findEntity.IdCity = NewProvider.IdCity;
                        findEntity.Phone = NewProvider.Phone;
                        findEntity.Email = NewProvider.Email;
                    }
                    else
                    {
                        var newProvider = context.Provider.Add(NewProvider);
                    }

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public async Task<bool> AddOrEditOrder()
        {
            try
            {
                using (var context = new FlowerShopEntities())
                {
                    var findEntity = await context.Orders.FirstOrDefaultAsync(s => s.Id == NewOrder.Id);
                    if (findEntity != null)
                    {
                        findEntity.IdCustomer = NewOrder.IdCustomer;
                        findEntity.TotalPrice = NewOrder.TotalPrice;
                        findEntity.OrderDate = NewOrder.OrderDate;
                    }
                    else
                    {
                        var newOrder = context.Orders.Add(NewOrder);
                    }

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public async Task<bool> AddOrEditOrderDetails()
        {
            try
            {
                using (var context = new FlowerShopEntities())
                {
                    var findEntity = await context.OrderDetails.FirstOrDefaultAsync(s => s.Id == NewOrderDetails.Id);
                    if (findEntity != null)
                    {
                        findEntity.IdOrder = NewOrderDetails.IdOrder;
                        findEntity.IdGood = NewOrderDetails.IdGood;
                        findEntity.Quantity = NewOrderDetails.Quantity;
                        findEntity.Price = NewOrderDetails.Price;
                    }
                    else
                    {
                        var newOrderDetail = context.OrderDetails.Add(NewOrderDetails);
                    }

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public async Task<bool> AddOrEditCustomer()
        {
            try
            {
                using (var context = new FlowerShopEntities())
                {
                    var findEntity = await context.Customer.FirstOrDefaultAsync(s => s.Id == NewCustomer.Id);
                    if (findEntity != null)
                    {
                        findEntity.Name = NewCustomer.Name;
                        findEntity.Phone = NewCustomer.Phone;
                        findEntity.Email = NewCustomer.Email;
                        findEntity.Password = NewCustomer.Password;
                    }
                    else
                    {
                        var newCustomer = context.Customer.Add(NewCustomer);
                    }

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public async Task<bool> AddOrEditCity()
        {
            try
            {
                using (var context = new FlowerShopEntities())
                {
                    var findEntity = await context.City.FirstOrDefaultAsync(s => s.Id == NewCity.Id);
                    if (findEntity != null)
                    {
                        findEntity.Name = NewCity.Name;
                    }
                    else
                    {
                        var newCity = context.City.Add(NewCity);
                    }

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public async Task<bool> AddOrEditCategory()
        {
            try
            {
                using (var context = new FlowerShopEntities())
                {
                    var findEntity = await context.Category.FirstOrDefaultAsync(s => s.Id == NewCategory.Id);
                    if (findEntity != null)
                    {
                        findEntity.Name = NewCategory.Name;
                    }
                    else
                    {
                        var newCategory = context.Category.Add(NewCategory);
                    }

                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

    }
}
