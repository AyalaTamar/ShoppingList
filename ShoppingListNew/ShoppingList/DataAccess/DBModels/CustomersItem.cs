using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class CustomersItem
{
    public int CustomerId { get; set; }

    public int ItemId { get; set; }

    public int? Quantity { get; set; }

    //public virtual Customer Customer { get; set; } = null!;

    //public virtual Item Item { get; set; } = null!;
}
