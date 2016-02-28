using System;
using System.Collections.Generic;
using System.Windows;

namespace Typed.Xaml
{
    public static class DependencyPropertyExtensions
    {
        public static DependencyProperty AddOwner<T>(this DependencyProperty property)
            where T : DependencyObject
        {
            return property.AddOwner(typeof(T));
        }
        
        public static DependencyProperty AddOwner<T>(this DependencyProperty property, PropertyMetadata metadata)
            where T : DependencyObject
        {
            return property.AddOwner(typeof(T), metadata);
        }
    }
}
