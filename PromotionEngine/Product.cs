﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    
    public class Product
    {
        public Product(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public decimal Price { get; set; }
    }
}
