using Consist.JsonTransformator.BL.DomainObjects.Settings;
using Consist.JsonTransformator.DAL.DataModels;
using MongoDB.Driver;

namespace Consist.JsonTransformator.DAL
{
    public class TestDalService
    {
        private IMongoCollection<TestModel> _collection;


        public TestDalService(IMongoDBConnectionSettings mongoDbConnectionSettings )
        {
            var client = new MongoClient(mongoDbConnectionSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbConnectionSettings.DatabaseName);

            _collection = database.GetCollection<TestModel>(mongoDbConnectionSettings.CollectionName);
        }

        public void Create(TestModel model)
        {
            _collection.InsertOne(model);
        }
    }
}