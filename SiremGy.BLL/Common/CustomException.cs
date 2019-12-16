using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SiremGy.BLL.Common
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1064:Exceptions should be public", Justification = "<Pending>")]
    internal class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CustomException()
        {
        }

        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
