using API.Helper.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.BusinessLayer.Exception
{
    public class BusinessException : BaseException
    {
        public BusinessException()
        {

        }

        public BusinessException(string message, int exceptionCode)
                :base(message, exceptionCode)
        {

        }
    }
}
