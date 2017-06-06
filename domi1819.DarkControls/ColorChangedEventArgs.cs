using System;
using System.Drawing;

namespace domi1819.DarkControls
{
    public class ColorChangedEventArgs : EventArgs
    {
        public Color NewColor { get; }

        public ColorChangedEventArgs(Color newColor)
        {
            this.NewColor = newColor;
        }
    }
}
