using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Animation;

namespace Typed.Xaml
{
    public static class AnimatableExtensions
    {
        public static T GetAnimationBase<T>(this IAnimatable animatable, DependencyProperty property)
        {
            return (T)animatable.GetAnimationBaseValue(property);
        }
    }
}