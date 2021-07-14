using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Models
{
    public class UserWithRoleSelectViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public SelectList Roles { get; set; }
    }
}
