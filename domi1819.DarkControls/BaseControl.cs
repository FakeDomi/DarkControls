using System;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public abstract class BaseControl : Control, IGlowComponent
    {
        protected bool Hover;

        /// <summary>
        /// The X coordinate of the glow box.
        /// </summary>
        public int GlowX => this.Location.X + this.DisplayRectangle.X;

        /// <summary>
        /// The Y coordinate of the glow box.
        /// </summary>
        public int GlowY => this.Location.Y + this.DisplayRectangle.Y;

        /// <summary>
        /// The witdh of the glow box.
        /// </summary>
        public int GlowW => this.DisplayRectangle.Width;

        /// <summary>
        /// The height of the glow box.
        /// </summary>
        public int GlowH => this.DisplayRectangle.Height;

        /// <summary>Gets or sets a value indicating whether this control should redraw its surface using a secondary buffer to reduce or prevent flicker.</summary>
        /// <returns>true if the surface of the control should be drawn using double buffering; otherwise, false.</returns>
        protected override bool DoubleBuffered => true;

        protected BaseControl()
        {
            this.SetStyle(ControlStyles.UserMouse, true);
        }

        protected BaseControl(bool userMouseFlag)
        {
            this.SetStyle(ControlStyles.UserMouse, userMouseFlag);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.GotFocus" /> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            DarkForm.UpdateGlow(true, this, true);
        }
        
        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.LostFocus" /> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            DarkForm.UpdateGlow(true, this, false);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseEnter" /> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.Hover = true;
            DarkForm.UpdateGlow(false, this, true);
            this.Invalidate();
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.MouseLeave" /> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.Hover = false;
            DarkForm.UpdateGlow(false, this, false);
            this.Invalidate();
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            DarkPainting.FillBackground(e.Graphics, this, this.Hover);
            DarkPainting.DrawBorder(e.Graphics, this.DisplayRectangle);
        }
    }
}
