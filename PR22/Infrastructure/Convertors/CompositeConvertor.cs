using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace PR22.Infrastructure.Convertors
{
    [MarkupExtensionReturnType(typeof(CompositeConvertor))]
    internal class CompositeConvertor : Convertor
    {
        [ConstructorArgument("First")]
        public IValueConverter First { get; set; }
        [ConstructorArgument("Second")]
        public IValueConverter Second { get; set; }


        public CompositeConvertor() { }

        public CompositeConvertor(IValueConverter first) => this.First = first;
        public CompositeConvertor(IValueConverter first, IValueConverter second) : this(first) => this.Second = second;


        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           var result1 = First?.Convert(value, targetType, parameter, culture) ?? value;
           var result2 = Second?.Convert(result1, targetType, parameter, culture) ?? result1;

            return result2;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            var result2 = Second?.ConvertBack(value, targetType, parameter, culture) ?? value;
            var result1 = First?.ConvertBack(result2, targetType, parameter, culture) ?? result2;

            return result1;
             
        }
    }
}
