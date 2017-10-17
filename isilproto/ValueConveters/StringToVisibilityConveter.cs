
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Cacm.Isils {
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Cacm.Isils.BaseValueConverter{Cacm.Isils.StringToVisibilityConveter}" />
    class StringToVisibilityConveter : BaseValueConverter<StringToVisibilityConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
       

           return  (String) value != null ? Visibility.Visible : Visibility.Hidden;   

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}