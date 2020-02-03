using System;
using System.Linq;
using HelpfulThings.Parser.PeFile.Common;
using HelpfulThings.Parser.PeFile.Data;
using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile.FileHeaders
{
    public class OptionalHeaderNtSpecificFields : PortableExecutableFilePart
    {
        public uint ImageBase => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.ImageBaseOffset,
                Data.Header.OptionalHeaderNtSpecificFields.ImageBaseLength).Dump(), 0);

        public uint SectionAlignment => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.SectionAlignmentOffset,
                Data.Header.OptionalHeaderNtSpecificFields.SectionAlignmentLength).Dump(), 0);

        public uint FileAlignment => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.FileAlignmentOffset,
                Data.Header.OptionalHeaderNtSpecificFields.FileAlignmentLength).Dump(), 0);

        public ushort OSMajor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.OsMajorOffset,
                Data.Header.OptionalHeaderNtSpecificFields.OsMajorLength).Dump(), 0);

        public ushort OSMinor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.OsMinorOffset,
                Data.Header.OptionalHeaderNtSpecificFields.OsMinorLength).Dump(), 0);

        public ushort UserMajor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.UserMajorOffset,
                Data.Header.OptionalHeaderNtSpecificFields.UserMajorLength).Dump(), 0);

        public ushort UserMinor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.UserMinorOffset,
                Data.Header.OptionalHeaderNtSpecificFields.UserMinorLength).Dump(), 0);

        public ushort SubSysMajor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.SubSysMajorOffset,
                Data.Header.OptionalHeaderNtSpecificFields.SubSysMajorLength).Dump(), 0);

        public ushort SubSysMinor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.SubSysMinorOffset,
                Data.Header.OptionalHeaderNtSpecificFields.SubSysMinorLength).Dump(), 0);

        public uint Reserved => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.ReservedOffset,
                Data.Header.OptionalHeaderNtSpecificFields.ReservedLength).Dump(), 0);

        public uint ImageSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.ImageSizeOffset,
                Data.Header.OptionalHeaderNtSpecificFields.ImageSizeLength).Dump(), 0);

        public uint HeaderSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.HeaderSizeOffset,
                Data.Header.OptionalHeaderNtSpecificFields.HeaderSizeLength).Dump(), 0);

        public uint FileChecksum => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.FileChecksumOffset,
                Data.Header.OptionalHeaderNtSpecificFields.FileChecksumLength).Dump(), 0);

        public ushort SubSystem => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.SubSystemOffset,
                Data.Header.OptionalHeaderNtSpecificFields.SubSystemLength).Dump(), 0);

        public ushort DLLFlags => BitConverter.ToUInt16(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.DllFlagsOffset,
                Data.Header.OptionalHeaderNtSpecificFields.DllFlagsLength).Dump(), 0);

        public uint StackReserveSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.StackReserveSizeOffset,
                Data.Header.OptionalHeaderNtSpecificFields.StackReserveSizeLength).Dump(), 0);

        public uint StackCommitSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.StackCommitSizeOffset,
                Data.Header.OptionalHeaderNtSpecificFields.StackCommitSizeLength).Dump(), 0);

        public uint HeapReserveSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.HeapReserveSizeOffset,
                Data.Header.OptionalHeaderNtSpecificFields.HeapReserveSizeLength).Dump(), 0);

        public uint HeapCommitSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.HeapCommitSizeOffset,
                Data.Header.OptionalHeaderNtSpecificFields.HeapCommitSizeLength).Dump(), 0);

        public uint LoaderFlags => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.LoaderFlagsOffset,
                Data.Header.OptionalHeaderNtSpecificFields.LoaderFlagsLength).Dump(), 0);

        public uint NumberOfDataDirectories => BitConverter.ToUInt32(
            Slice.GetSlice(
                Data.Header.OptionalHeaderNtSpecificFields.NumberOfDataDirectoriesOffset,
                Data.Header.OptionalHeaderNtSpecificFields.NumberOfDataDirectoriesLength).Dump(), 0);
        
        public OptionalHeaderNtSpecificFields(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            Validate(collector);
        }

        private void Validate(ExceptionCollector collector)
        {
            if (Slice.Count > Data.Header.OptionalHeaderNtSpecificFields.PeOptionalHeaderNtSpecificFieldsLength)
            {
                collector.Add(new OptionalHeaderNtSpecificFieldsException(ExceptionLevel.Critical, "The PE Optional Headers NT Specific Fields is too long."));
            }

            if (Slice.Count < Data.Header.OptionalHeaderNtSpecificFields.PeOptionalHeaderNtSpecificFieldsLength)
            {
                collector.Add(new OptionalHeaderNtSpecificFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Nt Specific Fields is too short."));
            }

            if (ImageBase % Data.Header.OptionalHeaderNtSpecificFields.ImageBaseMultiple != 0)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The ImageBase is not a multiple of {Data.Header.OptionalHeaderNtSpecificFields.ImageBaseMultiple}."));
            }

            if (SectionAlignment <= FileAlignment)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The SectionAlignment is less than the FileAlignment."));
            }

            if (FileAlignment != Data.Header.OptionalHeaderNtSpecificFields.FileAlignmentValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The FileAlignment is not {Data.Header.OptionalHeaderNtSpecificFields.FileAlignmentValue}."));
            }

            if (OSMajor != Data.Header.OptionalHeaderNtSpecificFields.OsMajorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The OSMajor is not {Data.Header.OptionalHeaderNtSpecificFields.OsMajorValue}."));
            }

            if (OSMinor != Data.Header.OptionalHeaderNtSpecificFields.OsMinorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The OSMinor is not {Data.Header.OptionalHeaderNtSpecificFields.OsMinorValue}."));
            }

            if (UserMajor != Data.Header.OptionalHeaderNtSpecificFields.UserMajorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The UserMajor is not {Data.Header.OptionalHeaderNtSpecificFields.UserMajorValue}."));
            }

            if (UserMinor != Data.Header.OptionalHeaderNtSpecificFields.UserMinorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The UserMinor is not {Data.Header.OptionalHeaderNtSpecificFields.UserMinorValue}."));
            }

            if (SubSysMajor != Data.Header.OptionalHeaderNtSpecificFields.SubSysMajorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The SubSysMajor is not {Data.Header.OptionalHeaderNtSpecificFields.SubSysMajorValue}."));
            }

            if (SubSysMinor != Data.Header.OptionalHeaderNtSpecificFields.SubSysMinorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The SubSysMinor is not {Data.Header.OptionalHeaderNtSpecificFields.SubSysMinorValue}."));
            }

            if (Reserved != Data.Header.OptionalHeaderNtSpecificFields.ReservedValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The Reserved is not {Data.Header.OptionalHeaderNtSpecificFields.ReservedValue}."));
            }

            if (ImageSize % SectionAlignment != 0)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The ImageSize is not a multiple of the SectionAlignment."));
            }

            if (HeaderSize % FileAlignment != 0)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The HeaderSize is not a multiple of FileAlignment."));
            }

            if (FileChecksum != Data.Header.OptionalHeaderNtSpecificFields.FileChecksumValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The FileChecksum is not {Data.Header.OptionalHeaderNtSpecificFields.FileChecksumValue}."));
            }

            if (Constants.Headers.OptionalHeaderNtSpecificFields.SubSystemValues.All(ss => ss != SubSystem))
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The SubSystem is not {Constants.Headers.OptionalHeaderNtSpecificFields.SubSystemValues[0]} or {Constants.Headers.OptionalHeaderNtSpecificFields.SubSystemValues[1]}."));
            }

            if (StackReserveSize != Data.Header.OptionalHeaderNtSpecificFields.StackReserveSizeValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The StackReserveSize is not {Data.Header.OptionalHeaderNtSpecificFields.StackReserveSizeValue}."));
            }

            if (StackCommitSize != Data.Header.OptionalHeaderNtSpecificFields.StackCommitSizeValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The StackCommitSize is not {Data.Header.OptionalHeaderNtSpecificFields.StackCommitSizeValue}."));
            }

            if (HeapReserveSize != Data.Header.OptionalHeaderNtSpecificFields.HeapReserveSizeValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The HeapReserveSize is not {Data.Header.OptionalHeaderNtSpecificFields.HeapReserveSizeValue}."));
            }

            if (HeapCommitSize != Data.Header.OptionalHeaderNtSpecificFields.HeapCommitSizeValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The HeapCommitSize is not {Data.Header.OptionalHeaderNtSpecificFields.HeapCommitSizeValue}."));
            }

            if (LoaderFlags != Data.Header.OptionalHeaderNtSpecificFields.LoaderFlagsValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The LoaderFlags is not {Data.Header.OptionalHeaderNtSpecificFields.LoaderFlagsValue}."));
            }

            if (NumberOfDataDirectories != Data.Header.OptionalHeaderNtSpecificFields.NumberOfDataDirectoriesValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The NumberOfDataDirectories is not {Data.Header.OptionalHeaderNtSpecificFields.NumberOfDataDirectoriesValue}."));
            }
        }
    }
}