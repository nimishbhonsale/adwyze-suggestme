using Adwyze.LastFm.Client.Artist.Model;
using Adwyze.LastFm.Client.Artist.Wrapper;
using Adwyze.LastFm.Client.Shared.Rest;
using DotLastFm.Api;

namespace Adwyze.LastFm.Client.Artist.Api
{
    /// <summary>
    /// Last.fm artist API
    /// </summary>
    public class ArtistApi : LastFmApiBase, IArtistApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistApi"/> class.
        /// </summary>
        /// <param name="api">The API wrapper.</param>
        public ArtistApi(ILastFmApi api)
            : base(api)
        {
        }

        /// <summary>
        /// Get the metadata for an artist. Includes biography.
        /// </summary>
        /// <param name="artist">The artist name.</param>
        /// <param name="autocorrect">Transform misspelled artist names into correct artis name, returning the correct version instead.</param>
        /// <param name="username">The username for the context of the request. If supplied, the user's playcount for this track and whether they have loved the track is included in the response.</param>
        /// <returns>
        /// The Artist object with metadata.
        /// </returns>
        public ArtistWithDetails GetInfo(string artist, bool autocorrect, string username)
        {
            var call = Rest.Method("artist.getInfo")
                           .AddParam("artist", artist)
                           .AddParam("autocorrect", autocorrect ? "1" : "0");

            if (username != null)
            {
                call.AddParam("username", username);
            }

            var wrapper = call.Execute<ArtistWithDetailsWrapper>();

            if (wrapper != null)
            {
                return wrapper.Artist;
            }

            return null;
        }

        /// <summary>
        /// Get the metadata for an artist. Includes biography.
        /// </summary>
        /// <param name="artist">The artist name.</param>
        /// <returns>
        /// The Artist object with metadata.
        /// </returns>
        public ArtistWithDetails GetInfo(string artist)
        {
            return GetInfo(artist, false, null);
        }
    }
}
