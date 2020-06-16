using API.Helper.LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.Configurations
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase<TBusiness> : ControllerBase
    {
        protected TBusiness BusinessIntance;
        protected ILoggerManager LoggerIntance;

        public ApiControllerBase(TBusiness business, ILoggerManager logger)
        {
            BusinessIntance = business != null ? business : throw new ArgumentNullException(nameof(logger));
            LoggerIntance = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    }
}
