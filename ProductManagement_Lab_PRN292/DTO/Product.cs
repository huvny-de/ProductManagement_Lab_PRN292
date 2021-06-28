using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.DTO
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }

        public string ProductInCategory { get; set; }

    }
}
