using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductWebApplication2.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product name cannot be empty")]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Category { get; set; }
        [Range(0.01, 1000.00, ErrorMessage = "Price must be between $0.01 and $1000.00")]
        public double Price { get; set; }
        [Range(0, 20, ErrorMessage = "Maximum quantity is 20")]
        public int Qty { get; set; }
        public string Pic { get; set; }
        public string Desc { get; set; }
    }
}
