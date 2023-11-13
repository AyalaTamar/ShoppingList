using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBModels
{
    public class ItemTemp
    {

        public int CustomerId { get; set; }

        public int ItemId { get; set; }

        public string? Name { get; set; }

        public int? Quantity { get; set; }
    }
}
