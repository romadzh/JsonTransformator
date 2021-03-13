using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Consist.JsonTransformator.BL.DomainObjects;
using Consist.JsonTransformator.BL.Services.Interfaces;
using Consist.JsonTransformator.PL.Middlewares;
using Microsoft.Extensions.Logging;

namespace Consist.JsonTransformator.PL.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthenticationService authenticationService,
            ILogger<AuthenticationController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }


        /// <summary>
        /// Provide a bearer token 
        /// </summary>
        [HttpGet("GetToken")]
        public IActionResult GetToken(string password = "123")
        {
            var authenticateDto = new AuthenticateDto {Password = password};
            try
            {
                _logger.LogInformation("Get token executed");
                var token = _authenticationService.GetToken(authenticateDto);
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return BadRequest("Operation Failed, something get wrong");
            }
        }


       


    }
}
