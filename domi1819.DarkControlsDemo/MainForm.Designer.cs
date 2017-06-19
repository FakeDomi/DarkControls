using System.Windows.Controls;

namespace domi1819.DarkControlsDemo
{
    partial class MainForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.darkTextbox23 = new domi1819.DarkControls.DarkTextbox2();
            this.darkTextbox21 = new domi1819.DarkControls.DarkTextbox2();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 208);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "darkTextbox21";
            // 
            // darkTextbox23
            // 
            this.darkTextbox23.Location = new System.Drawing.Point(116, 234);
            this.darkTextbox23.MinimumSize = new System.Drawing.Size(20, 20);
            this.darkTextbox23.Name = "darkTextbox23";
            this.darkTextbox23.Size = new System.Drawing.Size(109, 20);
            this.darkTextbox23.TabIndex = 3;
            this.darkTextbox23.Text = "darkTextbox23";
            this.darkTextbox23.UseSystemPasswordChar = false;
            // 
            // darkTextbox21
            // 
            this.darkTextbox21.Location = new System.Drawing.Point(116, 260);
            this.darkTextbox21.MinimumSize = new System.Drawing.Size(20, 20);
            this.darkTextbox21.Name = "darkTextbox21";
            this.darkTextbox21.ReadOnly = true;
            this.darkTextbox21.Size = new System.Drawing.Size(109, 20);
            this.darkTextbox21.TabIndex = 4;
            this.darkTextbox21.Text = "darkTextbox21";
            this.darkTextbox21.UseSystemPasswordChar = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 528);
            this.Controls.Add(this.darkTextbox21);
            this.Controls.Add(this.darkTextbox23);
            this.Controls.Add(this.textBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private DarkControls.DarkTextbox2 darkTextbox23;
        private DarkControls.DarkTextbox2 darkTextbox21;
    }
}

