using System;

namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class FileHeader
    {
        public const int PeFileHeaderLength = 24;

        public const int SignatureOffset = 0;
        public const int SignatureLength = 4;

        public const int MachineOffset = 4;
        public const int MachineLength = 2;

        public readonly byte[] ExpectedMachineValue = {0x4C, 0x01};

        public const int NumberOfSectionsOffset = 6;
        public const int NumberOfSectionsLength = 2;

        public const int TimeDateStampOffset = 8;
        public const int TimeDateStampLength = 4;

        public const int PointerToSymbolTableOffset = 12;
        public const int PointerToSymbolTableLength = 4;

        public const int NumberOfSymbolsOffset = 16;
        public const int NumberOfSymbolsLength = 4;

        public const int OptionalHeaderSizeOffset = 20;
        public const int OptionalHeaderSizeLength = 2;

        public const int CharacteristicsOffset = 22;
        public const int CharacteristicsLength = 2;

        public readonly DateTime UnixEpocBeginningDateTime = new DateTime(1970, 1, 1);
    }
}
