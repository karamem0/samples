using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows;

namespace Karamem0.Samples
{

    public static class DependencyObjectExtensions
    {

        public static T FindVisualAncestor<T>(this DependencyObject target) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(target);
            if (parent == null)
            {
                return null;
            }
            if (parent is T)
            {
                return (T)parent;
            }
            return parent.FindVisualAncestor<T>();
        }

    }

}
