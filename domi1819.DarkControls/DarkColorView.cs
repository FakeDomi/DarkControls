using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    [DefaultEvent("ColorSelected")]
    public class DarkColorView : BaseControl
    {
        private const int MinSize = 23;

        private static readonly Rectangle PreviewRectangle = new Rectangle(4, 4, 15, 15);
        private readonly ColorDialog colorDialog = new ColorDialog();

        private Color color;
        private Brush brush;

        private string customText, drawText;

        public Color Color
        {
            get => this.color;
            set
            {
                this.color = value;
                this.brush = new SolidBrush(value);
                this.colorDialog.Color = value;

                this.UpdateText();
            }
        }

        public string CustomText
        {
            get => this.customText;
            set
            {
                this.customText = value;
                this.UpdateText();
            }
        }

        /// <summary>Gets the default size of the control.</summary>
        /// <returns>The default <see cref="T:System.Drawing.Size" /> of the control.</returns>
        protected override Size DefaultSize => new Size(125, 23);

        public event EventHandler<ColorSelectedEventArgs> ColorSelected;

        public DarkColorView()
        {
            this.Color = DarkPainting.StrongColor;
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            DarkPainting.DrawText(e.Graphics, this.drawText, new Rectangle(MinSize, 0, this.DisplayRectangle.Width - MinSize, MinSize));

            e.Graphics.FillRectangle(this.brush, PreviewRectangle);
            DarkPainting.DrawBorder(e.Graphics, PreviewRectangle);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Click" /> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data. </param>
        protected override void OnClick(EventArgs e)
        {
            if (this.colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Color = this.colorDialog.Color;
                this.ColorSelected?.Invoke(this, new ColorSelectedEventArgs(this.Color));
            }
        }

        private void UpdateText()
        {
            this.drawText = $"{this.customText ?? ""}{this.color.ToHexString()}";
            this.Invalidate();
        }
    }
}
