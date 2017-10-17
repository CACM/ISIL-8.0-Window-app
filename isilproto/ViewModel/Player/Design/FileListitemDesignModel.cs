using Cacm.Isils.Model;
using Cacm.Isils.Model.Data;
using System;

namespace Cacm.Isils.ViewModel
{
   public class FileListitemDesignModel: MultimediaFilesModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static FileListitemDesignModel Instance => new FileListitemDesignModel();

        #endregion

        #region Constructor
        public FileListitemDesignModel()
        {
             ItemType = PlayerFileType.Audio ;
             FileName = "Audiofileasdas.wav";
             FullPath = "C:\\Users\\sumit\\Desktop\\fasetto-word-develop\\Source\\"+FileName;
             Duration = "00:22:12";
             IsPlaying = true;
        }
        #endregion
    }
}
