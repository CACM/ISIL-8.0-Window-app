
using Cacm.Isils.Model.Data;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Cacm.Isils
{
    public class EnvironmentConverter : BaseValueConverter<EnvironmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {            
            return Environment.Is64BitProcess ? "x64" : "x86";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}