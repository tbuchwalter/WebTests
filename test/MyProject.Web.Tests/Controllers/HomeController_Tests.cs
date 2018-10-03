using System.Threading.Tasks;
using MyProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyProject.Web.Tests.Controllers
{
    public class HomeController_Tests:MyProjectWebTestBase
    {
        
        [Fact]
        public async Task Index_Test()
        {
            //var controller = new HomeController();
            //controller.ControllerContext = new ControllerContext
            //{
            //    HttpContext = new DefaultHttpContext
            //    {
            //        User = LoginAsDefaultTenantAdmin()
            //    }
            //};
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
