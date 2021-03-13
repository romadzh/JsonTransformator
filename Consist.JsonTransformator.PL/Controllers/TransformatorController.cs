using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consist.JsonTransformator.BL.Services;
using Consist.JsonTransformator.PL.Entities;
using Consist.JsonTransformator.PL.Middlewares;
using Microsoft.Extensions.Logging;

namespace Consist.JsonTransformator.PL.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransformatorController : ControllerBase
    {
        private readonly IChildService _childService;
        private readonly ILogger<TransformatorController> _logger;

        public TransformatorController(IChildService childService,
            ILogger<TransformatorController> logger)
        {
            _childService = childService;
            _logger = logger;
        }

        
        [HttpPost("Transform")]
        [Authorize]
        public async Task<Child> Transform([FromBody] IEnumerable<Parent> parents)
        {

            try
            {
                var child =  _childService.TransformToChild(parents);
                await _childService.InsertAsync(child);
                return child;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                
            }

            return null;

        }


       
    }
}
