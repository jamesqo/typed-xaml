using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Xaml;

namespace Typed.Xaml
{
    public class PropertyChangedArgs<T> : EventArgs, IPropertyChangedArgs<T>
    {
        public T OldValue { get; }
        public T NewValue { get; }
        public DependencyProperty Property { get; }

        public PropertyChangedArgs(T oldValue, T newValue, DependencyProperty property)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.Property = property;
        }

        public static PropertyChangedArgs<T> CreateFrom(DependencyPropertyChangedEventArgs original)
        {
            var oldValue = (T)original.OldValue;
            var newValue = (T)original.NewValue;
            return new PropertyChangedArgs<T>(oldValue, newValue, original.Property);
        }
    }
}
