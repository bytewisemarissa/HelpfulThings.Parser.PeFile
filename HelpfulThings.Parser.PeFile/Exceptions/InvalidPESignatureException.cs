using System;

namespace HelpfulThings.Parser.PeFile.Exceptions
{
    public class InvalidPeSignatureException : ParserException
    {
        public InvalidPeSignatureException(string message) : base(ExceptionLevel.Critical, message) { }
        public InvalidPeSignatureException(string message, Exception innerException) : base(ExceptionLevel.Critical, message, innerException) { }
    }
}
