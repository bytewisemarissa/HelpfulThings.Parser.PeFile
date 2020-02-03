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
                Data.Header.OptionalHeaderDataDirectories.ExportTableRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.ExportTableRvaLength).Dump(), 0);

        public uint ExportTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.ExportTableLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.ExportTableLengthLength).Dump(), 0);

        public uint ImportTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.ImportTableRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.ImportTableRvaLength).Dump(), 0);

        public uint ImportTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.ImportTableLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.ImportTableLengthLength).Dump(), 0);

        public uint ResourceTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.ResourceTableRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.ResourceTableRvaLength).Dump(), 0);

        public uint ResourceTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.ResourceTableLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.ResourceTableLengthLength).Dump(), 0);

        public uint ExceptionTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.ExceptionTableRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.ExceptionTableRvaLength).Dump(), 0);

        public uint ExceptionTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.ExceptionTableLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.ExceptionTableLengthLength).Dump(), 0);

        public uint CertificateTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.CertificateTableRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.CertificateTableRvaLength).Dump(), 0);

        public uint CertificateTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.CertificateTableLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.CertificateTableLengthLength).Dump(), 0);

        public uint BaseRelocationTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.BaseRelocationTableRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.BaseRelocationTableRvaLength).Dump(), 0);

        public uint BaseRelocationTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.BaseRelocationTableLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.BaseRelocationTableLengthLength).Dump(), 0);

        public bool BaseRelocationIsInUse => BaseRelocationTableRva != 0 && BaseRelocationTableLength != 0;

        public uint DebugRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.DebugRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.DebugRvaLength).Dump(), 0);

        public uint DebugLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.DebugLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.DebugLengthLength).Dump(), 0);

        public uint CopyrightRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.CopyrightRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.CopyrightRvaLength).Dump(), 0);

        public uint CopyrightLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.CopyrightLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.CopyrightLengthLength).Dump(), 0);

        public uint GlobalPtrRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.GlobalPtrRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.GlobalPtrRvaLength).Dump(), 0);

        public uint GlobalPtrLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.GlobalPtrLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.GlobalPtrLengthLength).Dump(), 0);

        public uint TlsTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.TlsTableRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.TlsTableRvaLength).Dump(), 0);

        public uint TlsTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.TlsTableLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.TlsTableLengthLength).Dump(), 0);

        public uint LoadConfigTableRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.LoadConfigTableRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.LoadConfigTableRvaLength).Dump(), 0);

        public uint LoadConfigTableLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.LoadConfigTableLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.LoadConfigTableLengthLength).Dump(), 0);

        public uint BoundImportRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.BoundImportRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.BoundImportRvaLength).Dump(), 0);

        public uint BoundImportLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.BoundImportLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.BoundImportLengthLength).Dump(), 0);

        public uint IatRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.IatRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.IatRvaLength).Dump(), 0);

        public uint IatLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.IatLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.IatLengthLength).Dump(), 0);

        public uint DelayImportDescriptorRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.DelayImportDescriptorRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.DelayImportDescriptorRvaLength).Dump(), 0);

        public uint DelayImportDescriptorLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.DelayImportDescriptorLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.DelayImportDescriptorLengthLength).Dump(), 0);

        public uint CliHeaderRva => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.CliHeaderRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.CliHeaderRvaLength).Dump(), 0);

        public uint CliHeaderLength => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.CliHeaderLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.CliHeaderLengthLength).Dump(), 0);

        public uint Reserved => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.ReservedRvaOffset,
                Data.Header.OptionalHeaderDataDirectories.ReservedRvaLength).Dump(), 0);

        public uint Length => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderDataDirectories.ReservedLengthOffset,
                Data.Header.OptionalHeaderDataDirectories.ReservedLengthLength).Dump(), 0);
        
        public OptionalHeaderDataDirectories(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            Validate(collector);
        }

        private void Validate(ExceptionCollector collector)
        {
            if (Slice.Count > Data.Header.OptionalHeaderDataDirectories.OptionalHeaderDataDirectoriesLength)
            {
                collector.Add(new OptionalHeaderNtSpecificFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Data Directories is too long."));
            }

            if (Slice.Count < Data.Header.OptionalHeaderDataDirectories.OptionalHeaderDataDirectoriesLength)
            {
                collector.Add(new OptionalHeaderNtSpecificFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Data Directories is too short."));
            }
        }
    }
}
