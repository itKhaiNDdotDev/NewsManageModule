using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace NewsManageModule.Helpers.Exceptions
{
    public class NMMException : Exception
    {
        public NMMException()
        {
        }

        public NMMException(string message) : base(message)
        {
        }

        public NMMException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //protected NMMException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}
