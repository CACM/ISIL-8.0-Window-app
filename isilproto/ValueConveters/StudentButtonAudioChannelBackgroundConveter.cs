
using Cacm.Isils.Model.Data;
using System;
using System.Globalization;
using System.Windows.Media;

namespace Cacm.Isils { 
    class StudentButtonAudioChannelBackgroundConveter : BaseValueConverter<StudentButtonAudioChannelBackgroundConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            
              if ((AudioChannelType)value != AudioChannelType.Default)
            {
                return (SolidColorBrush)(System.Windows.Application.Current.Resources["CacmCyanBrush"]);
            }
           
            else
            {
                return (SolidColorBrush)(System.Windows.Application.Current.Resources["BackgroundVeryDarkBrush"]); ;
            }
             
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}