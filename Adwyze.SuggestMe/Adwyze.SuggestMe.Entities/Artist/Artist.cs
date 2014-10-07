using System.Collections.Generic;
using DotLastFm.Models;

namespace Adwyze.SuggestMe.Entities.Artist
{
    public class Artist
    {
        public ArtistWithDetails ArtistDetails { get; set; }
        public IEnumerable<TagTopTrack> Tracks { get; set; }
    }
}