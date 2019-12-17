using System;
using System.Collections.Generic;
using System.Text;

namespace SiremGy.BLL.Interfaces.Exceptions
{
    public class UniqueConstraintException : BLLException
    {
        public UniqueConstraintException(string message) : base(message)
        {
        }

        public UniqueConstraintException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public UniqueConstraintException()
        {
        }
    }
}
