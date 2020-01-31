using System;

namespace HelpfulThings.Parser.PeFile.Exceptions
{
    public class ParserException : Exception
    {
        public readonly ExceptionLevel Level;

        public ParserException(ExceptionLevel level, string message) : base(message)
        {
            Level = level;
        }

        public ParserException(ExceptionLevel level, string message, Exception innerException) : base(message, innerException)
        {
            Level = level;
        }
    }
}
