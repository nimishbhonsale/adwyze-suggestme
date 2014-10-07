using Adwyze.LastFm.Client.Artist.Model;

namespace Adwyze.LastFm.Client.Artist.Api
{
    /// <summary>
    /// Last.fm artist API
    /// </summary>
    public interface IArtistApi
    {
        /// <summary>
        /// Get the metadata for an artist. Includes biography.
        /// </summary>
        /// <param name="artist">The artist name.</param>
        /// <returns>The Artist object with metadata.</returns>
        ArtistWithDetails GetInfo(string artist);
    }
}
