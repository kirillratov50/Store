using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Store.Model.Models
{
    public partial class Jobs
    {
        public Jobs()
        {
            Workers = new HashSet<Workers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Workers> Workers { get; set; }
    }
}
