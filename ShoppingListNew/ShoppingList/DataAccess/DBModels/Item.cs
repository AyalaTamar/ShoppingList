using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Item
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CategoryId { get; set; }

    //public virtual Category? Category { get; set; }

    //public virtual ICollection<CustomersItem> CustomersItems { get; set; } = new List<CustomersItem>();
}
