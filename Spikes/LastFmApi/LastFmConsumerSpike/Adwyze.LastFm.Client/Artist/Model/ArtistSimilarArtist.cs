using System.Collections.Generic;
using Adwyze.LastFm.Client.Shared.Model;

namespace Adwyze.LastFm.Client.Artist.Model
{
    public class ArtistSimilarArtist : Artist
    {
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
    }
}