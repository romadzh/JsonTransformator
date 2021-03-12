using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace ParentChildTest
{
    public class Child
    {
        public int? Id { get; set; }
        public List<Child> Children { get; set; }

        public Child()
        {
            Children = new List<Child>();
        }

        public void Set(Person person)
        {
            if (person.ParentId == Id)
            {
                Children.Add(new Child
                {
                    Id = person.Id,
                    Children = new List<Child>()
                });
            }

            foreach (var child in Children)
            {
                child.Set(person);
            }
        }

        public void Set(IGrouping<int, Person> parentGroup)
        {

            if (parentGroup.Key == 0)
            {
                Id = parentGroup.First().Id;
                Children = new List<Child>();
            }


            else if (parentGroup.Key == Id)
            {
                Children.AddRange(parentGroup.Select(a=>new Child{Id = a.Id,Children = new List<Child>()}));
            }
            else
            {
                foreach (var child in Children)
                {
                    child.Set(parentGroup);
                }
            }
            
           
        }
    }
}