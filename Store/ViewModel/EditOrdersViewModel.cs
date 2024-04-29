using Store.Model.Models;
using Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    internal class EditOrdersViewModel : NotifyPropertyChanged
    {
        public List<Orders> Orders { get; set; } = DataWorker.SelectAllOrders();

        private MainViewModel _mainViewModel;
        public EditOrdersViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private Orders _selectedOrder;
        public Orders SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                Status = _selectedOrder.Status;
                Id = _selectedOrder.Id;
            }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private RelayCommand _editOrderCommand;
        public RelayCommand EditOrderCommand
        {
            get
            {
                if (_editOrderCommand == null)
                {
                    _editOrderCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.editOrder(SelectedOrder, Status) == true)
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
                return _editOrderCommand;
            }
        }
    }
}
