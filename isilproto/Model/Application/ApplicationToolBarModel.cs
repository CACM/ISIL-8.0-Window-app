using Cacm.Isils.Model.Base;
using Cacm.Isils.ViewModel;

namespace Cacm.Isils.Model
{
    class ApplicationToolBarModel : BaseModel
    {



        #region Private Properties
        private bool 
            _pollStatus, _openGroup, _closeGroup, 
            _oneToOne, _pushToTalk, _handRaise, _aux,
            _headSet,_courseWare,_close,_settings,
            _sideDock,_normalDock,_reset, _students;
        private string _webAddress; 
        #endregion

        #region Get & Set Properties      
        public bool PollStatus  { get { return _pollStatus; } set { _pollStatus = value; RaisePropertyChanged(nameof(PollStatus)); } }
        public bool HeadSet     { get { return _headSet; }  set { _headSet = value; RaisePropertyChanged(nameof(HeadSet)); } }
        public bool Aux         { get { return _aux; } set { _aux = value; RaisePropertyChanged(nameof(Aux)); } }
        public bool HandRaise   { get { return _handRaise; } set { _handRaise = value; RaisePropertyChanged(nameof(HandRaise)); } }
        public bool PushToTalk  { get { return _pushToTalk; } set { _pushToTalk = value; RaisePropertyChanged(nameof(PushToTalk)); } }
        public bool OneToOne    { get { return _oneToOne; } set { _oneToOne = value; RaisePropertyChanged(nameof(OneToOne)); } }
        public bool CloseGroup  { get { return _closeGroup; } set { _closeGroup = value; RaisePropertyChanged(nameof(CloseGroup)); } }
        public bool OpenGroup   { get { return _openGroup; } set { _openGroup = value; RaisePropertyChanged(nameof(OpenGroup)); } }
        public bool CourseWare  { get { return _courseWare; } set { _courseWare = value; RaisePropertyChanged(nameof(CourseWare)); } }
        public bool Close       { get { return _close; } set { _close = value; RaisePropertyChanged(nameof(Close)); } }
        public bool Settings    { get { return _settings; } set { _settings = value; RaisePropertyChanged(nameof(Settings)); } }
        public bool SideDock    { get { return _sideDock; } set { _sideDock = value; RaisePropertyChanged(nameof(_sideDock)); } }
        public bool NormalDock  { get { return _normalDock; } set { _normalDock = value; RaisePropertyChanged(nameof(NormalDock)); } }
        public bool Reset       { get { return _reset; } set { _reset = value; RaisePropertyChanged(nameof(Reset)); } }
        public bool Students    { get { return _students; } set { _students = value; RaisePropertyChanged(nameof(Students)); } }
        public string WebAddress { get { return _webAddress; } set { _webAddress = value; RaisePropertyChanged(nameof(WebAddress)); } }

  

        #endregion
        public ApplicationToolBarModel()
        {
            WebAddress = "http://192.168.2.12:8080";
        }


    }
}
