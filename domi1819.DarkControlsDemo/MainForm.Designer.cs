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
            this.coloredBox1 = new domi1819.DarkControls.ColoredBox();
            this.darkColorView1 = new domi1819.DarkControls.DarkColorView();
            this.darkColorView2 = new domi1819.DarkControls.DarkColorView();
            this.SuspendLayout();
            // 
            // coloredBox1
            // 
            this.coloredBox1.BorderColor = System.Drawing.Color.Gold;
            this.coloredBox1.Location = new System.Drawing.Point(12, 12);
            this.coloredBox1.Name = "coloredBox1";
            this.coloredBox1.Size = new System.Drawing.Size(114, 52);
            this.coloredBox1.TabIndex = 0;
            this.coloredBox1.Text = "coloredBox1";
            // 
            // darkColorView1
            // 
            this.darkColorView1.Color = System.Drawing.Color.Gray;
            this.darkColorView1.CustomText = "Filling: ";
            this.darkColorView1.Location = new System.Drawing.Point(132, 12);
            this.darkColorView1.Name = "darkColorView1";
            this.darkColorView1.Size = new System.Drawing.Size(166, 23);
            this.darkColorView1.TabIndex = 1;
            this.darkColorView1.Text = "darkColorView1";
            this.darkColorView1.ColorSelected += new System.EventHandler<domi1819.DarkControls.ColorSelectedEventArgs>(this.UpdateColors);
            // 
            // darkColorView2
            // 
            this.darkColorView2.Color = System.Drawing.Color.Gold;
            this.darkColorView2.CustomText = "Border: ";
            this.darkColorView2.Location = new System.Drawing.Point(132, 41);
            this.darkColorView2.Name = "darkColorView2";
            this.darkColorView2.Size = new System.Drawing.Size(166, 23);
            this.darkColorView2.TabIndex = 2;
            this.darkColorView2.Text = "darkColorView2";
            this.darkColorView2.ColorSelected += new System.EventHandler<domi1819.DarkControls.ColorSelectedEventArgs>(this.UpdateColors);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 433);
            this.Controls.Add(this.darkColorView2);
            this.Controls.Add(this.darkColorView1);
            this.Controls.Add(this.coloredBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private DarkControls.ColoredBox coloredBox1;
        private DarkControls.DarkColorView darkColorView1;
        private DarkControls.DarkColorView darkColorView2;
    }
}

