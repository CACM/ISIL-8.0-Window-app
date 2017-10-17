using Cacm.Isils.Model.Base;
using Cacm.Isils.Model.Data;
using NAudio.CoreAudioApi;

namespace Cacm.Isils.Model
{
    /// <summary>
    /// Multimedia file structure Model
    /// </summary>
    /// <seealso cref="BaseModel" />
    public class MultimediaPlayerModel : BaseModel
    {
        #region Private Properties   
        private float _audioVolume;
        private bool _isPlaying;

        #endregion

        #region Get & Set Properties      
        public float AudioVolume { get { return _audioVolume; } set { _audioVolume = value; RaisePropertyChanged(nameof(AudioVolume)); } }
        public bool IsPlaying { get { return _isPlaying; } set { _isPlaying = value; RaisePropertyChanged(nameof(IsPlaying)); } }

        #endregion

    }
}
