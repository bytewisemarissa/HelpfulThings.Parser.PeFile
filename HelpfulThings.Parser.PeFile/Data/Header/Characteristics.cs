namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class Characteristics
    {
        public readonly int CharacteristicsLength = 2;

        public readonly uint ImageFileRelocsStrippedMask = 0b0000_0000_0000_0001;
        public readonly uint ImageFileExecutableImageMask = 0b0000_0000_0000_0010;
        public readonly uint ImplementationSpecific1 = 0b0000_0000_0001_0000;
        public readonly uint ImplementationSpecific2 = 0b0000_0000_0010_0000;
        public readonly uint ImplementationSpecific3 = 0b0000_0100_0000_0000;
        public readonly uint ImplementationSpecific4 = 0b0000_1000_0000_0000;
        public readonly uint ImageFile32BitMachineMask = 0b0000_0001_0000_0000;
        public readonly uint ImageFileDllMask = 0b0010_0000_0000_0000;
        public readonly uint ZeroCheck = 0b1101_0010_1100_1100;
    }
}
