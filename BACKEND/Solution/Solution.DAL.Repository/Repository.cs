using MongoDB.Driver;
using Solution.DAL.Mongo;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class Repository<T> : IRepository<Customers>
    {
        /* private readonly IMongoCollection<T> _collection;

         public Repository(IMongoDatabase database)
         {
             _collection = database.GetCollection<T>(typeof(T).Name);
         }

         public void Delete(T t)
         {
             _collection.DeleteOne(Builders<T>.Filter.Eq(x => x.Id, t.Id));
         }

         public IEnumerable<T> GetAll()
         {
             return _collection.Find(Builders<T>.Filter.Empty).ToEnumerable();
         }

         public T GetOneById(int id)
         {
             return _collection.FindOneAndDelete
         }

         public void Insert(T t)
         {
             _collection.InsertOne(t);
         }

         public void Update(T t)
         {
             _collection.ReplaceOne(Builders<T>.Filter.Eq(x => x.Id, t.Id), t);
         }*/
        /*12:25*/
        private readonly IMongoCollection<Customers> _customers;
        public Repository(MongoDBSettings settings, IMongoClient mongoClient) 
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _customers = database.GetCollection<Customers>(settings.CollectionName);
            
        }
        public Customers Create(Customers customers)
        {
            _customers.InsertOne(customers);
            return customers;
        }

        public void Delete(string id)
        {
            _customers.DeleteOne(customer => customer.Id == id);
        }

        public List<Customers> Get()
        {
            return _customers.Find(customer=>true).ToList();
        }

        public Customers Get(string id)
        {
            return _customers.Find(customer => customer.Id==id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _customers.DeleteOne(customer =>customer.Id==id);
        }

        public void Update(string id, Customers customer)
        {
            _customers.ReplaceOne(customer => customer.Id == id, customer);
        }

       
    }
}
