namespace PS2ImageTool
{
    public partial class CoreForm : Form
    {
        public CoreForm()
        {
            InitializeComponent();
        }


        private void MakeImgBtn_Click(object sender, EventArgs e)
        {

        }


        private void UnswizzleBtn_Click(object sender, EventArgs e)
        {

        }

        private void EnableDisableGUI(bool isEnabled)
        {
            // ImageTabPage
            ImgOptionsGrpBox.Enabled = isEnabled;
            MakeImgBtn.Enabled = isEnabled;

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