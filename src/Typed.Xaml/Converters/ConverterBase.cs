using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;
using Windows.UI.Xaml.Data;

namespace Typed.Xaml.Converters
{
    public abstract class ConverterBase : IValueConverter
    {
        // TODO: targetType validation?
        protected abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        // TODO: targetType validation?
        protected abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        // Different APIs: WPF uses Convert(object, Type, object, CultureInfo),
        // while WinRT has Convert(object, Type, object, string).
#if NET451
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack(value, targetType, parameter, culture);
        }
#else
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            return Convert(value, targetType, parameter, new CultureInfo(language));
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ConvertBack(value, targetType, parameter, new CultureInfo(language));
        }
#endif
    }
}
