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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeshDisplayer));
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
            colorDialog = new ColorDialog();
            lightColorButton = new Button();
            kdPanel = new Panel();
            kdValueLabel = new Label();
            kdLabel = new Label();
            kdTrackBar = new TrackBar();
            lightColorPictureBox = new PictureBox();
            ksPanel = new Panel();
            ksValueLabel = new Label();
            ksLabel = new Label();
            ksTrackBar = new TrackBar();
            mPanel = new Panel();
            mValueLabel = new Label();
            mLabel = new Label();
            mTrackBar = new TrackBar();
            LightZCoordPanel = new Panel();
            lightZCoordValueLabel = new Label();
            lightZCoordLabel = new Label();
            lightZCoordTrackBar = new TrackBar();
            objectColorPanel = new Panel();
            textureRadioButton = new RadioButton();
            fixedColorRadioButton = new RadioButton();
            openFileDialog = new OpenFileDialog();
            meshColorButton = new Button();
            meshGroupBox = new GroupBox();
            textureButton = new Button();
            lightAndColorsGroupBox = new GroupBox();
            resetLightPositionButton = new Button();
            moveLightCheckBox = new CheckBox();
            surfaceGroupBox = new GroupBox();
            texturePictureBox = new PictureBox();
            normalMapCheckBox = new CheckBox();
            meshColorPictureBox = new PictureBox();
            drawFillingCheckBox = new CheckBox();
            normalMapPictureBox = new PictureBox();
            drawEdgesCheckBox = new CheckBox();
            normalMapButton = new Button();
            fpsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            fidelityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fidelityTrackBar).BeginInit();
            alphaAnglePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)alphaAngleTrackBar).BeginInit();
            betaAnglePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)betaAngleTrackBar).BeginInit();
            kdPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lightColorPictureBox).BeginInit();
            ksPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).BeginInit();
            mPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).BeginInit();
            LightZCoordPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightZCoordTrackBar).BeginInit();
            objectColorPanel.SuspendLayout();
            meshGroupBox.SuspendLayout();
            lightAndColorsGroupBox.SuspendLayout();
            surfaceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)texturePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)meshColorPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)normalMapPictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = SystemColors.Control;
            pictureBox.Location = new Point(12, 132);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(943, 663);
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
            alphaAnglePanel.Location = new Point(6, 120);
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
            betaAnglePanel.Location = new Point(6, 208);
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
            lightColorButton.Location = new Point(7, 22);
            lightColorButton.Name = "lightColorButton";
            lightColorButton.Size = new Size(139, 23);
            lightColorButton.TabIndex = 5;
            lightColorButton.Text = "Zmień kolor światła";
            lightColorButton.UseVisualStyleBackColor = true;
            lightColorButton.Click += lightColorButton_Click;
            // 
            // kdPanel
            // 
            kdPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            kdPanel.Controls.Add(kdValueLabel);
            kdPanel.Controls.Add(kdLabel);
            kdPanel.Controls.Add(kdTrackBar);
            kdPanel.Location = new Point(7, 60);
            kdPanel.Name = "kdPanel";
            kdPanel.Size = new Size(187, 82);
            kdPanel.TabIndex = 3;
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
            kdTrackBar.Value = 10;
            kdTrackBar.Scroll += kdTrackBar_Scroll;
            // 
            // lightColorPictureBox
            // 
            lightColorPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lightColorPictureBox.Location = new Point(152, 22);
            lightColorPictureBox.Name = "lightColorPictureBox";
            lightColorPictureBox.Size = new Size(42, 23);
            lightColorPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            lightColorPictureBox.TabIndex = 20;
            lightColorPictureBox.TabStop = false;
            // 
            // ksPanel
            // 
            ksPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ksPanel.Controls.Add(ksValueLabel);
            ksPanel.Controls.Add(ksLabel);
            ksPanel.Controls.Add(ksTrackBar);
            ksPanel.Location = new Point(7, 148);
            ksPanel.Name = "ksPanel";
            ksPanel.Size = new Size(187, 82);
            ksPanel.TabIndex = 6;
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
            ksTrackBar.Scroll += ksTrackBar_Scroll;
            // 
            // mPanel
            // 
            mPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            mPanel.Controls.Add(mValueLabel);
            mPanel.Controls.Add(mLabel);
            mPanel.Controls.Add(mTrackBar);
            mPanel.Location = new Point(7, 236);
            mPanel.Name = "mPanel";
            mPanel.Size = new Size(187, 82);
            mPanel.TabIndex = 7;
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
            // LightZCoordPanel
            // 
            LightZCoordPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LightZCoordPanel.Controls.Add(lightZCoordValueLabel);
            LightZCoordPanel.Controls.Add(lightZCoordLabel);
            LightZCoordPanel.Controls.Add(lightZCoordTrackBar);
            LightZCoordPanel.Location = new Point(7, 324);
            LightZCoordPanel.Name = "LightZCoordPanel";
            LightZCoordPanel.Size = new Size(187, 82);
            LightZCoordPanel.TabIndex = 8;
            // 
            // lightZCoordValueLabel
            // 
            lightZCoordValueLabel.Location = new Point(146, 11);
            lightZCoordValueLabel.Name = "lightZCoordValueLabel";
            lightZCoordValueLabel.Size = new Size(38, 15);
            lightZCoordValueLabel.TabIndex = 2;
            lightZCoordValueLabel.Text = "000";
            lightZCoordValueLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lightZCoordLabel
            // 
            lightZCoordLabel.AutoSize = true;
            lightZCoordLabel.Location = new Point(3, 11);
            lightZCoordLabel.Name = "lightZCoordLabel";
            lightZCoordLabel.Size = new Size(99, 15);
            lightZCoordLabel.TabIndex = 1;
            lightZCoordLabel.Text = "Wysokość światła";
            // 
            // lightZCoordTrackBar
            // 
            lightZCoordTrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lightZCoordTrackBar.LargeChange = 50;
            lightZCoordTrackBar.Location = new Point(3, 34);
            lightZCoordTrackBar.Maximum = 500;
            lightZCoordTrackBar.Minimum = -500;
            lightZCoordTrackBar.Name = "lightZCoordTrackBar";
            lightZCoordTrackBar.Size = new Size(181, 45);
            lightZCoordTrackBar.SmallChange = 5;
            lightZCoordTrackBar.TabIndex = 0;
            lightZCoordTrackBar.TickFrequency = 5;
            lightZCoordTrackBar.Value = 200;
            lightZCoordTrackBar.Scroll += lightZAxisTrackBar_Scroll;
            // 
            // objectColorPanel
            // 
            objectColorPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            objectColorPanel.Controls.Add(textureRadioButton);
            objectColorPanel.Controls.Add(fixedColorRadioButton);
            objectColorPanel.Location = new Point(749, 19);
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
            meshColorButton.Location = new Point(226, 19);
            meshColorButton.Name = "meshColorButton";
            meshColorButton.Size = new Size(89, 89);
            meshColorButton.TabIndex = 10;
            meshColorButton.Text = "Zmień kolor siatki";
            meshColorButton.UseVisualStyleBackColor = true;
            meshColorButton.Click += meshColorButton_Click;
            // 
            // meshGroupBox
            // 
            meshGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            meshGroupBox.Controls.Add(fidelityPanel);
            meshGroupBox.Controls.Add(alphaAnglePanel);
            meshGroupBox.Controls.Add(betaAnglePanel);
            meshGroupBox.Location = new Point(960, 12);
            meshGroupBox.Name = "meshGroupBox";
            meshGroupBox.Size = new Size(200, 299);
            meshGroupBox.TabIndex = 11;
            meshGroupBox.TabStop = false;
            meshGroupBox.Text = "Siatka";
            // 
            // textureButton
            // 
            textureButton.Location = new Point(448, 19);
            textureButton.Name = "textureButton";
            textureButton.Size = new Size(89, 89);
            textureButton.TabIndex = 12;
            textureButton.Text = "Zmień teskturę";
            textureButton.UseVisualStyleBackColor = true;
            textureButton.Click += textureButton_Click;
            // 
            // lightAndColorsGroupBox
            // 
            lightAndColorsGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lightAndColorsGroupBox.Controls.Add(lightColorPictureBox);
            lightAndColorsGroupBox.Controls.Add(resetLightPositionButton);
            lightAndColorsGroupBox.Controls.Add(moveLightCheckBox);
            lightAndColorsGroupBox.Controls.Add(lightColorButton);
            lightAndColorsGroupBox.Controls.Add(kdPanel);
            lightAndColorsGroupBox.Controls.Add(ksPanel);
            lightAndColorsGroupBox.Controls.Add(mPanel);
            lightAndColorsGroupBox.Controls.Add(LightZCoordPanel);
            lightAndColorsGroupBox.Location = new Point(960, 317);
            lightAndColorsGroupBox.Name = "lightAndColorsGroupBox";
            lightAndColorsGroupBox.Size = new Size(200, 478);
            lightAndColorsGroupBox.TabIndex = 13;
            lightAndColorsGroupBox.TabStop = false;
            lightAndColorsGroupBox.Text = "Oświetlenie i kolory";
            // 
            // resetLightPositionButton
            // 
            resetLightPositionButton.Location = new Point(6, 447);
            resetLightPositionButton.Name = "resetLightPositionButton";
            resetLightPositionButton.Size = new Size(188, 23);
            resetLightPositionButton.TabIndex = 18;
            resetLightPositionButton.Text = "Zresetuj pozycję światła";
            resetLightPositionButton.UseVisualStyleBackColor = true;
            resetLightPositionButton.Click += resetLightPositionButton_Click;
            // 
            // moveLightCheckBox
            // 
            moveLightCheckBox.AutoSize = true;
            moveLightCheckBox.Location = new Point(9, 422);
            moveLightCheckBox.Name = "moveLightCheckBox";
            moveLightCheckBox.Size = new Size(120, 19);
            moveLightCheckBox.TabIndex = 17;
            moveLightCheckBox.Text = "Poruszaj światłem";
            moveLightCheckBox.UseVisualStyleBackColor = true;
            moveLightCheckBox.CheckedChanged += moveLightCheckBox_CheckedChanged;
            // 
            // surfaceGroupBox
            // 
            surfaceGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            surfaceGroupBox.Controls.Add(texturePictureBox);
            surfaceGroupBox.Controls.Add(normalMapCheckBox);
            surfaceGroupBox.Controls.Add(textureButton);
            surfaceGroupBox.Controls.Add(meshColorPictureBox);
            surfaceGroupBox.Controls.Add(drawFillingCheckBox);
            surfaceGroupBox.Controls.Add(normalMapPictureBox);
            surfaceGroupBox.Controls.Add(meshColorButton);
            surfaceGroupBox.Controls.Add(drawEdgesCheckBox);
            surfaceGroupBox.Controls.Add(normalMapButton);
            surfaceGroupBox.Controls.Add(objectColorPanel);
            surfaceGroupBox.Location = new Point(12, 12);
            surfaceGroupBox.Name = "surfaceGroupBox";
            surfaceGroupBox.Size = new Size(942, 114);
            surfaceGroupBox.TabIndex = 14;
            surfaceGroupBox.TabStop = false;
            surfaceGroupBox.Text = "Powierzchnia siatki";
            // 
            // texturePictureBox
            // 
            texturePictureBox.Location = new Point(543, 19);
            texturePictureBox.Name = "texturePictureBox";
            texturePictureBox.Size = new Size(121, 89);
            texturePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            texturePictureBox.TabIndex = 19;
            texturePictureBox.TabStop = false;
            // 
            // normalMapCheckBox
            // 
            normalMapCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            normalMapCheckBox.AutoSize = true;
            normalMapCheckBox.Location = new Point(730, 80);
            normalMapCheckBox.Name = "normalMapCheckBox";
            normalMapCheckBox.Size = new Size(203, 19);
            normalMapCheckBox.TabIndex = 15;
            normalMapCheckBox.Text = "Użyj mapy wektorów normalnych";
            normalMapCheckBox.UseVisualStyleBackColor = true;
            normalMapCheckBox.CheckedChanged += normalMapCheckBox_CheckedChanged;
            // 
            // meshColorPictureBox
            // 
            meshColorPictureBox.Location = new Point(321, 19);
            meshColorPictureBox.Name = "meshColorPictureBox";
            meshColorPictureBox.Size = new Size(121, 89);
            meshColorPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            meshColorPictureBox.TabIndex = 18;
            meshColorPictureBox.TabStop = false;
            // 
            // drawFillingCheckBox
            // 
            drawFillingCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            drawFillingCheckBox.AutoSize = true;
            drawFillingCheckBox.Checked = true;
            drawFillingCheckBox.CheckState = CheckState.Checked;
            drawFillingCheckBox.Location = new Point(701, 55);
            drawFillingCheckBox.Name = "drawFillingCheckBox";
            drawFillingCheckBox.Size = new Size(120, 19);
            drawFillingCheckBox.TabIndex = 14;
            drawFillingCheckBox.Text = "Rysuj wypełnienie";
            drawFillingCheckBox.UseVisualStyleBackColor = true;
            drawFillingCheckBox.CheckedChanged += drawFillingCheckBox_CheckedChanged;
            // 
            // normalMapPictureBox
            // 
            normalMapPictureBox.Location = new Point(99, 19);
            normalMapPictureBox.Name = "normalMapPictureBox";
            normalMapPictureBox.Size = new Size(121, 89);
            normalMapPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            normalMapPictureBox.TabIndex = 17;
            normalMapPictureBox.TabStop = false;
            // 
            // drawEdgesCheckBox
            // 
            drawEdgesCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            drawEdgesCheckBox.AutoSize = true;
            drawEdgesCheckBox.Checked = true;
            drawEdgesCheckBox.CheckState = CheckState.Checked;
            drawEdgesCheckBox.Location = new Point(827, 55);
            drawEdgesCheckBox.Name = "drawEdgesCheckBox";
            drawEdgesCheckBox.Size = new Size(109, 19);
            drawEdgesCheckBox.TabIndex = 13;
            drawEdgesCheckBox.Text = "Rysuj krawędzie";
            drawEdgesCheckBox.UseVisualStyleBackColor = true;
            drawEdgesCheckBox.CheckedChanged += drawEdgesCheckBox_CheckedChanged;
            // 
            // normalMapButton
            // 
            normalMapButton.Location = new Point(6, 19);
            normalMapButton.Name = "normalMapButton";
            normalMapButton.Size = new Size(87, 89);
            normalMapButton.TabIndex = 16;
            normalMapButton.Text = "Zmień mapę wektorów normalnych";
            normalMapButton.UseVisualStyleBackColor = true;
            normalMapButton.Click += normalMapButton_Click;
            // 
            // fpsLabel
            // 
            fpsLabel.AutoSize = true;
            fpsLabel.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            fpsLabel.Location = new Point(20, 139);
            fpsLabel.Name = "fpsLabel";
            fpsLabel.Size = new Size(62, 40);
            fpsLabel.TabIndex = 15;
            fpsLabel.Text = "FPS";
            // 
            // MeshDisplayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1172, 807);
            Controls.Add(fpsLabel);
            Controls.Add(surfaceGroupBox);
            Controls.Add(lightAndColorsGroupBox);
            Controls.Add(meshGroupBox);
            Controls.Add(pictureBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1188, 846);
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
            kdPanel.ResumeLayout(false);
            kdPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)lightColorPictureBox).EndInit();
            ksPanel.ResumeLayout(false);
            ksPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).EndInit();
            mPanel.ResumeLayout(false);
            mPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).EndInit();
            LightZCoordPanel.ResumeLayout(false);
            LightZCoordPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightZCoordTrackBar).EndInit();
            objectColorPanel.ResumeLayout(false);
            objectColorPanel.PerformLayout();
            meshGroupBox.ResumeLayout(false);
            lightAndColorsGroupBox.ResumeLayout(false);
            lightAndColorsGroupBox.PerformLayout();
            surfaceGroupBox.ResumeLayout(false);
            surfaceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)texturePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)meshColorPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)normalMapPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private ColorDialog colorDialog;
        private Button lightColorButton;
        private Panel kdPanel;
        private Label kdValueLabel;
        private Label kdLabel;
        private TrackBar kdTrackBar;
        private Panel ksPanel;
        private Label ksValueLabel;
        private Label ksLabel;
        private TrackBar ksTrackBar;
        private Panel mPanel;
        private Label mValueLabel;
        private Label mLabel;
        private TrackBar mTrackBar;
        private Panel LightZCoordPanel;
        private Label lightZCoordValueLabel;
        private Label lightZCoordLabel;
        private TrackBar lightZCoordTrackBar;
        private Panel objectColorPanel;
        private RadioButton textureRadioButton;
        private RadioButton fixedColorRadioButton;
        private OpenFileDialog openFileDialog;
        private Button meshColorButton;
        private GroupBox meshGroupBox;
        private Button textureButton;
        private GroupBox lightAndColorsGroupBox;
        private GroupBox surfaceGroupBox;
        private CheckBox drawFillingCheckBox;
        private CheckBox drawEdgesCheckBox;
        private Button normalMapButton;
        private CheckBox normalMapCheckBox;
        private CheckBox moveLightCheckBox;
        private Button resetLightPositionButton;
        private PictureBox texturePictureBox;
        private PictureBox meshColorPictureBox;
        private PictureBox normalMapPictureBox;
        private PictureBox lightColorPictureBox;
        private Label fpsLabel;
    }
}
