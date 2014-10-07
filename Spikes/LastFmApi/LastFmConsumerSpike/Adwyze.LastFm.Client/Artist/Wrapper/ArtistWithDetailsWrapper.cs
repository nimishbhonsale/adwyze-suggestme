using Adwyze.LastFm.Client.Artist.Model;
using RestSharp.Deserializers;

namespace Adwyze.LastFm.Client.Artist.Wrapper
{
    public class ArtistWithDetailsWrapper
    {
        /// <summary>
        /// Gets or sets the artist object.
        /// </summary>
        /// <value>
        /// The artist object.
        /// </value>
        [DeserializeAs(Name = "artist")]
        public ArtistWithDetails Artist
        {
            get;
            set;
        }
    }
}
