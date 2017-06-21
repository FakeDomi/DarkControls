using System.ComponentModel;
using System.Windows.Forms;
using domi1819.DarkControls.Designer;

namespace domi1819.DarkControls
{
    [Designer(typeof(ButtonDesigner))]
    public class DarkButton : BaseControl, IButtonControl
    {
        public DarkButton()
        {
            this.SetStyle(ControlStyles.StandardClick, true);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.</summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data. </param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DarkPainting.DrawText(e.Graphics, this.Text, this.DisplayRectangle);
        }

        /// <summary>Notifies a control that it is the default button so that its appearance and behavior is adjusted accordingly.</summary>
        /// <param name="value">true if the control should behave as a default button; otherwise false. </param>
        public void NotifyDefault(bool value)
        {
        }

        /// <summary>Generates a <see cref="E:System.Windows.Forms.Control.Click" /> event for the control.</summary>
        public void PerformClick()
        {
        }

        /// <summary>Gets or sets the value returned to the parent form when the button is clicked.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        public DialogResult DialogResult { get; set; }
    }
}
