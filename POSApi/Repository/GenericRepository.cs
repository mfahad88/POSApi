using POSApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace POSApi.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        
        private DbContext context = null;
        private DbSet<T> table;
        public GenericRepository(DbContext context)
        {
            
            this.context = context;
            table = context.Set<T>();
        }
        public void Delete(object id)
        {
            table.Remove(table.Find(id));
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
        }
    }
}