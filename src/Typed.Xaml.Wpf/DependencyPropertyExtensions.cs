using System;
using System.Collections.Generic;
using System.Windows;

namespace Typed.Xaml
{
    public static class DependencyPropertyExtensions
    {
        public static DependencyProperty AddOwner<TOwner>(this DependencyProperty property)
            where TOwner : DependencyObject
        {
            return property.AddOwner(typeof(TOwner));
        }
        
        public static DependencyProperty AddOwner<TOwner>(this DependencyProperty property, PropertyMetadata metadata)
            where TOwner : DependencyObject
        {
            return property.AddOwner(typeof(TOwner), metadata);
        }
    }
}
