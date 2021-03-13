using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Consist.JsonTransformator.PL.Entities
{
    public class Child
    {
        //[JsonIgnore]
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public int PrimaryId { get; set; }
        [JsonPropertyName("id")]
        [BsonElement("Id")]
        public int ItemId { get; set; }
        public string Name { get; set; }
        [BsonElement("Childs")]
        public List<Child> Childs { get; }

        public Child()
        {
            Childs = new List<Child>();
        }
        public void SetChildren(IGrouping<int, Parent> itemsGroup)
        {
            if (itemsGroup.Key == 0) // current key is root
            {
                PopulateSelf(itemsGroup);
            }

            else if (itemsGroup.Key == ItemId) // items are children of the current child
            {
                Childs.AddRange(itemsGroup.Select(a => new Child { ItemId = a.Id,Name = a.Name}));
            }
            else  // items are children of any of other child
            {
                foreach (var child in Childs)
                {
                    child.SetChildren(itemsGroup);
                }
            }


        }

        private void PopulateSelf(IGrouping<int, Parent> parentGroup)
        {
            ItemId = parentGroup.First().Id;
            Name = parentGroup.First().Name;
        }
    }
}
