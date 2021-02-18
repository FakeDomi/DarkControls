using System.Drawing;
using System.Windows.Forms;

namespace Domi.DarkControls
{
    public class DarkKeyBox : BaseControl
    {
        private string text;

        public Keys Modifiers { get; private set; }

        public Keys Key { get; private set; }

        public string EmptyText { get; set; } = "No Hotkey";

        /// <summary>
        /// Set the key and modifier pair of this control.
        /// </summary>
        /// <param name="modifiers">The modifiers.</param>
        /// <param name="key">The key scancode.</param>
        public void Set(Keys modifiers, Keys key)
        {
            this.Modifiers = modifiers;
            this.Key = key;

            this.text = modifiers != Keys.None && key != Keys.None ? $"{modifiers} + {key}" : null;

            this.Invalidate();
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.PreviewKeyDown" /> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PreviewKeyDownEventArgs" /> that contains the event data.</param>
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

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            DarkPainting.DrawText(e.Graphics, this.text ?? this.EmptyText, new Rectangle(this.DisplayRectangle.X + 1, this.DisplayRectangle.Y, this.DisplayRectangle.Width - 5, this.DisplayRectangle.Height), this.text == null ? DarkPainting.ForegroundInactive : DarkPainting.Foreground, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }
    }
}
