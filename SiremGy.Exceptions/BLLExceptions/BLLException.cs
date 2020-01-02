using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace SiremGy.Exceptions.BLLExceptions
{
    public class BLLException : Exception
    {
        public BLLException(string message) : base(message)
        {
        }

        public BLLException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BLLException()
        {
        }

        protected BLLException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
