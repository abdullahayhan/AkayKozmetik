using Directory.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

        // Relation Prop
        public List<Product> Products { get; set; }
    }
}
