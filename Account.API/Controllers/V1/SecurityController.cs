using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Account.API.Configurations;
using Account.DTO.Input;
using Account.DTO.Output;
using Account.Interfaces.Business;
using API.Helper.LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers.V1
{
    public class SecurityController : ApiControllerBase<ISecurityBusiness>
    {
        public SecurityController(ISecurityBusiness securityBusiness, ILoggerManager logger)
            :base(securityBusiness, logger)
        {

        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OutAuthenticateDTO))]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        public IActionResult Authenticate([FromBody] InAuthenticateDTO model)
        {
            var response =  BusinessIntance.Authenticate(model);
            return Ok(response);
        }
    }
}