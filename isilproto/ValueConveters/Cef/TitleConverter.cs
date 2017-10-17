using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cacm.Isils
{
 
    public class TitleConverter : BaseValueConverter<TitleConverter>
    {
  

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return   (value ?? "No Title Specified");
        }

   

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
              return System.Windows.Data.Binding.DoNothing;
        }
    }
}
