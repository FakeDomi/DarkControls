using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using domi1819.DarkControls.Designer;

namespace domi1819.DarkControls
{
    [DefaultEvent("ColorSelected")]
    [Designer(typeof(ColorViewDesigner))]
    public class DarkColorView : BaseControl
    {
        private const int MinSize = 23;
        private const int CenterOffset = 20;

        private static readonly Rectangle PreviewRectangle = new Rectangle(4, 4, 15, 15);
        private readonly ColorDialog colorDialog = new ColorDialog();

        private Color color;
        private Brush brush;

        private string customText, drawText;

        private bool forceCenter;

        public Color Color
        {
            get => this.color;
            set
            {
                this.color = value;
                this.brush = new SolidBrush(value);
                this.colorDialog.Color = value;

                this.UpdateTextAndInvalidate();
            }
        }

        public string CustomText
        {
            get => this.customText;
            set
            {
                this.customText = value;
                this.UpdateTextAndInvalidate();
            }
        }

        public bool ForceCenter
        {
            get => this.forceCenter;
            set
            {
                this.forceCenter = value;
                this.Invalidate();
            }
        }

        /// <summary>Gets the default size of the control.</summary>
        /// <returns>The default <see cref="T:System.Drawing.Size" /> of the control.</returns>
        protected override Size DefaultSize => new Size(125, MinSize);

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

            int offset = this.forceCenter ? 0 : CenterOffset;

            DarkPainting.DrawText(e.Graphics, this.drawText, new Rectangle(offset, 0, this.DisplayRectangle.Width - offset, MinSize));

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

        /// <summary>Performs the work of setting the specified bounds of this control.</summary>
        /// <param name="x">The new <see cref="P:System.Windows.Forms.Control.Left" /> property value of the control. </param>
        /// <param name="y">The new <see cref="P:System.Windows.Forms.Control.Top" /> property value of the control. </param>
        /// <param name="width">The new <see cref="P:System.Windows.Forms.Control.Width" /> property value of the control. </param>
        /// <param name="height">The new <see cref="P:System.Windows.Forms.Control.Height" /> property value of the control. </param>
        /// <param name="specified">A bitwise combination of the <see cref="T:System.Windows.Forms.BoundsSpecified" /> values. </param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, MinSize, specified);
        }

        private void UpdateTextAndInvalidate()
        {
            this.drawText = $"{this.customText ?? ""}{this.color.ToHexString()}";
            this.Invalidate();
        }
    }
}
