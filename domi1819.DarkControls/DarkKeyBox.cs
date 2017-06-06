using System;
using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public sealed partial class DarkKeyBox : UserControl, IGlowComponent
    {
        private bool hover;
        private string text;

        public Keys Modifiers { get; private set; }

        public Keys Key { get; private set; }

        public string EmptyText { get; set; } = "No Hotkey";

        public DarkKeyBox()
        {
            this.InitializeComponent();

            this.DoubleBuffered = true;
        }

        public void Set(Keys modifiers, Keys key)
        {
            this.Modifiers = modifiers;
            this.Key = key;

            this.text = modifiers != Keys.None && key != Keys.None ? $"{modifiers} + {key}" : null;

            this.Invalidate();
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.Modifiers == Keys.None)
            {
                if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                {
                    this.Set(Keys.None, Keys.None);

                    this.Parent.SelectNextControl(this, true, true, true, true);
                }
            }
            else if (e.Modifiers != Keys.None && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Menu && !(e.Modifiers == Keys.Shift && e.KeyCode == Keys.Tab))
            {
                this.Set(e.Modifiers, e.KeyCode);

                this.Parent.SelectNextControl(this, true, true, true, true);
            }

            base.OnPreviewKeyDown(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(DarkPainting.BackgroundBrush(this.hover), this.DisplayRectangle);
            DarkPainting.DrawText(e.Graphics, this.text ?? this.EmptyText, new Rectangle(this.DisplayRectangle.X + 1, this.DisplayRectangle.Y, this.DisplayRectangle.Width - 5, this.DisplayRectangle.Height), this.text == null ? DarkPainting.ForegroundInactive : DarkPainting.Foreground, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            DarkPainting.DrawBorder(e.Graphics, this.DisplayRectangle);
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
