using System;

namespace Api.Common.Exceptions
{
    public class MissingResourceException : Exception
    {
        public string Details { get; }

        public MissingResourceException(string message = "", string details = "") : base(message)
        {
            Details = details;
        }
    }
}
