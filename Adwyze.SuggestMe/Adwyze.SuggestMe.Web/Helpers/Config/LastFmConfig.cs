using System.Configuration;
using DotLastFm.Api;

namespace Adwyze.SuggestMe.Helpers.Config
{
    /// <summary>
    /// Last fm config helper
    /// </summary>
    public class LastFmConfig : ILastFmConfig
    {
        private readonly string _baseUri;
        private readonly string _apiKey;
        private readonly string _secret;

        /// <summary>
        /// Last fm config read from configuration file
        /// </summary>
        public LastFmConfig()
        {
            _baseUri = ConfigurationManager.AppSettings["LastFmBaseUri"];
            _apiKey = ConfigurationManager.AppSettings["LastFmApiKey"];
            _secret = ConfigurationManager.AppSettings["LastFmSecret"];
        }

        /// <summary>
        /// Base Uri
        /// </summary>
        public string BaseUrl { get { return _baseUri; } }

        /// <summary>
        /// Application Key
        /// </summary>
        public string ApiKey { get { return _apiKey; } }

        /// <summary>
        /// Application Secret
        /// </summary>
        public string Secret { get { return _secret; } }
    }
}