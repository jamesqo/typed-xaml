using System;
using System.Collections.Generic;
using System.Windows;
using Windows.UI.Xaml;

namespace Typed.Xaml.Internal
{
    internal static class Metadata
    {
        public static PropertyMetadata CreateFrom<T, TOwner>(PropertyChangedCallback<T, TOwner> callback)
            where TOwner : DependencyObject
        {
            return new PropertyMetadata(default(T), WrapGenericCallback(callback));
        }

        private static PropertyChangedCallback WrapGenericCallback<T, TOwner>(PropertyChangedCallback<T, TOwner> original)
            where TOwner : DependencyObject
        {
            return (o, args) => original((TOwner)o, PropertyChangedArgs<T>.CreateFrom(args));
        }
    }
}
