using System;
using System.Drawing;
using System.Windows.Forms;

namespace domi1819.DarkControls
{
    public static class DarkPainting
    {
        private static Color strongColor;

        public static Color Control { get; }
        public static Color ControlHighlight { get; }
        public static Color Workspace { get; }
        public static Color Border { get; }
        public static Color Foreground { get; }
        public static Color ForegroundInactive { get; }

        public static Color ForegroundOverlay { get; private set; }

        public static Color StrongColor
        {
            get => strongColor;
            set
            {
                strongColor = value;
                PaleColor = Color.FromArgb(92, value);

                ForegroundOverlay = GetForegroundColor(value);
            }
        }

        public static Color PaleColor { get; private set; }

        public static readonly Font TextFont = new Font(FontFamily.GenericSansSerif, 8.25F);

        public static Brush ForegroundBrush { get; }

        static DarkPainting()
        {
            Control = Color.FromArgb(37, 37, 38);
            ControlHighlight = Color.FromArgb(45, 45, 48);
            Workspace = Color.FromArgb(45, 45, 48);
            Border = Color.FromArgb(67, 67, 70);
            Foreground = Color.FromArgb(241, 241, 241);
            ForegroundInactive = Color.FromArgb(96, 96, 100);

            StrongColor = Color.FromArgb(16, 48, 128);

            ForegroundBrush = new SolidBrush(Foreground);
        }

        public static Color GetForegroundColor(Color background)
        {
            return (int)Math.Sqrt(background.R * background.R * 0.299 + background.G * background.G * 0.587 + background.B * background.B * 0.114) > 127 ? Color.Black : Foreground;
        }

        public static Color GetBackgroundColor(bool hover, bool mouseDown)
        {
            return mouseDown ? Workspace : hover ? ControlHighlight : Control;
        }

        public static SolidBrush BackgroundBrush(bool hover)
        {
            return new SolidBrush(GetBackgroundColor(hover, false));
        }

        public static void DrawText(Graphics graphics, string text, Rectangle rectangle)
        {
            TextRenderer.DrawText(graphics, text, TextFont, rectangle, Foreground);
        }

        public static void DrawText(Graphics graphics, string text, Rectangle rectangle, Color color, TextFormatFlags flags)
        {
            TextRenderer.DrawText(graphics, text, TextFont, rectangle, color, flags);
        }

        public static void DrawBorder(Graphics graphics, Rectangle rectangle)
        {
            ControlPaint.DrawBorder(graphics, rectangle, Border, ButtonBorderStyle.Solid);
        }
    }
}
