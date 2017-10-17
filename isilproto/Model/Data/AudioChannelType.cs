namespace Cacm.Isils.Model.Data
{
    /// <summary>
    /// audio channel type for group call
    /// </summary>
    public enum AudioChannelType
    {
        /// <summary>
        /// The default is for no channel so the user can only listen . no mic is activated
        /// </summary>
        Default = 0,
        /// <summary>
        /// The open channel is one to many where ever one can listen what other speaking
        /// </summary>
        OpenChannel = 1,
        /// <summary>
        /// The close channel is private channel where only seleted student and teacher can listen
        /// </summary>
        CloseChannel = 2,
        /// <summary>
        /// The one to one channel for only student teacher
        /// </summary>
        OneToOneChannel = 3,
        /// <summary>
        /// The push to talk channel, intiate from student
        /// </summary>
        PushToTalkChannel = 4
    }
}
