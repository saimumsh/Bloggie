using Blogie.core;
using Blogie.data.DataBlog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogie.data.Repositoty
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BlogDbContext _db;
        internal DbSet<T> dbSet;
        public Repository( BlogDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
                _db.Add(entity);
                _db.SaveChanges();
          
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            _db.SaveChanges();
        }

        public void DeleteAll(List<T> entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            List<T> list = dbSet.ToList();
            return list;
        }

        public T GetById(int id)
        {
            T obj= dbSet.Find(id);
            return obj;
            
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            _db.SaveChanges();
        }
    }
}
