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
        [Required]
        [MaxLength(6)]
        [DisplayName("Product ID")]
        public string ProductId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string ProductName { get; set; }

        [Required]
        [DisplayName("Price")]
        public float Price { get; set; }

        [DisplayName("Amount")]
        public int Amount { get; set; }

        public string Photo { get; set; }

        [Required]
        [ForeignKey("Cateid")]
        [DisplayName("Category")]
        public string CategoryOfProduct { get; set; }
        public Category CateId { get; set; }

    }
}
