using System;
using System.Globalization;

namespace Cacm.Isils
{
    class FontSizeConveters : BaseValueConverter<FontSizeConveters>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if(System.Windows.SystemParameters.WorkArea.Width>1300)
            return  14;
            else
            return 11;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
