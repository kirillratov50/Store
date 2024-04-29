using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Model.Models;

namespace Store.Model
{
    public class ProductsTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int? Price { get; set; }
        public int? Quantity{ get; set; }
        public int? CategoriId { get; set; }
        public string NameCategorii{ get; set; }

        public static ProductsTable ConvertProductOnProductsTable(Products product)
        {
            ProductsTable productsTable= new ProductsTable();
            productsTable.Id = product.Id;
            productsTable.Name = product.Name;
            productsTable.Info = product.Info;
            productsTable.Price = product.Price;
            productsTable.Quantity = product.Quantity;
            productsTable.CategoriId = product.CategoriId;

            using (ApplicationContext db = new ApplicationContext())
            {
                productsTable.NameCategorii= db.Categorii.FirstOrDefault(g => g.Id== product.CategoriId).Name;
            }

            return productsTable;
        }

    }
}
