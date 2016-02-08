using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Typed.Xaml
{
    public static class Dependency
    {
        public static DependencyProperty Register<T, TOwner>(string name, PropertyChangedCallback<T, TOwner> callback)
            where TOwner : DependencyObject
        {
            var metadata = CreateMetadata(callback);
            return DependencyProperty.Register(name, typeof(T), typeof(TOwner), metadata);
        }

        public static DependencyProperty RegisterAttached<T, TOwner, TDeclaring>(string name, PropertyChangedCallback<T, TOwner> callback)
            where TOwner : DependencyObject
        {
            var metadata = CreateMetadata(callback);
            return DependencyProperty.RegisterAttached(name, typeof(T), typeof(TDeclaring), metadata);
        }
    }
}
