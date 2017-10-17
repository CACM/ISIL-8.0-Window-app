using Cacm.Isils.Model.Base;
using Cacm.Isils.Model.Data;

namespace Cacm.Isils.Model
{
    /// <summary>
    /// Multimedia file structure Model
    /// </summary>
    /// <seealso cref="BaseModel" />
    public class MultimediaFilesModel : BaseModel
    {
        #region Private Properties   
        private string _fileName, _fullPath, _duration;
        private bool _isPlaying;
        private PlayerFileType _itemType;
        #endregion

        #region Get & Set Properties      
        public PlayerFileType ItemType { get { return _itemType; } set { _itemType = value; RaisePropertyChanged(nameof(ItemType)); } }
        public string FileName { get { return _fileName; } set { _fileName = value; RaisePropertyChanged(nameof(FileName)); } }
        public string FullPath { get { return _fullPath; } set { _fullPath = value; RaisePropertyChanged(nameof(FullPath)); } }
        public string Duration { get { return _duration; } set { _duration = value; RaisePropertyChanged(nameof(Duration)); } }
        public bool IsPlaying { get { return _isPlaying; } set { _isPlaying = value; RaisePropertyChanged(nameof(IsPlaying)); } }

        #endregion
 
    }
}
