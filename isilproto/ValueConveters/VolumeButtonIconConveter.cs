
using System;
using System.Globalization;
using System.Windows.Media;
using NAudio.CoreAudioApi;
namespace Cacm.Isils { 
    class VolumeButtonIconConveter : BaseValueConverter<VolumeButtonIconConveter>
    {
        private MMDevice device;
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine(value);
            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            device = DevEnum.GetDefaultAudioEndpoint(DataFlow.Render,Role.Multimedia);
            var sliderValue=float.Parse(value.ToString());
            device.AudioEndpointVolume.MasterVolumeLevelScalar = sliderValue;
            //

            if (sliderValue <= 0 )
            {
                device.AudioEndpointVolume.Mute = true;
                return (string)(System.Windows.Application.Current.Resources["IcoMoonVolumeMute"]);
            }
            else if (sliderValue >= 0 && sliderValue <= .3)
            {
                device.AudioEndpointVolume.Mute = false;
                return (string)(System.Windows.Application.Current.Resources["IcoMoonVolumeVeryLow"]);
            }
            else if (sliderValue >= .3 && sliderValue <= .6)
            {
                device.AudioEndpointVolume.Mute = false;
                return (string)(System.Windows.Application.Current.Resources["IcoMoonVolumeLow"]);
            }
            else if (sliderValue >= .6 && sliderValue <= .8)
            {
                device.AudioEndpointVolume.Mute = false;
                return (string)(System.Windows.Application.Current.Resources["IcoMoonVolumeHigh"]);
            }
            else
            {
                device.AudioEndpointVolume.Mute = false;
                return (string)(System.Windows.Application.Current.Resources["IcoMoonVolumeVeryHigh"]); ;
            }
             
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}