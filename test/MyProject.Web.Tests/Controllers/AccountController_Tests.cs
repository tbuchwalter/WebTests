using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Abp.Web.Models;
using AngleSharp.Dom.Html;
using MyProject.Web.Controllers;
using MyProject.Web.Models.Account;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace MyProject.Web.Tests.Controllers
{
    public class AccountControllerTests: MyProjectWebTestBase
    {
       
       [Fact]
        public async Task Login_Renders_View_Test()
        {
            //Arrange


            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<AccountController>(nameof(AccountController.Login))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();


        }

        [Theory]
        [InlineData(null, "", null, "/")]
        [InlineData(null, "/About/Index", null, "/About/Index")]
        public async Task Login_Has_ReturnUrl_Test(string userName, string url, string message, string expectedUrl)
        {
           
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<AccountController>(nameof(AccountController.Login),
                    new { userNameOrEmailAddress = userName, returnUrl = url, successMessage = message })
            );

            //Assert
            var document = ParseHtml(response);
            var input = (IHtmlInputElement)document.QuerySelector("input[name='returnUrl']");
            input.Value.ShouldBe(expectedUrl);


        }

        [Theory]
        [InlineData( "/")]
        [InlineData("/About/Index")]
        public async Task Login_Form_Logs_In(string returnUrl)
        {
            ////Arrange
             var loginModel = new LoginViewModel{Password = "P@ssw0rd", RememberMe = false, UsernameOrEmailAddress = "admin"};
            var data = JsonConvert.SerializeObject(new {loginModel, returnUrl});
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            //Act
            var response = await PostResponseAsObjectAsync<AjaxResponse>(

                GetUrl<AccountController>(nameof(AccountController.Login), new {loginModel.UsernameOrEmailAddress, loginModel.Password, loginModel.RememberMe, returnUrl}), 
                    new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded"), HttpStatusCode.Found
                    );

            //Assert
            response.ShouldBeOfType<AjaxResponse>();
            response.TargetUrl.ShouldBe(returnUrl);
        }

        [Fact]
        public async Task Login_Form_Fails()
        {
            //Arrange
            var loginModel = new LoginViewModel { Password = "P@ssw0rd!", RememberMe = false, UsernameOrEmailAddress = "admin" };
            var data = JsonConvert.SerializeObject(new { loginModel, returnUrl="/" });
            Client.DefaultRequestHeaders.Add("my-name", "admin");

            //Act
            var response = await PostResponseAsObjectAsync<AjaxResponse>(
                GetUrl<AccountController>(nameof(AccountController.Login), new { loginModel.UsernameOrEmailAddress, loginModel.Password, loginModel.RememberMe, returnUrl = "/" }),
                new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded"), HttpStatusCode.InternalServerError
            );

            //Assert
            response.ShouldNotBe(null);
            response.Error.Details.ShouldBe("Invalid user name or password");
            response.Error.Message.ShouldBe("Login failed!");
        }

        [Fact]
        public async Task Logout_signs_out_User()
        {
            //Arrange
            LoginAsDefaultTenantAdmin();
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<AccountController>(nameof(AccountController.Logout)), HttpStatusCode.Redirect
            );

            //Assert
            response.ShouldNotBeNull();
        }
    }
}
