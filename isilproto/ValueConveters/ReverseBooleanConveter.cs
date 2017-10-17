
using System;
using System.Globalization;
using System.Windows.Media;

namespace Cacm.Isils { 
    class ReverseBooleanConveter : BaseValueConverter<ReverseBooleanConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
 
           return  (Boolean) value ? false : true;   

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}