using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagazynexAPI.Models
{
    public class Barcode
    {
        public string Code { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string Units { get; set; }
        public string Batch { get; set; }


        public Barcode(string code, string name, int quan, string units, string batch)
        {
            Code = code;
            ItemName = name;
            Quantity = quan;
            Units = units;
            Batch = batch;
        }
    }
}
