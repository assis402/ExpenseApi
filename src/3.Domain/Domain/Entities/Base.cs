using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities
{
    public class Base
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
