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
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            fidelityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fidelityTrackBar).BeginInit();
            alphaAnglePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)alphaAngleTrackBar).BeginInit();
            betaAnglePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)betaAngleTrackBar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = SystemColors.Control;
            pictureBox.Location = new Point(12, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(583, 426);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.SizeChanged += pictureBox_SizeChanged;
            pictureBox.Paint += pictureBox_Paint;
            // 
            // fidelityPanel
            // 
            fidelityPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            fidelityPanel.Controls.Add(fideltyValueLabel);
            fidelityPanel.Controls.Add(fidelityLabel);
            fidelityPanel.Controls.Add(fidelityTrackBar);
            fidelityPanel.Location = new Point(601, 12);
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
            fidelityTrackBar.LargeChange = 20;
            fidelityTrackBar.Location = new Point(3, 34);
            fidelityTrackBar.Maximum = 100;
            fidelityTrackBar.Minimum = 10;
            fidelityTrackBar.Name = "fidelityTrackBar";
            fidelityTrackBar.Size = new Size(181, 45);
            fidelityTrackBar.SmallChange = 10;
            fidelityTrackBar.TabIndex = 0;
            fidelityTrackBar.TickFrequency = 10;
            fidelityTrackBar.Value = 10;
            fidelityTrackBar.Scroll += fidelityTrackBar_Scroll;
            // 
            // alphaAnglePanel
            // 
            alphaAnglePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            alphaAnglePanel.Controls.Add(alphaAngleValueLabel);
            alphaAnglePanel.Controls.Add(alphaAngleLabel);
            alphaAnglePanel.Controls.Add(alphaAngleTrackBar);
            alphaAnglePanel.Location = new Point(601, 100);
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
            betaAnglePanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            betaAnglePanel.Controls.Add(betaAngleValueLabel);
            betaAnglePanel.Controls.Add(betaAngleLabel);
            betaAnglePanel.Controls.Add(betaAngleTrackBar);
            betaAnglePanel.Location = new Point(601, 188);
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
            betaAngleTrackBar.Name = "betaAngleTrackBar";
            betaAngleTrackBar.Size = new Size(181, 45);
            betaAngleTrackBar.TabIndex = 0;
            betaAngleTrackBar.Scroll += betaAngleTrackBar_Scroll;
            // 
            // MeshDisplayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(betaAnglePanel);
            Controls.Add(alphaAnglePanel);
            Controls.Add(fidelityPanel);
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
    }
}
