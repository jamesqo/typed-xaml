using System;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace Typed.Xaml
{
    public static partial class DependencyObjectExtensions
    {
        public static T GetAnimationBase<T>(this DependencyObject obj, DependencyProperty property)
        {
            return (T)obj.GetAnimationBaseValue(property);
        }
    }
}
