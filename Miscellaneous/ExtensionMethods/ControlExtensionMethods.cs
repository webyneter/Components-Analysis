using System.Collections.Generic;
using System.Windows.Forms;


namespace Webyneter.ComponentsAnalysis.Miscellaneous.ExtensionMethods
{
    public static class ControlExtensionMethods
    {
        public static IEnumerable<T> EnumerateDescendants<T>(this Control control)
            where T : class
        {
            foreach (Control child in control.Controls)
            {
                var childAsT = child as T;
                if (childAsT != null)
                {
                    yield return childAsT;
                }
                if (child.HasChildren)
                {
                    foreach (T descendant in EnumerateDescendants<T>(child))
                    {
                        yield return descendant;
                    }
                }
            }
        }
    }
}