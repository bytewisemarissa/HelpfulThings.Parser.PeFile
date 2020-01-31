using System;

namespace HelpfulThings.Parser.PeFile.Exceptions
{
    public class OptionalHeaderNtSpecificFieldsException : ParserException
    {
        public OptionalHeaderNtSpecificFieldsException(ExceptionLevel level, string message) : base(level, message) { }
        public OptionalHeaderNtSpecificFieldsException(ExceptionLevel level, string message, Exception innerException) : base(level, message, innerException) { }
    }
}
