using System;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public sealed class DarkButton : Button, IGlowComponent
    {
        protected override bool ShowFocusCues => false;

        public DarkButton()
        {
            this.ForeColor = DarkPainting.Foreground;
            this.BackColor = DarkPainting.Control;
            this.FlatStyle = FlatStyle.Flat;

            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseOverBackColor = DarkPainting.ControlHighlight;
            this.FlatAppearance.MouseDownBackColor = DarkPainting.ControlHighlight;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DarkPainting.DrawBorder(e.Graphics, this.DisplayRectangle);
        }

        #region GlowComponent

        public int GlowX => this.Location.X + this.DisplayRectangle.X;

        public int GlowY => this.Location.Y + this.DisplayRectangle.Y;

        public int GlowW => this.DisplayRectangle.Width;

        public int GlowH => this.DisplayRectangle.Height;

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            DarkForm.UpdateGlow(false, this, true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

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

        #endregion
    }
}
