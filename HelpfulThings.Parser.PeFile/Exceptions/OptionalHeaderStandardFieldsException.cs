using System;

namespace HelpfulThings.Parser.PeFile.Exceptions
{
    public class OptionalHeaderStandardFieldsException : ParserException
    {
        public OptionalHeaderStandardFieldsException(ExceptionLevel level, string message) : base(level, message) { }
        public OptionalHeaderStandardFieldsException(ExceptionLevel level, string message, Exception innerException) : base(level, message, innerException) { }
    }
}
