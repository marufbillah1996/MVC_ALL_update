using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.GenricRepository
{
    public class GenricRepo<T> : IGenricRepo<T> where T : class
    {
        internal EmployeeContext dbcontext;
        internal DbSet<T> dbset;
        public GenricRepo(EmployeeContext db)
        {
            this.dbcontext = db;
            this.dbset = db.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetById(object id)
        {
            return dbset.Find(id);
        }

        public void Insert(T obj)
        {
            dbset.Add(obj);
        }

        public void Update(T obj)
        {
            //dbset.Attach(obj);
            dbcontext.Entry(obj).State = EntityState.Modified;
        }
        //public void Delete(object obj)
        //{
        //    if (dbcontext.Entry(obj).State == EntityState.Detached)
        //    {
        //        dbset.Attach(obj);
        //    }
        //    dbset.Remove(obj);
        //}
        public virtual void Delete(object id)
        {
            T entityToDelete = dbset.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(T entityToDelete)
        {
            if (dbcontext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbset.Attach(entityToDelete);
            }
            dbset.Remove(entityToDelete);
        }
    }
}