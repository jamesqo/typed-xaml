using System;
using System.Collections.Generic;
using System.Windows;
using Windows.UI.Xaml;

namespace Typed.Xaml
{
    public static class DependencyObjectExtensions
    {
        public static T Get<T>(this DependencyObject obj, DependencyProperty property)
        {
            return (T)obj.GetValue(property);
        }

        public static void Set<T>(this DependencyObject obj, DependencyProperty property, T value)
        {
            obj.SetValue(property, value);
        }
    }
}
