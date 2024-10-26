namespace PS2ImageTool
{
    partial class CoreForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TabControl = new TabControl();
            ImageTabPage = new TabPage();
            ImgOptionsGrpBox = new GroupBox();
            BppLabel = new Label();
            HeightLabel = new Label();
            WidthLabel = new Label();
            BppNumUpDown = new NumericUpDown();
            HeightNumUpDown = new NumericUpDown();
            WidthNumUpDown = new NumericUpDown();
            CreateImgBtn = new Button();
            SwizzleTabPage = new TabPage();
            SwizzleOptionsGrpBox = new GroupBox();
            PixelOptionsGrpBox = new GroupBox();
            SwizzWidthLabel = new Label();
            SwizzWidthNumUpDown = new NumericUpDown();
            SwizzBppLabel = new Label();
            SwizzHeightNumUpDown = new NumericUpDown();
            SwizzHeightLabel = new Label();
            SwizzBppNumUpDown = new NumericUpDown();
            UnswizzleBtn = new Button();
            PalUnswizzleRadioBtn = new RadioButton();
            PixUnswizzleRadioBtn = new RadioButton();
            PicBox = new PictureBox();
            PicBoxContextMenu = new ContextMenuStrip(components);
            saveImageToolStripMenuItem = new ToolStripMenuItem();
            PictureBoxPanel = new Panel();
            TabControl.SuspendLayout();
            ImageTabPage.SuspendLayout();
            ImgOptionsGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BppNumUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)HeightNumUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WidthNumUpDown).BeginInit();
            SwizzleTabPage.SuspendLayout();
            SwizzleOptionsGrpBox.SuspendLayout();
            PixelOptionsGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SwizzWidthNumUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SwizzHeightNumUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SwizzBppNumUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PicBox).BeginInit();
            PicBoxContextMenu.SuspendLayout();
            PictureBoxPanel.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Controls.Add(ImageTabPage);
            TabControl.Controls.Add(SwizzleTabPage);
            TabControl.Location = new Point(12, 292);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(424, 222);
            TabControl.TabIndex = 0;
            // 
            // ImageTabPage
            // 
            ImageTabPage.BackColor = SystemColors.Menu;
            ImageTabPage.Controls.Add(ImgOptionsGrpBox);
            ImageTabPage.Controls.Add(CreateImgBtn);
            ImageTabPage.Location = new Point(4, 24);
            ImageTabPage.Name = "ImageTabPage";
            ImageTabPage.Padding = new Padding(3);
            ImageTabPage.Size = new Size(416, 194);
            ImageTabPage.TabIndex = 0;
            ImageTabPage.Text = "Image tools";
            // 
            // ImgOptionsGrpBox
            // 
            ImgOptionsGrpBox.Controls.Add(BppLabel);
            ImgOptionsGrpBox.Controls.Add(HeightLabel);
            ImgOptionsGrpBox.Controls.Add(WidthLabel);
            ImgOptionsGrpBox.Controls.Add(BppNumUpDown);
            ImgOptionsGrpBox.Controls.Add(HeightNumUpDown);
            ImgOptionsGrpBox.Controls.Add(WidthNumUpDown);
            ImgOptionsGrpBox.Location = new Point(20, 20);
            ImgOptionsGrpBox.Name = "ImgOptionsGrpBox";
            ImgOptionsGrpBox.Size = new Size(200, 137);
            ImgOptionsGrpBox.TabIndex = 1;
            ImgOptionsGrpBox.TabStop = false;
            ImgOptionsGrpBox.Text = "Image Options:";
            // 
            // BppLabel
            // 
            BppLabel.AutoSize = true;
            BppLabel.Location = new Point(15, 76);
            BppLabel.Name = "BppLabel";
            BppLabel.Size = new Size(31, 15);
            BppLabel.TabIndex = 1;
            BppLabel.Text = "Bpp:";
            // 
            // HeightLabel
            // 
            HeightLabel.AutoSize = true;
            HeightLabel.Location = new Point(113, 22);
            HeightLabel.Name = "HeightLabel";
            HeightLabel.Size = new Size(46, 15);
            HeightLabel.TabIndex = 1;
            HeightLabel.Text = "Height:";
            // 
            // WidthLabel
            // 
            WidthLabel.AutoSize = true;
            WidthLabel.Location = new Point(15, 22);
            WidthLabel.Name = "WidthLabel";
            WidthLabel.Size = new Size(42, 15);
            WidthLabel.TabIndex = 1;
            WidthLabel.Text = "Width:";
            // 
            // BppNumUpDown
            // 
            BppNumUpDown.Location = new Point(15, 94);
            BppNumUpDown.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            BppNumUpDown.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            BppNumUpDown.Name = "BppNumUpDown";
            BppNumUpDown.Size = new Size(60, 23);
            BppNumUpDown.TabIndex = 0;
            BppNumUpDown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // HeightNumUpDown
            // 
            HeightNumUpDown.Location = new Point(113, 40);
            HeightNumUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            HeightNumUpDown.Name = "HeightNumUpDown";
            HeightNumUpDown.Size = new Size(60, 23);
            HeightNumUpDown.TabIndex = 0;
            // 
            // WidthNumUpDown
            // 
            WidthNumUpDown.Location = new Point(15, 40);
            WidthNumUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            WidthNumUpDown.Name = "WidthNumUpDown";
            WidthNumUpDown.Size = new Size(60, 23);
            WidthNumUpDown.TabIndex = 0;
            // 
            // CreateImgBtn
            // 
            CreateImgBtn.Location = new Point(271, 68);
            CreateImgBtn.Name = "CreateImgBtn";
            CreateImgBtn.Size = new Size(90, 40);
            CreateImgBtn.TabIndex = 0;
            CreateImgBtn.Text = "Create Image";
            CreateImgBtn.UseVisualStyleBackColor = true;
            CreateImgBtn.Click += CreateImgBtn_Click;
            // 
            // SwizzleTabPage
            // 
            SwizzleTabPage.BackColor = SystemColors.Menu;
            SwizzleTabPage.Controls.Add(SwizzleOptionsGrpBox);
            SwizzleTabPage.Location = new Point(4, 24);
            SwizzleTabPage.Name = "SwizzleTabPage";
            SwizzleTabPage.Padding = new Padding(3);
            SwizzleTabPage.Size = new Size(416, 194);
            SwizzleTabPage.TabIndex = 1;
            SwizzleTabPage.Text = "Swizzle tools";
            // 
            // SwizzleOptionsGrpBox
            // 
            SwizzleOptionsGrpBox.Controls.Add(PixelOptionsGrpBox);
            SwizzleOptionsGrpBox.Controls.Add(UnswizzleBtn);
            SwizzleOptionsGrpBox.Controls.Add(PalUnswizzleRadioBtn);
            SwizzleOptionsGrpBox.Controls.Add(PixUnswizzleRadioBtn);
            SwizzleOptionsGrpBox.Location = new Point(20, 20);
            SwizzleOptionsGrpBox.Name = "SwizzleOptionsGrpBox";
            SwizzleOptionsGrpBox.Size = new Size(374, 156);
            SwizzleOptionsGrpBox.TabIndex = 2;
            SwizzleOptionsGrpBox.TabStop = false;
            SwizzleOptionsGrpBox.Text = "Swizzle Options:";
            // 
            // PixelOptionsGrpBox
            // 
            PixelOptionsGrpBox.Controls.Add(SwizzWidthLabel);
            PixelOptionsGrpBox.Controls.Add(SwizzWidthNumUpDown);
            PixelOptionsGrpBox.Controls.Add(SwizzBppLabel);
            PixelOptionsGrpBox.Controls.Add(SwizzHeightNumUpDown);
            PixelOptionsGrpBox.Controls.Add(SwizzHeightLabel);
            PixelOptionsGrpBox.Controls.Add(SwizzBppNumUpDown);
            PixelOptionsGrpBox.Location = new Point(185, 22);
            PixelOptionsGrpBox.Name = "PixelOptionsGrpBox";
            PixelOptionsGrpBox.Size = new Size(171, 117);
            PixelOptionsGrpBox.TabIndex = 2;
            PixelOptionsGrpBox.TabStop = false;
            PixelOptionsGrpBox.Text = "Pixel Options:";
            // 
            // SwizzWidthLabel
            // 
            SwizzWidthLabel.AutoSize = true;
            SwizzWidthLabel.Location = new Point(18, 19);
            SwizzWidthLabel.Name = "SwizzWidthLabel";
            SwizzWidthLabel.Size = new Size(42, 15);
            SwizzWidthLabel.TabIndex = 1;
            SwizzWidthLabel.Text = "Width:";
            // 
            // SwizzWidthNumUpDown
            // 
            SwizzWidthNumUpDown.Location = new Point(18, 37);
            SwizzWidthNumUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            SwizzWidthNumUpDown.Name = "SwizzWidthNumUpDown";
            SwizzWidthNumUpDown.Size = new Size(60, 23);
            SwizzWidthNumUpDown.TabIndex = 0;
            // 
            // SwizzBppLabel
            // 
            SwizzBppLabel.AutoSize = true;
            SwizzBppLabel.Location = new Point(18, 63);
            SwizzBppLabel.Name = "SwizzBppLabel";
            SwizzBppLabel.Size = new Size(31, 15);
            SwizzBppLabel.TabIndex = 1;
            SwizzBppLabel.Text = "Bpp:";
            // 
            // SwizzHeightNumUpDown
            // 
            SwizzHeightNumUpDown.Location = new Point(96, 37);
            SwizzHeightNumUpDown.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            SwizzHeightNumUpDown.Name = "SwizzHeightNumUpDown";
            SwizzHeightNumUpDown.Size = new Size(60, 23);
            SwizzHeightNumUpDown.TabIndex = 0;
            // 
            // SwizzHeightLabel
            // 
            SwizzHeightLabel.AutoSize = true;
            SwizzHeightLabel.Location = new Point(96, 19);
            SwizzHeightLabel.Name = "SwizzHeightLabel";
            SwizzHeightLabel.Size = new Size(46, 15);
            SwizzHeightLabel.TabIndex = 1;
            SwizzHeightLabel.Text = "Height:";
            // 
            // SwizzBppNumUpDown
            // 
            SwizzBppNumUpDown.Location = new Point(18, 81);
            SwizzBppNumUpDown.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            SwizzBppNumUpDown.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            SwizzBppNumUpDown.Name = "SwizzBppNumUpDown";
            SwizzBppNumUpDown.Size = new Size(60, 23);
            SwizzBppNumUpDown.TabIndex = 0;
            SwizzBppNumUpDown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // UnswizzleBtn
            // 
            UnswizzleBtn.Location = new Point(35, 101);
            UnswizzleBtn.Name = "UnswizzleBtn";
            UnswizzleBtn.Size = new Size(75, 23);
            UnswizzleBtn.TabIndex = 3;
            UnswizzleBtn.Text = "Unswizzle";
            UnswizzleBtn.UseVisualStyleBackColor = true;
            UnswizzleBtn.Click += UnswizzleBtn_Click;
            // 
            // PalUnswizzleRadioBtn
            // 
            PalUnswizzleRadioBtn.AutoSize = true;
            PalUnswizzleRadioBtn.Location = new Point(15, 59);
            PalUnswizzleRadioBtn.Name = "PalUnswizzleRadioBtn";
            PalUnswizzleRadioBtn.Size = new Size(115, 19);
            PalUnswizzleRadioBtn.TabIndex = 5;
            PalUnswizzleRadioBtn.Text = "Palette Unswizzle";
            PalUnswizzleRadioBtn.UseVisualStyleBackColor = true;
            PalUnswizzleRadioBtn.CheckedChanged += PalUnswizzleRadioBtn_CheckedChanged;
            // 
            // PixUnswizzleRadioBtn
            // 
            PixUnswizzleRadioBtn.AutoSize = true;
            PixUnswizzleRadioBtn.Checked = true;
            PixUnswizzleRadioBtn.Location = new Point(15, 34);
            PixUnswizzleRadioBtn.Name = "PixUnswizzleRadioBtn";
            PixUnswizzleRadioBtn.Size = new Size(104, 19);
            PixUnswizzleRadioBtn.TabIndex = 4;
            PixUnswizzleRadioBtn.TabStop = true;
            PixUnswizzleRadioBtn.Text = "Pixel Unswizzle";
            PixUnswizzleRadioBtn.UseVisualStyleBackColor = true;
            PixUnswizzleRadioBtn.CheckedChanged += PixUnswizzleRadioBtn_CheckedChanged;
            // 
            // PicBox
            // 
            PicBox.Dock = DockStyle.Fill;
            PicBox.Location = new Point(0, 0);
            PicBox.Name = "PicBox";
            PicBox.Size = new Size(424, 256);
            PicBox.SizeMode = PictureBoxSizeMode.Zoom;
            PicBox.TabIndex = 1;
            PicBox.TabStop = false;
            // 
            // PicBoxContextMenu
            // 
            PicBoxContextMenu.Items.AddRange(new ToolStripItem[] { saveImageToolStripMenuItem });
            PicBoxContextMenu.Name = "contextMenuStrip1";
            PicBoxContextMenu.Size = new Size(160, 26);
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new Size(159, 22);
            saveImageToolStripMenuItem.Text = "Save Image As...";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // PictureBoxPanel
            // 
            PictureBoxPanel.Controls.Add(PicBox);
            PictureBoxPanel.Location = new Point(12, 12);
            PictureBoxPanel.Name = "PictureBoxPanel";
            PictureBoxPanel.Size = new Size(424, 256);
            PictureBoxPanel.TabIndex = 0;
            // 
            // CoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 526);
            Controls.Add(PictureBoxPanel);
            Controls.Add(TabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CoreForm";
            Text = "PS2ImageTool";
            TabControl.ResumeLayout(false);
            ImageTabPage.ResumeLayout(false);
            ImgOptionsGrpBox.ResumeLayout(false);
            ImgOptionsGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BppNumUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)HeightNumUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)WidthNumUpDown).EndInit();
            SwizzleTabPage.ResumeLayout(false);
            SwizzleOptionsGrpBox.ResumeLayout(false);
            SwizzleOptionsGrpBox.PerformLayout();
            PixelOptionsGrpBox.ResumeLayout(false);
            PixelOptionsGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SwizzWidthNumUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)SwizzHeightNumUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)SwizzBppNumUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)PicBox).EndInit();
            PicBoxContextMenu.ResumeLayout(false);
            PictureBoxPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControl;
        private TabPage ImageTabPage;
        private TabPage SwizzleTabPage;
        private PictureBox PicBox;
        private GroupBox ImgOptionsGrpBox;
        private Button CreateImgBtn;
        private Label BppLabel;
        private Label HeightLabel;
        private Label WidthLabel;
        private NumericUpDown BppNumUpDown;
        private NumericUpDown HeightNumUpDown;
        private NumericUpDown WidthNumUpDown;
        private GroupBox SwizzleOptionsGrpBox;
        private RadioButton PalUnswizzleRadioBtn;
        private RadioButton PixUnswizzleRadioBtn;
        private Button UnswizzleBtn;
        private Label SwizzBppLabel;
        private Label SwizzHeightLabel;
        private Label SwizzWidthLabel;
        private NumericUpDown SwizzBppNumUpDown;
        private NumericUpDown SwizzHeightNumUpDown;
        private NumericUpDown SwizzWidthNumUpDown;
        private GroupBox PixelOptionsGrpBox;
        private ContextMenuStrip PicBoxContextMenu;
        private ToolStripMenuItem saveImageToolStripMenuItem;
        private Panel PictureBoxPanel;
    }
}
