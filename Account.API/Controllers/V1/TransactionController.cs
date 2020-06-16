using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Account.API.Configurations;
using Account.DTO.Input;
using Account.Interfaces.Business;
using API.Helper.LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers.V1
{
    public class TransactionController : ApiControllerBase<ITransactionBusiness>
    {
        public TransactionController(ITransactionBusiness securityBusiness, ILoggerManager logger)
            : base(securityBusiness, logger)
        {

        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] InTransactionDTO model)
        {
            return Ok();
        }
    }
}