﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SiremGy.BLL.Interfaces.Exceptions
{
    public class InvalidEmailOrPasswordException : Exception
    {
        const string errorMessage = "Incorrect Email or Password";
        public InvalidEmailOrPasswordException() : base(errorMessage)
        {
        }

        public InvalidEmailOrPasswordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidEmailOrPasswordException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InvalidEmailOrPasswordException(string message) : base(message)
        {
        }
    }
}
