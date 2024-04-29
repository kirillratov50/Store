using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    internal class OrdersTable
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? ProductId { get; set; }
        public int? Price { get; set; }
        public int? WorkerId { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }

        public string NameClient { get; set; }
        public string NameProduct { get; set; }
        public string NameWorker { get; set; }

        public static OrdersTable ConvertOrderOnOrdersTable(Orders order)
        {
            OrdersTable ordersTable = new OrdersTable();
            ordersTable.Id = order.Id;
            ordersTable.ClientId = order.ClientId;
            ordersTable.WorkerId = order.WorkerId;
            ordersTable.Price = order.Price;
            ordersTable.ProductId = order.ProductId;
            ordersTable.Date = order.Date;
            ordersTable.Status = order.Status;


            using (ApplicationContext db = new ApplicationContext())
            {
                ordersTable.NameProduct= db.Products.FirstOrDefault(g => g.Id == order.ProductId).Name;
                Workers worker = db.Workers.FirstOrDefault(g => g.Id == order.WorkerId);
                ordersTable.NameWorker = $"{worker.Lastname} {worker.Firstname} {worker.Surname}";
                Clients client = db.Clients.FirstOrDefault(g => g.Id == order.ClientId);
                ordersTable.NameClient = $"{client.Lastname} {client.Firstname} {client.Surname} ";
            }

            return ordersTable;
        }
    }

}
