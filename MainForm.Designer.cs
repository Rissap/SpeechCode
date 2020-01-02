/*
 * Created by SharpDevelop.
 * User: Riisa
 * Date: 02.01.2020
 * Time: 12:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SpeechCode
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.inputLabel = new System.Windows.Forms.TextBox();
			this.outputLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(497, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Recognize";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.RecognizeText);
			// 
			// inputLabel
			// 
			this.inputLabel.Location = new System.Drawing.Point(12, 13);
			this.inputLabel.Name = "inputLabel";
			this.inputLabel.Size = new System.Drawing.Size(479, 20);
			this.inputLabel.TabIndex = 1;
			// 
			// outputLabel
			// 
			this.outputLabel.Location = new System.Drawing.Point(12, 45);
			this.outputLabel.Name = "outputLabel";
			this.outputLabel.Size = new System.Drawing.Size(560, 237);
			this.outputLabel.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 291);
			this.Controls.Add(this.outputLabel);
			this.Controls.Add(this.inputLabel);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "SpeechCode";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label outputLabel;
		private System.Windows.Forms.TextBox inputLabel;
		private System.Windows.Forms.Button button1;
	}
}
