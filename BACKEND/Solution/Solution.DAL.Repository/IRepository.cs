using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        /*  IEnumerable<T> GetAll();
          T GetOneById(int id);
          void Insert(T t);
          void Update(T t);
          void Delete(T t);*/

        List<Customers> Get();
        Customers Get(string id);
        Customers Create(Customers customers);
        void Update(string id, Customers customers);
        void Remove(string id);

    }
}
