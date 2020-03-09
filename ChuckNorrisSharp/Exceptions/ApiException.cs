using System;
using System.Collections.Generic;
using System.Text;

namespace ChuckNorrisSharp.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException() { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, Exception inner) : base(message) { }
    }
}
