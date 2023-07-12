﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR22.Infrastructure.Convertors
{
    internal class DebugConvertor : Convertor
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Diagnostics.Debugger.Break();
            return value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Diagnostics.Debugger.Break();
            return value;
        }
    }
}
