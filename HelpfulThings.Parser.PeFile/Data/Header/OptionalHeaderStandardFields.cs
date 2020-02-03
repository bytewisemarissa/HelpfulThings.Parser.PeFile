namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class OptionalHeaderStandardFields
    {
        public const int PeOptionalHeaderLength = 28;

        public const int MagicOffset = 0;
        public const int MagicLength = 2;
        public readonly byte[] MagicValue = { 0x0B, 0x01 };

        public const int LMajorOffset = 2;
        public const int LMajorLength = 1;
        public const byte LMajorValue = 0x06;

        public const int LMinorOffset = 3;
        public const int LMinorLength = 1;
        public const byte LMinorValue = 0x00;

        public const int CodeSizeOffset = 4;
        public const int CodeSizeLength = 4;

        public const int InitializedDataSizeOffset = 8;
        public const int InitializedDataSizeLength = 4;

        public const int UninitializedDataSizeOffset = 12;
        public const int UninitializedDataSizeLength = 4;

        public const int EntryPointRvaOffset = 16;
        public const int EntryPointRvaLength = 4;

        public const int BaseOfCodeOffset = 20;
        public const int BaseOfCodeLength = 4;

        public const int BaseOfDataOffset = 24;
        public const int BaseOfDataLength = 4;
    }
}
