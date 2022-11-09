using BLL.RepositoryPattern.Interfaces;
using DAL.Context;
using Directory.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RepositoryPattern.Base_Abstract_
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        MyDbContext db;
        protected DbSet<T> table;
        public Repository(MyDbContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public void Add(T item)
        {
            table.Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return table.Any(exp);
        }

        public void Delete(int id)
        {
            T item = table.Find(id);
            item.ModifiedDate = DateTime.Now;
            item.Status = Directory.MODEL.Enums.DataStatus.Deleted;
            table.Update(item);
            Save();
        }

        public List<T> GetActives()
        {
           return table.Where(x=>x.Status!=Directory.MODEL.Enums.DataStatus.Deleted).ToList();
        }

        public List<T> GetByFilter(Expression<Func<T, bool>> exp)
        {
            return table.Where(exp).ToList();
        }

        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Update(T item)
        {
            item.Status = Directory.MODEL.Enums.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            table.Update(item);
            Save();
        }
        public T Default(Expression<Func<T, bool>> exp)
        {
            return table.FirstOrDefault(exp); // table içinde arama yap ve ilk bulduğun veriye bana dön demek.
        }
    }
}
