using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
