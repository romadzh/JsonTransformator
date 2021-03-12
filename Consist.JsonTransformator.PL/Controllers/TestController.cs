using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consist.JsonTransformator.PL.Entities;
using Consist.JsonTransformator.PL.Middlewares;

namespace Consist.JsonTransformator.PL.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
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



          return child;
        }
    }
}
