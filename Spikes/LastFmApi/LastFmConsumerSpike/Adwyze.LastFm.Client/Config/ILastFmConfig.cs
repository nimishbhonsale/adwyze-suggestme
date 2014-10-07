namespace Adwyze.LastFm.Client.Config
{
    /// <summary>
    /// Last.fm configuration
    /// </summary>
    public interface ILastFmConfig
    {
        /// <summary>
        /// Gets the base Last.fm's URL.
        /// </summary>
        string BaseUrl
        {
            get;
        }

        /// <summary>
        /// Gets the Last.fm's API key.
        /// </summary>
        string ApiKey
        {
            get;
        }

        /// <summary>
        /// Gets the Last.fm's secret.
        /// </summary>
        string Secret
        {
            get;
        }
    }
}
