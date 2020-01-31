using System.Linq;
using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile
{
    public interface IPortableExecutableParser
    {
        ParseResult Parse(byte[] fileBytes, out PortableExecutableFile file);
    }

    public class PortableExecutableParser : IPortableExecutableParser
    {
        public ParserExceptionOption ExceptionOption { get; set; }

        public PortableExecutableParser()
        {
            ExceptionOption = ParserExceptionOption.ContinueSafely;
        }

        public ParseResult Parse(byte[] fileBytes, out PortableExecutableFile file)
        {
            ExceptionCollector collector = new ExceptionCollector(ExceptionOption);

            //try
            //{
                file = new PortableExecutableFile(collector, new MemoryWindow(fileBytes));

                return new ParseResult(true, collector.ToList());
            //}
            //catch
            //{
            //    file = null;

            //    return new ParseResult(false, collector.ToList());
            //}
        }
    }
}
