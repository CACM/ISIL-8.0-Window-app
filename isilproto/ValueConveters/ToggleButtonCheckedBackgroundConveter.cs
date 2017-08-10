
using System;
using System.Globalization;
using System.Windows.Media;

namespace Cacm.Isils { 
    class ToggleButtonCheckedBackgroundConveter : BaseValueConverter<ToggleButtonCheckedBackgroundConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.Write("value"+value);
           return new SolidColorBrush(Colors.Blue);

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}