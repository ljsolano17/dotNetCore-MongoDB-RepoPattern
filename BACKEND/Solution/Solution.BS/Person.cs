using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Person : ICRUD<data.Person>
    {
        private readonly IMongoRepository<data.Person> _repo;
        public Person(IMongoRepository<data.Person> repo)
        {
            _repo = repo;
        }

        public void Delete(data.Person t)
        {
            new DAL.Person(_repo).Delete(t);
        }

        public IEnumerable<data.Person> GetAll()
        {
            return new DAL.Person(_repo).GetAll();
        }

        public data.Person GetOneById(string id)
        {
            return new DAL.Person(_repo).GetOneById(id);
        }

        public void Insert(data.Person t)
        {
            new DAL.Person(_repo).Insert(t);
        }

        public void Update(data.Person t)
        {
            new DAL.Person(_repo).Update(t);
        }
    }
}
