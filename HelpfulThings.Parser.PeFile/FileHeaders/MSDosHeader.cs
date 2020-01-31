using System;
using HelpfulThings.Parser.PeFile.Common;
using HelpfulThings.Parser.PeFile.Data;
using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile.FileHeaders
{
    public class MsDosHeader : PortableExecutableFilePart
    {
        public readonly uint LongFileAddressOfNewExeHeader;
        // ReSharper disable once InconsistentNaming
        public uint e_lfanew => LongFileAddressOfNewExeHeader;

        public MsDosHeader(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            if (Slice.Count > Constants.Headers.MsDosHeader.HeaderLength)
            {
                collector.Add(new MsDosHeaderException("The MS-DOS header is too long."));
            }
            if (Slice.Count < Constants.Headers.MsDosHeader.HeaderLength)
            {
                collector.Add(new MsDosHeaderException("The MS-DOS header is too short."));
            }
            
            Validate(collector);

            LongFileAddressOfNewExeHeader = BitConverter.ToUInt32(
                Slice.GetSlice(
                        Constants.Headers.MsDosHeader.LfanewStartingOffset,
                        Constants.Headers.MsDosHeader.LfanewLength)
                    .Dump(), 0);
        }
        
        private void Validate(ExceptionCollector collector)
        {
            var cursor = Slice.GetCursorAtBeginning();

            int iterator = 0;
            while (cursor.Read(out var currentByte))
            {
                if (currentByte != Constants.Headers.MsDosHeader.ValidMsDosHeader[iterator] &&
                    (iterator < Constants.Headers.MsDosHeader.LfanewStartingOffset ||
                     iterator > Constants.Headers.MsDosHeader.LfanewEndingOffset))
                {
                    collector.Add(
                        new MsDosHeaderException($"The MS-DOS header has an invalid byte in offset {iterator}"));
                }

                iterator++;
            }
        }
    }
}
