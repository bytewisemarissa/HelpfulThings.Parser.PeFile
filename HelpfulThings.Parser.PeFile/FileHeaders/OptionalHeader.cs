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
            if (Slice.Count > Constants.Headers.OptionalHeader.PeOptionalHeaderLength)
            {
                collector.Add(new OptionalHeaderException(ExceptionLevel.Critical, "The PE Optional header is too long."));
            }
            if (Slice.Count < Constants.Headers.OptionalHeader.PeOptionalHeaderLength)
            {
                collector.Add(new OptionalHeaderException(ExceptionLevel.Critical, "The PE Optional header is too short."));
            }

            StandardFields = new OptionalHeaderStandardFields(collector, slice.GetSlice(
                Constants.Headers.OptionalHeader.StandardFieldsOffset,
                Constants.Headers.OptionalHeader.StandardFieldsLength));

            NtSpecificFields = new OptionalHeaderNtSpecificFields(collector, slice.GetSlice(
                Constants.Headers.OptionalHeader.NtSpecificFieldsOffset,
                Constants.Headers.OptionalHeader.NtSpecificFieldsLength));
        }


    }
}
