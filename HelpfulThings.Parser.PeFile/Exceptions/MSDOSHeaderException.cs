using System;

namespace HelpfulThings.Parser.PeFile.Exceptions
{
    public class MsDosHeaderException : ParserException
    {
        public MsDosHeaderException(string message) : base(ExceptionLevel.Critical, message) { }
        public MsDosHeaderException(string message, Exception innerException) : base(ExceptionLevel.Critical, message, innerException) { }
    }
}
