namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class OptionalHeader
    {
        public readonly int PeOptionalHeaderLength = 224;

        public readonly int StandardFieldsOffset = 0;
        public readonly int StandardFieldsLength = 28;

        public readonly int NtSpecificFieldsOffset = 28;
        public readonly int NtSpecificFieldsLength = 68;

        public readonly int DataDirectoriesOffset = 96;
        public readonly int DataDirectoriesLength = 128;
    }
}
