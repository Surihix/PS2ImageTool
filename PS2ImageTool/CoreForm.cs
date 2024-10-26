namespace PS2ImageTool
{
    public partial class CoreForm : Form
    {
        public CoreForm()
        {
            InitializeComponent();
        }

        private static byte[]? CurrentPixelData { get; set; }
        private static byte[]? CurrentPaletteData { get; set; }
        private static uint CurrentWidth { get; set; }
        private static uint CurrentHeight { get; set; }

        private void CreateImgBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PicBox.ContextMenuStrip = null;
                PicBox.Image = null;

                EnableDisableGUI(false);

                var pixelFile = GenerateOFD("Select pixel file");
                var paletteFile = GenerateOFD("Select palette file");

                if (pixelFile == "" || paletteFile == "")
                {
                    MessageBox.Show($"One or more paths was not set properly\n\nPixelFilePath: {pixelFile}\n\nPaletteFilePath: {paletteFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    uint width = Convert.ToUInt32(WidthNumUpDown.Value);
                    uint height = Convert.ToUInt32(HeightNumUpDown.Value);

                    if (width == 0 || height == 0)
                    {
                        MessageBox.Show("Width or Height values for pixel data, is not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        CurrentWidth = width;
                        CurrentHeight = height;

                        var bppValid = false;

                        if (BppNumUpDown.Value < 8 && BppNumUpDown.Value < 4)
                        {
                            BppNumUpDown.Value = 8;
                            bppValid = true;
                        }

                        if (BppNumUpDown.Value == 4 || BppNumUpDown.Value == 8)
                        {
                            bppValid = true;
                        }

                        if (bppValid)
                        {
                            byte[] pixBuffer;

                            if (BppNumUpDown.Value == 4)
                            {
                                pixBuffer = ImageHelpers.ConvertPixelsTo8Bpp(File.ReadAllBytes(pixelFile));
                            }
                            else
                            {
                                pixBuffer = File.ReadAllBytes(pixelFile);
                                CurrentPixelData = pixBuffer;
                            }

                            using (var pixelsData = new MemoryStream())
                            {
                                pixelsData.Write(pixBuffer, 0, pixBuffer.Length);
                                pixelsData.Seek(0, SeekOrigin.Begin);

                                using (var pixelReader = new BinaryReader(pixelsData))
                                {
                                    CurrentPaletteData = File.ReadAllBytes(paletteFile);

                                    using (var paletteReader = new BinaryReader(File.Open(paletteFile, FileMode.Open, FileAccess.Read)))
                                    {
                                        using (var pngStream = new MemoryStream())
                                        {
                                            ImageHelpers.DrawOnPicBox(width, height, pixelReader, paletteReader, pngStream);
                                            PicBox.Image = Image.FromStream(pngStream);
                                        }

                                        MessageBox.Show("Created image from pixel and palette data", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        PicBox.ContextMenuStrip = PicBoxContextMenu;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Specified bpp value was invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                EnableDisableGUI(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableDisableGUI(true);
            }
        }


        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Save Image file";
                sfd.Filter = "Portable Network Graphics (*.png)|*.png|Bitmap (*.bmp)|*.bmp|DDS Uncompressed (*.dds)|*.dds";
                sfd.AddExtension = true;
                sfd.OverwritePrompt = true;
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var filePath = sfd.FileName;

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    switch (Path.GetExtension(filePath))
                    {
                        case ".png":
                            PicBox.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                            break;

                        case ".bmp":
                            PicBox.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case ".dds":
                            using (var pixStream = new MemoryStream(CurrentPixelData))
                            {
                                using (var pixReader = new BinaryReader(pixStream))
                                {
                                    using (var palStream = new MemoryStream(CurrentPaletteData))
                                    {
                                        using (var palReader = new BinaryReader(palStream))
                                        {
                                            ImageHelpers.DDS(filePath, CurrentWidth, CurrentHeight, pixReader, palReader);
                                        }
                                    }
                                }
                            }
                            break;
                    }

                    MessageBox.Show("Saved image file", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EnableDisableGUI(true);
                }
            }
        }


        private void UnswizzleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EnableDisableGUI(false);

                if (PixUnswizzleRadioBtn.Checked)
                {
                    var pixFile = GenerateOFD("Select swizzled pixel file");

                    if (pixFile == "")
                    {
                        MessageBox.Show("Pixel file is not specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var width = Convert.ToInt32(SwizzWidthNumUpDown.Value);
                        var height = Convert.ToInt32(SwizzHeightNumUpDown.Value);

                        if (width == 0 || height == 0)
                        {
                            MessageBox.Show("Width or Height values for swizzled pixel data, is not set", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var bppValid = false;

                            if (SwizzBppNumUpDown.Value < 8 && SwizzBppNumUpDown.Value < 4)
                            {
                                SwizzBppNumUpDown.Value = 8;
                            }

                            if (SwizzBppNumUpDown.Value == 8)
                            {
                                bppValid = true;
                            }

                            if (bppValid)
                            {
                                var pixBuffer = File.ReadAllBytes(pixFile);
                                var unswizzPixBuffer = Unswizzlers.Pixel8Bpp(pixBuffer, width, height);

                                if (File.Exists(pixFile + "_unswizzled.bin"))
                                {
                                    File.Delete(pixFile + "_unswizzled.bin");
                                }

                                File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(pixFile), Path.GetFileNameWithoutExtension(pixFile) + "_unswizzled.bin"), unswizzPixBuffer);
                                MessageBox.Show("Unswizzled Pixel file", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Specified bpp value is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }

                if (PalUnswizzleRadioBtn.Checked)
                {
                    var palFile = GenerateOFD("Select swizzled palette file");

                    if (palFile == "")
                    {
                        MessageBox.Show("Palette file is not specified", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var palLength = new FileInfo(palFile).Length;

                        if (palLength == 1024)
                        {
                            var unswizzPalBuffer = Unswizzlers.Palette1024(File.ReadAllBytes(palFile));

                            if (File.Exists(palFile + "_unswizzled.bin"))
                            {
                                File.Delete(palFile + "_unswizzled.bin");
                            }

                            File.WriteAllBytes(Path.Combine(Path.GetDirectoryName(palFile), Path.GetFileNameWithoutExtension(palFile) + "_unswizzled.bin"), unswizzPalBuffer);
                            MessageBox.Show("Unswizzled Palette file", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Palette file is not 1024 bytes in length", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                EnableDisableGUI(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EnableDisableGUI(true);
            }
        }


        private void EnableDisableGUI(bool isEnabled)
        {
            // ImageTabPage
            ImgOptionsGrpBox.Enabled = isEnabled;
            CreateImgBtn.Enabled = isEnabled;

            // SwizzleTabPage
            if (PixUnswizzleRadioBtn.Checked)
            {
                PixelOptionsGrpBox.Enabled = isEnabled;
            }

            UnswizzleBtn.Enabled = isEnabled;
        }


        private static string GenerateOFD(string ofdTitle)
        {
            var filePath = "";

            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = ofdTitle;
                ofd.Filter = "bin files (*.bin)|*.bin";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                }
            }

            return filePath;
        }


        private void PixUnswizzleRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            PixelOptionsGrpBox.Enabled = true;
        }

        private void PalUnswizzleRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            PixelOptionsGrpBox.Enabled = false;
        }
    }
}