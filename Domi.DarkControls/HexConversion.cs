using System.Drawing;

namespace Domi.DarkControls
{
    /// <summary>
    /// This class adds extension methods for color to hex string conversion.
    /// </summary>
    internal static class HexConversion
    {
        /// <summary>
        /// Converts a 8-bit channel depth color into an [A]RGB hex string.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>The color string, prefixed by a '#'.</returns>
        internal static string ToHexString(this Color color)
        {
            return $"#{(color.A == 255 ? "" : ToHex(color.A))}{ToHex(color.R)}{ToHex(color.G)}{ToHex(color.B)}";
        }

        /// <summary>
        /// Converts a single byte to hexadecimal notation.
        /// </summary>
        /// <param name="value">The input byte.</param>
        /// <returns>A string of two chars that represents the input byte as hex.</returns>
        private static string ToHex(byte value)
        {
            return $"{GetHexChar(value >> 4)}{GetHexChar(value)}";
        }

        /// <summary>
        /// Gets the char that converts the lowest 4 bits of an int in hexadecimal notation.
        /// </summary>
        /// <param name="value">The input int.</param>
        /// <returns>A char that represents the lowest nibble of the input as hex.</returns>
        private static char GetHexChar(int value)
        {
            int loNibble = value & 0x0F;

            return (char)(loNibble + (loNibble < 10 ? '0' : 'A' - 10));
        }
    }
}
