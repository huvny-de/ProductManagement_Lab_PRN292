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
        public string SelectedCategory { get; set; }
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<Product> SearchResults { get; set; } = new List<Product>();
    }
}
