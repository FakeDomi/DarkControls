using System;
using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public sealed partial class DarkProgressBar : UserControl, IGlowComponent
    {
        private const int BarPadding = 2;

        private bool hover;

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
                this.text = $"{this.ValueInt} %";
                this.Invalidate();
            }
        }

        public int ValueInt
        {
            get => (int)(this.Value * 100 + 0.5);
            set => this.Value = value / 100F;
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

        public DarkProgressBar()
        {
            this.InitializeComponent();

            this.DoubleBuffered = true;
            this.BarColor = DarkPainting.StrongColor;

            this.Value = 0;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(DarkPainting.BackgroundBrush(this.hover), this.DisplayRectangle);
            DarkPainting.DrawBorder(e.Graphics, this.DisplayRectangle);

            if (this.value >= 0)
            {
                Rectangle barArea = new Rectangle(BarPadding, BarPadding, (int)((this.Width - 2 * BarPadding) * this.value), this.Height - 2 * BarPadding);

                DarkPainting.DrawText(e.Graphics, this.text, this.DisplayRectangle);
                e.Graphics.FillRectangle(this.barBrush, barArea);
                e.Graphics.Clip = new Region(barArea);
                DarkPainting.DrawText(e.Graphics, this.text, this.DisplayRectangle, this.textOverlayColor, TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        #region GlowComponent

        public int GlowX => this.Location.X + this.DisplayRectangle.X;

        public int GlowY => this.Location.Y + this.DisplayRectangle.Y;

        public int GlowW => this.DisplayRectangle.Width;

        public int GlowH => this.DisplayRectangle.Height;

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

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            this.hover = true;
            DarkForm.UpdateGlow(false, this, true);
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            this.hover = false;
            DarkForm.UpdateGlow(false, this, false);
            this.Invalidate();
        }

        #endregion
    }
}
