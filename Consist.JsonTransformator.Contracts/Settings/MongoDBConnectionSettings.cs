using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace Consist.JsonTransformator.BL.DomainObjects.Settings
{
    public interface IMongoDBConnectionSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

    }

    public class MongoDBConnectionSettings:IMongoDBConnectionSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}