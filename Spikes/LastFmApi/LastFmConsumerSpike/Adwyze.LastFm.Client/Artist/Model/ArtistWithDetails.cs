using System.Collections.Generic;
using Adwyze.LastFm.Client.Shared.Model;
using RestSharp.Deserializers;

namespace Adwyze.LastFm.Client.Artist.Model
{
    public class ArtistWithDetails : Artist
    {
        /// <summary>
        /// Gets or sets the mb ID.
        /// </summary>
        /// <value>
        /// The valeu of mb ID.
        /// </value>
        public string MbId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this artists is streamable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if streamable; otherwise, <c>false</c>.
        /// </value>
        public bool Streamable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the similar artists collection.
        /// </summary>
        /// <value>
        /// The similar artists collection.
        /// </value>
        [DeserializeAs(Name = "similar")]
        public List<ArtistSimilarArtist> SimilarArtists
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the images collection.
        /// </summary>
        /// <value>
        /// The images collection.
        /// </value>
        public List<Image> Images
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the tags of the artist.
        /// </summary>
        /// <value>
        /// The tags of the artist.
        /// </value>
        public List<Tag.Model.Tag> Tags
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wiki texts.
        /// </summary>
        /// <value>
        /// The wiki texts.
        /// </value>
        public Wiki Bio
        {
            get;
            set;
        }
    }
}