using System;
using System.Collections.Generic;
using System.Text;

namespace API.Helper.Exception
{
    public class BaseException : ApplicationException
    {
        public int ExceptionCode { get; set; }

        public BaseException() : base()
        {

        }

        public BaseException(string message, int exceptionCode) : base(message)
        {
            ExceptionCode = exceptionCode;
        }
    }
}
