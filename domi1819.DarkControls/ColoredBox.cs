using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public class ColoredBox : Control
    {
        private Color borderColor;

        public Color? BorderColor
        {
            get => this.borderColor;
            set
            {
                this.borderColor = value ?? Color.Black;
                this.Invalidate();
            }
        }

        /// <summary>Gets or sets a value indicating whether this control should redraw its surface using a secondary buffer to reduce or prevent flicker.</summary>
        /// <returns>true if the surface of the control should be drawn using double buffering; otherwise, false.</returns>
        protected override bool DoubleBuffered => true;

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.BorderColor != null)
            {
                DarkPainting.DrawBorder(e.Graphics, this.DisplayRectangle, this.BorderColor.Value);
            }
        }
    }
}
