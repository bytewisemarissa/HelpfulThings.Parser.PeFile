using System;

namespace HelpfulThings.Parser.PeFile.Exceptions
{
    public class CharacteristicsException : ParserException
    {
        public CharacteristicsException(ExceptionLevel level, string message) : base(level, message)
        {
        }

        public CharacteristicsException(ExceptionLevel level, string message, Exception innerException) : base(level, message, innerException)
        {
        }
    }
}
