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
            Constants.Headers.OptionalHeaderStandardFields.MagicOffset, 
            Constants.Headers.OptionalHeaderStandardFields.MagicLength).Dump();

        public byte LMajor => Slice.GetSlice(
            Constants.Headers.OptionalHeaderStandardFields.LMajorOffset, 
            Constants.Headers.OptionalHeaderStandardFields.LMajorLength)[0];

        public byte LMinor => Slice.GetSlice(
            Constants.Headers.OptionalHeaderStandardFields.LMinorOffset, 
            Constants.Headers.OptionalHeaderStandardFields.LMinorLength)[0];

        public uint CodeSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderStandardFields.CodeSizeOffset, 
                Constants.Headers.OptionalHeaderStandardFields.CodeSizeLength).Dump(), 0);

        public uint InitializedDataSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderStandardFields.InitializedDataSizeOffset, 
                Constants.Headers.OptionalHeaderStandardFields.InitializedDataSizeLength).Dump(), 0);

        public uint UninitializedDataSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderStandardFields.UninitializedDataSizeOffset, 
                Constants.Headers.OptionalHeaderStandardFields.UninitializedDataSizeLength).Dump(), 0);

        public uint EntryPointRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderStandardFields.EntryPointRvaOffset, 
                Constants.Headers.OptionalHeaderStandardFields.EntryPointRvaLength).Dump(), 0);

        public uint BaseOfCode => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderStandardFields.BaseOfCodeOffset, 
                Constants.Headers.OptionalHeaderStandardFields.BaseOfCodeLength).Dump(), 0);

        public uint BaseOfData => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderStandardFields.BaseOfDataOffset, 
                Constants.Headers.OptionalHeaderStandardFields.BaseOfDataLength).Dump(), 0);

        public OptionalHeaderStandardFields(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            if (Slice.Count > Constants.Headers.OptionalHeaderStandardFields.PeOptionalHeaderLength)
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Standard Fields is too long."));
            }

            if (Slice.Count < Constants.Headers.OptionalHeaderStandardFields.PeOptionalHeaderLength)
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Standard Fields is too short."));
            }

            Validate(collector);
        }

        private void Validate(ExceptionCollector collector)
        {
            var magicTest = Slice.GetSlice(
                Constants.Headers.OptionalHeaderStandardFields.MagicOffset,
                Constants.Headers.OptionalHeaderStandardFields.MagicLength);
            if (magicTest[0] != Constants.Headers.OptionalHeaderStandardFields.MagicValue[0] || magicTest[1] != Constants.Headers.OptionalHeaderStandardFields.MagicValue[1])
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Warning, "The magic values in the PE optional are incorrect."));
            }

            var lMajorTest = Slice.GetSlice(
                Constants.Headers.OptionalHeaderStandardFields.LMajorOffset,
                Constants.Headers.OptionalHeaderStandardFields.LMajorLength);
            if (lMajorTest[0] != Constants.Headers.OptionalHeaderStandardFields.LMajorValue)
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Warning, "The LMajorTest in the PE optional are incorrect."));
            }

            var lMinorTest = Slice.GetSlice(
                Constants.Headers.OptionalHeaderStandardFields.LMinorOffset,
                Constants.Headers.OptionalHeaderStandardFields.LMinorLength);
            if (lMinorTest[0] != Constants.Headers.OptionalHeaderStandardFields.LMinorValue)
            {
                collector.Add(new OptionalHeaderStandardFieldsException(ExceptionLevel.Warning, "The LMinorTest in the PE optional are incorrect."));
            }
        }
    }
}
