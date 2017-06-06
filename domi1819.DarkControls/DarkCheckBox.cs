using System;
using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public class DarkCheckBox : CheckBox, IGlowComponent
    {
        private bool hover;
        private bool mouseDown;

        public bool RadioStyle { get; set; }

        public int GlowX => this.Location.X + this.Padding.Left;

        public int GlowY => this.Location.Y + this.Height / 2 - 6;

        public int GlowW => 13;

        public int GlowH => 13;

        protected override bool ShowFocusCues => false;

        public DarkCheckBox()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            const int size = 12;

            int x = this.Padding.Left;
            int y = this.Height / 2 - size / 2;

            e.Graphics.FillRectangle(new SolidBrush(this.mouseDown ? DarkPainting.Workspace : this.hover ? DarkPainting.ControlHighlight : DarkPainting.Control), x, y, size, size);
            e.Graphics.DrawRectangle(new Pen(DarkPainting.Border), x, y, size, size);

            if (this.Checked)
            {
                if (this.RadioStyle)
                {
                    e.Graphics.FillRectangle(new SolidBrush(DarkPainting.Foreground), x + 4, y + 4, 5, 5);
                }
                else
                {
                    e.Graphics.DrawImage(Check, x + 2, y + 2);
                }
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.hover = true;

            DarkForm.UpdateGlow(false, this, true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.hover = false;

            DarkForm.UpdateGlow(false, this, false);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);

            this.mouseDown = true;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);

            this.mouseDown = false;
            this.Invalidate();
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

        private static readonly Bitmap Check;

        static DarkCheckBox()
        {
            const long image = 292205365999747200;
            long checkBit = 1L;

            Check = new Bitmap(9, 9);

            for (int y = 1; y < 9; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if ((image & checkBit) > 0)
                    {
                        Check.SetPixel(x, y, DarkPainting.Foreground);
                    }

                    checkBit = checkBit << 1;
                }
            }

            Check.SetPixel(8, 0, DarkPainting.Foreground);
            Check.SetPixel(8, 1, DarkPainting.Foreground);
            Check.SetPixel(8, 2, DarkPainting.Foreground);
        }
    }
}
