using System;
using HelpfulThings.Parser.PeFile.Common;
using HelpfulThings.Parser.PeFile.Data;
using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile.FileHeaders
{
    public class OptionalHeaderStandardFields : PortableExecutableFilePart
    {
        public byte[] Magic => Slice.GetSlice(
            Data.Header.OptionalHeaderStandardFields.MagicOffset, 
            Data.Header.OptionalHeaderStandardFields.MagicLength).Dump();

        public byte LMajor => Slice.GetSlice(
            Data.Header.OptionalHeaderStandardFields.LMajorOffset, 
            Data.Header.OptionalHeaderStandardFields.LMajorLength)[0];

        public byte LMinor => Slice.GetSlice(
            Data.Header.OptionalHeaderStandardFields.LMinorOffset, 
            Data.Header.OptionalHeaderStandardFields.LMinorLength)[0];

        public uint CodeSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderStandardFields.CodeSizeOffset, 
                Data.Header.OptionalHeaderStandardFields.CodeSizeLength).Dump(), 0);

        public uint InitializedDataSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderStandardFields.InitializedDataSizeOffset, 
                Data.Header.OptionalHeaderStandardFields.InitializedDataSizeLength).Dump(), 0);

        public uint UninitializedDataSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderStandardFields.UninitializedDataSizeOffset, 
                Data.Header.OptionalHeaderStandardFields.UninitializedDataSizeLength).Dump(), 0);

        public uint EntryPointRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderStandardFields.EntryPointRvaOffset, 
                Data.Header.OptionalHeaderStandardFields.EntryPointRvaLength).Dump(), 0);

        public uint BaseOfCode => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderStandardFields.BaseOfCodeOffset, 
                Data.Header.OptionalHeaderStandardFields.BaseOfCodeLength).Dump(), 0);

        public uint BaseOfData => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderStandardFields.BaseOfDataOffset, 
                Data.Header.OptionalHeaderStandardFields.BaseOfDataLength).Dump(), 0);

        public OptionalHeaderStandardFields(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            if (Slice.Count > Data.Header.OptionalHeaderStandardFields.PeOptionalHeaderLength)
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Standard Fields is too long."));
            }

            if (Slice.Count < Data.Header.OptionalHeaderStandardFields.PeOptionalHeaderLength)
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Standard Fields is too short."));
            }

            Validate(collector);
        }

        private void Validate(ExceptionCollector collector)
        {
            var magicTest = Slice.GetSlice(
                Data.Header.OptionalHeaderStandardFields.MagicOffset,
                Data.Header.OptionalHeaderStandardFields.MagicLength);
            if (magicTest[0] != Constants.Headers.OptionalHeaderStandardFields.MagicValue[0] || magicTest[1] != Constants.Headers.OptionalHeaderStandardFields.MagicValue[1])
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Warning, "The magic values in the PE optional are incorrect."));
            }

            var lMajorTest = Slice.GetSlice(
                Data.Header.OptionalHeaderStandardFields.LMajorOffset,
                Data.Header.OptionalHeaderStandardFields.LMajorLength);
            if (lMajorTest[0] != Data.Header.OptionalHeaderStandardFields.LMajorValue)
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Warning, "The LMajorTest in the PE optional are incorrect."));
            }

            var lMinorTest = Slice.GetSlice(
                Data.Header.OptionalHeaderStandardFields.LMinorOffset,
                Data.Header.OptionalHeaderStandardFields.LMinorLength);
            if (lMinorTest[0] != Data.Header.OptionalHeaderStandardFields.LMinorValue)
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Warning, "The LMinorTest in the PE optional are incorrect."));
            }
        }
    }
}
