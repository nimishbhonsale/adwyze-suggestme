using RestSharp.Deserializers;

namespace Adwyze.LastFm.Client.Shared.Model
{
    /// <summary>
    /// The Last.fm's image 
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [DeserializeAs(Attribute = true, Name = "size")]
        public ImageSize Size
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Value
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
            return Value;
        }
    }
}