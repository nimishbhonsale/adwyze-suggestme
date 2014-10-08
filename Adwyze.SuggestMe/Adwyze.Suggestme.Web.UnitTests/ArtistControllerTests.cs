using Adwyze.SuggestMe.Controllers;
using Adwyze.SuggestMe.Controllers.Abstraction;
using Adwyze.SuggestMe.Helpers.Container;
using Adwyze.SuggestMe.Repository.Contracts.User;
using Adwyze.SuggestMe.Services;
using Microsoft.Practices.Unity;
using Moq;
using NUnit.Framework;

namespace Adwyze.Suggestme.Web.UnitTests
{
    [TestFixture]
    public class ArtistControllerTests
    {
        private ArtistController _controller;
        private const string UserId = "nimish";

        [TestFixtureSetUp]
        public void SetUp()
        {
            Bootstrapper.Container = new UnityContainer();
            //var fmService = new Mock<ILastFmService>();
            //fmService.SetReturnsDefault();
            Bootstrapper.Container.RegisterType<IUserRepository, StubUserRepository>();
            Bootstrapper.Container.RegisterType<IUserRepository, StubUserRepository>();
            Bootstrapper.Container.RegisterType<IUserRepository, StubUserRepository>();
            _controller = new ArtistController();
        }

    }
}