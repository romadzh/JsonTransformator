using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Consist.JsonTransformator.PL.Entities
{
    public class Child
    {
        [JsonIgnore]
        public int PrimaryId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
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

            else if (itemsGroup.Key == Id) // items are children of the current child
            {
                Childs.AddRange(itemsGroup.Select(a => new Child { Id = a.Id,Name = a.Name}));
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
            Id = parentGroup.First().Id;
            Name = parentGroup.First().Name;
        }
    }
}
