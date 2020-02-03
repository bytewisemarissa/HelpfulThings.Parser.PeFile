using System;
using HelpfulThings.Parser.PeFile.Common;
using HelpfulThings.Parser.PeFile.Data;
using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Parser.PeFile.FileHeaders.Signatures;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile.FileHeaders
{
    public class FileHeader : PortableExecutableFilePart
    {
        public FileHeaderCharacteristics Characteristics { get; }

        public PortableExecutableFileHeaderSignature Signature { get; }

        public byte[] Machine => Slice.GetSlice(
            Data.Header.FileHeader.MachineOffset,
            Data.Header.FileHeader.MachineLength).Dump();

        public UInt16 NumberOfSections => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.FileHeader.NumberOfSectionsOffset,
                Data.Header.FileHeader.NumberOfSectionsLength).Dump(), 0);

        public UInt32 PointerToSymbolTable => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.FileHeader.PointerToSymbolTableOffset,
                Data.Header.FileHeader.PointerToSymbolTableLength).Dump(), 0);

        public UInt32 NumberOfSymbols => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.FileHeader.NumberOfSymbolsOffset,
                Data.Header.FileHeader.NumberOfSymbolsLength).Dump(), 0);

        public UInt16 OptionalHeaderSize => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.FileHeader.OptionalHeaderSizeOffset,
                Data.Header.FileHeader.OptionalHeaderSizeLength).Dump(), 0);

        public DateTime TimestampUtc
        {
            get
            {
                UInt32 seconds = BitConverter.ToUInt32(
                    Slice.GetSlice(
                        Data.Header.FileHeader.TimeDateStampOffset,
                        Data.Header.FileHeader.TimeDateStampLength).Dump(), 0);

                return Constants.Headers.FileHeader.UnixEpocBeginningDateTime.AddSeconds(seconds);
            }
        }

        public FileHeader(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            if (Slice.Count > Data.Header.FileHeader.PeFileHeaderLength)
            {
                collector.Add(new HeaderException("The PE File header is too long."));
            }
            if (Slice.Count < Data.Header.FileHeader.PeFileHeaderLength)
            {
                collector.Add(new HeaderException("The PE File header is too short."));
            }

            Signature = new PortableExecutableFileHeaderSignature(
                collector,
                Slice.GetSlice(
                    Data.Header.FileHeader.SignatureOffset,
                    Data.Header.FileHeader.SignatureLength));

            Validate(collector);

            Characteristics = new FileHeaderCharacteristics(collector,
                Slice.GetSlice(
                    Data.Header.FileHeader.CharacteristicsOffset,
                    Data.Header.FileHeader.CharacteristicsLength));
        }

        private void Validate(ExceptionCollector collector)
        {
            var machineSlice = Slice.GetSlice(
                Data.Header.FileHeader.MachineOffset,
                Data.Header.FileHeader.MachineLength);
            
            if (machineSlice[0] != Constants.Headers.FileHeader.ExpectedMachineValue[0] || machineSlice[1] != Constants.Headers.FileHeader.ExpectedMachineValue[1])
            {
                collector.Add(new HeaderException("The Machine value does not match 0x14c."));
            }

            if (BitConverter.ToUInt32(
                    Slice.GetSlice(
                        Data.Header.FileHeader.PointerToSymbolTableOffset,
                        Data.Header.FileHeader.PointerToSymbolTableLength).Dump(), 0) != 0)
            {
                collector.Add(new HeaderException("The Pointer to Symbol Table value does not match 0x0."));
            }

            if (BitConverter.ToUInt32(Slice.GetSlice(
                    Data.Header.FileHeader.NumberOfSymbolsOffset,
                    Data.Header.FileHeader.NumberOfSymbolsLength).Dump(), 0) != 0)
            {
                collector.Add(new HeaderException("The Number of Symbols value does not match 0x0."));
            }
        }
    }
}
