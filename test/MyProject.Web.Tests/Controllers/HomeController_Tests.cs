using System.Net;
using System.Threading.Tasks;
using MyProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyProject.Web.Tests.Controllers
{
    public class HomeController_Tests:MyProjectWebTestBase
    {
        /// <summary>
        /// Tests that the Home page will render html for logged in user
        /// </summary>
        /// <returns>Html Response</returns>
        [Fact]
        public async Task Index_Test() 
        {
            //Login Test User
            LoginAsDefaultTenantAdmin();
            //Set Session Cookie values
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }


        /// <summary>
        /// Tests that the Home page will redirect user to Login if not authenticated.
        /// </summary>
        /// <returns>Redirect Response</returns>
        [Fact]
        public async Task Index_Redirect_Test()
        {
           //Act
            var response = await GetResponseAsync(
                GetUrl<HomeController>(nameof(HomeController.Index)),HttpStatusCode.Redirect
            );

            //Assert
            response.Headers.Location.LocalPath.ShouldBe("/Account/Login");
        }
    }
}
