using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.APl.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string  Id { get; set; }

        [BsonElement("Name")]
        public string  Name { get; set; }
        public string Category { get; set; }
        public string Des { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
