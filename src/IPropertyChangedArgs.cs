using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Windows.UI.Xaml;

namespace Typed.Xaml
{
    public interface IPropertyChangedArgs<out T>
    {
        T OldValue { get; }
        T NewValue { get; }
        DependencyProperty Property { get; }
    }
}
