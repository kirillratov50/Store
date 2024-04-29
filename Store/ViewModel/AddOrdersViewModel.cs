using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    internal class AddOrdersViewModel : NotifyPropertyChanged
    {
        private MainViewModel _mainViewModel;
        public List<Products> Products { get; set; } = DataWorker.SelectAllProducts();
        public List<Workers> Workers { get; set; } = DataWorker.SelectAllWorkers();
        public List<Clients> Clients{ get; set; } = DataWorker.SelectAllClients();

        public AddOrdersViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                OnPropertyChanged("ProductId");
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
                ProductId = _selectedProduct.Id;
            }
        }

        private int _workerId;
        public int WorkerId
        {
            get { return _workerId; }
            set
            {
                _workerId = value;
                OnPropertyChanged("WorkerId");
            }
        }

        private Workers _selectedWorker;
        public Workers SelectedWorker
        {
            get
            {
                return _selectedWorker;
            }
            set
            {
                _selectedWorker= value;
                WorkerId= _selectedWorker.Id;
            }
        }

        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId= value;
                OnPropertyChanged("ClientId");
            }
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
                ClientId = _selectedClient.Id;
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

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status= value;
                OnPropertyChanged("Status");
            }
        }

        private RelayCommand _addOrderCommand;
        public RelayCommand AddOrderCommand
        {
            get
            {
                if (_addOrderCommand == null)
                {
                    _addOrderCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.createOrder(ClientId, WorkerId, ProductId, Price, Status) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            ClientId = 0;
                            WorkerId = 0;
                            ProductId = 0;
                            Price = 0;
                            Status = "";
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                        }
                    });
                }
                return _addOrderCommand;
            }
        }
    }
}
