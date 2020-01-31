using System;
using HelpfulThings.Parser.PeFile.Common;
using HelpfulThings.Parser.PeFile.Data;
using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile.FileHeaders
{
    public class OptionalHeaderDataDirectories : PortableExecutableFilePart
    {
        public uint ExportTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ExportTableRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ExportTableRvaLength).Dump(), 0);

        public uint ExportTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ExportTableLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ExportTableLengthLength).Dump(), 0);

        public uint ImportTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ImportTableRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ImportTableRvaLength).Dump(), 0);

        public uint ImportTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ImportTableLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ImportTableLengthLength).Dump(), 0);

        public uint ResourceTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ResourceTableRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ResourceTableRvaLength).Dump(), 0);

        public uint ResourceTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ResourceTableLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ResourceTableLengthLength).Dump(), 0);

        public uint ExceptionTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ExceptionTableRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ExceptionTableRvaLength).Dump(), 0);

        public uint ExceptionTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ExceptionTableLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ExceptionTableLengthLength).Dump(), 0);

        public uint CertificateTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.CertificateTableRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.CertificateTableRvaLength).Dump(), 0);

        public uint CertificateTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.CertificateTableLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.CertificateTableLengthLength).Dump(), 0);

        public uint BaseRelocationTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.BaseRelocationTableRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.BaseRelocationTableRvaLength).Dump(), 0);

        public uint BaseRelocationTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.BaseRelocationTableLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.BaseRelocationTableLengthLength).Dump(), 0);

        public bool BaseRelocationIsInUse => BaseRelocationTableRva != 0 && BaseRelocationTableLength != 0;

        public uint DebugRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.DebugRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.DebugRvaLength).Dump(), 0);

        public uint DebugLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.DebugLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.DebugLengthLength).Dump(), 0);

        public uint CopyrightRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.CopyrightRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.CopyrightRvaLength).Dump(), 0);

        public uint CopyrightLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.CopyrightLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.CopyrightLengthLength).Dump(), 0);

        public uint GlobalPtrRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.GlobalPtrRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.GlobalPtrRvaLength).Dump(), 0);

        public uint GlobalPtrLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.GlobalPtrLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.GlobalPtrLengthLength).Dump(), 0);

        public uint TlsTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.TlsTableRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.TlsTableRvaLength).Dump(), 0);

        public uint TlsTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.TlsTableLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.TlsTableLengthLength).Dump(), 0);

        public uint LoadConfigTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.LoadConfigTableRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.LoadConfigTableRvaLength).Dump(), 0);

        public uint LoadConfigTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.LoadConfigTableLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.LoadConfigTableLengthLength).Dump(), 0);

        public uint BoundImportRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.BoundImportRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.BoundImportRvaLength).Dump(), 0);

        public uint BoundImportLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.BoundImportLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.BoundImportLengthLength).Dump(), 0);

        public uint IatRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.IatRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.IatRvaLength).Dump(), 0);

        public uint IatLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.IatLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.IatLengthLength).Dump(), 0);

        public uint DelayImportDescriptorRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.DelayImportDescriptorRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.DelayImportDescriptorRvaLength).Dump(), 0);

        public uint DelayImportDescriptorLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.DelayImportDescriptorLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.DelayImportDescriptorLengthLength).Dump(), 0);

        public uint CliHeaderRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.CliHeaderRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.CliHeaderRvaLength).Dump(), 0);

        public uint CliHeaderLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.CliHeaderLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.CliHeaderLengthLength).Dump(), 0);

        public uint Reserved => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ReservedRvaOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ReservedRvaLength).Dump(), 0);

        public uint Length => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderDataDirectories.ReservedLengthOffset,
                Constants.Headers.OptionalHeaderDataDirectories.ReservedLengthLength).Dump(), 0);
        
        public OptionalHeaderDataDirectories(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            Validate(collector);
        }

        private void Validate(ExceptionCollector collector)
        {
            if (Slice.Count > Constants.Headers.OptionalHeaderDataDirectories.OptionalHeaderDataDirectoriesLength)
            {
                collector.Add(new OptionalHeaderNtSpecificFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Data Directories is too long."));
            }

            if (Slice.Count < Constants.Headers.OptionalHeaderDataDirectories.OptionalHeaderDataDirectoriesLength)
            {
                collector.Add(new OptionalHeaderNtSpecificFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Data Directories is too short."));
            }


        }
    }
}
