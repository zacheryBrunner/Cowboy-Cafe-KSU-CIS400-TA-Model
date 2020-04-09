/*
 * Author: Nathan Bean
 * Class: ExtensionMethods.cs
 * Purpose: Switches screens
*/
using System.Windows;
using System.Windows.Media;

namespace PointOfSale.ExtensionMethods
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Finds the control passed to the function
        /// </summary>
        /// <typeparam name="T">Some control</typeparam>
        /// <param name="element"></param>
        /// <returns>The control we were looking for when found</returns>
        public static T FindAncestor<T>(this DependencyObject element) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(element);

            if (parent == null) return null;

            if (parent is T) return parent as T;

            return parent.FindAncestor<T>();
        }
    }
}