using BLL.RepositoryPattern.Base_Abstract_;
using BLL.RepositoryPattern.Interfaces;
using DAL.Context;
using Microsoft.EntityFrameworkCore;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RepositoryPattern.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        MyDbContext db;
        public ProductRepository(MyDbContext db):base(db){}
        public List<Product> GetProducts()
        {
            return table.Where(x => x.Status != Directory.MODEL.Enums.DataStatus.Deleted).Include(x => x.Category).ToList();
        }
        public List<Product> GetProductByCategory(string CategoryName, string ProductName)
        {
            if (String.IsNullOrEmpty(ProductName))
            {
                return GetProducts().Where(x => x.Category.CategoryName == CategoryName).ToList();
            }
            else
            {
                return GetProducts().Where(x => x.Category.CategoryName == CategoryName).Where(x => x.ProductName != ProductName).ToList();
            }
            
        }

        public List<Product> GetProductsByPrice(int id)
        {
            List<Product> products;
            switch (id)
            {
                case (1):
                    products = table.Where(x=>x.Price > 0 && x.Price <= 200).ToList();
                    break;                 
                case (2):                 
                    products = table.Where(x=>x.Price > 200 && x.Price <= 400).ToList();
                    break;                 
                case (3):                  
                    products = table.Where(x=>x.Price > 400 && x.Price <= 500).ToList();
                    break;                 
                case (4):                  
                    products = table.Where(x=>x.Price > 500 ).ToList();
                    break;      
                default:        
                    products = table.ToList();
                    break;
            }
            return products;
        }
    }
}
