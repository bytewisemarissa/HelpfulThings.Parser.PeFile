namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class Characteristics
    {
        public const int CharacteristicsLength = 2;

        public const uint ImageFileRelocsStrippedMask = 0b0000_0000_0000_0001;
        public const uint ImageFileExecutableImageMask = 0b0000_0000_0000_0010;
        public const uint ImplementationSpecific1 = 0b0000_0000_0001_0000;
        public const uint ImplementationSpecific2 = 0b0000_0000_0010_0000;
        public const uint ImplementationSpecific3 = 0b0000_0100_0000_0000;
        public const uint ImplementationSpecific4 = 0b0000_1000_0000_0000;
        public const uint ImageFile32BitMachineMask = 0b0000_0001_0000_0000;
        public const uint ImageFileDllMask = 0b0010_0000_0000_0000;
        public const uint ZeroCheck = 0b1101_0010_1100_1100;
    }
}
