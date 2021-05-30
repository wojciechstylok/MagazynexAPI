using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynexAPI.Models
{
    public class OrderItem
    {
        public string OrderNumber { get; set; }
        public Barcode Product { get; set; }
        public int Quantity { get; set; }

        public OrderItem(string orderNumber, Barcode product, int quantity)
        {
            OrderNumber = orderNumber;
            Product = product;
            Quantity = quantity;
        }
    }
}
