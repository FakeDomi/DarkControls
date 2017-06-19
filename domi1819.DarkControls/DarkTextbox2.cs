using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    [Designer(typeof(TextBoxDesigner))]
    public class DarkTextbox2 : BaseControl
    {
        private const int TextBoxHeight = 13;
        private const int TextBoxPadding = 3;

        private readonly TextBox textBox = new TextBox { BorderStyle = BorderStyle.None, Location = new Point(TextBoxPadding, TextBoxPadding), Size = new Size(94, TextBoxHeight) };

        /// <summary>Gets or sets the background color for the control.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color" /> that represents the background color of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor" /> property.</returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override Color BackColor
        {
            get => this.textBox.BackColor;
            set => this.textBox.BackColor = value;
        }

        /// <summary>Gets or sets the foreground color of the control.</summary>
        /// <returns>The foreground <see cref="T:System.Drawing.Color" /> of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultForeColor" /> property.</returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        /// </PermissionSet>
        public override Color ForeColor
        {
            get => this.textBox.ForeColor;
            set => this.textBox.ForeColor = value;
        }

        public override string Text
        {
            get => this.textBox.Text;
            set => this.textBox.Text = value;
        }

        public bool UseSystemPasswordChar
        {
            get => this.textBox.UseSystemPasswordChar;
            set => this.textBox.UseSystemPasswordChar = value;
        }

        public bool ReadOnly
        {
            get => this.textBox.ReadOnly;
            set
            {
                this.textBox.ForeColor = value ? DarkPainting.ForegroundInactive : DarkPainting.Foreground;
                this.textBox.ReadOnly = value;
            }
        }

        /// <summary>Gets the default size of the control.</summary>
        /// <returns>The default <see cref="T:System.Drawing.Size" /> of the control.</returns>
        protected override Size DefaultSize => new Size(100, 20);

        /// <summary>Gets or sets the size that is the lower limit that <see cref="M:System.Windows.Forms.Control.GetPreferredSize(System.Drawing.Size)" /> can specify.</summary>
        /// <returns>An ordered pair of type <see cref="T:System.Drawing.Size" /> representing the width and height of a rectangle.</returns>
        public override Size MinimumSize => new Size(20, 20);

        public DarkTextbox2()
        {
            this.SuspendLayout();

            this.Controls.Add(this.textBox);

            this.ResumeLayout(false);
            this.PerformLayout();

            this.textBox.BackColor = DarkPainting.Control;
            this.textBox.ForeColor = DarkPainting.Foreground;

            this.textBox.MouseEnter += (sender, args) => { this.OnMouseEnter(args); };
            this.textBox.MouseLeave += (sender, args) => { this.OnMouseLeave(args); };

            this.textBox.GotFocus += (sender, args) => { this.OnGotFocus(args); };
            this.textBox.LostFocus += (sender, args) => { this.OnLostFocus(args); };
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            this.textBox.Size = new Size(this.Width - 2 * TextBoxPadding, TextBoxHeight);
        }

        /// <summary>Performs the work of setting the specified bounds of this control.</summary>
        /// <param name="x">The new <see cref="P:System.Windows.Forms.Control.Left" /> property value of the control. </param>
        /// <param name="y">The new <see cref="P:System.Windows.Forms.Control.Top" /> property value of the control. </param>
        /// <param name="width">The new <see cref="P:System.Windows.Forms.Control.Width" /> property value of the control. </param>
        /// <param name="height">The new <see cref="P:System.Windows.Forms.Control.Height" /> property value of the control. </param>
        /// <param name="specified">A bitwise combination of the <see cref="T:System.Windows.Forms.BoundsSpecified" /> values. </param>
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, 20, specified);
        }
    }
}
