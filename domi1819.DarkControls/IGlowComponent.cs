namespace domi1819.DarkControls
{
    /// <summary>
    /// This interface allows a parent control or window to check glow boundaries.
    /// </summary>
    internal interface IGlowComponent
    {
        /// <summary>
        /// The X coordinate of the glow box.
        /// </summary>
        int GlowX { get; }

        /// <summary>
        /// The Y coordinate of the glow box.
        /// </summary>
        int GlowY { get; }

        /// <summary>
        /// The witdh of the glow box.
        /// </summary>
        int GlowW { get; }

        /// <summary>
        /// The height of the glow box.
        /// </summary>
        int GlowH { get; }
    }
}
