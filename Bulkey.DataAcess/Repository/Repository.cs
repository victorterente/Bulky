using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAcess.Data;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AplicationDBcontext _db;
        internal DbSet<T> dbSet;
        public Repository(AplicationDBcontext db)
        {
            _db = db;
            this.dbSet = db.Set<T>();
            
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
  
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }


        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
                dbSet.Remove(entity);

        }

        public void RemoveRange(IEnumerable<T> entity)
        {
              dbSet.RemoveRange(entity);

        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
