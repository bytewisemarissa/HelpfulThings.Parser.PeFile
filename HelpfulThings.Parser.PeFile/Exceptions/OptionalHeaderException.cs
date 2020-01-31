using System;

namespace HelpfulThings.Parser.PeFile.Exceptions
{
    public class OptionalHeaderException : ParserException
    {
        public OptionalHeaderException(ExceptionLevel level, string message) : base(level, message) { }
        public OptionalHeaderException(ExceptionLevel level,string message, Exception innerException) : base(level, message, innerException) { }
    }
}
