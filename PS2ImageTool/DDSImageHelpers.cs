namespace PS2ImageTool
{
    internal static class DDSImageHelpers
    {
        public static void BaseHeader(this BinaryWriter ddsStreamWriter, uint height, uint width, uint mipCount)
        {
            // Pad the stream with
            // 128 null bytes
            for (int h = 0; h < 128; h++)
            {
                ddsStreamWriter.BaseStream.WriteByte(0);
            }

            // Write common DDS header flags
            _ = ddsStreamWriter.BaseStream.Position = 0;
            ddsStreamWriter.Write(BitConverter.GetBytes((uint)542327876));

            _ = ddsStreamWriter.BaseStream.Position = 4;
            ddsStreamWriter.Write(BitConverter.GetBytes(124));

            _ = ddsStreamWriter.BaseStream.Position = 12;
            ddsStreamWriter.Write(BitConverter.GetBytes(height));

            _ = ddsStreamWriter.BaseStream.Position = 16;
            ddsStreamWriter.Write(BitConverter.GetBytes(width));

            _ = ddsStreamWriter.BaseStream.Position = 28;
            ddsStreamWriter.Write(BitConverter.GetBytes(mipCount));

            _ = ddsStreamWriter.BaseStream.Position = 76;
            ddsStreamWriter.Write(BitConverter.GetBytes((uint)32));

            // Writes the mip related flag
            // if mip count is more than one
            _ = ddsStreamWriter.BaseStream.Position = 108;

            if (mipCount > 1)
            {
                ddsStreamWriter.Write((uint)4198408);
            }
            else
            {
                ddsStreamWriter.Write((uint)4096);
            }
        }


        public enum PixelFormat
        {
            DXT1,
            DXT3,
            DXT5,
            R8G8B8A8
        }


        public static void PixelFormatHeader(this BinaryWriter ddsStreamWriter, PixelFormat pixelFormat, uint width, uint height, uint mipCount)
        {
            // Computes DDS pitch and writes DXT string
            // chars for BC pixel formats
            uint pitch = 0;

            // Move the basestream position
            // for the pixel format chars
            _ = ddsStreamWriter.BaseStream.Position = 84;
            switch (pixelFormat)
            {
                case PixelFormat.R8G8B8A8:     // R8G8B8A8
                    pitch = (width * 32 + 7) / 8;
                    break;

                case PixelFormat.DXT1:     // DXT1
                    pitch = Math.Max(1, ((width + 3) / 4)) * Math.Max(1, ((height + 3) / 4)) * 8;
                    ddsStreamWriter.Write(BitConverter.GetBytes((uint)827611204));     // writes DXT1 string
                    break;

                case PixelFormat.DXT3:     // DXT3
                    pitch = Math.Max(1, ((width + 3) / 4)) * Math.Max(1, ((height + 3) / 4)) * 16;
                    ddsStreamWriter.Write(BitConverter.GetBytes((uint)861165636));     // writes DXT3 string
                    break;

                case PixelFormat.DXT5:     // DXT5             
                    pitch = Math.Max(1, ((width + 3) / 4)) * Math.Max(1, ((height + 3) / 4)) * 16;
                    ddsStreamWriter.Write(BitConverter.GetBytes((uint)894720068));     // writes DXT5 string
                    break;
            }

            _ = ddsStreamWriter.BaseStream.Position = 20;
            ddsStreamWriter.Write(BitConverter.GetBytes(pitch));

            // Writes pixel format flags which are
            // common for R8G8B8A8
            if (pixelFormat == PixelFormat.R8G8B8A8)
            {
                _ = ddsStreamWriter.BaseStream.Position = 80;
                ddsStreamWriter.Write(BitConverter.GetBytes((uint)65));

                _ = ddsStreamWriter.BaseStream.Position = 88;
                ddsStreamWriter.Write(BitConverter.GetBytes((uint)32));

                _ = ddsStreamWriter.BaseStream.Position = 92;
                ddsStreamWriter.Write(BitConverter.GetBytes((uint)16711680));

                _ = ddsStreamWriter.BaseStream.Position = 96;
                ddsStreamWriter.Write(BitConverter.GetBytes((uint)65280));

                _ = ddsStreamWriter.BaseStream.Position = 100;
                ddsStreamWriter.Write(BitConverter.GetBytes((uint)255));

                _ = ddsStreamWriter.BaseStream.Position = 104;
                ddsStreamWriter.Write(BitConverter.GetBytes((uint)4278190080));

                _ = ddsStreamWriter.BaseStream.Position = 8;
                if (mipCount > 1)
                {
                    ddsStreamWriter.Write(BitConverter.GetBytes((uint)135183));
                }
                else
                {
                    ddsStreamWriter.Write(BitConverter.GetBytes((uint)4111));
                }
            }

            // Writes pixel format flags which are
            // common for DXT1, DXT3, and DXT5
            if (pixelFormat != PixelFormat.R8G8B8A8)
            {
                _ = ddsStreamWriter.BaseStream.Position = 80;
                ddsStreamWriter.Write(BitConverter.GetBytes((uint)4));

                _ = ddsStreamWriter.BaseStream.Position = 8;
                if (mipCount > 1)
                {
                    ddsStreamWriter.Write(BitConverter.GetBytes((uint)659463));
                }
                else
                {
                    ddsStreamWriter.Write(BitConverter.GetBytes((uint)528391));
                }
            }
        }
    }
}