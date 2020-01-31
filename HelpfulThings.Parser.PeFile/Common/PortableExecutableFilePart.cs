using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile.Common
{
    public abstract class PortableExecutableFilePart
    {
        public MemorySlice Slice { get; }

        protected PortableExecutableFilePart(MemorySlice slice)
        {
            Slice = slice;
        }
    }
}
