using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynexAPI.Models
{
    public class Order
    {
        public string Number { get; set; }
        public bool IsRealized { get; set; }
        public int Priority { get; set; }

        public Order(string number, int priority)
        {
            Number = number;
            IsRealized = false;
            Priority = priority;
        }
    }
}
