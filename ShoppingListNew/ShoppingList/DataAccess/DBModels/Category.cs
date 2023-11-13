using System;
using System.Collections.Generic;

namespace DataAccess.DBModels;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Sum { get; set; }

    //public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
