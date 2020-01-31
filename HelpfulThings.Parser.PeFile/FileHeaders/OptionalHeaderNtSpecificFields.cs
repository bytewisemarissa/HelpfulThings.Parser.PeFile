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
                Constants.Headers.OptionalHeaderNtSpecificFields.ImageBaseOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.ImageBaseLength).Dump(), 0);

        public uint SectionAlignment => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.SectionAlignmentOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.SectionAlignmentLength).Dump(), 0);

        public uint FileAlignment => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.FileAlignmentOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.FileAlignmentLength).Dump(), 0);

        public ushort OSMajor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.OSMajorOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.OSMajorLength).Dump(), 0);

        public ushort OSMinor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.OSMinorOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.OSMinorLength).Dump(), 0);

        public ushort UserMajor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.UserMajorOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.UserMajorLength).Dump(), 0);

        public ushort UserMinor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.UserMinorOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.UserMinorLength).Dump(), 0);

        public ushort SubSysMajor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.SubSysMajorOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.SubSysMajorLength).Dump(), 0);

        public ushort SubSysMinor => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.SubSysMinorOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.SubSysMinorLength).Dump(), 0);

        public uint Reserved => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.ReservedOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.ReservedLength).Dump(), 0);

        public uint ImageSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.ImageSizeOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.ImageSizeLength).Dump(), 0);

        public uint HeaderSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.HeaderSizeOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.HeaderSizeLength).Dump(), 0);

        public uint FileChecksum => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.FileChecksumOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.FileChecksumLength).Dump(), 0);

        public ushort SubSystem => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.SubSystemOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.SubSystemLength).Dump(), 0);

        public ushort DLLFlags => BitConverter.ToUInt16(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.DLLFlagsOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.DLLFlagsLength).Dump(), 0);

        public uint StackReserveSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.StackReserveSizeOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.StackReserveSizeLength).Dump(), 0);

        public uint StackCommitSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.StackCommitSizeOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.StackCommitSizeLength).Dump(), 0);

        public uint HeapReserveSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.HeapReserveSizeOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.HeapReserveSizeLength).Dump(), 0);

        public uint HeapCommitSize => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.HeapCommitSizeOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.HeapCommitSizeLength).Dump(), 0);

        public uint LoaderFlags => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.LoaderFlagsOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.LoaderFlagsLength).Dump(), 0);

        public uint NumberOfDataDirectories => BitConverter.ToUInt32(
            Slice.GetSlice(
                Constants.Headers.OptionalHeaderNtSpecificFields.NumberOfDataDirectoriesOffset,
                Constants.Headers.OptionalHeaderNtSpecificFields.NumberOfDataDirectoriesLength).Dump(), 0);
        
        public OptionalHeaderNtSpecificFields(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            Validate(collector);
        }

        private void Validate(ExceptionCollector collector)
        {
            if (Slice.Count > Constants.Headers.OptionalHeaderNtSpecificFields.PeOptionalHeaderNtSpecificFieldsLength)
            {
                collector.Add(new OptionalHeaderNtSpecificFieldsException(ExceptionLevel.Critical, "The PE Optional Headers NT Specific Fields is too long."));
            }

            if (Slice.Count < Constants.Headers.OptionalHeaderNtSpecificFields.PeOptionalHeaderNtSpecificFieldsLength)
            {
                collector.Add(new OptionalHeaderNtSpecificFieldsException(ExceptionLevel.Critical, "The PE Optional Headers Nt Specific Fields is too short."));
            }

            if (ImageBase % Constants.Headers.OptionalHeaderNtSpecificFields.ImageBaseMultiple != 0)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The ImageBase is not a multiple of {Constants.Headers.OptionalHeaderNtSpecificFields.ImageBaseMultiple}."));
            }

            if (SectionAlignment <= FileAlignment)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The SectionAlignment is less than the FileAlignment."));
            }

            if (FileAlignment != Constants.Headers.OptionalHeaderNtSpecificFields.FileAlignmentValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The FileAlignment is not {Constants.Headers.OptionalHeaderNtSpecificFields.FileAlignmentValue}."));
            }

            if (OSMajor != Constants.Headers.OptionalHeaderNtSpecificFields.OSMajorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The OSMajor is not {Constants.Headers.OptionalHeaderNtSpecificFields.OSMajorValue}."));
            }

            if (OSMinor != Constants.Headers.OptionalHeaderNtSpecificFields.OSMinorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The OSMinor is not {Constants.Headers.OptionalHeaderNtSpecificFields.OSMinorValue}."));
            }

            if (UserMajor != Constants.Headers.OptionalHeaderNtSpecificFields.UserMajorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The UserMajor is not {Constants.Headers.OptionalHeaderNtSpecificFields.UserMajorValue}."));
            }

            if (UserMinor != Constants.Headers.OptionalHeaderNtSpecificFields.UserMinorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The UserMinor is not {Constants.Headers.OptionalHeaderNtSpecificFields.UserMinorValue}."));
            }

            if (SubSysMajor != Constants.Headers.OptionalHeaderNtSpecificFields.SubSysMajorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The SubSysMajor is not {Constants.Headers.OptionalHeaderNtSpecificFields.SubSysMajorValue}."));
            }

            if (SubSysMinor != Constants.Headers.OptionalHeaderNtSpecificFields.SubSysMinorValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The SubSysMinor is not {Constants.Headers.OptionalHeaderNtSpecificFields.SubSysMinorValue}."));
            }

            if (Reserved != Constants.Headers.OptionalHeaderNtSpecificFields.ReservedValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The Reserved is not {Constants.Headers.OptionalHeaderNtSpecificFields.ReservedValue}."));
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

            if (FileChecksum != Constants.Headers.OptionalHeaderNtSpecificFields.FileChecksumValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The FileChecksum is not {Constants.Headers.OptionalHeaderNtSpecificFields.FileChecksumValue}."));
            }

            if (Constants.Headers.OptionalHeaderNtSpecificFields.SubSystemValues.All(ss => ss != SubSystem))
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The SubSystem is not {Constants.Headers.OptionalHeaderNtSpecificFields.SubSystemValues[0]} or {Constants.Headers.OptionalHeaderNtSpecificFields.SubSystemValues[1]}."));
            }

            if (StackReserveSize != Constants.Headers.OptionalHeaderNtSpecificFields.StackReserveSizeValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The StackReserveSize is not {Constants.Headers.OptionalHeaderNtSpecificFields.StackReserveSizeValue}."));
            }

            if (StackCommitSize != Constants.Headers.OptionalHeaderNtSpecificFields.StackCommitSizeValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The StackCommitSize is not {Constants.Headers.OptionalHeaderNtSpecificFields.StackCommitSizeValue}."));
            }

            if (HeapReserveSize != Constants.Headers.OptionalHeaderNtSpecificFields.HeapReserveSizeValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The HeapReserveSize is not {Constants.Headers.OptionalHeaderNtSpecificFields.HeapReserveSizeValue}."));
            }

            if (HeapCommitSize != Constants.Headers.OptionalHeaderNtSpecificFields.HeapCommitSizeValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The HeapCommitSize is not {Constants.Headers.OptionalHeaderNtSpecificFields.HeapCommitSizeValue}."));
            }

            if (LoaderFlags != Constants.Headers.OptionalHeaderNtSpecificFields.LoaderFlagsValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The LoaderFlags is not {Constants.Headers.OptionalHeaderNtSpecificFields.LoaderFlagsValue}."));
            }

            if (NumberOfDataDirectories != Constants.Headers.OptionalHeaderNtSpecificFields.NumberOfDataDirectoriesValue)
            {
                collector.Add(
                    new OptionalHeaderNtSpecificFieldsException(
                        ExceptionLevel.Warning,
                        $"The NumberOfDataDirectories is not {Constants.Headers.OptionalHeaderNtSpecificFields.NumberOfDataDirectoriesValue}."));
            }
        }
    }
}
