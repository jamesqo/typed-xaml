using System;
using System.Collections.Generic;
using System.Windows;
using Windows.UI.Xaml;

namespace Typed.Xaml
{
    public delegate void PropertyChangedCallback<in T, in TOwner>(TOwner o, IPropertyChangedArgs<T> args)
        where TOwner : DependencyObject;
}
