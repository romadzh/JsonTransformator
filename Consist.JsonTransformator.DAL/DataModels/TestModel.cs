using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Consist.JsonTransformator.DAL.DataModels
{
    public class TestModel
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public List<int> TestArray { get; set; }

    }
}