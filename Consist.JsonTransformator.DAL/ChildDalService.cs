using Consist.JsonTransformator.BL.DomainObjects.Settings;
using Consist.JsonTransformator.DAL.DataModels;
using Consist.JsonTransformator.PL.Entities;
using MongoDB.Driver;

namespace Consist.JsonTransformator.DAL
{
    public class ChildDalService
    {
        private readonly IMongoCollection<Child> _collection;

        public ChildDalService(IMongoDBConnectionSettings mongoDbConnectionSettings)
        {
            var client = new MongoClient(mongoDbConnectionSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbConnectionSettings.DatabaseName);

            _collection = database.GetCollection<Child>(mongoDbConnectionSettings.CollectionName);
        }

        public void Create(Child model)
        {
            _collection.DeleteOne(a => a.Id == model.Id);
            _collection.InsertOne(model);
            
        }
    }
}