using Store.Model.Models;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;
using Store.ViewModel;

namespace Store.ViewModel.EditViewModel
{
    internal class EditCategoriViewModel : NotifyPropertyChanged
    {
        public List<Categorii> Categoriis { get; set; } = DataWorker.SelectAllCategorii();

        private MainViewModel _mainViewModel;
        public EditCategoriViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
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
                Name = _selectedCategori.Name;
                Info = _selectedCategori.Info;
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

        private RelayCommand _editCategoriCommand;
        public RelayCommand EditCategoriCommand
        {
            get
            {
                if (_editCategoriCommand == null)
                {
                    _editCategoriCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.editCategori(SelectedCategori, Name, Info) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            _mainViewModel.Products = DataWorker.SelectAllProductsTable();
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                            
                        }
                    });
                }
                return _editCategoriCommand;
            }
        }
    }
}
