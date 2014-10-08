using System.Collections.Generic;
using DotLastFm.Models;

namespace Adwyze.SuggestMe.Entities.Artist
{
    /// <summary>
    /// Artist Dto
    /// </summary>
    public class Artist
    {
        /// <summary>
        /// Artist details
        /// </summary>
        public ArtistWithDetails ArtistDetails { get; set; }

        /// <summary>
        /// Tracks for the artist
        /// </summary>
        public IEnumerable<TagTopTrack> Tracks { get; set; }
    }
}