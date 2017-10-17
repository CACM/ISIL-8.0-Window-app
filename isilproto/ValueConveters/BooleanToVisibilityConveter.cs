
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Cacm.Isils { 
    class BooleanToVisibilityConveter : BaseValueConverter<BooleanToVisibilityConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
         
           return  (Boolean) value ? Visibility.Visible : Visibility.Collapsed;   

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}