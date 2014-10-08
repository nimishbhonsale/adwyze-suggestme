using DotLastFm.Api;

namespace Adwyze.SuggestMe.Web.IntegrationTests.Stub
{
    /// <summary>
    /// Last Fm config stub
    /// </summary>
    public class StubLastFmConfig : ILastFmConfig
    {
        private const string BaseUri = "http://ws.audioscrobbler.com/2.0/";
        private const string Api = "8e2c29ec20854a04816f37dd7ee918c9";
        private const string SecretKey = "170fcdcae4fff75d8282b8fdaf4891a5";

        public string BaseUrl { get { return BaseUri; } }
        public string ApiKey { get { return Api; } }
        public string Secret { get { return SecretKey; } }
    }
}