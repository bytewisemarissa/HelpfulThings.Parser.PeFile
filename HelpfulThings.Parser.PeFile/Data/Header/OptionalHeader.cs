namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class OptionalHeader
    {
        public const int PeOptionalHeaderLength = 224;

        public const int StandardFieldsOffset = 0;
        public const int StandardFieldsLength = 28;

        public const int NtSpecificFieldsOffset = 28;
        public const int NtSpecificFieldsLength = 68;

        public const int DataDirectoriesOffset = 96;
        public const int DataDirectoriesLength = 128;
    }
}
