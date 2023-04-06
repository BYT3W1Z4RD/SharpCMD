namespace SharpCMD
{
    partial class SharpCMD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpCMD));
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.outputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.outputTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.outputTextBox.Location = new System.Drawing.Point(0, 0);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(711, 313);
            this.outputTextBox.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputTextBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.inputTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.inputTextBox.Location = new System.Drawing.Point(0, 313);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(711, 25);
            this.inputTextBox.TabIndex = 1;
            this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputTextBox_KeyDown);
            // 
            // SharpCMD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(711, 338);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.inputTextBox);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "SharpCMD";
            this.Text = "SharpCMD";
            this.Load += new System.EventHandler(this.CommandPromptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
    }
}