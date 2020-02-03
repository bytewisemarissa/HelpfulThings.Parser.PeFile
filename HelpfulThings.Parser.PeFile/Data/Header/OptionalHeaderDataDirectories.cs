namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class OptionalHeaderDataDirectories
    {
        public const int OptionalHeaderDataDirectoriesLength = 128;

        public const int ExportTableRvaOffset = 0;
        public const int ExportTableRvaLength = 4;

        public const int ExportTableLengthOffset = 4;
        public const int ExportTableLengthLength = 4;

        public const int ImportTableRvaOffset = 8;
        public const int ImportTableRvaLength = 4;

        public const int ImportTableLengthOffset = 12;
        public const int ImportTableLengthLength = 4;

        public const int ResourceTableRvaOffset = 16;
        public const int ResourceTableRvaLength = 4;

        public const int ResourceTableLengthOffset = 20;
        public const int ResourceTableLengthLength = 4;

        public const int ExceptionTableRvaOffset = 24;
        public const int ExceptionTableRvaLength = 4;

        public const int ExceptionTableLengthOffset = 28;
        public const int ExceptionTableLengthLength = 4;

        public const int CertificateTableRvaOffset = 32;
        public const int CertificateTableRvaLength = 4;

        public const int CertificateTableLengthOffset = 36;
        public const int CertificateTableLengthLength = 4;

        public const int BaseRelocationTableRvaOffset = 40;
        public const int BaseRelocationTableRvaLength = 4;

        public const int BaseRelocationTableLengthOffset = 44;
        public const int BaseRelocationTableLengthLength = 4;

        public const int DebugRvaOffset = 48;
        public const int DebugRvaLength = 4;

        public const int DebugLengthOffset = 52;
        public const int DebugLengthLength = 4;

        public const int CopyrightRvaOffset = 56;
        public const int CopyrightRvaLength = 4;

        public const int CopyrightLengthOffset = 60;
        public const int CopyrightLengthLength = 4;

        public const int GlobalPtrRvaOffset = 64;
        public const int GlobalPtrRvaLength = 4;

        public const int GlobalPtrLengthOffset = 68;
        public const int GlobalPtrLengthLength = 4;

        public const int TlsTableRvaOffset = 72;
        public const int TlsTableRvaLength = 4;

        public const int TlsTableLengthOffset = 76;
        public const int TlsTableLengthLength = 4;

        public const int LoadConfigTableRvaOffset = 80;
        public const int LoadConfigTableRvaLength = 4;

        public const int LoadConfigTableLengthOffset = 84;
        public const int LoadConfigTableLengthLength = 4;

        public const int BoundImportRvaOffset = 88;
        public const int BoundImportRvaLength = 4;

        public const int BoundImportLengthOffset = 92;
        public const int BoundImportLengthLength = 4;

        public const int IatRvaOffset = 96;
        public const int IatRvaLength = 4;

        public const int IatLengthOffset = 100;
        public const int IatLengthLength = 4;

        public const int DelayImportDescriptorRvaOffset = 104;
        public const int DelayImportDescriptorRvaLength = 4;

        public const int DelayImportDescriptorLengthOffset = 108;
        public const int DelayImportDescriptorLengthLength = 4;

        public const int CliHeaderRvaOffset = 112;
        public const int CliHeaderRvaLength = 4;

        public const int CliHeaderLengthOffset = 116;
        public const int CliHeaderLengthLength = 4;

        public const int ReservedRvaOffset = 120;
        public const int ReservedRvaLength = 4;

        public const int ReservedLengthOffset = 124;
        public const int ReservedLengthLength = 4;
    }
}
