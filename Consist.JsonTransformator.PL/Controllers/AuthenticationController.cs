using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Consist.JsonTransformator.BL.DomainObjects;
using Consist.JsonTransformator.BL.Services.Interfaces;

namespace Consist.JsonTransformator.PL.Controllers
{

    

    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpGet("GetToken")]
        public IActionResult GetToken(string password = "123")
        {
            var token = _authenticationService.GetToken(new AuthenticateDto
            {
                Password = password
            });
            return Ok(token);
        }
    }
}
