using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RepositoryPattern.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProducts();
        List<Product> GetProductByCategory(string name, string ProductName);
    }
}
