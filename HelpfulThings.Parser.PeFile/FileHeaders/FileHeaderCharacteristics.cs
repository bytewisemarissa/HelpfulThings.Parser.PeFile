using System;
using HelpfulThings.Parser.PeFile.Common;
using HelpfulThings.Parser.PeFile.Data;
using HelpfulThings.Parser.PeFile.Data.Header;
using HelpfulThings.Parser.PeFile.Exceptions;
using HelpfulThings.Tooling.MemoryWindow;

namespace HelpfulThings.Parser.PeFile.FileHeaders
{
    public class FileHeaderCharacteristics : PortableExecutableFilePart
    {
        private readonly ushort _characteristics;

        #region ECMA-335 Naming
        // ReSharper disable once InconsistentNaming
        public bool IMAGE_FILE_RELOCS_STRIPPED => Convert.ToBoolean(_characteristics & Characteristics.ImageFileRelocsStrippedMask);
        // ReSharper disable once InconsistentNaming
        public bool IMAGE_FILE_EXECUTABLE_IMAGE => Convert.ToBoolean(_characteristics & Characteristics.ImageFileExecutableImageMask);
        // ReSharper disable once InconsistentNaming
        public bool IMPLEMENTATION_SPECIFIC1 => Convert.ToBoolean(_characteristics & Characteristics.ImplementationSpecific1);
        // ReSharper disable once InconsistentNaming
        public bool IMPLEMENTATION_SPECIFIC2 => Convert.ToBoolean(_characteristics & Characteristics.ImplementationSpecific2);
        // ReSharper disable once InconsistentNaming
        public bool IMPLEMENTATION_SPECIFIC3 => Convert.ToBoolean(_characteristics & Characteristics.ImplementationSpecific3);
        // ReSharper disable once InconsistentNaming
        public bool IMPLEMENTATION_SPECIFIC4 => Convert.ToBoolean(_characteristics & Characteristics.ImplementationSpecific4);
        // ReSharper disable once InconsistentNaming
        public bool IMAGE_FILE_32BIT_MACHINE => Convert.ToBoolean(_characteristics & Characteristics.ImageFile32BitMachineMask);
        // ReSharper disable once InconsistentNaming
        public bool IMAGE_FILE_DLL => Convert.ToBoolean(_characteristics & Characteristics.ImageFileDllMask);
        #endregion

        #region FriendlyNaming
        public bool AreFileRelocationsStripped => IMAGE_FILE_RELOCS_STRIPPED;
        public bool IsFileExecutableImage => IMAGE_FILE_EXECUTABLE_IMAGE;
        public bool ImplementationSpecificBit1 => IMPLEMENTATION_SPECIFIC1;
        public bool ImplementationSpecificBit2 => IMPLEMENTATION_SPECIFIC2;
        public bool ImplementationSpecificBit3 => IMPLEMENTATION_SPECIFIC3;
        public bool ImplementationSpecificBit4 => IMPLEMENTATION_SPECIFIC4;
        public bool DoesImageRequire32BitMachine => IMAGE_FILE_32BIT_MACHINE;
        public bool IsDllFile => IMAGE_FILE_DLL;
        #endregion

        public FileHeaderCharacteristics(ExceptionCollector collector, MemorySlice slice) : base(slice)
        {
            if (Slice.Count > Characteristics.CharacteristicsLength)
            {
                collector.Add(new CharacteristicsException(ExceptionLevel.Critical, "The PE Characteristics is too long."));
            }
            if (Slice.Count < Characteristics.CharacteristicsLength)
            {
                collector.Add(new CharacteristicsException(ExceptionLevel.Critical, "The PE Characteristics is too short."));
            }

            _characteristics = BitConverter.ToUInt16(Slice.Dump(), 0);
            
            Verify(collector);
        }

        private void Verify(ExceptionCollector collector)
        {
            if (IMAGE_FILE_RELOCS_STRIPPED)
                collector.Add(new CharacteristicsException(ExceptionLevel.Problem, $"{nameof(IMAGE_FILE_RELOCS_STRIPPED)} should be false"));

            if (!IMAGE_FILE_EXECUTABLE_IMAGE)
                collector.Add(new CharacteristicsException(ExceptionLevel.Problem, $"{nameof(IMAGE_FILE_EXECUTABLE_IMAGE)} should be true"));

            if (Convert.ToBoolean(_characteristics & Characteristics.ZeroCheck))
            {
                collector.Add(new CharacteristicsException(ExceptionLevel.Warning, $"Some characteristics bits which should be zero are not."));
            }
        }
    }
}
