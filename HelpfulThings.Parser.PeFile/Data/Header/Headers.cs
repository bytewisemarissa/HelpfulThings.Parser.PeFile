namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class Headers
    {
        public readonly MsDosHeader MsDosHeader = new MsDosHeader();
        public readonly FileHeader FileHeader = new FileHeader();
        public readonly OptionalHeader OptionalHeader = new OptionalHeader();
        public readonly OptionalHeaderStandardFields OptionalHeaderStandardFields = new OptionalHeaderStandardFields();
        public readonly OptionalHeaderNtSpecificFields OptionalHeaderNtSpecificFields = new OptionalHeaderNtSpecificFields();
        public readonly OptionalHeaderDataDirectories OptionalHeaderDataDirectories = new OptionalHeaderDataDirectories();
        public readonly Characteristics Characteristics = new Characteristics();
    }
}
