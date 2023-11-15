using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using Solution.DO.Objects;

namespace Solution.DAL.Mongo
{
    public class MongoDBService 
    {
        private readonly IMongoCollection<Customers> _customersCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _customersCollection = database.GetCollection<Customers>(mongoDBSettings.Value.CollectionName);

        }
    
        public  async Task<List<Customers>> GetAsync() {  }
        public  async Task CreateAsync(Customers customers) { }
        public static async Task DeleteAsync(string id) { }

    }
}
