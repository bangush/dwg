﻿using Xunit;

namespace IxMilia.Dwg.Test
{
    public class FileHeaderTests
    {
        [Fact]
        public void SimpleFileHeader()
        {
            var data = new byte[]
            {
                (byte)'A', (byte)'C', (byte)'1', (byte)'0', (byte)'1', (byte)'4',
                0, 0, 0, 0, 0,
                42, // maintver
                1,
                0, 0, 0, 0, // image seeker
                0, 0, // unknown
                0x00, 0x01, // codepage
                0, 0, 0, 0, // no section locators
                0, 0, // CRC
                0x95, 0xA0, 0x4E, 0x28, 0x99, 0x82, 0x1A, 0xE5, // sentinel
                0x5E, 0x41, 0xE0, 0x5F, 0x9D, 0x3A, 0x4D, 0x00,
            };
            var reader = new BitReader(data);
            var fileHeader = DwgFileHeader.Parse(reader);
            Assert.Equal(DwgVersionId.R14, fileHeader.Version);
            Assert.Equal(42, fileHeader.MaintenenceVersion);
            Assert.Equal(256, fileHeader.CodePage);
        }
    }
}
