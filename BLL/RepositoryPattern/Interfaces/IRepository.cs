using Directory.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.RepositoryPattern.Interfaces
{
    public interface IRepository<T> where T:BaseEntity
    {
        List<T> GetActives();
        T GetById(int id);
        T Default(Expression<Func<T, bool>> exp);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        List<T> GetByFilter(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
    }
}
