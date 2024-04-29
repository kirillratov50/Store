using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.ViewModel
{
    internal class RemoveItemViewModel : NotifyPropertyChanged
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        private List<object> _items;
        public List<object> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        MainViewModel _mainViewModel;
        public RemoveItemViewModel(string text, List<object> items, MainViewModel mainViewModel)
        {
            _text = text;
            Items = items;
            _mainViewModel = mainViewModel;
        }

        
        public object SelectedItem { get; set; }

        private RelayCommand _removeItem;
        public RelayCommand RemoveItem
        {
            get
            {
                if (_removeItem == null)
                {
                    _removeItem = new RelayCommand((o) =>
                    {

                        if (SelectedItem is Products product)
                        {
                            try
                            {
                                DataWorker.deleteProduct(product);
                                CreatedWindow.CreateMessageBox("Успешно");
                                SelectedItem = null;
                                _mainViewModel.Products = DataWorker.SelectAllProductsTable();
                                Items = DataWorker.SelectAllProducts().Select(x => (object)x).ToList();

                            }
                            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                            {
                                CreatedWindow.CreateMessageBox("Этот элемент используется и его нельзя удалить");
                            }
                        }
                        else if (SelectedItem is Categorii categori)
                        {

                            try
                            {
                                DataWorker.deleteCategori(categori);
                                CreatedWindow.CreateMessageBox("успешно");
                                _mainViewModel.Products = DataWorker.SelectAllProductsTable();
                                Items = DataWorker.SelectAllProducts().Select(x => (object)x).ToList();
                            }
                            catch(Microsoft.EntityFrameworkCore.DbUpdateException)
                            {
                                CreatedWindow.CreateMessageBox("Этот элемент используется и его нельзя удалить");
                            }
                        }
                        else if (SelectedItem is Orders order)
                        {

                            try
                            {
                                DataWorker.deleteOrder(order);
                                CreatedWindow.CreateMessageBox("успешно");
                                _mainViewModel.Orders = DataWorker.SelectAllOrdersTable();
                                Items = DataWorker.SelectAllOrders().Select(x => (object)x).ToList();
                            }
                            catch (Microsoft.EntityFrameworkCore.DbUpdateException)
                            {
                                CreatedWindow.CreateMessageBox("Этот элемент используется и его нельзя удалить");
                            }
                        }

                    },
                    (o) =>
                    {
                        return SelectedItem != null;
                    });
                }
                return _removeItem;
            }
        }
    }
}
