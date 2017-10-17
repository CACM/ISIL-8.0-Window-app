
using Cacm.Isils.Model.Data;
using System;
using System.Globalization;
using System.Windows.Media;

namespace Cacm.Isils { 
    class PlayerItemToIconConveter : BaseValueConverter<PlayerItemToIconConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (PlayerFileType.Audio==(PlayerFileType)value)
            {
                return (string)(System.Windows.Application.Current.Resources["FontAwesomeAudioFile"]);
            }
            else if (PlayerFileType.Video == (PlayerFileType)value)
            {
                return (string)(System.Windows.Application.Current.Resources["FontAwesomeVideoFile"]);
            }
            else
            {
                return (string)(System.Windows.Application.Current.Resources["FontAwesomeOtherFile"]); ;
            }
             
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}