using System.Collections.Generic;

namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class OptionalHeaderNtSpecificFields
    {
        public readonly int PeOptionalHeaderNtSpecificFieldsLength = 68;

        public readonly int ImageBaseOffset = 0;
        public readonly int ImageBaseLength = 4;
        public readonly uint ImageBaseMultiple = 0x10000;

        public readonly int SectionAlignmentOffset = 4;
        public readonly int SectionAlignmentLength = 4;

        public readonly int FileAlignmentOffset = 8;
        public readonly int FileAlignmentLength = 4;
        public readonly uint FileAlignmentValue = 0x200;


        public readonly int OSMajorOffset = 12;
        public readonly int OSMajorLength = 2;
        public readonly ushort OSMajorValue = 5;

        public readonly int OSMinorOffset = 14;
        public readonly int OSMinorLength = 2;
        public readonly ushort OSMinorValue = 0;

        public readonly int UserMajorOffset = 16;
        public readonly int UserMajorLength = 2;
        public readonly ushort UserMajorValue = 0;

        public readonly int UserMinorOffset = 18;
        public readonly int UserMinorLength = 2;
        public readonly ushort UserMinorValue = 0;

        public readonly int SubSysMajorOffset = 20;
        public readonly int SubSysMajorLength = 2;
        public readonly ushort SubSysMajorValue = 5;

        public readonly int SubSysMinorOffset = 22;
        public readonly int SubSysMinorLength = 2;
        public readonly ushort SubSysMinorValue = 0;

        public readonly int ReservedOffset = 24;
        public readonly int ReservedLength = 4;
        public readonly uint ReservedValue = 0;

        public readonly int ImageSizeOffset = 28;
        public readonly int ImageSizeLength = 4;

        public readonly int HeaderSizeOffset = 32;
        public readonly int HeaderSizeLength = 4;

        public readonly int FileChecksumOffset = 36;
        public readonly int FileChecksumLength = 4;
        public readonly uint FileChecksumValue = 0;

        public readonly int SubSystemOffset = 40;
        public readonly int SubSystemLength = 2;
        public readonly List<ushort> SubSystemValues = new List<ushort>()
        {
            0x3,
            0x2
        };

        public readonly int DLLFlagsOffset = 42;
        public readonly int DLLFlagsLength = 2;
        public readonly ushort DLLFlagsMask = 0x100f;
        public readonly bool DllFlagsValue = false;

        public readonly int StackReserveSizeOffset = 44;
        public readonly int StackReserveSizeLength = 4;
        public readonly uint StackReserveSizeValue = 0x100000;

        public readonly int StackCommitSizeOffset = 48;
        public readonly int StackCommitSizeLength = 4;
        public readonly uint StackCommitSizeValue = 0x1000;

        public readonly int HeapReserveSizeOffset = 52;
        public readonly int HeapReserveSizeLength = 4;
        public readonly uint HeapReserveSizeValue = 0x100000;

        public readonly int HeapCommitSizeOffset = 56;
        public readonly int HeapCommitSizeLength = 4;
        public readonly uint HeapCommitSizeValue = 0x1000;

        public readonly int LoaderFlagsOffset = 60;
        public readonly int LoaderFlagsLength = 4;
        public readonly uint LoaderFlagsValue = 0;

        public readonly int NumberOfDataDirectoriesOffset = 64;
        public readonly int NumberOfDataDirectoriesLength = 4;
        public readonly uint NumberOfDataDirectoriesValue = 0x10;
    }
}
