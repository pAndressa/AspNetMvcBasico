using AspMVC.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspMVC.Repository
{
    public class Repository<T> : IDisposable where T : class
    {
        ContextApp _context;
        DbSet<T> _dbSet;

        public Repository(ContextApp context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        //implementação da interface IDisposable
        public void Dispose()
        {
            _context.Dispose();
        }
       
        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        //Ao invés de criar uma condição para trazer 10 registros num ex: if é possível fazer dessa maneira:
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        //busca por Id
        public T FindById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
    }
}
