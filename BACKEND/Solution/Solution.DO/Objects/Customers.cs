using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Objects
{
    public class Customers
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id {  get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("Age")]
        public int Age { get; set; }

        [BsonElement("Address")]
        public string Address {  get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("PostalCode")]
        public int PostalCode {  get; set; }
    }
}
