using System.Collections.Generic;
using System.Security.Principal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Consist.JsonTransformator.DAL.DataModels
{
    public class ChildModel
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        [BsonElement("Childs")]
        public List<ChildModel> Children { get; set; }
    }
}