using HelpfulThings.Parser.PeFile;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PEFileParser.Tests
{
    [TestClass]
    public class PortableExecutableParserTests
    {
        private PortableExecutableParser _parserUnderTest;

        public PortableExecutableParserTests()
        {
            _parserUnderTest = new PortableExecutableParser();
        }

        [TestMethod]
        public void Parse_HelloWorld()
        {
            var result = _parserUnderTest.Parse(ByteCollections.HelloWorldBytes, out var file);

            Assert.IsNotNull(file);
        }
    }
}
