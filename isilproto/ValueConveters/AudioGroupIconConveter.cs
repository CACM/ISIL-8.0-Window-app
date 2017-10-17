
using Cacm.Isils.Model.Data;
using System;
using System.Globalization;

namespace Cacm.Isils
{
    class AudioGroupIconConveter : BaseValueConverter<AudioGroupIconConveter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((AudioChannelType)value==AudioChannelType.CloseChannel )
            {
                return (string)(System.Windows.Application.Current.Resources["IcoMoonCloseGroup"]);
            }
            else if ((AudioChannelType)value == AudioChannelType.OpenChannel)
            {
                return (string)(System.Windows.Application.Current.Resources["IcoMoonOpenGroup"]);
            }
            else if ((AudioChannelType)value == AudioChannelType.OneToOneChannel)
            {
                return (string)(System.Windows.Application.Current.Resources["IcoMoonOnetoOne"]);
            }
            else if ((AudioChannelType)value == AudioChannelType.PushToTalkChannel)
            {
                return (string)(System.Windows.Application.Current.Resources["IcoMoonPushToTalk"]);
            }
            else
            {
                return (string)(System.Windows.Application.Current.Resources["IcoMoonUser"]); ;
            }
             
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}