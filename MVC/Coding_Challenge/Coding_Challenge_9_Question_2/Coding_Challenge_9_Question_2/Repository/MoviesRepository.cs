using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Coding_Challenge_9_Question_2.Models;


namespace Coding_Challenge_9_Question_2.Repository
{
    public class MoviesRepository<T> : IMoviesRepository<T> where T : class
    {
        MoviesContext db;
        DbSet<T> dbset;

        public MoviesRepository()
        {
            db = new MoviesContext();
            dbset = db.Set<T>();
        }
        public void Delete(object Id)
        {
            T getModel = dbset.Find(Id);
            dbset.Remove(getModel);
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public T GetByID(object Id)
        {
            return dbset.Find(Id);
        }

        public void Insert(T obj)
        {
            dbset.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T obj)
        {
            db.Entry(obj).State = EntityState.Modified;
        }
    }
}