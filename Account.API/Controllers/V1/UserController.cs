using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Account.API.Configurations;
using Account.DTO;
using Account.DTO.Output;
using Account.Interfaces.Business;
using API.Helper.LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers.V1
{
    public class UserController : ApiControllerBase<IUserBusiness>
    {
        public UserController(IUserBusiness userBusinees, ILoggerManager logger) 
            : base(userBusinees, logger)
        {

        }

        [Authorize]
        [HttpGet("{userId}", Name = "getUser")]
        public async Task<IActionResult> Get(int userId)
        {
            var response = await BusinessIntance.Get(userId);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OutUserDTO))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] InUserCreateDTO model)
        {
            var response = await BusinessIntance.Save(model);

            return new CreatedAtRouteResult("getUser", new { userId = response.UserId }, response);
        }
    }
}