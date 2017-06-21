using System.Collections;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;

namespace domi1819.DarkControls.Designer
{
    internal class TextBoxDesigner : ControlDesigner
    {
        /// <summary>Gets the selection rules that indicate the movement capabilities of a component.</summary>
        /// <returns>A bitwise combination of <see cref="T:System.Windows.Forms.Design.SelectionRules" /> values.</returns>
        public override SelectionRules SelectionRules => SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable;

        /// <summary>Gets a list of <see cref="T:System.Windows.Forms.Design.Behavior.SnapLine" /> objects representing significant alignment points for this control.</summary>
        /// <returns>A list of <see cref="T:System.Windows.Forms.Design.Behavior.SnapLine" /> objects representing significant alignment points for this control.</returns>
        public override IList SnapLines
        {
            get
            {
                IList snapLines = base.SnapLines ?? new ArrayList();

                snapLines.Add(new SnapLine(SnapLineType.Baseline, 15));

                return snapLines;
            }
        }
    }
}
