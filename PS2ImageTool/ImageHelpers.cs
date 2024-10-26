using System.Drawing.Imaging;

namespace PS2ImageTool
{
    internal class ImageHelpers
    {
        public static byte[] ConvertPixelsTo8Bpp(byte[] pixelsBufferVar)
        {
            using (var pixels4bpp = new MemoryStream())
            {
                pixels4bpp.Write(pixelsBufferVar, 0, pixelsBufferVar.Length);

                using (var convertedPixelData = new MemoryStream())
                {
                    using (var convertedPixelDataWriter = new BinaryWriter(convertedPixelData))
                    {
                        using (var pixels4bppReader = new BinaryReader(pixels4bpp))
                        {
                            uint readPos = 0;
                            byte pixelBits;
                            int pixelBit1;
                            int pixelBit2;
                            uint writePos = 0;
                            for (int c = 0; c < pixels4bpp.Length; c++)
                            {
                                pixels4bppReader.BaseStream.Position = readPos;
                                pixelBits = pixels4bppReader.ReadByte();

                                pixelBit1 = pixelBits >> 4;
                                pixelBit2 = pixelBits & 0xF;

                                convertedPixelDataWriter.BaseStream.Position = writePos;
                                convertedPixelDataWriter.Write((byte)pixelBit2);
                                convertedPixelDataWriter.Write((byte)pixelBit1);

                                readPos++;
                                writePos += 2;
                            }

                            byte[] convertedPixelsVar = convertedPixelData.ToArray();
                            return convertedPixelsVar;
                        }
                    }
                }
            }
        }


        public static void DDS(string outImgPath, uint width, uint height, BinaryReader pixelReader, BinaryReader paletteReader)
        {
            using (var ddsFile = new FileStream(outImgPath, FileMode.Append, FileAccess.Write))
            {
                using (var ddsFileWriter = new BinaryWriter(ddsFile))
                {
                    ddsFileWriter.BaseHeader(height, width, 1);
                    ddsFileWriter.PixelFormatHeader(DDSImageHelpers.PixelFormat.R8G8B8A8, width, height, 1);

                    var pixelDataLength = width * height;
                    uint readPos = 0;
                    uint getPalettePos;
                    uint palettePos;
                    byte red = 0;
                    byte green = 0;
                    byte blue = 0;
                    byte alpha = 0;
                    uint writePos = 128;
                    for (int i = 0; i < pixelDataLength; i++)
                    {
                        pixelReader.BaseStream.Position = readPos;
                        getPalettePos = pixelReader.ReadByte();
                        palettePos = getPalettePos * 4;

                        ReadColorValues(paletteReader, palettePos, ref red, ref green, ref blue, ref alpha);

                        ddsFileWriter.BaseStream.Position = writePos;
                        ddsFileWriter.Write(blue);
                        ddsFileWriter.Write(green);
                        ddsFileWriter.Write(red);
                        ddsFileWriter.Write(alpha);

                        writePos += 4;
                        readPos++;
                    }
                }
            }
        }


        public static void DrawOnPicBox(uint width, uint height, BinaryReader pixelReader, BinaryReader paletteReader, MemoryStream pngStream)
        {
            pixelReader.BaseStream.Seek(0, SeekOrigin.Begin);
            paletteReader.BaseStream.Seek(0, SeekOrigin.Begin);

            int currentPixel;
            uint getPalettePos;
            uint palettePos;
            byte red = 0;
            byte green = 0;
            byte blue = 0;
            byte alpha = 0;
            Color pixelColor;

            using (var finalImg = new Bitmap((int)width, (int)height))
            {
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        currentPixel = (int)(y * width) + x;
                        pixelReader.BaseStream.Position = currentPixel;
                        getPalettePos = pixelReader.ReadByte();

                        palettePos = getPalettePos * 4;
                        ReadColorValues(paletteReader, palettePos, ref red, ref green, ref blue, ref alpha);

                        pixelColor = Color.FromArgb(alpha, red, green, blue);
                        finalImg.SetPixel(x, y, pixelColor);
                    }
                }

                finalImg.Save(pngStream, ImageFormat.Png);
            }
        }


        private static void ReadColorValues(BinaryReader paletteReaderVar, uint readPos, ref byte redVar, ref byte greenVar, ref byte blueVar, ref byte alphaVar)
        {
            paletteReaderVar.BaseStream.Position = readPos;
            redVar = paletteReaderVar.ReadByte();
            greenVar = paletteReaderVar.ReadByte();
            blueVar = paletteReaderVar.ReadByte();
            alphaVar = paletteReaderVar.ReadByte();

            if (alphaVar > 128)
            {
                alphaVar = 128;
            }
        }
    }
}