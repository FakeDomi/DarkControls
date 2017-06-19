using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public partial class DarkTextBox : UserControl, IGlowComponent
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public new string Text
        {
            get => this.textBox.Text;
            set => this.textBox.Text = value;
        }

        public bool UseSystemPasswordChar
        {
            get => this.textBox.UseSystemPasswordChar;
            set => this.textBox.UseSystemPasswordChar = value;
        }

        public bool ReadOnly
        {
            get => this.textBox.ReadOnly;
            set
            {
                this.textBox.ForeColor = value ? DarkPainting.ForegroundInactive : DarkPainting.Foreground;
                this.textBox.ReadOnly = value;
            }
        }

        public int GlowX => this.Location.X + this.DisplayRectangle.X;

        public int GlowY => this.Location.Y + this.DisplayRectangle.Y;

        public int GlowW => this.DisplayRectangle.Width;

        public int GlowH => this.DisplayRectangle.Height;

        public DarkTextBox()
        {
            this.InitializeComponent();

            this.DoubleBuffered = true;

            this.BackColor = DarkPainting.Control;
            this.textBox.BackColor = DarkPainting.Control;
            this.textBox.ForeColor = DarkPainting.Foreground;

            this.textBox.AutoSize = false;

            this.MinimumSize = new Size(20, 20);

            this.textBox.MouseEnter += (sender, args) => { this.OnMouseEnter(args); };
            this.textBox.MouseLeave += (sender, args) => { this.OnMouseLeave(args); };

            this.textBox.GotFocus += (sender, args) => { this.OnGotFocus(args); };
            this.textBox.LostFocus += (sender, args) => { this.OnLostFocus(args); };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.DisplayRectangle, DarkPainting.Border, ButtonBorderStyle.Solid);
        }

        protected override void OnEnter(EventArgs e)
        {
            this.BeginInvoke((Action)delegate
            {
                this.textBox.SelectAll();
            });
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.textBox.Size = new Size(this.Width - 8, this.Height - 7);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.textBox.BackColor = DarkPainting.ControlHighlight;
            this.BackColor = DarkPainting.ControlHighlight;

            DarkForm.UpdateGlow(false, this, true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.textBox.BackColor = DarkPainting.Control;
            this.BackColor = DarkPainting.Control;

            DarkForm.UpdateGlow(false, this, false);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            DarkForm.UpdateGlow(true, this, true);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            DarkForm.UpdateGlow(true, this, false);
        }
    }
}
