using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.Model.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public int? WorkerId { get; set; }
        public int? ProductId { get; set; }
        public int? Price { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }

        public virtual Clients Client { get; set; }
        public virtual Products Product { get; set; }
        public virtual Workers Worker { get; set; }

        public override string ToString()
        {
            return $"{Id} ";
        }
    }
}
