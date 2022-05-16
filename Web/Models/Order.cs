using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    using System.Security.AccessControl;

    public class Order
    {
        public int OrderId { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

    }


    public class OrderProduct
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }

    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
    public class OrderDetails {
        public string Description { get; set; }
        public decimal ItemTotal { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public string ProductName { get; set; }
    }
    public class Ledger
    {
        public string CompanyName { get; set; }

        public List<OrderDetails> Orders { get; set; }

        public decimal OrderTotal { get; set; }
    }
}