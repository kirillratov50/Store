using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Store.Model.Models;

namespace Store.Model
{
    internal class DataWorker
    {
        public static bool createCategori(string name, string info)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Products.Any(el => el.Name == name))
                {
                    Categorii categori = new Categorii()
                    {
                        Name = name,
                        Info = info,
                    };
                    db.Categorii.Add(categori);
                    db.SaveChanges();

                    return true;
                }
                return false;
            }
        }
        public static bool editCategori(Categorii oldCategori, string name, string info)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Categorii categori = db.Categorii.FirstOrDefault(i => i.Id == oldCategori.Id);
                if (categori != null)
                {
                    categori.Name = name;
                    categori.Info = info;

                    db.SaveChanges();

                    return true;
                }
                return false;
            }
        }
        public static void deleteCategori(Categorii categori)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Categorii.Remove(categori);
                db.SaveChanges();
            }
        }

        public static List<Categorii> SelectAllCategorii()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Categorii.ToList();
            }
        }

        public static bool createProduct(string name, int price, string info, int categoriId, int quantity)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (!db.Products.Any(el => el.Name == name))
                {
                    Products product = new Products()
                    {
                        Name = name,
                        Price = price,
                        Info = info,
                        CategoriId = categoriId,
                        Quantity = quantity
                    };
                    db.Products.Add(product);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public static bool editProduct(Products oldProduct, string name, int price, string info, int categoriId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Products product = db.Products.FirstOrDefault(i => i.Id == oldProduct.Id);
                if (product != null)
                {
                    product.Name = name;
                    product.Price = price;
                    product.Info = info;
                    product.CategoriId = categoriId;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void deleteProduct(Products product)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public static List<Products> SelectAllProducts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Products.ToList();
            }
        }

        public static List<ProductsTable> SelectAllProductsTable()
        {
            List<Products> products = SelectAllProducts();
            List<ProductsTable> productTable= new List<ProductsTable>();
            
            foreach(Products product in products)
            {
                productTable.Add(ProductsTable.ConvertProductOnProductsTable(product));
            }
            return productTable;
        }

        public static List<Workers> SelectAllWorkers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Workers.ToList();
            }
        }

        public static bool createOrder(int clientId, int workerId, int productId, int price, string status)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Orders order = new Orders()
                {
                    ClientId = clientId,
                    WorkerId = workerId,
                    ProductId = productId,
                    Price = price, 
                    Date = DateTime.Now,
                    Status = status,
                };
                db.Orders.Add(order);
                db.SaveChanges();
                return true;
            }
        }

        public static bool editOrder(Orders oldOrder, string status)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Orders order = db.Orders.FirstOrDefault(i => i.Id == oldOrder.Id);
                if (order != null)
                {
                    order.Status = status; 
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void deleteOrder(Orders order)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public static List<Orders> SelectAllOrders()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Orders.ToList();
            }
        }

        public static List<OrdersTable> SelectAllOrdersTable()
        {
            List<Orders> orders = SelectAllOrders();
            List<OrdersTable> ordersTable = new List<OrdersTable>();

            foreach (Orders order in orders)
            {
                ordersTable.Add(OrdersTable.ConvertOrderOnOrdersTable(order));
            }
            
            return ordersTable;
        }

        public static bool createClient(string firstname, string lastname, string surname, int telephone)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Clients client = new Clients()
                {
                    Firstname = firstname, 
                    Lastname = lastname, 
                    Surname = surname,
                    Telephone = telephone,
                };

                db.Clients.Add(client);
                db.SaveChanges();
                return true;
            }
        }

        public static bool editClient(Clients oldClient, string firstname, string lastname, string surname, int? telephone)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Clients client = db.Clients.FirstOrDefault(i => i.Id == oldClient.Id);
                if (client != null)
                {
                    client.Firstname = firstname;
                    client.Lastname = lastname;
                    client.Surname = surname;
                    client.Telephone = telephone;
                    
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public static void deleteClient(Clients client)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        public static List<Clients> SelectAllClients()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                return db.Clients.ToList();
            }
        }

        public static List<ClientsTable> SelectAllClientsTable()
        {
            List<Clients> clients = SelectAllClients();
            List<ClientsTable> clientsTable = new List<ClientsTable>();

            foreach (Clients client in clients)
            {
                clientsTable.Add(ClientsTable.ConvertClientOnClientsTable(client));
            }
            return clientsTable;
        }

        

    }
}
