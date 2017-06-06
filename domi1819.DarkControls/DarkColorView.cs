using System;
using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public sealed partial class DarkColorView : UserControl, IGlowComponent
    {
        private static readonly Rectangle PreviewRectangle = new Rectangle(4, 4, 15, 15);
        private readonly ColorDialog colorDialog = new ColorDialog();

        private bool hover;

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

        public event EventHandler ColorSelected;

        public DarkColorView()
        {
            this.InitializeComponent();

            this.DoubleBuffered = true;
            this.Color = DarkPainting.StrongColor;

            this.colorDialog.CustomColors = new[] { ColorTranslator.ToOle(DarkPainting.StrongColor) };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(DarkPainting.BackgroundBrush(this.hover), this.DisplayRectangle);
            DarkPainting.DrawText(e.Graphics, this.drawText, this.DisplayRectangle);
            DarkPainting.DrawBorder(e.Graphics, this.DisplayRectangle);

            e.Graphics.FillRectangle(this.brush, PreviewRectangle);
            DarkPainting.DrawBorder(e.Graphics, PreviewRectangle);
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                this.Color = this.colorDialog.Color;
                this.ColorSelected?.Invoke(this, EventArgs.Empty);
            }
        }

        private void UpdateText()
        {
            this.drawText = $"{this.customText ?? ""}{this.color.ToHexString()}";
            this.Invalidate();
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
