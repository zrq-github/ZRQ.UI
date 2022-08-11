using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;

namespace ZRQ.UI.UIUtils
{
    /// <summary>
    /// WPF-UI 各种找自控件
    /// </summary>
    /// <remarks>
    /// </remarks>
    public static class UIFinder
    {
        /// <summary>
        /// Finds a parent of a given item on the visual tree.
        /// </summary>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="child">A direct or indirect child of the queried item.</param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, a null reference is being returned.</returns>
        public static T FindVisualParent<T>(DependencyObject child)
          where T : DependencyObject
        {
            // get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            // we’ve reached the end of the tree
            if (parentObject == null) return null;

            // check if the parent matches the type we’re looking for
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                // use recursion to proceed with next level
                return FindVisualParent<T>(parentObject);
            }
        }

        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }

        /// <summary>
        /// 其实这玩意 就是类型于 tatic T FindChild<T>(DependencyObject parent, string childName)
        /// </summary>
        internal static DependencyObject FindChild(this DependencyObject reference, string childName, Type childType)
        {
            DependencyObject foundChild = null;
            if (reference != null)
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(reference);
                for (int i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(reference, i);
                    // If the child is not of the request child type child
                    if (child.GetType() != childType)
                    {
                        // recursively drill down the tree
                        foundChild = child.FindChild(childName, childType);
                        if (foundChild != null) break;
                    }
                    else if (!string.IsNullOrEmpty(childName))
                    {
                        var frameworkElement = child as FrameworkElement;
                        // If the child's name is set for search
                        if (frameworkElement != null && frameworkElement.Name == childName)
                        {
                            // if the child's name is of the request name
                            foundChild = child;
                            break;
                        }
                    }
                    else
                    {
                        // child element found.
                        foundChild = child;
                        break;
                    }
                }
            }
            return foundChild;
        }

        /// <summary>
        /// 找到子对象, 通过绑定的属性
        /// </summary>
        /// <param name="parent">父控件</param>
        /// <param name="dp">控件的属性</param>
        /// <param name="bindName">绑定的属性的名字</param>
        public static T FindChild<T>(DependencyObject parent, DependencyProperty dp, string bindName)
            where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;
            if (dp == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, dp, bindName);
                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(bindName))
                {
                    var frameworkElement = child as FrameworkElement;
                    if (null == frameworkElement) continue;
                    var bindingExpression = frameworkElement.GetBindingExpression(dp);
                    if (null == bindingExpression) continue;

                    if (bindingExpression.ResolvedSourcePropertyName.Equals(bindName))
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }

        /// <summary>
        /// 找到所有的子控件,具有验证错误的构件
        /// </summary>
        public static List<T> FindChildsHasError<T>(DependencyObject parent)
            where T : DependencyObject
        {
            List<T> dependencyObjects = new List<T>();

            if (parent == null) return dependencyObjects;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                FindValidationChilds<T>(parent, ref dependencyObjects);
            }

            return dependencyObjects;
        }

        private static void FindValidationChilds<T>(DependencyObject parent, ref List<T> dependencyObjects) where T : DependencyObject
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                FindValidationChilds<T>(child, ref dependencyObjects);

                T childType = child as T;
                if (null != childType)
                {
                    if (System.Windows.Controls.Validation.GetHasError(childType))
                    {
                        dependencyObjects.Add((T)child);
                    }
                }
            }
        }
    }
}
