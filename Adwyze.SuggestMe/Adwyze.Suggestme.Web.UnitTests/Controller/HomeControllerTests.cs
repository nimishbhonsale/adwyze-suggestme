using Adwyze.SuggestMe.Controllers;
using Adwyze.SuggestMe.Entities.User;
using Adwyze.SuggestMe.Helpers.Container;
using Adwyze.SuggestMe.Repository.Contracts.User;
using Adwyze.Suggestme.Web.UnitTests.Stubs;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace Adwyze.Suggestme.Web.UnitTests.Controller
{
    /// <summary>
    /// Tests for Home controller
    /// </summary>
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private const string UserId = "nimish";

        /// <summary>
        /// Initial setup
        /// </summary>
        [TestFixtureSetUp]
        public void SetUp()
        {
            Bootstrapper.Container = new UnityContainer();
            Bootstrapper.Container.RegisterType<IUserRepository, StubUserRepository>();
            _controller = new HomeController();
        }

        /// <summary>
        /// Check instantiation
        /// </summary>
        [Test]
        public void Construction_WithUserRepo_IsValidInstance()
        {
            Assert.IsNotNull(_controller.UserRepository);
            Assert.IsTrue(_controller.UserRepository.GetType() == typeof(StubUserRepository));
        }

        /// <summary>
        /// Verify login action
        /// </summary>
        [Test]
        public void VerifyLogin_WithUserRepo_ShowsLoginView()
        {
            var viewResult = _controller.Login();
            Assert.IsNotNull(viewResult);
        }

        /// <summary>
        /// Verify save action
        /// </summary>
        [Test]
        public void VerifySave_WithUserRepo_InvokesUserRepoSave()
        {
            var stub = (StubUserRepository) _controller.UserRepository;
            stub.OnSave = OnSave;
            var jsonResult = _controller.Save(UserId);
            Assert.IsTrue(stub.IsSaveInvoked);
            const string sessionidNimish = "{ sessionid = "+ UserId + " }";
            Assert.AreEqual(jsonResult.Data.ToString(), sessionidNimish);
        }

        /// <summary>
        /// On save call back
        /// </summary>
        private void OnSave(User user)
        {
            Assert.AreEqual(UserId,user.UserId);
        }

        /// <summary>
        /// Verify logout action
        /// </summary>
        [Test]
        public void VerifyLogout_WithUserRepo_ReturnEmptyJson()
        {
            var jsonResult = _controller.Logout();
            Assert.AreEqual(jsonResult.Data.ToString(), "{ sessionid =  }");
        }
    }
}
