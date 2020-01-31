namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class OptionalHeaderStandardFields
    {
        public readonly int PeOptionalHeaderLength = 28;

        public readonly int MagicOffset = 0;
        public readonly int MagicLength = 2;
        public readonly byte[] MagicValue = { 0x0B, 0x01 };

        public readonly int LMajorOffset = 2;
        public readonly int LMajorLength = 1;
        public readonly byte LMajorValue = 0x06;

        public readonly int LMinorOffset = 3;
        public readonly int LMinorLength = 1;
        public readonly byte LMinorValue = 0x00;

        public readonly int CodeSizeOffset = 4;
        public readonly int CodeSizeLength = 4;

        public readonly int InitializedDataSizeOffset = 8;
        public readonly int InitializedDataSizeLength = 4;

        public readonly int UninitializedDataSizeOffset = 12;
        public readonly int UninitializedDataSizeLength = 4;

        public readonly int EntryPointRvaOffset = 16;
        public readonly int EntryPointRvaLength = 4;

        public readonly int BaseOfCodeOffset = 20;
        public readonly int BaseOfCodeLength = 4;

        public readonly int BaseOfDataOffset = 24;
        public readonly int BaseOfDataLength = 4;
    }
}
