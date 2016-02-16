using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Typed.Xaml
{
#if !NET451
    public static class FrameExtensions
    {
        public static bool Navigate<T>(this Frame frame) =>
            frame.Navigate(typeof(T));

        public static bool Navigate<T>(this Frame frame, object parameter) =>
            frame.Navigate(typeof(T), parameter);

#if !NETCORE45
        public static bool Navigate<T>(this Frame frame, object parameter, NavigationTransitionInfo infoOverride) =>
            frame.Navigate(typeof(T), parameter, infoOverride);
#endif
    }
#endif
}
