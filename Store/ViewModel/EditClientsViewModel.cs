using Store.Model.Models;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Store.ViewModel
{
    internal class EditClientsViewModel : NotifyPropertyChanged
    {
        public List<Clients> Clients { get; set; } = DataWorker.SelectAllClients();


        private MainViewModel _mainViewModel;
        public EditClientsViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private Clients _selectedClient;
        public Clients SelectedClient
        {
            get
            {
                return _selectedClient;   
            }
            set
            {
                _selectedClient = value;
                Firstname = _selectedClient.Firstname;
                Lastname = _selectedClient.Lastname;
                Surname = _selectedClient.Surname;
                Telephone = _selectedClient.Telephone;
            }
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

        private int? _telephone;
        public int? Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                OnPropertyChanged("Telephone");
            }
        }

        private RelayCommand _editClientCommand;
        public RelayCommand EditClientCommand
        {
            get
            {
                if (_editClientCommand == null)
                {
                    _editClientCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.editClient(SelectedClient, Firstname, Lastname, Surname, Telephone) == true)
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
                return _editClientCommand;
            }
        }
    }
}
