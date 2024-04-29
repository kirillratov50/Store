using Store.Model.Models;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    internal class AddClientsViewModel : NotifyPropertyChanged
    {
        public List<Clients> Clients { get; set; } = DataWorker.SelectAllClients();


        private MainViewModel _mainViewModel;
        public AddClientsViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private string _Firstname;
        public string Firstname
        {
            get { return _Firstname; }
            set
            {
                _Firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private int _telephone;
        public int Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone= value;
                OnPropertyChanged("Telephone");
            }
        }

        private RelayCommand _addClientCommand;
        public RelayCommand AddClientCommand
        {
            get
            {
                if (_addClientCommand == null)
                {
                    _addClientCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.createClient(Firstname, Lastname, Surname, Telephone) == true)
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
                return _addClientCommand;
            }
        }
    }
}
