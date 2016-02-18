using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;
using Windows.UI.Xaml.Data;

namespace Typed.Xaml.Converters
{
    public abstract partial class ConverterBase : IValueConverter
    {
        // TODO: targetType validation?
        protected abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        // TODO: targetType validation?
        protected abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
