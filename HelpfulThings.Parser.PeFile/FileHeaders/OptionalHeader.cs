using HelpfulThings.Parser.PeFile.Common;
using HelpfulThings.Parser.PeFile.Data;
using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile.FileHeaders
{
    public class OptionalHeader : PortableExecutableFilePart
    {
        public OptionalHeaderStandardFields StandardFields { get; }

        public OptionalHeaderNtSpecificFields NtSpecificFields { get; }

        public OptionalHeader(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            if (Slice.Count > Data.Header.OptionalHeader.PeOptionalHeaderLength)
            {
                collector.Add(new OptionalHeaderException(ExceptionLevel.Critical, "The PE Optional header is too long."));
            }
            if (Slice.Count < Data.Header.OptionalHeader.PeOptionalHeaderLength)
            {
                collector.Add(new OptionalHeaderException(ExceptionLevel.Critical, "The PE Optional header is too short."));
            }

            StandardFields = new OptionalHeaderStandardFields(collector, slice.GetSlice(
                Data.Header.OptionalHeader.StandardFieldsOffset,
                Data.Header.OptionalHeader.StandardFieldsLength));

            NtSpecificFields = new OptionalHeaderNtSpecificFields(collector, slice.GetSlice(
                Data.Header.OptionalHeader.NtSpecificFieldsOffset,
                Data.Header.OptionalHeader.NtSpecificFieldsLength));
        }


    }
}
