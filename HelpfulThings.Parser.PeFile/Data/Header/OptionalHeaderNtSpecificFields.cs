using System.Collections.Generic;

namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class OptionalHeaderNtSpecificFields
    {
        public const int PeOptionalHeaderNtSpecificFieldsLength = 68;

        public const int ImageBaseOffset = 0;
        public const int ImageBaseLength = 4;
        public const uint ImageBaseMultiple = 0x10000;

        public const int SectionAlignmentOffset = 4;
        public const int SectionAlignmentLength = 4;

        public const int FileAlignmentOffset = 8;
        public const int FileAlignmentLength = 4;
        public const uint FileAlignmentValue = 0x200;


        public const int OsMajorOffset = 12;
        public const int OsMajorLength = 2;
        public const ushort OsMajorValue = 5;

        public const int OsMinorOffset = 14;
        public const int OsMinorLength = 2;
        public const ushort OsMinorValue = 0;

        public const int UserMajorOffset = 16;
        public const int UserMajorLength = 2;
        public const ushort UserMajorValue = 0;

        public const int UserMinorOffset = 18;
        public const int UserMinorLength = 2;
        public const ushort UserMinorValue = 0;

        public const int SubSysMajorOffset = 20;
        public const int SubSysMajorLength = 2;
        public const ushort SubSysMajorValue = 5;

        public const int SubSysMinorOffset = 22;
        public const int SubSysMinorLength = 2;
        public const ushort SubSysMinorValue = 0;

        public const int ReservedOffset = 24;
        public const int ReservedLength = 4;
        public const uint ReservedValue = 0;

        public const int ImageSizeOffset = 28;
        public const int ImageSizeLength = 4;

        public const int HeaderSizeOffset = 32;
        public const int HeaderSizeLength = 4;

        public const int FileChecksumOffset = 36;
        public const int FileChecksumLength = 4;
        public const uint FileChecksumValue = 0;

        public const int SubSystemOffset = 40;
        public const int SubSystemLength = 2;

        public readonly List<ushort> SubSystemValues = new List<ushort>()
        {
            0x3,
            0x2
        };

        public const int DllFlagsOffset = 42;
        public const int DllFlagsLength = 2;
        public const ushort DllFlagsMask = 0x100f;
        public const bool DllFlagsValue = false;

        public const int StackReserveSizeOffset = 44;
        public const int StackReserveSizeLength = 4;
        public const uint StackReserveSizeValue = 0x100000;

        public const int StackCommitSizeOffset = 48;
        public const int StackCommitSizeLength = 4;
        public const uint StackCommitSizeValue = 0x1000;

        public const int HeapReserveSizeOffset = 52;
        public const int HeapReserveSizeLength = 4;
        public const uint HeapReserveSizeValue = 0x100000;

        public const int HeapCommitSizeOffset = 56;
        public const int HeapCommitSizeLength = 4;
        public const uint HeapCommitSizeValue = 0x1000;

        public const int LoaderFlagsOffset = 60;
        public const int LoaderFlagsLength = 4;
        public const uint LoaderFlagsValue = 0;

        public const int NumberOfDataDirectoriesOffset = 64;
        public const int NumberOfDataDirectoriesLength = 4;
        public const uint NumberOfDataDirectoriesValue = 0x10;
    }
}
