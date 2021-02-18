using System.Windows.Forms.Design;

namespace Domi.DarkControls.Designer
{
    internal abstract class FixedHeightDesigner : ControlDesigner
    {
        /// <summary>Gets the selection rules that indicate the movement capabilities of a component.</summary>
        /// <returns>A bitwise combination of <see cref="T:System.Windows.Forms.Design.SelectionRules" /> values.</returns>
        public override SelectionRules SelectionRules => SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable;
    }
}
