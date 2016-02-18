using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Typed.Xaml
{
    public static class FrameExtensions
    {
        public static bool Navigate<T>(this Frame frame)
            where T : Page
        {
            return frame.Navigate(typeof(T));
        }

        public static bool Navigate<T>(this Frame frame, object parameter)
            where T : Page
        {
            return frame.Navigate(typeof(T), parameter);
        }

        public static bool Navigate<T>(this Frame frame, object parameter, NavigationTransitionInfo infoOverride)
            where T : Page
        {
            return frame.Navigate(typeof(T), parameter, infoOverride);
        }
    }
}
