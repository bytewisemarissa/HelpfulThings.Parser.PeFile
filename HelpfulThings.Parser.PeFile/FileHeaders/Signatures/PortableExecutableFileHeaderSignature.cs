using System.Linq;
using System.Text;
using HelpfulThings.Parser.PeFile.Common;
using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile.FileHeaders.Signatures
{
    public class PortableExecutableFileHeaderSignature : PortableExecutableFilePart
    {
        public byte[] HeaderValue => Slice.Dump();

        public PortableExecutableFileHeaderSignature(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            Validate(collector);
        }

        private void Validate(ExceptionCollector collector)
        {
            if ((Slice[0] != Encoding.ASCII.GetBytes("P").First()) ||
                (Slice[1] != Encoding.ASCII.GetBytes("E").First()) ||
                (Slice[2] != 0) ||
                (Slice[3] != 0))
            {
                throw new InvalidPeSignatureException("The PE Signature was invalid.");
            }
        }
    }
}
