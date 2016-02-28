using System;
using System.Collections.Generic;
using System.Windows;

namespace Typed.Xaml
{
    public static partial class DependencyObjectExtensions
    {
        public static void SetCurrent<T>(this DependencyObject obj, DependencyProperty property, T value)
        {
            obj.SetCurrentValue(property, value);
        }
    }
}
