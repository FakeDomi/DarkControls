using System.Collections;
using System.Windows.Forms.Design.Behavior;

namespace Domi.DarkControls.Designer
{
    internal class ColorViewDesigner : FixedHeightDesigner
    {
        /// <summary>Gets a list of <see cref="T:System.Windows.Forms.Design.Behavior.SnapLine" /> objects representing significant alignment points for this control.</summary>
        /// <returns>A list of <see cref="T:System.Windows.Forms.Design.Behavior.SnapLine" /> objects representing significant alignment points for this control.</returns>
        public override IList SnapLines
        {
            get
            {
                IList snapLines = base.SnapLines ?? new ArrayList();

                snapLines.Add(new SnapLine(SnapLineType.Baseline, 17));

                return snapLines;
            }
        }
    }
}
