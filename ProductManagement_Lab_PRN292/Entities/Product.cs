using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Entities
{
    public class Product
    {
        [Key]
        [Required]
        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Price")]
        public float Price { get; set; }

        [DisplayName("Amount")]
        public int Amount { get; set; }

        public string Photo { get; set; }

        [Required]
        [DisplayName("Category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
