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
        
        public static T ReadLocal<T>(this DependencyObject obj, DependencyProperty property)
        {
            // TODO: Handle checking for DependencyProperty.UnsetValue.
            return (T)obj.ReadLocalValue(property);
        }

        public static void Set<T>(this DependencyObject obj, DependencyProperty property, T value)
        {
            obj.SetValue(property, value);
        }
        
        public static bool TryReadLocal<T>(this DependencyObject obj, DependencyProperty property, out T value)
        {
            // TODO: Do we need to handle DependencyProperty.UnsetValue?
            object result = obj.ReadLocalValue(property);
            
            if (result is T)
            {
                value = (T)result;
                return true;
            }
            
            value = default(T);
            return false;
        }
    }
}
