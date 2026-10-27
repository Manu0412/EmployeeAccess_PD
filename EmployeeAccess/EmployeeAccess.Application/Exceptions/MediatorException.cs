using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeAccess.Application.Exceptions
{
    public class MediatorException : Exception
    {
        public MediatorException(string message) : base(message)
        {
        }
    }
}
