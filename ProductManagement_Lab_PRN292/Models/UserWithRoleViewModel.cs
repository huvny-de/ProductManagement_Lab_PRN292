﻿using Microsoft.AspNetCore.Identity;
using ProductManagement_Lab_PRN292.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement_Lab_PRN292.Models
{
    public class UserWithRoleViewModel
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
