using Adwyze.LastFm.Client.Artist.Api;
using Adwyze.LastFm.Client.Config;

namespace Adwyze.LastFm.Client
{
    /// <summary>
    /// Last.fm API sesspis
    /// </summary>
    public class LastFmApi : ILastFmApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LastFmApi"/> class.
        /// </summary>
        /// <param name="config">The config.</param>
        public LastFmApi(ILastFmConfig config)
        {
            Config = config;
            Artist = new ArtistApi(this);
        }

        /// <summary>
        /// Gets the config.
        /// </summary>
        public ILastFmConfig Config
        {
            get;
            private set;
        }


        /// <summary>
        /// Gets the artist API methods.
        /// </summary>
        public IArtistApi Artist
        {
            get;
            private set;
        }

    }
}