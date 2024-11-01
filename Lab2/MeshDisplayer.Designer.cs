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
            fideltyPanel = new Panel();
            fideltyValueLabel = new Label();
            fideltyLabel = new Label();
            fideltyTrackBar = new TrackBar();
            panel1 = new Panel();
            alphaAngleValueLabel = new Label();
            alphaAngleLabel = new Label();
            alphaAngleTrackBar = new TrackBar();
            panel2 = new Panel();
            betaAngleValueLabel = new Label();
            betaAngleLabel = new Label();
            betaAngleTrackBar = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            fideltyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fideltyTrackBar).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)alphaAngleTrackBar).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)betaAngleTrackBar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox.BackColor = Color.White;
            pictureBox.Location = new Point(12, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(583, 426);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // fideltyPanel
            // 
            fideltyPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            fideltyPanel.Controls.Add(fideltyValueLabel);
            fideltyPanel.Controls.Add(fideltyLabel);
            fideltyPanel.Controls.Add(fideltyTrackBar);
            fideltyPanel.Location = new Point(601, 12);
            fideltyPanel.Name = "fideltyPanel";
            fideltyPanel.Size = new Size(187, 82);
            fideltyPanel.TabIndex = 1;
            // 
            // fideltyValueLabel
            // 
            fideltyValueLabel.Location = new Point(146, 11);
            fideltyValueLabel.Name = "fideltyValueLabel";
            fideltyValueLabel.Size = new Size(38, 15);
            fideltyValueLabel.TabIndex = 2;
            fideltyValueLabel.Text = "000";
            // 
            // fideltyLabel
            // 
            fideltyLabel.AutoSize = true;
            fideltyLabel.Location = new Point(3, 11);
            fideltyLabel.Name = "fideltyLabel";
            fideltyLabel.Size = new Size(137, 15);
            fideltyLabel.TabIndex = 1;
            fideltyLabel.Text = "Dokładność triangulacji: ";
            // 
            // fideltyTrackBar
            // 
            fideltyTrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fideltyTrackBar.Location = new Point(3, 34);
            fideltyTrackBar.Name = "fideltyTrackBar";
            fideltyTrackBar.Size = new Size(181, 45);
            fideltyTrackBar.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(alphaAngleValueLabel);
            panel1.Controls.Add(alphaAngleLabel);
            panel1.Controls.Add(alphaAngleTrackBar);
            panel1.Location = new Point(601, 100);
            panel1.Name = "panel1";
            panel1.Size = new Size(187, 82);
            panel1.TabIndex = 3;
            // 
            // alphaAngleValueLabel
            // 
            alphaAngleValueLabel.Location = new Point(146, 11);
            alphaAngleValueLabel.Name = "alphaAngleValueLabel";
            alphaAngleValueLabel.Size = new Size(38, 15);
            alphaAngleValueLabel.TabIndex = 2;
            alphaAngleValueLabel.Text = "000";
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
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(betaAngleValueLabel);
            panel2.Controls.Add(betaAngleLabel);
            panel2.Controls.Add(betaAngleTrackBar);
            panel2.Location = new Point(604, 188);
            panel2.Name = "panel2";
            panel2.Size = new Size(184, 82);
            panel2.TabIndex = 4;
            // 
            // betaAngleValueLabel
            // 
            betaAngleValueLabel.Location = new Point(146, 11);
            betaAngleValueLabel.Name = "betaAngleValueLabel";
            betaAngleValueLabel.Size = new Size(35, 15);
            betaAngleValueLabel.TabIndex = 2;
            betaAngleValueLabel.Text = "000";
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
            betaAngleTrackBar.Size = new Size(178, 45);
            betaAngleTrackBar.TabIndex = 0;
            // 
            // MeshDisplayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(fideltyPanel);
            Controls.Add(pictureBox);
            Name = "MeshDisplayer";
            Text = "MeshDisplayer";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            fideltyPanel.ResumeLayout(false);
            fideltyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fideltyTrackBar).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)alphaAngleTrackBar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)betaAngleTrackBar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Panel fideltyPanel;
        private Label fideltyLabel;
        private TrackBar fideltyTrackBar;
        private Label fideltyValueLabel;
        private Panel panel1;
        private Label alphaAngleValueLabel;
        private Label alphaAngleLabel;
        private TrackBar alphaAngleTrackBar;
        private Panel panel2;
        private Label betaAngleValueLabel;
        private Label betaAngleLabel;
        private TrackBar betaAngleTrackBar;
    }
}
