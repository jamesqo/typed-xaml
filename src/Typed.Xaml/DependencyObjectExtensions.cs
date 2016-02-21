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
            T result;
            obj.TryReadLocal(property, out result);
            return result;
        }

        public static void Set<T>(this DependencyObject obj, DependencyProperty property, T value)
        {
            obj.SetValue(property, value);
        }
        
        public static bool TryReadLocal<T>(this DependencyObject obj, DependencyProperty property, out T value)
        {
            object result = obj.ReadLocalValue(property);
            
            if (result == DependencyProperty.UnsetValue)
            {
                value = default(T);
                return false;
            }
            
            value = (T)result;
            return true;
        }
    }
}
