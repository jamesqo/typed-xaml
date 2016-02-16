using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Windows.UI.Xaml.Data;

namespace Typed.Xaml.Converters
{
    public abstract class Converter<TIn, TOut> : Converter<TIn, TOut, object>, IConverter<TIn, TOut>
    {
        public abstract TOut Convert(TIn value, CultureInfo culture);

        public virtual TIn ConvertBack(TOut value, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        public sealed override TOut Convert(TIn value, object parameter, CultureInfo culture)
        {
            return Convert(value, culture);
        }

        public sealed override TIn ConvertBack(TOut value, object parameter, CultureInfo culture)
        {
            return ConvertBack(value, culture);
        }
    }

    public abstract class Converter<TIn, TOut, TParameter> : IConverter<TIn, TOut, TParameter>, IValueConverter
    {
        public abstract TOut Convert(TIn value, TParameter parameter, CultureInfo culture);

        public virtual TIn ConvertBack(TOut value, TParameter parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

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

        // Helper methods

        private object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: targetType validation?
            return Convert((TIn)value, (TParameter)parameter, culture);
        }

        private object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // TODO: targetType validation?
            return ConvertBack((TOut)value, (TParameter)parameter, culture);
        }
    }
}
