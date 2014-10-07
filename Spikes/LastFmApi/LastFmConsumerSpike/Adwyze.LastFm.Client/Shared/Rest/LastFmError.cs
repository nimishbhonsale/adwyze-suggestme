namespace Adwyze.LastFm.Client.Shared.Rest
{
    public class LastFmError
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the error value.
        /// </summary>
        /// <value>
        /// The error value.
        /// </value>
        public string Value
        {
            get;
            set;
        }
    }
}