﻿namespace Polycode.NostalgicPlayer.GuiKit.Controls
{
	partial class CustomMessageBox
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomMessageBox));
			this.messageLabel = new Krypton.Toolkit.KryptonLabel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.messagePanel = new System.Windows.Forms.Panel();
			this.buttonPanel = new System.Windows.Forms.Panel();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.fontPalette = new Polycode.NostalgicPlayer.GuiKit.Components.FontPalette(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.messagePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// messageLabel
			// 
			this.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.messageLabel.Location = new System.Drawing.Point(0, 0);
			this.messageLabel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.messageLabel.Name = "messageLabel";
			this.messageLabel.Palette = this.fontPalette;
			this.messageLabel.PaletteMode = Krypton.Toolkit.PaletteMode.Custom;
			this.messageLabel.Size = new System.Drawing.Size(54, 18);
			this.messageLabel.TabIndex = 0;
			this.messageLabel.Values.Text = "label1";
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(15, 15);
			this.pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(37, 37);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			// 
			// messagePanel
			// 
			this.messagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.messagePanel.AutoSize = true;
			this.messagePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.messagePanel.Controls.Add(this.messageLabel);
			this.messagePanel.Location = new System.Drawing.Point(56, 15);
			this.messagePanel.Margin = new System.Windows.Forms.Padding(0);
			this.messagePanel.Name = "messagePanel";
			this.messagePanel.Size = new System.Drawing.Size(54, 18);
			this.messagePanel.TabIndex = 3;
			// 
			// buttonPanel
			// 
			this.buttonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPanel.AutoSize = true;
			this.buttonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.buttonPanel.Location = new System.Drawing.Point(273, 56);
			this.buttonPanel.Margin = new System.Windows.Forms.Padding(0, 12, 0, 6);
			this.buttonPanel.Name = "buttonPanel";
			this.buttonPanel.Size = new System.Drawing.Size(0, 0);
			this.buttonPanel.TabIndex = 4;
			// 
			// imageList
			// 
			this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "Information.png");
			this.imageList.Images.SetKeyName(1, "Question.png");
			this.imageList.Images.SetKeyName(2, "Warning.png");
			this.imageList.Images.SetKeyName(3, "Error.png");
			// 
			// CustomMessageBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(284, 62);
			this.ControlBox = false;
			this.Controls.Add(this.buttonPanel);
			this.Controls.Add(this.messagePanel);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(581, 340);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(114, 52);
			this.Name = "CustomMessageBox";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Dialog";
			this.Resize += new System.EventHandler(this.CustomMessageBox_Resize);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.messagePanel.ResumeLayout(false);
			this.messagePanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Krypton.Toolkit.KryptonLabel messageLabel;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Panel messagePanel;
		private System.Windows.Forms.Panel buttonPanel;
		private System.Windows.Forms.ImageList imageList;
		private Components.FontPalette fontPalette;
	}
}