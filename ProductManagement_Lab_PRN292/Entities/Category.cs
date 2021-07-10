using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Entities
{
    public class Category
    {
        [Key]
        [Required]
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
