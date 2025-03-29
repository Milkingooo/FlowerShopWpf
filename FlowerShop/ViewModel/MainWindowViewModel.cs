using FlowerShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlowerShop.ViewModel
{
    public class MainWindowViewModel : BVM
    {
        private string _name;
        private string _price;
        private string _quantity;
        private string _idCategory;
        private ObservableCollection<Good> _goods;
        private Good _selectedGood;
        private Good _newGood;

        public string Name
        {
            get => _name;
            set => SetPropertyChanged(ref _name, value, nameof(Name));
        }

        public string Price
        {
            get => _price;
            set => SetPropertyChanged(ref _price, value, nameof(Price));
        }

        public string Quantity
        {
            get => _quantity;
            set => SetPropertyChanged(ref _quantity, value, nameof(Quantity));
        }

        public string Idcategory
        {
            get => _idCategory;
            set => SetPropertyChanged(ref _idCategory, value, nameof(Idcategory));
        }
        public ObservableCollection<Good> Goods
        {
            get => _goods;
            set => SetPropertyChanged(ref _goods, value, nameof(Goods));
        }

        public Good SelectedGood
        {
            get => _selectedGood;
            set => SetPropertyChanged(ref _selectedGood, value, nameof(SelectedGood));
        }

        public Good NewGood
        {
            get => _newGood;
            set => SetPropertyChanged(ref _newGood, value, nameof(NewGood));
        }

        public MainWindowViewModel()
        {
            Goods = new ObservableCollection<Good>();
            NewGood = new Good();
        }

        public void LoadCustomers()
        {
            Goods.Clear();
            using(var context = new FlowerShopEntities())
            {
                var temp = context.Good.ToList();

                foreach (var good in temp)
                {
                    Goods.Add(good);
                }
            }
        }

        public void DeleteCustomer()
        {
            try
            {
                MessageBoxResult result1;
                result1 = MessageBox.Show("Вы действительно хотите удалить объект?", "Удаление объекта", MessageBoxButton.OKCancel);

                if (result1 == MessageBoxResult.OK)
                {
                    using (var context = new FlowerShopEntities())
                    {
                        var findEntity = context.Good.FirstOrDefault(s => s.Id == SelectedGood.Id);
                        if (findEntity == null) return;
                        var result = context.Good.Remove(findEntity);
                        context.SaveChanges();
                        LoadCustomers();
                    }
                }
            }
            catch
            (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool AddGood()
        {
            using (var context = new FlowerShopEntities())
            {
                var newGood = context.Good.Add(NewGood);
                context.SaveChanges();
                return true;
            }
        }

        public bool EditGood()
        {
            using(var context = new FlowerShopEntities())
            {
                var findEntity = context.Good.FirstOrDefault(s => s.Id == NewGood.Id);
                if (findEntity != null)
                {
                    context.Good.AddOrUpdate(NewGood);
                    context.SaveChanges();
                }
                else { return false; }
                return true;
            }
        }
    }
}
