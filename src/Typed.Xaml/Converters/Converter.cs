using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using Windows.UI.Xaml.Data;

namespace Typed.Xaml.Converters
{
    public abstract class Converter<TIn, TOut> : ConverterBase
    {
        public abstract TOut Convert(TIn value, CultureInfo culture);

        public virtual TIn ConvertBack(TOut value, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        protected sealed override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert((TIn)value, culture);
        }

        protected sealed override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack((TOut)value, culture);
        }
    }

    public abstract class Converter<TIn, TOut, TParameter> : ConverterBase
    {
        public abstract TOut Convert(TIn value, TParameter parameter, CultureInfo culture);

        public virtual TIn ConvertBack(TOut value, TParameter parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        protected sealed override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert((TIn)value, (TParameter)parameter, culture);
        }

        protected sealed override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack((TOut)value, (TParameter)parameter, culture);
        }
    }
}
