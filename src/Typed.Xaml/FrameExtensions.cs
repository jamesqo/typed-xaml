using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Controls;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Typed.Xaml
{
#if NETCORE50
    public static class FrameExtensions
    {
        public static bool Navigate<T>(this Frame frame) =>
            frame.Navigate(typeof(T));

        public static bool Navigate<T>(this Frame frame, object parameter) =>
            frame.Navigate(typeof(T), parameter);

        public static bool Navigate<T>(this Frame frame, object parameter, NavigationTransitionInfo infoOverride) =>
            frame.Navigate(typeof(T), parameter, infoOverride);
    }
#endif
}
