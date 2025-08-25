using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coding_Challenge_9_Question_2.Models;

namespace Coding_Challenge_9_Question_2.Repository
{

    public interface IMoviesRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(object Id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object Id);
        void Save();
    }

}
