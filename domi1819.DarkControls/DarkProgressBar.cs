using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public class DarkProgressBar : BaseControl
    {
        private const int BarPadding = 2;

        private float value;
        private string text;
        private SolidBrush barBrush;
        private Color textOverlayColor;

        public float Value
        {
            get => this.value;
            set
            {
                this.value = value < 0 ? 0 : value > 1 ? 1 : value;
                this.text = $"{(int)(this.Value * 100 + 0.5)} %";
                this.Invalidate();
            }
        }

        public Color BarColor
        {
            get => this.barBrush.Color;
            set
            {
                this.barBrush = new SolidBrush(value);
                this.textOverlayColor = DarkPainting.GetForegroundColor(value);
                this.Invalidate();
            }
        }
        
        /// <summary>Gets the default size of the control.</summary>
        /// <returns>The default <see cref="T:System.Drawing.Size" /> of the control.</returns>
        protected override Size DefaultSize => new Size(100, 24);

        /// <summary>Gets the length and height, in pixels, that is specified as the default minimum size of a control.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size" /> representing the size of the control.</returns>
        protected override Size DefaultMinimumSize => new Size(36, 17);

        public DarkProgressBar()
        {
            this.BarColor = DarkPainting.StrongColor;
            this.Value = 0;
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            Rectangle barArea = new Rectangle(BarPadding, BarPadding, (int)((this.Width - 2 * BarPadding) * this.value), this.Height - 2 * BarPadding);

            DarkPainting.DrawText(e.Graphics, this.text, this.DisplayRectangle);
            e.Graphics.FillRectangle(this.barBrush, barArea);
            e.Graphics.Clip = new Region(barArea);
            DarkPainting.DrawText(e.Graphics, this.text, this.DisplayRectangle, this.textOverlayColor, TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }
    }
}
