using System;
using System.Collections.Generic;

namespace Presentation.Utils
{
    public class AppException : Exception
    {
        internal List<string> _errors;
        
        public IReadOnlyList<string> Errors => _errors;

        public AppException()
        {}

        public AppException(string message, List<string> errors) : base(message)
        {
            _errors = errors;
        }

        public AppException(string message) : base(message)
        { }

        public AppException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}