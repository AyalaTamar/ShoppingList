using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    //public virtual ICollection<CustomersItem> CustomersItems { get; set; } = new List<CustomersItem>();
}
