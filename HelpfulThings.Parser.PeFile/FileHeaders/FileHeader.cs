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
            Constants.Headers.FileHeader.MachineOffset,
            Constants.Headers.FileHeader.MachineLength).Dump();

        public UInt16 NumberOfSections => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.FileHeader.NumberOfSectionsOffset,
                Constants.Headers.FileHeader.NumberOfSectionsLength).Dump(), 0);

        public UInt32 PointerToSymbolTable => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.FileHeader.PointerToSymbolTableOffset,
                Constants.Headers.FileHeader.PointerToSymbolTableLength).Dump(), 0);

        public UInt32 NumberOfSymbols => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.FileHeader.NumberOfSymbolsOffset,
                Constants.Headers.FileHeader.NumberOfSymbolsLength).Dump(), 0);

        public UInt16 OptionalHeaderSize => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.FileHeader.OptionalHeaderSizeOffset,
                Constants.Headers.FileHeader.OptionalHeaderSizeLength).Dump(), 0);

        public DateTime TimestampUtc
        {
            get
            {
                UInt32 seconds = BitConverter.ToUInt32(
                    Slice.GetSlice(
                        Constants.Headers.FileHeader.TimeDateStampOffset,
                        Constants.Headers.FileHeader.TimeDateStampLength).Dump(), 0);

                return Constants.Headers.FileHeader.UnixEpocBeginningDateTime.AddSeconds(seconds);
            }
        }

        public FileHeader(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            if (Slice.Count > Constants.Headers.FileHeader.PeFileHeaderLength)
            {
                collector.Add(new HeaderException("The PE File header is too long."));
            }
            if (Slice.Count < Constants.Headers.FileHeader.PeFileHeaderLength)
            {
                collector.Add(new HeaderException("The PE File header is too short."));
            }

            Signature = new PortableExecutableFileHeaderSignature(
                collector,
                Slice.GetSlice(
                    Constants.Headers.FileHeader.SignatureOffset,
                    Constants.Headers.FileHeader.SignatureLength));

            Validate(collector);

            Characteristics = new FileHeaderCharacteristics(collector,
                Slice.GetSlice(
                    Constants.Headers.FileHeader.CharacteristicsOffset,
                    Constants.Headers.FileHeader.CharacteristicsLength));
        }

        private void Validate(ExceptionCollector collector)
        {
            var machineSlice = Slice.GetSlice(
                Constants.Headers.FileHeader.MachineOffset,
                Constants.Headers.FileHeader.MachineLength);
            
            if (machineSlice[0] != Constants.Headers.FileHeader.ExpectedMachineValue[0] || machineSlice[1] != Constants.Headers.FileHeader.ExpectedMachineValue[1])
            {
                collector.Add(new HeaderException("The Machine value does not match 0x14c."));
            }

            if (BitConverter.ToUInt32(
                    Slice.GetSlice(
                        Constants.Headers.FileHeader.PointerToSymbolTableOffset,
                        Constants.Headers.FileHeader.PointerToSymbolTableLength).Dump(), 0) != 0)
            {
                collector.Add(new HeaderException("The Pointer to Symbol Table value does not match 0x0."));
            }

            if (BitConverter.ToUInt32(Slice.GetSlice(
                    Constants.Headers.FileHeader.NumberOfSymbolsOffset,
                    Constants.Headers.FileHeader.NumberOfSymbolsLength).Dump(), 0) != 0)
            {
                collector.Add(new HeaderException("The Number of Symbols value does not match 0x0."));
            }
        }
    }
}
