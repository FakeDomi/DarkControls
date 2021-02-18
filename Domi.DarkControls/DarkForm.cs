using System.Drawing;
using System.Windows.Forms;

// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global
namespace Domi.DarkControls
{
    /// <summary>
    /// A window that has some values set for a dark themed environment.
    /// Also allows selected components to glow.
    /// </summary>
    public class DarkForm : Form
    {
        private IGlowComponent focus, hover;

        /// <summary>
        /// Whether glow for focused/hovered components should be disabled.
        /// </summary>
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public bool DisableGlow { get; set; }
        
        public override Color BackColor => DarkPainting.Workspace;

        public override Color ForeColor => DarkPainting.Foreground;

        protected sealed override bool DoubleBuffered { get => base.DoubleBuffered; set => base.DoubleBuffered = value; }

        public DarkForm()
        {
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.DisableGlow)
            {
                return;
            }

            if (this.focus != null)
            {
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(this.focus.GlowX - 1, this.focus.GlowY - 1, this.focus.GlowW + 2, this.focus.GlowH + 2), DarkPainting.StrongColor, ButtonBorderStyle.Solid);
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(this.focus.GlowX - 2, this.focus.GlowY, this.focus.GlowW + 4, this.focus.GlowH), DarkPainting.PaleColor, ButtonBorderStyle.Solid);
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(this.focus.GlowX, this.focus.GlowY - 2, this.focus.GlowW, this.focus.GlowH + 4), DarkPainting.PaleColor, ButtonBorderStyle.Solid);
            }

            if (this.hover != null)
            {
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(this.hover.GlowX - 1, this.hover.GlowY - 1, this.hover.GlowW + 2, this.hover.GlowH + 2), DarkPainting.StrongColor, ButtonBorderStyle.Solid);
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(this.hover.GlowX - 2, this.hover.GlowY, this.hover.GlowW + 4, this.hover.GlowH), DarkPainting.PaleColor, ButtonBorderStyle.Solid);
                ControlPaint.DrawBorder(e.Graphics, new Rectangle(this.hover.GlowX, this.hover.GlowY - 2, this.hover.GlowW, this.hover.GlowH + 4), DarkPainting.PaleColor, ButtonBorderStyle.Solid);
            }
        }

        /// <summary>
        /// Called when a child control changes hover/focus state.
        /// Updates the form's glow information and then re-draws the window.
        /// </summary>
        /// <param name="focused">Whether the updating control is/was focused or hovered over.</param>
        /// <param name="control">The control that's updating.</param>
        /// <param name="active">The focus/hover state.</param>
        internal static void UpdateGlow(bool focused, Control control, bool active)
        {
            if (control.Parent is DarkForm parent)
            {
                IGlowComponent glowComponent = (IGlowComponent)(active ? control : null);

                if (focused)
                {
                    parent.focus = glowComponent;
                }
                else
                {
                    parent.hover = glowComponent;
                }

                parent.Invalidate();
            }
        }
    }
}
