using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Adwyze.SuggestMe.Controllers;
using Adwyze.SuggestMe.Entities.History;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Repository.Contracts.Search;
using Moq;
using NUnit.Framework;

namespace Adwyze.Suggestme.Web.UnitTests.Controller
{
    /// <summary>
    /// Tests for History controller
    /// </summary>
    [TestFixture]
    public class HistoryControllerTests
    {
        private HistoryController _controller;
        private const string UserId = "dummy";
        private const string SearchKeyWord = "mojo";

        /// <summary>
        /// Get all history records for a user
        /// </summary>
        [Test]
        public void GetSearchHistory_AnyUser_GetsHistoryRecords()
        {
            // Arrange
            var searchHistoryRepository = new Mock<ISearchHistoryRepository>();
            _controller = new HistoryController(searchHistoryRepository.Object);
            var historyCollection = new List<History>() {new History {Keyword = "mojo", Id = 1}};
            searchHistoryRepository.Setup(t => t.GetHistoryForUser(It.IsAny<User>())).Returns(historyCollection).Verifiable(); ;
           
            // Act
            var actionResult = _controller.Get();

            // Assert
            Assert.IsNotNull(actionResult);
            Type type = (((ViewResult) actionResult).Model).GetType();
            Type type1 = typeof (List<History>);
            Assert.IsTrue(type==type1);
            var histories = ((IList<History>)(((ViewResult)actionResult).Model));
            Assert.IsTrue(histories.Count == 1);
            Assert.IsTrue(histories[0].Keyword == "mojo");
            searchHistoryRepository.VerifyAll();
        }
    }
}