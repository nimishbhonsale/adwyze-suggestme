using Adwyze.LastFm.Client.Artist.Api;

namespace Adwyze.LastFm.Client
{
    /// <summary>
    /// Last.fm session interface
    /// </summary>
    public interface ILastFmApi
    {
        /// <summary>
        /// Gets the artist API.
        /// </summary>
        IArtistApi Artist
        {
            get;
        }

        /// <summary>
        /// Gets the config of last.fm client.
        /// </summary>
        Config.ILastFmConfig Config
        {
            get;
        }
    }
}
