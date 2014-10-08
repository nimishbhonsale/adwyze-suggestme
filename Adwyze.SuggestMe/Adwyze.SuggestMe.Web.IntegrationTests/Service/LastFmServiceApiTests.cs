using Adwyze.SuggestMe.Services;
using Adwyze.SuggestMe.Web.IntegrationTests.Stub;
using NUnit.Framework;

namespace Adwyze.SuggestMe.Web.IntegrationTests.Service
{
    /// <summary>
    /// Last fm service tests
    /// </summary>
    [TestFixture]
    public class LastFmServiceApiTests
    {
        /// <summary>
        /// Get the artist by name
        /// </summary>
        [Test]
        public void GetArtistByName_WithKeyword_ReturnsArtist()
        {
            // Arrange
            var config = new StubLastFmConfig();
            var fmService = new LastFmService(config);

            // Act
            var artistByName = fmService.GetArtistByName("mojo");

            // Assert
            Assert.IsNotNull(artistByName.ArtistDetails);
            Assert.IsNotNull(artistByName.Tracks);
            Assert.AreEqual(artistByName.ArtistDetails.Name.ToLower() , "mojo");
            Assert.IsTrue(artistByName.ArtistDetails.SimilarArtists.Count > 0);
            Assert.IsTrue(artistByName.ArtistDetails.Images.Count > 0);
            Assert.IsNotNull(artistByName.ArtistDetails.Bio);
            Assert.IsNotNullOrEmpty(artistByName.ArtistDetails.Bio.Summary);
            Assert.IsNotNull(artistByName.ArtistDetails.Stats);
            Assert.IsTrue(artistByName.ArtistDetails.Stats.Listeners > 0);
            Assert.IsTrue(artistByName.ArtistDetails.Stats.PlayCount > 0);
        }

    }
}
