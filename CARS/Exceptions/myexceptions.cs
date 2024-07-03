using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CARS.Exceptions
{
    public class IncidentNumberNotFoundException : Exception
    {
        public IncidentNumberNotFoundException()
        {
        }
        public IncidentNumberNotFoundException(string message) : base(message) 
        {
        }
    }

    public class InvalidDateFormat : Exception
    {
        public InvalidDateFormat()
        {
        }
        public InvalidDateFormat(string message) : base(message)
        {
        }
    }

    public class UserNameNotFoundException : Exception
    {
        public UserNameNotFoundException() 
        {
        }

        public UserNameNotFoundException(string message) : base(message) 
        {
        }
    }


    public class latitudeOutOfRange : Exception
    {
        public latitudeOutOfRange()
        {
        }

        public latitudeOutOfRange(string message) : base(message) 
        { 
        }
    }

    public class longitudeOutOfRange : Exception
    {
        public longitudeOutOfRange()
        {
        }

        public longitudeOutOfRange(string message) : base(message) 
        {
        }
    }
    public class NoSuchPersonFoundException : Exception
    {
        public NoSuchPersonFoundException()
        {
        }

        public NoSuchPersonFoundException(string message) : base(message)
        {
        }
    }
}
