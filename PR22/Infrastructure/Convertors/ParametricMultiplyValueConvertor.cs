using PR22.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PR22.Infrastructure.Convertors
{
    internal class ParametricMultiplyValueConvertor : Freezable, IValueConverter
    {

        #region ValueProperty

        /// <summary>
        /// Прибавляемое значение
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
    DependencyProperty.Register(
        nameof(Value),
        typeof(double),
        typeof(ParametricMultiplyValueConvertor),
        new PropertyMetadata(1.0));

 

        [Category("Моя категория")]
        [Description("Прибавляемое значение")]
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);

        }
        #endregion
        public object Convert(object v, Type targetType, object parameter, CultureInfo culture)
        {
            var value = System.Convert.ToDouble(v, culture);
            return value * Value;
        }

        public object ConvertBack(object v, Type targetType, object parameter, CultureInfo culture)
        {
            var value = System.Convert.ToDouble(v, culture);
            return value / Value;
        }

        protected override Freezable CreateInstanceCore() => new ParametricMultiplyValueConvertor { Value = Value };
    }
}
