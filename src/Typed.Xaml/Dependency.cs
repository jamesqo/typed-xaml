using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Typed.Xaml
{
    public static class Dependency
    {
        private static PropertyMetadata CreateMetadata<T, TOwner>(PropertyChangedCallback<T, TOwner> callback)
            where TOwner : DependencyObject
        {
            return new PropertyMetadata(default(T), WrapGenericCallback(callback));
        }

        public static DependencyProperty Register<T, TOwner>(string name, PropertyChangedCallback<T, TOwner> callback)
            where TOwner : DependencyObject
        {
            return Register<T, TOwner>(name, CreateMetadata(callback));
        }

        public static DependencyProperty Register<T, TOwner>(string name, PropertyMetadata metadata)
            where TOwner : DependencyObject
        {
            return DependencyProperty.Register(name, typeof(T), typeof(TOwner), metadata);
        }

        public static DependencyProperty RegisterAttached<T, TOwner, TDeclaring>(string name, PropertyChangedCallback<T, TOwner> callback)
            where TOwner : DependencyObject
        {
            return RegisterAttached<T, TDeclaring>(name, CreateMetadata(callback));
        }

        public static DependencyProperty RegisterAttached<T, TDeclaring>(string name, PropertyMetadata metadata)
        {
            return DependencyProperty.RegisterAttached(name, typeof(T), typeof(TDeclaring), metadata);
        }

        private static PropertyChangedCallback WrapGenericCallback<T, TOwner>(PropertyChangedCallback<T, TOwner> original)
            where TOwner : DependencyObject
        {
            return (o, args) => original((TOwner)o, PropertyChangedArgs<T>.CreateFrom(args));
        }
    }
}
