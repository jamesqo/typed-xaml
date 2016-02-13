using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace Typed.Xaml
{
    public static class FrameExtensions
    {
        public static bool Navigate<T>(this Frame frame) =>
#if NET46
            frame.Navigate(Activator.CreateInstance<T>());
#elif NETCORE50
            frame.Navigate(typeof(T));
#endif

        public static bool Navigate<T>(this Frame frame, object parameter) =>
#if NET46
            frame.Navigate(typeof(T), parameter);
#elif NETCORE50
            frame.Navigate(Activator.CreateInstance<T>(), parameter);
#endif

#if NETCORE50
        public static bool Navigate<T>(this Frame frame, object parameter, NavigationTransitionInfo infoOverride) =>
            frame.Navigate(typeof(T), parameter, infoOverride);
#endif
    }
}
