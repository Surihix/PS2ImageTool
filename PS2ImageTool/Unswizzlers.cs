namespace PS2ImageTool
{
    internal class Unswizzlers
    {
        public static byte[] Pixel8Bpp(byte[] pixelArray, int width, int height)
        {
            byte[] swizzledArray = new byte[pixelArray.Length];
            byte[] unswizzledArray = new byte[pixelArray.Length];

            Array.Copy(pixelArray, 0, swizzledArray, 0, swizzledArray.Length);
            Array.Copy(pixelArray, 0, unswizzledArray, 0, unswizzledArray.Length);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int blockLocation = (y & (-16)) * width + (x & (-16)) * 2;
                    int swapSelector = (((y + 2) >> 2) & 1) * 4;
                    int posY = (((y & (~3)) >> 1) + (y & 1)) & 7;
                    int columnLocation = posY * width * 2 + ((x + swapSelector) & 7) * 4;

                    int byteNum = ((y >> 1) & 1) + ((x >> 2) & 2);

                    unswizzledArray[0 + (y * width) + x] = swizzledArray[blockLocation + columnLocation + byteNum];
                }
            }

            return unswizzledArray;
        }


        public static void Palette1024_Mugi(ref byte[] palBufferVar)
        {
            uint[] newPalette = new uint[256];
            uint[] origPalette = new uint[256];
            Buffer.BlockCopy(palBufferVar, 0, origPalette, 0, 1024);

            for (uint k = 0; k < 8; k++)
            {
                for (uint j = 0; j < 2; j++)
                {
                    for (uint i = 0; i < 8; i++)
                    {
                        newPalette[k * 32 + j * 16 + i] = origPalette[k * 32 + 8 * j + i];
                        newPalette[k * 32 + j * 16 + i + 8] = origPalette[k * 32 + 8 * j + 16 + i];
                    }
                }
            }

            Buffer.BlockCopy(newPalette, 0, palBufferVar, 0, palBufferVar.Length);
        }


        public static byte[] Palette1024(byte[] paletteArray)
        {
            byte[] newPaletteArray = new byte[1024];
            int copyIndex = 0;
            int p = 0;

            // Per iteration, 128 bytes will be 
            // unswizzled
            while (p < 1024)
            {
                // Copy this iteration's first 32 bytes
                Array.ConstrainedCopy(paletteArray, p, newPaletteArray, copyIndex, 32);
                copyIndex += 32;

                // From the 64th position after the first 32 bytes of
                // this iteration, copy 32 bytes
                p += 64;
                Array.ConstrainedCopy(paletteArray, p, newPaletteArray, copyIndex, 32);
                copyIndex += 32;

                // From the 32nd position after the first 32 bytes of
                // this iteration, copy 32 bytes
                p -= 32;
                Array.ConstrainedCopy(paletteArray, p, newPaletteArray, copyIndex, 32);
                copyIndex += 32;

                // From the 96th position after the first 32 bytes of
                // this iteration, copy 32 bytes
                p += 64;
                Array.ConstrainedCopy(paletteArray, p, newPaletteArray, copyIndex, 32);
                copyIndex += 32;

                p += 32;
            }

            return newPaletteArray;
        }
    }
}