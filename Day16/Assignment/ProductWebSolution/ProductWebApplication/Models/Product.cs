using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApplication.Models
{
    public class Product
    {
        public int ProdId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int SuppId { get; set; }
        public int Qty { get; set; }
        public string Remarks { get; set; }
    }
}
