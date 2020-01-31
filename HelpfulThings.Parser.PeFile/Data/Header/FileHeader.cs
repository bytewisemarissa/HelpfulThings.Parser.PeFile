using System;

namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class FileHeader
    {
        public readonly int PeFileHeaderLength = 24;

        public readonly int SignatureOffset = 0;
        public readonly int SignatureLength = 4;

        public readonly int MachineOffset = 4;
        public readonly int MachineLength = 2;

        public readonly byte[] ExpectedMachineValue = {0x4C, 0x01};

        public readonly int NumberOfSectionsOffset = 6;
        public readonly int NumberOfSectionsLength = 2;

        public readonly int TimeDateStampOffset = 8;
        public readonly int TimeDateStampLength = 4;

        public readonly int PointerToSymbolTableOffset = 12;
        public readonly int PointerToSymbolTableLength = 4;

        public readonly int NumberOfSymbolsOffset = 16;
        public readonly int NumberOfSymbolsLength = 4;

        public readonly int OptionalHeaderSizeOffset = 20;
        public readonly int OptionalHeaderSizeLength = 2;

        public readonly int CharacteristicsOffset = 22;
        public readonly int CharacteristicsLength = 2;

        public readonly DateTime UnixEpocBeginningDateTime = new DateTime(1970, 1, 1);
    }
}
