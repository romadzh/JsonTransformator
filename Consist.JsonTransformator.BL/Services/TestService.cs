using System.Collections.Generic;
using Consist.JsonTransformator.DAL;
using Consist.JsonTransformator.DAL.DataModels;

namespace Consist.JsonTransformator.BL.Services
{
    public class TestService
    {
        private readonly TestDalService _dalService;

        public TestService(TestDalService dalService)
        {
            _dalService = dalService;
        }
        public void InsertTest()
        {
            _dalService.Create(new TestModel
            {
                Id = "6",
                Name = "this is test name",
                TestArray = new List<int>{1,23,4}
            });
        }
    }
}