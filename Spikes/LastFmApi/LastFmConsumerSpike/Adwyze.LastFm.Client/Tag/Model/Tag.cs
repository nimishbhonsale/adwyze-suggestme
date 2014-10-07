namespace Adwyze.LastFm.Client.Tag.Model
{
    /// <summary>
    /// Last.fm music Tag 
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last.fm's URL of the tag.
        /// </summary>
        /// <value>
        /// The last.fm URL.
        /// </value>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}