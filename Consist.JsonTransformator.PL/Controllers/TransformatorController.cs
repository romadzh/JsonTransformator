using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consist.JsonTransformator.BL.Services;
using Consist.JsonTransformator.PL.Entities;
using Consist.JsonTransformator.PL.Middlewares;

namespace Consist.JsonTransformator.PL.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransformatorController : ControllerBase
    {
        private readonly TestService _testService;
        private readonly ChildService _childService;

        public TransformatorController(TestService testService, ChildService childService)
        {
            _testService = testService;
            _childService = childService;
        }
        [HttpPost("Transform")]
        [Authorize]
        public Child Transform([FromBody] List<Parent> parents)
        {
            var sortedByParentId= parents.OrderBy(p => p.ParentId);
            var groupedBy = sortedByParentId.GroupBy(x => x.ParentId ?? 0).ToList();

            Child child = new Child();
            foreach (var childGrouped in groupedBy)
            {
                child.Set(childGrouped);
            }

            _childService.Insert(child);

          return child;
        }


        [HttpGet("testmongo")]
        public IActionResult TestMongo()
        {
            _testService.InsertTest();
            return Ok("salut");
        }
    }
}
