using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ParentChildTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var list = new List<Person>()
            {
                new Person(1, null),
                new Person(2,1),
                new Person(3,1),
                new Person(4,1),
                new Person(5,4),
                new Person(6,3),
                new Person(7,5)
            };


            var sortedList = list.OrderBy(p => p.ParentId);

            var groupedBy = sortedList.GroupBy(x => x.ParentId ?? 0);
            Child child = new Child();
            foreach (var parentGroup in groupedBy)
            {
                child.Set(parentGroup );
            }





        }
    }
}
