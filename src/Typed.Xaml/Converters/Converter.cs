using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Typed.Xaml.Converters
{
    public static class Converter
    {
        private class AnonymousConverter<TIn, TOut> : Converter<TIn, TOut>
        {
            private readonly Func<TIn, CultureInfo, TOut> convert;
            private readonly Func<TOut, CultureInfo, TIn> convertBack;

            public AnonymousConverter(Func<TIn, CultureInfo, TOut> convert, Func<TOut, CultureInfo, TIn> convertBack)
            {
                this.convert = convert;
                this.convertBack = convertBack;
            }

            public override TOut Convert(TIn value, CultureInfo culture) => convert(value, culture);

            public override TIn ConvertBack(TOut value, CultureInfo culture)
            {
                return convertBack == null ?
                    base.ConvertBack(value, culture) :
                    convertBack(value, culture);
            }
        }

        private class AnonymousConverter<TIn, TOut, TParameter> : Converter<TIn, TOut, TParameter>
        {
            private readonly Func<TIn, TParameter, CultureInfo, TOut> convert;
            private readonly Func<TOut, TParameter, CultureInfo, TIn> convertBack;

            public AnonymousConverter(Func<TIn, TParameter, CultureInfo, TOut> convert, Func<TOut, TParameter, CultureInfo, TIn> convertBack)
            {
                this.convert = convert;
                this.convertBack = convertBack;
            }

            public override TOut Convert(TIn value, TParameter parameter, CultureInfo culture)
            {
                return convert(value, parameter, culture);
            }

            public override TIn ConvertBack(TOut value, TParameter parameter, CultureInfo culture)
            {
                return convertBack == null ?
                    base.ConvertBack(value, parameter, culture) :
                    convertBack(value, parameter, culture);
            }
        }

        public static Converter<TIn, TOut> Create<TIn, TOut>(Func<TIn, CultureInfo, TOut> convert)
        {
            return Create(convert, null);
        }

        public static Converter<TIn, TOut> Create<TIn, TOut>(Func<TIn, CultureInfo, TOut> convert, Func<TOut, CultureInfo, TIn> convertBack)
        {
            return new AnonymousConverter<TIn, TOut>(convert, convertBack);
        }

        public static Converter<TIn, TOut, TParameter> Create<TIn, TOut, TParameter>(Func<TIn, TParameter, CultureInfo, TOut> convert)
        {
            return Create(convert, null);
        }

        public static Converter<TIn, TOut, TParameter> Create<TIn, TOut, TParameter>(Func<TIn, TParameter, CultureInfo, TOut> convert, Func<TOut, TParameter, CultureInfo, TIn> convertBack)
        {
            return new AnonymousConverter<TIn, TOut, TParameter>(convert, convertBack);
        }
    }
}
