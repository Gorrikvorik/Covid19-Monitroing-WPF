using System;
using System.Globalization;
using System.Windows.Markup;

namespace PR22.Infrastructure.Convertors
{
    [MarkupExtensionReturnType(typeof(Add))]
    internal class Add : Convertor
    {

        public Add() { }

        public Add(double k)
        {
            this.B = k;
        }
        [ConstructorArgument("K")]
        public double k { get; set; } = 1;


        [ConstructorArgument("K")]
        public double B { get; set; } = 1;



        public override object Convert(object value, Type t, object p, CultureInfo c)
        {
            if (value is null) return null;

            var x = System.Convert.ToDouble(value, c);

            return x + B;
        }

        public override object ConvertBack(object value, Type t, object p, CultureInfo c)
        {
            if (value is null) return null;


            var x = System.Convert.ToDouble(value, c);

            return x -  B;
        }
    }
}
