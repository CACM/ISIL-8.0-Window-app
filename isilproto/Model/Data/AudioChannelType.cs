namespace Cacm.Isils.Model.Data
{
    /// <summary>
    /// audio channel type for group call
    /// </summary>
    public enum AudioChannelType
    {
        /// <summary>
        /// The open channel is one to many where ever one can listen what other speaking
        /// </summary>
        OpenChannel = 1,
        /// <summary>
        /// The close channel is private channel where only seleted student and teacher can listen
        /// </summary>
        CloseChannel = 2
    }
}
