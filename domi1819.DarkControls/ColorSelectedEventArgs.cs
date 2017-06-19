using System;
using System.Drawing;

namespace domi1819.DarkControls
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
