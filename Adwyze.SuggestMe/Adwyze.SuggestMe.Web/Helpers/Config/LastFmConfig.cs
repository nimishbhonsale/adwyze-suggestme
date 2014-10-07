using System.Configuration;
using DotLastFm.Api;

namespace Adwyze.SuggestMe.Helpers.Config
{
    public class LastFmConfig : ILastFmConfig
    {
        private readonly string _baseUri;
        private readonly string _apiKey;
        private readonly string _secret;

        //public LastFmConfig(string baseUri, string apiKey, string secret)
        //{
        //    _baseUri = baseUri;
        //    _apiKey = apiKey;
        //    _secret = secret;
        //}

        public LastFmConfig()
        {
            _baseUri = ConfigurationManager.AppSettings["LastFmBaseUri"];
            _apiKey = ConfigurationManager.AppSettings["LastFmApiKey"];
            _secret = ConfigurationManager.AppSettings["LastFmSecret"];
        }

        public string BaseUrl { get { return _baseUri; } }
        public string ApiKey { get { return _apiKey; } }
        public string Secret { get { return _secret; } }
    }
}