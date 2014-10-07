
using DotLastFm.Api;

namespace LastFmConsumerSpike
{
    public class LastFmConfig : ILastFmConfig
    {
        private readonly string _baseUri;
        private readonly string _apiKey;
        private readonly string _secret;

        public LastFmConfig(string baseUri, string apiKey, string secret)
        {
            _baseUri = baseUri;
            _apiKey = apiKey;
            _secret = secret;
        }

        public LastFmConfig()
        {
            _baseUri = "http://ws.audioscrobbler.com/2.0/";
            _apiKey = "8e2c29ec20854a04816f37dd7ee918c9";
            _secret = "170fcdcae4fff75d8282b8fdaf4891a5";
        }

        public string BaseUrl { get { return _baseUri; } }
        public string ApiKey { get { return _apiKey; } }
        public string Secret { get { return _secret; } }
    }
}