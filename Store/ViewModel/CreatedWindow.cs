using Store.View;
using Store.ViewModel.AddViewModel;
using Store.ViewModel.EditViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Store.ViewModel
{
    internal class CreatedWindow
    {
        public static void CreateWindow(object dataContext)
        {
            if (dataContext is AddProductViewModel addProductView)
            {
                AddProduct addProduct = new AddProduct();
                addProduct.DataContext = addProductView;
                SettingWindow(addProduct);
            }
            else if (dataContext is EditProductViewModel editProduct)
            {
                EditProduct edit = new EditProduct();
                edit.DataContext = editProduct;
                SettingWindow(edit);
            }
            else if (dataContext is AddCategoriViewModel addCategoriiView)
            {
                AddCategori addCategorii = new AddCategori();
                addCategorii.DataContext = addCategoriiView;
                SettingWindow(addCategorii);
            }
            else if (dataContext is EditCategoriViewModel editCategoriView)
            {
                EditCategori editCategorii = new EditCategori();
                editCategorii.DataContext = editCategoriView;
                SettingWindow(editCategorii);
            }
            else if (dataContext is RemoveItemViewModel remove)
            {
                RemoveItem removeItem = new RemoveItem();
                removeItem.DataContext = remove;
                SettingWindow(removeItem);
            }
            else if (dataContext is AddOrdersViewModel addOrderView)
            {
                AddOrder addOrder = new AddOrder();
                addOrder.DataContext = addOrderView;
                SettingWindow(addOrder);
            }
            else if (dataContext is EditOrdersViewModel editOrderView)
            {
                EditOrder editOrder = new EditOrder();
                editOrder.DataContext = editOrderView;
                SettingWindow(editOrder);
            }
            else if (dataContext is AddClientsViewModel addClientView)
            {
                AddClient addClient = new AddClient();
                addClient.DataContext = addClientView;
                SettingWindow(addClient);
            }
            else if (dataContext is EditClientsViewModel editClientView)
            {
                EditClient editClient = new EditClient();
                editClient.DataContext = editClientView;
                SettingWindow(editClient);
            }

        }
        public static void CreateMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        private static void SettingWindow(Window window)
        {
            window.Visibility = Visibility.Visible;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }
    }
}
