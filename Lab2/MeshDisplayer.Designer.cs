namespace Lab2
{
    partial class MeshDisplayer
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
            pictureBox = new PictureBox();
            fidelityPanel = new Panel();
            fideltyValueLabel = new Label();
            fidelityLabel = new Label();
            fidelityTrackBar = new TrackBar();
            alphaAnglePanel = new Panel();
            alphaAngleValueLabel = new Label();
            alphaAngleLabel = new Label();
            alphaAngleTrackBar = new TrackBar();
            betaAnglePanel = new Panel();
            betaAngleValueLabel = new Label();
            betaAngleLabel = new Label();
            betaAngleTrackBar = new TrackBar();
            lightColorDialog = new ColorDialog();
            lightColorButton = new Button();
            panel1 = new Panel();
            kdValueLabel = new Label();
            kdLabel = new Label();
            kdTrackBar = new TrackBar();
            panel2 = new Panel();
            ksValueLabel = new Label();
            ksLabel = new Label();
            ksTrackBar = new TrackBar();
            panel3 = new Panel();
            mValueLabel = new Label();
            mLabel = new Label();
            mTrackBar = new TrackBar();
            panel4 = new Panel();
            lightZAxisValueLabel = new Label();
            lightZAxisLabel = new Label();
            lightZAxisTrackBar = new TrackBar();
            objectColorPanel = new Panel();
            textureRadioButton = new RadioButton();
            fixedColorRadioButton = new RadioButton();
            openFileDialog = new OpenFileDialog();
            meshColorButton = new Button();
            meshGroupBox = new GroupBox();
            textureButton = new Button();
            colorDialog1 = new ColorDialog();
            meshColorDialog = new ColorDialog();
            lightAndColorsGroupBox = new GroupBox();
            surfaceGroupBox = new GroupBox();
            drawFillingCheckBox = new CheckBox();
            drawEdgesCheckBox = new CheckBox();
            normalMapCheckBox = new CheckBox();
            normalMapButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            fidelityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fidelityTrackBar).BeginInit();
            alphaAnglePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)alphaAngleTrackBar).BeginInit();
            betaAnglePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)betaAngleTrackBar).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightZAxisTrackBar).BeginInit();
            objectColorPanel.SuspendLayout();
            meshGroupBox.SuspendLayout();
            lightAndColorsGroupBox.SuspendLayout();
            surfaceGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = SystemColors.Control;
            pictureBox.Location = new Point(12, 132);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(824, 494);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.SizeChanged += pictureBox_SizeChanged;
            pictureBox.Paint += pictureBox_Paint;
            // 
            // fidelityPanel
            // 
            fidelityPanel.Controls.Add(fideltyValueLabel);
            fidelityPanel.Controls.Add(fidelityLabel);
            fidelityPanel.Controls.Add(fidelityTrackBar);
            fidelityPanel.Location = new Point(6, 26);
            fidelityPanel.Name = "fidelityPanel";
            fidelityPanel.Size = new Size(187, 82);
            fidelityPanel.TabIndex = 1;
            // 
            // fideltyValueLabel
            // 
            fideltyValueLabel.Location = new Point(146, 11);
            fideltyValueLabel.Name = "fideltyValueLabel";
            fideltyValueLabel.Size = new Size(38, 15);
            fideltyValueLabel.TabIndex = 2;
            fideltyValueLabel.Text = "000";
            fideltyValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // fidelityLabel
            // 
            fidelityLabel.AutoSize = true;
            fidelityLabel.Location = new Point(3, 11);
            fidelityLabel.Name = "fidelityLabel";
            fidelityLabel.Size = new Size(137, 15);
            fidelityLabel.TabIndex = 1;
            fidelityLabel.Text = "Dokładność triangulacji: ";
            // 
            // fidelityTrackBar
            // 
            fidelityTrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fidelityTrackBar.LargeChange = 18;
            fidelityTrackBar.Location = new Point(3, 34);
            fidelityTrackBar.Maximum = 40;
            fidelityTrackBar.Minimum = 4;
            fidelityTrackBar.Name = "fidelityTrackBar";
            fidelityTrackBar.Size = new Size(181, 45);
            fidelityTrackBar.SmallChange = 4;
            fidelityTrackBar.TabIndex = 0;
            fidelityTrackBar.TickFrequency = 4;
            fidelityTrackBar.Value = 4;
            fidelityTrackBar.Scroll += fidelityTrackBar_Scroll;
            // 
            // alphaAnglePanel
            // 
            alphaAnglePanel.Controls.Add(alphaAngleValueLabel);
            alphaAnglePanel.Controls.Add(alphaAngleLabel);
            alphaAnglePanel.Controls.Add(alphaAngleTrackBar);
            alphaAnglePanel.Location = new Point(196, 26);
            alphaAnglePanel.Name = "alphaAnglePanel";
            alphaAnglePanel.Size = new Size(187, 82);
            alphaAnglePanel.TabIndex = 3;
            // 
            // alphaAngleValueLabel
            // 
            alphaAngleValueLabel.Location = new Point(146, 11);
            alphaAngleValueLabel.Name = "alphaAngleValueLabel";
            alphaAngleValueLabel.Size = new Size(38, 15);
            alphaAngleValueLabel.TabIndex = 2;
            alphaAngleValueLabel.Text = "000";
            alphaAngleValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // alphaAngleLabel
            // 
            alphaAngleLabel.AutoSize = true;
            alphaAngleLabel.Location = new Point(3, 11);
            alphaAngleLabel.Name = "alphaAngleLabel";
            alphaAngleLabel.Size = new Size(52, 15);
            alphaAngleLabel.TabIndex = 1;
            alphaAngleLabel.Text = "Kąt alfa: ";
            // 
            // alphaAngleTrackBar
            // 
            alphaAngleTrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            alphaAngleTrackBar.Location = new Point(3, 34);
            alphaAngleTrackBar.Maximum = 45;
            alphaAngleTrackBar.Minimum = -45;
            alphaAngleTrackBar.Name = "alphaAngleTrackBar";
            alphaAngleTrackBar.Size = new Size(181, 45);
            alphaAngleTrackBar.TabIndex = 0;
            alphaAngleTrackBar.Scroll += alphaAngleTrackBar_Scroll;
            // 
            // betaAnglePanel
            // 
            betaAnglePanel.Controls.Add(betaAngleValueLabel);
            betaAnglePanel.Controls.Add(betaAngleLabel);
            betaAnglePanel.Controls.Add(betaAngleTrackBar);
            betaAnglePanel.Location = new Point(389, 26);
            betaAnglePanel.Name = "betaAnglePanel";
            betaAnglePanel.Size = new Size(187, 82);
            betaAnglePanel.TabIndex = 4;
            // 
            // betaAngleValueLabel
            // 
            betaAngleValueLabel.Location = new Point(146, 11);
            betaAngleValueLabel.Name = "betaAngleValueLabel";
            betaAngleValueLabel.Size = new Size(35, 15);
            betaAngleValueLabel.TabIndex = 2;
            betaAngleValueLabel.Text = "000";
            betaAngleValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // betaAngleLabel
            // 
            betaAngleLabel.AutoSize = true;
            betaAngleLabel.Location = new Point(3, 11);
            betaAngleLabel.Name = "betaAngleLabel";
            betaAngleLabel.Size = new Size(56, 15);
            betaAngleLabel.TabIndex = 1;
            betaAngleLabel.Text = "Kąt beta: ";
            // 
            // betaAngleTrackBar
            // 
            betaAngleTrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            betaAngleTrackBar.Location = new Point(3, 34);
            betaAngleTrackBar.Maximum = 90;
            betaAngleTrackBar.Name = "betaAngleTrackBar";
            betaAngleTrackBar.Size = new Size(181, 45);
            betaAngleTrackBar.TabIndex = 0;
            betaAngleTrackBar.Scroll += betaAngleTrackBar_Scroll;
            // 
            // lightColorButton
            // 
            lightColorButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lightColorButton.Location = new Point(6, 22);
            lightColorButton.Name = "lightColorButton";
            lightColorButton.Size = new Size(187, 23);
            lightColorButton.TabIndex = 5;
            lightColorButton.Text = "Zmień kolor światła";
            lightColorButton.UseVisualStyleBackColor = true;
            lightColorButton.Click += lightColorButton_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(kdValueLabel);
            panel1.Controls.Add(kdLabel);
            panel1.Controls.Add(kdTrackBar);
            panel1.Location = new Point(6, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(187, 82);
            panel1.TabIndex = 3;
            // 
            // kdValueLabel
            // 
            kdValueLabel.Location = new Point(146, 11);
            kdValueLabel.Name = "kdValueLabel";
            kdValueLabel.Size = new Size(38, 15);
            kdValueLabel.TabIndex = 2;
            kdValueLabel.Text = "000";
            kdValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // kdLabel
            // 
            kdLabel.AutoSize = true;
            kdLabel.Location = new Point(3, 11);
            kdLabel.Name = "kdLabel";
            kdLabel.Size = new Size(102, 15);
            kdLabel.TabIndex = 1;
            kdLabel.Text = "Współczynnik kd: ";
            // 
            // kdTrackBar
            // 
            kdTrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            kdTrackBar.LargeChange = 2;
            kdTrackBar.Location = new Point(3, 34);
            kdTrackBar.Name = "kdTrackBar";
            kdTrackBar.Size = new Size(181, 45);
            kdTrackBar.TabIndex = 0;
            kdTrackBar.TickFrequency = 10;
            kdTrackBar.Value = 10;
            kdTrackBar.Scroll += kdTrackBar_Scroll;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(ksValueLabel);
            panel2.Controls.Add(ksLabel);
            panel2.Controls.Add(ksTrackBar);
            panel2.Location = new Point(6, 148);
            panel2.Name = "panel2";
            panel2.Size = new Size(187, 82);
            panel2.TabIndex = 6;
            // 
            // ksValueLabel
            // 
            ksValueLabel.Location = new Point(146, 11);
            ksValueLabel.Name = "ksValueLabel";
            ksValueLabel.Size = new Size(38, 15);
            ksValueLabel.TabIndex = 2;
            ksValueLabel.Text = "000";
            ksValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ksLabel
            // 
            ksLabel.AutoSize = true;
            ksLabel.Location = new Point(3, 11);
            ksLabel.Name = "ksLabel";
            ksLabel.Size = new Size(100, 15);
            ksLabel.TabIndex = 1;
            ksLabel.Text = "Współczynnik ks: ";
            // 
            // ksTrackBar
            // 
            ksTrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ksTrackBar.LargeChange = 2;
            ksTrackBar.Location = new Point(3, 34);
            ksTrackBar.Name = "ksTrackBar";
            ksTrackBar.Size = new Size(181, 45);
            ksTrackBar.TabIndex = 0;
            ksTrackBar.TickFrequency = 10;
            ksTrackBar.Scroll += ksTrackBar_Scroll;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(mValueLabel);
            panel3.Controls.Add(mLabel);
            panel3.Controls.Add(mTrackBar);
            panel3.Location = new Point(6, 236);
            panel3.Name = "panel3";
            panel3.Size = new Size(187, 82);
            panel3.TabIndex = 7;
            // 
            // mValueLabel
            // 
            mValueLabel.Location = new Point(146, 11);
            mValueLabel.Name = "mValueLabel";
            mValueLabel.Size = new Size(38, 15);
            mValueLabel.TabIndex = 2;
            mValueLabel.Text = "000";
            mValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // mLabel
            // 
            mLabel.AutoSize = true;
            mLabel.Location = new Point(3, 11);
            mLabel.Name = "mLabel";
            mLabel.Size = new Size(100, 15);
            mLabel.TabIndex = 1;
            mLabel.Text = "Współczynnik m: ";
            // 
            // mTrackBar
            // 
            mTrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mTrackBar.LargeChange = 10;
            mTrackBar.Location = new Point(3, 34);
            mTrackBar.Maximum = 100;
            mTrackBar.Name = "mTrackBar";
            mTrackBar.Size = new Size(181, 45);
            mTrackBar.TabIndex = 0;
            mTrackBar.Scroll += mTrackBar_Scroll;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.Controls.Add(lightZAxisValueLabel);
            panel4.Controls.Add(lightZAxisLabel);
            panel4.Controls.Add(lightZAxisTrackBar);
            panel4.Location = new Point(6, 324);
            panel4.Name = "panel4";
            panel4.Size = new Size(187, 82);
            panel4.TabIndex = 8;
            // 
            // lightZAxisValueLabel
            // 
            lightZAxisValueLabel.Location = new Point(146, 11);
            lightZAxisValueLabel.Name = "lightZAxisValueLabel";
            lightZAxisValueLabel.Size = new Size(38, 15);
            lightZAxisValueLabel.TabIndex = 2;
            lightZAxisValueLabel.Text = "000";
            lightZAxisValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lightZAxisLabel
            // 
            lightZAxisLabel.AutoSize = true;
            lightZAxisLabel.Location = new Point(3, 11);
            lightZAxisLabel.Name = "lightZAxisLabel";
            lightZAxisLabel.Size = new Size(134, 15);
            lightZAxisLabel.TabIndex = 1;
            lightZAxisLabel.Text = "Oś obrotu źródła światła";
            // 
            // lightZAxisTrackBar
            // 
            lightZAxisTrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lightZAxisTrackBar.LargeChange = 10;
            lightZAxisTrackBar.Location = new Point(3, 34);
            lightZAxisTrackBar.Maximum = 100;
            lightZAxisTrackBar.Minimum = -100;
            lightZAxisTrackBar.Name = "lightZAxisTrackBar";
            lightZAxisTrackBar.Size = new Size(181, 45);
            lightZAxisTrackBar.SmallChange = 5;
            lightZAxisTrackBar.TabIndex = 0;
            lightZAxisTrackBar.TickFrequency = 5;
            lightZAxisTrackBar.Scroll += lightZAxisTrackBar_Scroll;
            // 
            // objectColorPanel
            // 
            objectColorPanel.Controls.Add(textureRadioButton);
            objectColorPanel.Controls.Add(fixedColorRadioButton);
            objectColorPanel.Location = new Point(6, 28);
            objectColorPanel.Name = "objectColorPanel";
            objectColorPanel.Size = new Size(187, 26);
            objectColorPanel.TabIndex = 9;
            // 
            // textureRadioButton
            // 
            textureRadioButton.AutoSize = true;
            textureRadioButton.Location = new Point(116, 3);
            textureRadioButton.Name = "textureRadioButton";
            textureRadioButton.Size = new Size(68, 19);
            textureRadioButton.TabIndex = 1;
            textureRadioButton.Text = "Tekstura";
            textureRadioButton.UseVisualStyleBackColor = true;
            textureRadioButton.CheckedChanged += textureRadioButton_CheckedChanged;
            // 
            // fixedColorRadioButton
            // 
            fixedColorRadioButton.AutoSize = true;
            fixedColorRadioButton.Checked = true;
            fixedColorRadioButton.Location = new Point(3, 3);
            fixedColorRadioButton.Name = "fixedColorRadioButton";
            fixedColorRadioButton.Size = new Size(80, 19);
            fixedColorRadioButton.TabIndex = 0;
            fixedColorRadioButton.TabStop = true;
            fixedColorRadioButton.Text = "Stały kolor";
            fixedColorRadioButton.UseVisualStyleBackColor = true;
            fixedColorRadioButton.CheckedChanged += fixedColorRadioButton_CheckedChanged;
            // 
            // meshColorButton
            // 
            meshColorButton.Location = new Point(6, 66);
            meshColorButton.Name = "meshColorButton";
            meshColorButton.Size = new Size(89, 42);
            meshColorButton.TabIndex = 10;
            meshColorButton.Text = "Zmień kolor siatki";
            meshColorButton.UseVisualStyleBackColor = true;
            meshColorButton.Click += meshColorButton_Click;
            // 
            // meshGroupBox
            // 
            meshGroupBox.Controls.Add(fidelityPanel);
            meshGroupBox.Controls.Add(alphaAnglePanel);
            meshGroupBox.Controls.Add(betaAnglePanel);
            meshGroupBox.Location = new Point(12, 12);
            meshGroupBox.Name = "meshGroupBox";
            meshGroupBox.Size = new Size(584, 114);
            meshGroupBox.TabIndex = 11;
            meshGroupBox.TabStop = false;
            meshGroupBox.Text = "Siatka";
            // 
            // textureButton
            // 
            textureButton.Location = new Point(104, 66);
            textureButton.Name = "textureButton";
            textureButton.Size = new Size(89, 42);
            textureButton.TabIndex = 12;
            textureButton.Text = "Zmień teskturę";
            textureButton.UseVisualStyleBackColor = true;
            textureButton.Click += textureButton_Click;
            // 
            // lightAndColorsGroupBox
            // 
            lightAndColorsGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lightAndColorsGroupBox.Controls.Add(lightColorButton);
            lightAndColorsGroupBox.Controls.Add(panel1);
            lightAndColorsGroupBox.Controls.Add(panel2);
            lightAndColorsGroupBox.Controls.Add(panel3);
            lightAndColorsGroupBox.Controls.Add(panel4);
            lightAndColorsGroupBox.Location = new Point(842, 132);
            lightAndColorsGroupBox.Name = "lightAndColorsGroupBox";
            lightAndColorsGroupBox.Size = new Size(199, 494);
            lightAndColorsGroupBox.TabIndex = 13;
            lightAndColorsGroupBox.TabStop = false;
            lightAndColorsGroupBox.Text = "Oświetlenie i kolory";
            // 
            // surfaceGroupBox
            // 
            surfaceGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            surfaceGroupBox.Controls.Add(normalMapButton);
            surfaceGroupBox.Controls.Add(normalMapCheckBox);
            surfaceGroupBox.Controls.Add(drawFillingCheckBox);
            surfaceGroupBox.Controls.Add(drawEdgesCheckBox);
            surfaceGroupBox.Controls.Add(objectColorPanel);
            surfaceGroupBox.Controls.Add(textureButton);
            surfaceGroupBox.Controls.Add(meshColorButton);
            surfaceGroupBox.Location = new Point(602, 12);
            surfaceGroupBox.Name = "surfaceGroupBox";
            surfaceGroupBox.Size = new Size(439, 114);
            surfaceGroupBox.TabIndex = 14;
            surfaceGroupBox.TabStop = false;
            surfaceGroupBox.Text = "Powierzchnia siatki";
            // 
            // drawFillingCheckBox
            // 
            drawFillingCheckBox.AutoSize = true;
            drawFillingCheckBox.Checked = true;
            drawFillingCheckBox.CheckState = CheckState.Checked;
            drawFillingCheckBox.Location = new Point(314, 26);
            drawFillingCheckBox.Name = "drawFillingCheckBox";
            drawFillingCheckBox.Size = new Size(120, 19);
            drawFillingCheckBox.TabIndex = 14;
            drawFillingCheckBox.Text = "Rysuj wypełnienie";
            drawFillingCheckBox.UseVisualStyleBackColor = true;
            drawFillingCheckBox.CheckedChanged += drawFillingCheckBox_CheckedChanged;
            // 
            // drawEdgesCheckBox
            // 
            drawEdgesCheckBox.AutoSize = true;
            drawEdgesCheckBox.Checked = true;
            drawEdgesCheckBox.CheckState = CheckState.Checked;
            drawEdgesCheckBox.Location = new Point(199, 26);
            drawEdgesCheckBox.Name = "drawEdgesCheckBox";
            drawEdgesCheckBox.Size = new Size(109, 19);
            drawEdgesCheckBox.TabIndex = 13;
            drawEdgesCheckBox.Text = "Rysuj krawędzie";
            drawEdgesCheckBox.UseVisualStyleBackColor = true;
            drawEdgesCheckBox.CheckedChanged += drawEdgesCheckBox_CheckedChanged;
            // 
            // normalMapCheckBox
            // 
            normalMapCheckBox.AutoSize = true;
            normalMapCheckBox.Location = new Point(199, 66);
            normalMapCheckBox.Name = "normalMapCheckBox";
            normalMapCheckBox.Size = new Size(203, 19);
            normalMapCheckBox.TabIndex = 15;
            normalMapCheckBox.Text = "Użyj mapy wektorów normalnych";
            normalMapCheckBox.UseVisualStyleBackColor = true;
            normalMapCheckBox.CheckedChanged += normalMapCheckBox_CheckedChanged;
            // 
            // normalMapButton
            // 
            normalMapButton.Location = new Point(199, 85);
            normalMapButton.Name = "normalMapButton";
            normalMapButton.Size = new Size(224, 23);
            normalMapButton.TabIndex = 16;
            normalMapButton.Text = "Zmień mapę wektorów normalnych";
            normalMapButton.UseVisualStyleBackColor = true;
            normalMapButton.Click += normalMapButton_Click;
            // 
            // MeshDisplayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 630);
            Controls.Add(surfaceGroupBox);
            Controls.Add(lightAndColorsGroupBox);
            Controls.Add(meshGroupBox);
            Controls.Add(pictureBox);
            Name = "MeshDisplayer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MeshDisplayer";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            fidelityPanel.ResumeLayout(false);
            fidelityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fidelityTrackBar).EndInit();
            alphaAnglePanel.ResumeLayout(false);
            alphaAnglePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)alphaAngleTrackBar).EndInit();
            betaAnglePanel.ResumeLayout(false);
            betaAnglePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)betaAngleTrackBar).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightZAxisTrackBar).EndInit();
            objectColorPanel.ResumeLayout(false);
            objectColorPanel.PerformLayout();
            meshGroupBox.ResumeLayout(false);
            lightAndColorsGroupBox.ResumeLayout(false);
            surfaceGroupBox.ResumeLayout(false);
            surfaceGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Panel fidelityPanel;
        private Label fidelityLabel;
        private TrackBar fidelityTrackBar;
        private Label fideltyValueLabel;
        private Panel alphaAnglePanel;
        private Label alphaAngleValueLabel;
        private Label alphaAngleLabel;
        private TrackBar alphaAngleTrackBar;
        private Panel betaAnglePanel;
        private Label betaAngleValueLabel;
        private Label betaAngleLabel;
        private TrackBar betaAngleTrackBar;
        private ColorDialog lightColorDialog;
        private Button lightColorButton;
        private Panel panel1;
        private Label kdValueLabel;
        private Label kdLabel;
        private TrackBar kdTrackBar;
        private Panel panel2;
        private Label ksValueLabel;
        private Label ksLabel;
        private TrackBar ksTrackBar;
        private Panel panel3;
        private Label mValueLabel;
        private Label mLabel;
        private TrackBar mTrackBar;
        private Panel panel4;
        private Label lightZAxisValueLabel;
        private Label lightZAxisLabel;
        private TrackBar lightZAxisTrackBar;
        private Panel objectColorPanel;
        private RadioButton textureRadioButton;
        private RadioButton fixedColorRadioButton;
        private OpenFileDialog openFileDialog;
        private Button meshColorButton;
        private GroupBox meshGroupBox;
        private Button textureButton;
        private ColorDialog colorDialog1;
        private ColorDialog meshColorDialog;
        private GroupBox lightAndColorsGroupBox;
        private GroupBox surfaceGroupBox;
        private CheckBox drawFillingCheckBox;
        private CheckBox drawEdgesCheckBox;
        private Button normalMapButton;
        private CheckBox normalMapCheckBox;
    }
}
