using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.View;
using Store.Model;
using Store.ViewModel.AddViewModel;
using Store.ViewModel.EditViewModel;
using System.Windows;
using Store.Model.Models;

namespace Store.ViewModel
{
    internal class MainViewModel : NotifyPropertyChanged
    {
        public MainViewModel(Workers worker)
        {
            Worker = worker.Firstname + " " + worker.Surname + " " + worker.Lastname;
        }
        public string Worker { get; set; }

        private List<ProductsTable> _products = DataWorker.SelectAllProductsTable();
        public List<ProductsTable> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");
            }
        }

        private List<OrdersTable> _orders = DataWorker.SelectAllOrdersTable();
        public List<OrdersTable> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }

        private List<ClientsTable> _clients= DataWorker.SelectAllClientsTable();
        public List<ClientsTable> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private string _searchText = "";
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value.Replace(" ", string.Empty);
                OnPropertyChanged("SearchText");
            }
        }

        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                if(_searchCommand == null)
                {
                    _searchCommand = new RelayCommand((o) =>
                    {
                        if (SearchText != string.Empty)
                        {
                            Products = DataWorker.SelectAllProductsTable().Where(c => $"{c.Name}{c.Info}{c.Price}{c.NameCategorii}".ToLower().Contains(SearchText.ToLower())).ToList();
                        }
                        else
                        {
                            Products = DataWorker.SelectAllProductsTable();
                        }
                    });
                }
                return _searchCommand;
            }
        }

        private RelayCommand _openAddProductWindow;
        public RelayCommand OpenAddProductWindow
        {
            get
            {
                if (_openAddProductWindow == null)
                {
                    _openAddProductWindow = new RelayCommand((o) =>
                    {
                        AddProductViewModel addProductViewModel = new AddProductViewModel(this);
                        CreatedWindow.CreateWindow(addProductViewModel);
                    });
                }

                return _openAddProductWindow;
            }
        }

        private RelayCommand _openEditProductWindow;
        public RelayCommand OpenEditProductWindow
        {
            get
            {
                if (_openEditProductWindow == null)
                {
                    _openEditProductWindow = new RelayCommand((o) =>
                    {
                        EditProductViewModel editProductViewModel = new EditProductViewModel(this);
                        CreatedWindow.CreateWindow(editProductViewModel);
                    });
                }

                return _openEditProductWindow;
            }
        }

        private RelayCommand _openEditCategoriiWindow;
        public RelayCommand OpenEditCategoriiWindow
        {
            get
            {
                if(_openEditCategoriiWindow == null)
                {
                    _openEditCategoriiWindow = new RelayCommand((o) =>
                    {
                        EditCategoriViewModel editCategoriViewModel = new EditCategoriViewModel(this);
                        CreatedWindow.CreateWindow(editCategoriViewModel);
                    });
                }
                return _openEditCategoriiWindow;
            }
        }
                                
        private RelayCommand _openAddCategoriiWindow;
        public RelayCommand OpenAddCategoriiWindow
        {
            get
            {
                if (_openAddCategoriiWindow == null)
                {
                    _openAddCategoriiWindow = new RelayCommand((o) =>
                    {
                        AddCategoriViewModel addCategoriViewModel = new AddCategoriViewModel(this);
                        CreatedWindow.CreateWindow(addCategoriViewModel);
                    });
                }

                return _openAddCategoriiWindow;
            }
        }

        private RelayCommand _openRemoveCategoriWindow;
        public RelayCommand OpenRemoveCategoriWindow
        {
            get
            {
                if (_openRemoveCategoriWindow == null)
                {
                    _openRemoveCategoriWindow = new RelayCommand((o) =>
                    {
                       
                        
                        string text = "Выберете категорию";
                        List<object> list = DataWorker.SelectAllCategorii().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);
                        
                    
                    });
                }
                return _openRemoveCategoriWindow;
            }
        }

        private RelayCommand _openRemoveProductWindow;
        public RelayCommand OpenRemoveProductWindow
        {
            get
            {
                if (_openRemoveProductWindow == null)
                {
                    _openRemoveProductWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберете товар";
                        List<object> list = DataWorker.SelectAllProducts().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);
                        CreatedWindow.CreateWindow(removeItemViewModel);
                     
                    });
                }
                return _openRemoveProductWindow;
            }
        }

        private RelayCommand _openEditOrdersWindow;
        public RelayCommand OpenEditOrdersWindow
        {
            get
            {
                if (_openEditOrdersWindow == null)
                {
                    _openEditOrdersWindow = new RelayCommand((o) =>
                    {
                        EditOrdersViewModel editOrdersViewModel = new EditOrdersViewModel(this);
                        CreatedWindow.CreateWindow(editOrdersViewModel);
                    });
                }
                return _openEditOrdersWindow;
            }
        }

        private RelayCommand _openAddOrdersWindow;
        public RelayCommand OpenAddOrdersWindow
        {
            get
            {
                if (_openAddOrdersWindow == null)
                {
                    _openAddOrdersWindow = new RelayCommand((o) =>
                    {
                        AddOrdersViewModel addOrderViewModel = new AddOrdersViewModel(this);
                        CreatedWindow.CreateWindow(addOrderViewModel);
                    });
                }

                return _openAddOrdersWindow;
            }
        }

        private RelayCommand _openRemoveOrderWindow;
        public RelayCommand OpenRemoveOrdersWindow
        {
            get
            {
                if (_openRemoveOrderWindow == null)
                {
                    _openRemoveOrderWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберете заказ";
                        List<object> list = DataWorker.SelectAllOrders().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);

                    });
                }
                return _openRemoveOrderWindow;
            }
        }



        private RelayCommand _openEditClientsWindow;
        public RelayCommand OpenEditClientsWindow
        {
            get
            {
                if (_openEditClientsWindow == null)
                {
                    _openEditClientsWindow = new RelayCommand((o) =>
                    {
                        EditClientsViewModel editClientsViewModel = new EditClientsViewModel(this);
                        CreatedWindow.CreateWindow(editClientsViewModel);
                    });
                }
                return _openEditClientsWindow;
            }
        }

        private RelayCommand _openAddClientsWindow;
        public RelayCommand OpenAddClientsWindow
        {
            get
            {
                if (_openAddClientsWindow == null)
                {
                    _openAddClientsWindow = new RelayCommand((o) =>
                    {
                        AddClientsViewModel addClientViewModel = new AddClientsViewModel(this);
                        CreatedWindow.CreateWindow(addClientViewModel);
                    });
                }

                return _openAddClientsWindow;
            }
        }

        private RelayCommand _openRemoveClientWindow;
        public RelayCommand OpenRemoveClientsWindow
        {
            get
            {
                if (_openRemoveClientWindow == null)
                {
                    _openRemoveClientWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберете клиента";
                        List<object> list = DataWorker.SelectAllOrders().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);

                    });
                }
                return _openRemoveClientWindow;
            }
        }





    }

}
