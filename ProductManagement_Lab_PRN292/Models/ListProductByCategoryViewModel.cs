using Microsoft.AspNetCore.Mvc.Rendering;
using ProductManagement_Lab_PRN292.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Models
{
    public class ListProductByCategoryViewModel
    {
        public List<Product> Products { get; set; }
        public SelectList Categories { get; set; }
        public List<String> CategoriesName { get; set; }

        public int ProductCategory { get; set; }
        public string SearchString { get; set; }
    }
}
