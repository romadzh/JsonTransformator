namespace ParentChildTest
{
    public class Person
    {
        public Person(int id, int? parentId)
        {
            Id = id;
            ParentId = parentId;
        }

       
        public int Id { get; }
        public int? ParentId { get; }
    }
}