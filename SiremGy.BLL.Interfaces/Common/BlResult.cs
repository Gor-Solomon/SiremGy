using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SiremGy.BLL.Interfaces.Common
{
    public class BlResult
    {
        public bool Succeed { get; protected set; }
        public string Message { get; protected set; }
        public string ErrorMessage { get; protected set; }
        

        public void Success(string message = null)
        {
            Succeed = true;
            Message = message;
        }

        public BlResult Fail(string errorMessage)
        {
            Succeed = false;
            ErrorMessage = errorMessage;

            return this;
        }
    }

    public class BlResult<T> : BlResult
    {
        public T Value { get; protected set; }

        public BlResult<T> Success(T value, string message = null)
        {
            Succeed = true;
            Message = message;
            Value = value;

            return this;
        }
    }
}
