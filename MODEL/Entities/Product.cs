﻿using Directory.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Quantity { get; set; }
        public int StockNumber { get; set; }
        public int CategoryID { get; set; }

        // Relation Prop
        public Category Category { get; set; }
    }
}