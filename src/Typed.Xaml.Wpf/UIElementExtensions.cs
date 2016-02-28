using System;
using System.Collections.Generic;
using System.Windows;

namespace Typed.Xaml
{
    public static class UIElementExtensions
    {
        public static T GetAnimationBase<T>(this UIElement element, DependencyProperty property)
        {
            return (T)element.GetAnimationBaseValue(property);
        }
    }
}
