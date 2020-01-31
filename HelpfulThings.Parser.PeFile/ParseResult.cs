using System.Collections.Generic;
using HelpfulThings.Parser.PeFile.Exceptions;

namespace HelpfulThings.Parser.PeFile
{
    public class ParseResult
    {
        public bool ParsedSuccessfully { get; }
        public List<ParserException> Exceptions { get; }

        public ParseResult(bool parsedSuccessfully, List<ParserException> exceptions)
        {
            ParsedSuccessfully = parsedSuccessfully;
            Exceptions = exceptions;
        }
    }
}
