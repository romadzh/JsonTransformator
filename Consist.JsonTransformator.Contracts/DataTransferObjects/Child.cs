using System.Collections.Generic;
using System.Linq;

namespace Consist.JsonTransformator.PL.Entities
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Child> Childs { get; set; }

        public void Set(IGrouping<int, Parent> parentGroup)
        {
            if (parentGroup.Key == 0)
            {
                PopulateRoot(parentGroup);
            }

            else if (parentGroup.Key == Id)
            {
                Childs.AddRange(parentGroup.Select(a => new Child { Id = a.Id,Name = a.Name,Childs = new List<Child>() }));
            }
            else
            {
                foreach (var child in Childs)
                {
                    child.Set(parentGroup);
                }
            }


        }

        private void PopulateRoot(IGrouping<int, Parent> parentGroup)
        {
            Id = parentGroup.First().Id;
            Name = parentGroup.First().Name;
            Childs = new List<Child>();
        }
    }
}
