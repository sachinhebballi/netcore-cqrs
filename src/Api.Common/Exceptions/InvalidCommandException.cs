﻿using System;

namespace Api.Common.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public string Details { get; }

        public InvalidCommandException(string message = "", string details = "") : base(message)
        {
            Details = details;
        }
    }
}
