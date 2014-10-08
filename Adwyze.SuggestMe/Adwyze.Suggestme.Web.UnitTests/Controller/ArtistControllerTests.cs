using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Adwyze.SuggestMe;
using Adwyze.SuggestMe.Controllers;
using Adwyze.SuggestMe.Entities.History;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Repository.Contracts.Search;
using Adwyze.SuggestMe.Repository.Contracts.User;
using Adwyze.SuggestMe.Services;
using DotLastFm.Models;
using Moq;
using NUnit.Framework;
using Artist = Adwyze.SuggestMe.Entities.Artist.Artist;

namespace Adwyze.Suggestme.Web.UnitTests.Controller
{
    /// <summary>
    /// Tests for Artist controller
    /// </summary>
    [TestFixture]
    public class ArtistControllerTests
    {
        private ArtistController _controller;
        private const string UserId = "dummy";
        private const string SearchKeyWord = "mojo";

        /// <summary>
        /// Search artist name
        /// </summary>
        [Test]
        public void Search_ValidArtistName_GetsAddedToRepository()
        {
            // Arrange
            var fmService = new Mock<ILastFmService>();
            var userRepository = new Mock<IUserRepository>();
            var searchHistoryRepository = new Mock<ISearchHistoryRepository>();
            _controller = new ArtistController(searchHistoryRepository.Object,fmService.Object,userRepository.Object);
            userRepository.Setup(t =>t.Save(It.IsAny<User>())).Verifiable();
            searchHistoryRepository.Setup(t => t.AddHistoryForUser(It.IsAny<User>(), It.IsAny<History>())).Verifiable(); ;
            var artist = new Artist{ArtistDetails = new ArtistWithDetails{Name="nimish"},Tracks = new List<TagTopTrack>()};
            fmService.Setup(t => t.GetArtistByName(SearchKeyWord, 1)).Returns(artist);

            // Act
            var actionResult = _controller.GetByName(SearchKeyWord);

            // Assert
            Assert.IsNotNull(actionResult);
            fmService.VerifyAll();
            userRepository.Verify(x => x.Save(It.IsAny<User>()));
            searchHistoryRepository.Verify(x => x.AddHistoryForUser(It.IsAny<User>(), It.IsAny<History>()));
        }

    }
}