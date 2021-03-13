using System.Threading.Tasks;
using Consist.JsonTransformator.BL.DomainObjects.Settings;
using Consist.JsonTransformator.DAL.DataModels;
using Consist.JsonTransformator.PL.Entities;
using MongoDB.Driver;

namespace Consist.JsonTransformator.DAL
{
    public interface IChildDalService
    {
        Task CreateAsync(Child model);
    }
    public class ChildDalService : IChildDalService
    {
        private readonly IMongoCollection<Child> _collection;

        public ChildDalService(IMongoDBConnectionSettings mongoDbConnectionSettings)
        {
            var client = new MongoClient(mongoDbConnectionSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbConnectionSettings.DatabaseName);

            _collection = database.GetCollection<Child>(mongoDbConnectionSettings.CollectionName);
        }

        public async Task CreateAsync(Child model)
        {
            await _collection.DeleteOneAsync(a => a.Id == model.Id);
            await _collection.InsertOneAsync(model);
            
        }
    }
}