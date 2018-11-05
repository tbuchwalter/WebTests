using System.Threading.Tasks;
using MyProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyProject.Web.Tests.Controllers
{
    public class AboutController_Tests : MyProjectWebTestBase
    {
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
                GetUrl<AboutController>(nameof(AboutController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
