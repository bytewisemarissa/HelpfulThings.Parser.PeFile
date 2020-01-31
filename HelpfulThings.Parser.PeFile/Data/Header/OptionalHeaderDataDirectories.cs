namespace HelpfulThings.Parser.PeFile.Data.Header
{
    public class OptionalHeaderDataDirectories
    {
        public int OptionalHeaderDataDirectoriesLength = 128;

        public int ExportTableRvaOffset = 0;
        public int ExportTableRvaLength = 4;

        public int ExportTableLengthOffset = 4;
        public int ExportTableLengthLength = 4;

        public int ImportTableRvaOffset = 8;
        public int ImportTableRvaLength = 4;

        public int ImportTableLengthOffset = 12;
        public int ImportTableLengthLength = 4;

        public int ResourceTableRvaOffset = 16;
        public int ResourceTableRvaLength = 4;

        public int ResourceTableLengthOffset = 20;
        public int ResourceTableLengthLength = 4;

        public int ExceptionTableRvaOffset = 24;
        public int ExceptionTableRvaLength = 4;

        public int ExceptionTableLengthOffset = 28;
        public int ExceptionTableLengthLength = 4;

        public int CertificateTableRvaOffset = 32;
        public int CertificateTableRvaLength = 4;

        public int CertificateTableLengthOffset = 36;
        public int CertificateTableLengthLength = 4;

        public int BaseRelocationTableRvaOffset = 40;
        public int BaseRelocationTableRvaLength = 4;

        public int BaseRelocationTableLengthOffset = 44;
        public int BaseRelocationTableLengthLength = 4;

        public int DebugRvaOffset = 48;
        public int DebugRvaLength = 4;

        public int DebugLengthOffset = 52;
        public int DebugLengthLength = 4;

        public int CopyrightRvaOffset = 56;
        public int CopyrightRvaLength = 4;

        public int CopyrightLengthOffset = 60;
        public int CopyrightLengthLength = 4;

        public int GlobalPtrRvaOffset = 64;
        public int GlobalPtrRvaLength = 4;

        public int GlobalPtrLengthOffset = 68;
        public int GlobalPtrLengthLength = 4;

        public int TlsTableRvaOffset = 72;
        public int TlsTableRvaLength = 4;

        public int TlsTableLengthOffset = 76;
        public int TlsTableLengthLength = 4;

        public int LoadConfigTableRvaOffset = 80;
        public int LoadConfigTableRvaLength = 4;

        public int LoadConfigTableLengthOffset = 84;
        public int LoadConfigTableLengthLength = 4;

        public int BoundImportRvaOffset = 88;
        public int BoundImportRvaLength = 4;

        public int BoundImportLengthOffset = 92;
        public int BoundImportLengthLength = 4;

        public int IatRvaOffset = 96;
        public int IatRvaLength = 4;

        public int IatLengthOffset = 100;
        public int IatLengthLength = 4;

        public int DelayImportDescriptorRvaOffset = 104;
        public int DelayImportDescriptorRvaLength = 4;

        public int DelayImportDescriptorLengthOffset = 108;
        public int DelayImportDescriptorLengthLength = 4;

        public int CliHeaderRvaOffset = 112;
        public int CliHeaderRvaLength = 4;

        public int CliHeaderLengthOffset = 116;
        public int CliHeaderLengthLength = 4;

        public int ReservedRvaOffset = 120;
        public int ReservedRvaLength = 4;

        public int ReservedLengthOffset = 124;
        public int ReservedLengthLength = 4;
    }
}
