using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class UserException : Exception
    {
        public UserException()
            : base() { }

        public UserException(string message)
            : base(message) { }

        public UserException(string message, Exception inner)
            : base(message, inner) { }

        public UserException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
