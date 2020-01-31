using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Parser.PeFile.FileHeaders;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile
{
    // ReSharper disable once InconsistentNaming
    public class PortableExecutableFile
    {
        public MemoryWindow Window { get; }
        
        public MsDosHeader MsDosHeader { get; private set; }
        public FileHeader FileHeader { get; private set; }
        public OptionalHeader OptionalHeader { get; private set; }


        public PortableExecutableFile(ExceptionCollector collector, MemoryWindow window)
        {
            Window = window;

            ConstructHeaders(collector);
        }

        private void ConstructHeaders(ExceptionCollector collector)
        {
            MsDosHeader = new MsDosHeader(collector, Window.GetSlice(0, 128));
            FileHeader = new FileHeader(collector, Window.GetSlice(MsDosHeader.LongFileAddressOfNewExeHeader, 24));

            if (FileHeader.OptionalHeaderSize > 0)
            {
                OptionalHeader = new OptionalHeader(collector,
                    Window.GetSlice(MsDosHeader.LongFileAddressOfNewExeHeader + 24,
                        FileHeader.OptionalHeaderSize));
            }
        }
    }
}
