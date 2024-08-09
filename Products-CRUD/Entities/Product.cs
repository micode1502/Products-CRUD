﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_CRUD.Entities
{
    public class Product
    {
        public int id { get; set; }
        public int categoryId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
    }
}
