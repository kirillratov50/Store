using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Store.Model.Models;
using Store.Model;

namespace Store.ViewModel.AddViewModel
{
    internal class AddProductViewModel : NotifyPropertyChanged
    {
        public List<Categorii> Categoriis { get; set; } = DataWorker.SelectAllCategorii();
        private MainViewModel _mainViewModel;
        public AddProductViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        private string _name; 
        public string Name
        {
            get { return _name;  }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        private int categoriId;
        private string _info;
        public string Info
        {
            get { return _info; }
            set
            {
                _info = value;
                OnPropertyChanged("Info");
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private Categorii _selectedCategori;
        public Categorii SelectedCategori
        {
            get
            {
                return _selectedCategori;
            }
            set
            {
                _selectedCategori = value;
                categoriId= _selectedCategori.Id;
            }
        }

        private RelayCommand _addProductCommand;
        public RelayCommand AddProductCommand
        {
            get
            {
                if(_addProductCommand == null)
                {
                    _addProductCommand = new RelayCommand((o) =>
                    {
                        if(DataWorker.createProduct(Name, Price, Info, categoriId, Quantity) == true && Name.Length > 0)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            Name = null;
                            Info = null;
                            _mainViewModel.Products = DataWorker.SelectAllProductsTable();
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                        }
                    });
                }
                return _addProductCommand;
            }
        }


    }
}
