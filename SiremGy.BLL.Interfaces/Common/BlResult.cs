using System;
using System.Collections.Generic;
using System.Text;

namespace SiremGy.BLL.Interfaces.Common
{
    public class BlResult
    {
        public bool Succeed { get; protected set; }
        public string ErrorMessage { get; protected set; }
        public Exception Exception { get; protected set; }

        public void Success()
        {
            Succeed = true;
        }

        public BlResult Fail(string errorMessage)
        {
            return Fail(errorMessage, null);
        }

        public BlResult Fail(Exception exception)
        {
            return Fail(exception?.Message, exception);
        }

        public BlResult Fail(string errorMessage, Exception exception)
        {
            Succeed = false;
            ErrorMessage = errorMessage;
            Exception = exception;

            return this;
        }
    }

    public class BlResult<T> : BlResult
    {
        public T Value { get; protected set; }

        public BlResult<T> Success(T value)
        {
            Succeed = true;
            Value = value;

            return this;
        }
    }
}
