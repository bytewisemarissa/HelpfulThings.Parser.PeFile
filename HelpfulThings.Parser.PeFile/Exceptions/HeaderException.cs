using System;

namespace HelpfulThings.Parser.PeFile.Exceptions
{
    public class HeaderException : ParserException
    {
        public HeaderException(string message) : base(ExceptionLevel.Critical, message) { }
        public HeaderException(string message, Exception innerException) : base(ExceptionLevel.Critical, message, innerException) { }
    }
}
