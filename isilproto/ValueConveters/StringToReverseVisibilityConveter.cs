
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Cacm.Isils {
    /// <summary>
    /// reverse visibilty to hide when data is avilable
    /// </summary>StringToReverseVisibilityConveter
    /// <seealso cref="Cacm.Isils.BaseValueConverter{Cacm.Isils.StringToVisibilityConveter}" />
    class StringToReverseVisibilityConveter : BaseValueConverter<StringToReverseVisibilityConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
       

           return  (String) value != null ? Visibility.Hidden : Visibility.Visible;   

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}