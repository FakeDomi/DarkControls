using System;
using System.Drawing;

namespace Domi.DarkControls
{
    public class ColorSelectedEventArgs : EventArgs
    {
        public Color NewColor { get; }

        public ColorSelectedEventArgs(Color newColor)
        {
            this.NewColor = newColor;
        }
    }
}
