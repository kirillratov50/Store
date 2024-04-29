using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model
{
    internal class ClientsTable
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Surname { get; set; }
        public int? Telephone { get; set; }

        public static ClientsTable ConvertClientOnClientsTable(Clients client)
        {
            ClientsTable clientsTable = new ClientsTable();
            clientsTable.Id = client.Id;
            clientsTable.Firstname = client.Firstname;
            clientsTable.Lastname = client.Lastname;
            clientsTable.Surname = client.Surname;
            clientsTable.Telephone = client.Telephone;

            return clientsTable;
        }
    }
}
