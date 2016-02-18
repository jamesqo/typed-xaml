using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Typed.Xaml.Converters
{
    public abstract partial class ConverterBase : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            return this.Convert(value, targetType, parameter, new CultureInfo(language));
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return this.ConvertBack(value, targetType, parameter, new CultureInfo(language));
        }
    }
}
