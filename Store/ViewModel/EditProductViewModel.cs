using Store.Model.Models;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModel.EditViewModel
{
    internal class EditProductViewModel : NotifyPropertyChanged
    {
        public List<Categorii> Categoriis { get; set; } = DataWorker.SelectAllCategorii();
        public List<Products> Productss { get; set; } = DataWorker.SelectAllProducts();

        private MainViewModel _mainViewModel;
        public EditProductViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private int categoriId;

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
                 categoriId = _selectedCategori.Id;
            }
        }

        private Products _selectedProduct;
        public Products SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                Name = _selectedProduct.Name;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
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

        private string _quantity;
        public string Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private string _info;
        public string Info
        {
            get { return _info; }
            set
            {
                _info= value;
                OnPropertyChanged("Info");
            }
        }

        private RelayCommand _editProductCommand;
        public RelayCommand EditProductCommand
        {
            get
            {
                if (_editProductCommand == null)
                {
                    _editProductCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.editProduct(SelectedProduct, Name, Price, Info, categoriId) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                            _mainViewModel.Products = DataWorker.SelectAllProductsTable();
                            Productss = DataWorker.SelectAllProducts();
                        }
                    });
                }
                return _editProductCommand;
            }
        }
    }
}
