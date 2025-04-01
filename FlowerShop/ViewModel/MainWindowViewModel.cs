using FlowerShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlowerShop.ViewModel
{
    public class MainWindowViewModel : BVM
    {
        private ObservableCollection<Good> _goods;
        private ObservableCollection<Supply> _supplies;

        //Good
        private string _name;
        private string _price;
        private string _quantity;
        private string _idCategory;
        private Good _selectedGood;
        private Good _newGood;

        //Supply
        private string _idProvider;
        private string _idGood;
        private string _quantitySupply;
        private DateTime _dateSupply;
        private Supply _selctedSupply;
        private Supply _newSupply;

        //good
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

        //supply
        public string IdProvider
        {
            get => _idProvider;
            set => SetPropertyChanged(ref _idProvider, value, nameof(IdProvider));
        }

        public string IdGood
        {
            get => _idGood;
            set => SetPropertyChanged(ref _idGood, value, nameof(IdGood));
        }
        public DateTime DateSupply
        {
            get => _dateSupply;
            set => SetPropertyChanged(ref _dateSupply, value, nameof(DateSupply));
        }

        //
        public ObservableCollection<Good> Goods
        {
            get => _goods;
            set => SetPropertyChanged(ref _goods, value, nameof(Goods));
        }

        public ObservableCollection<Supply> Supplies
        {
            get => _supplies;
            set => SetPropertyChanged(ref _supplies, value, nameof(Supply));
        }

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

        public MainWindowViewModel()
        {
            Goods = new ObservableCollection<Good>();
            Supplies = new ObservableCollection<Supply>();
            NewGood = new Good();
            NewSupply = new Supply();
        }

        public void LoadGood()
        {
            Goods.Clear();
            try
            {
                using (var context = new FlowerShopEntities())
                {
                    var temp = context.Good.ToList();

                    foreach (var good in temp)
                    {
                        Goods.Add(good);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных! Проверте подлкючение к БД.");
            }
        }

        public void LoadSupply()
        {
            Supplies.Clear();
            try {
                using (var context = new FlowerShopEntities())
                {
                    var temp = context.Supply.ToList();

                    foreach (var supply in temp)
                    {
                        Supplies.Add(supply);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных! Проверте подлкючение к БД.");
            }
        }

        public void DeleteGood()
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
                        LoadGood();
                    }
                }
            }
            catch
            (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeleteSupply()
                {
                    try
                    {
                        MessageBoxResult result1;
                        result1 = MessageBox.Show("Вы действительно хотите удалить объект?", "Удаление объекта", MessageBoxButton.OKCancel);

                        if (result1 == MessageBoxResult.OK)
                        {
                            using (var context = new FlowerShopEntities())
                            {
                                var findEntity = context.Supply.FirstOrDefault(s => s.Id == SelectedSupply.Id);
                                if (findEntity == null) return;
                                var result = context.Supply.Remove(findEntity);
                                context.SaveChanges();
                                LoadSupply();
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
        public bool AddSupply()
        {
            using (var context = new FlowerShopEntities())
            {
                var newSuppl = context.Supply.Add(NewSupply);
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
                    return true;
                }
                else { return false; }
            }
        }
        public bool EditSupply()
        {
            using (var context = new FlowerShopEntities())
            {
                var findEntity = context.Supply.FirstOrDefault(s => s.Id == NewSupply.Id);
                if (findEntity != null)
                {
                    context.Supply.AddOrUpdate(NewSupply);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
        }
    }
}
