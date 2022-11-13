using Directory.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MODEL.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string SmallDescp { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Quantity { get; set; }
        public int StockNumber { get; set; }
        public int CategoryID { get; set; }

        // Relation Prop
        public Category Category { get; set; }
    }
}
