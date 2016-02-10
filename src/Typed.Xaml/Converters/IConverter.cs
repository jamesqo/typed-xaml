using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Typed.Xaml.Converters
{
    public interface IConverter<in TIn, out TOut> : IConverter<TIn, TOut, object>
    {
        TOut Convert(TIn value, CultureInfo culture);
    }

    public interface IConverter<in TIn, out TOut, in TParameter>
    {
        TOut Convert(TIn value, TParameter parameter, CultureInfo culture);
    }
}
