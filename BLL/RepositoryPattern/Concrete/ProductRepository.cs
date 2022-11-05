﻿using BLL.RepositoryPattern.Base_Abstract_;
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
    }
}
