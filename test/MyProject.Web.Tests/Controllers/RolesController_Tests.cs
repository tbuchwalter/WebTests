using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Abp.Web.Models;
using AngleSharp.Dom.Html;
using Microsoft.EntityFrameworkCore;
using MyProject.Roles.Dto;
using MyProject.Web.Controllers;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace MyProject.Web.Tests.Controllers
{
    public class RolesController_Tests:MyProjectWebTestBase
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
                GetUrl<RolesController>(nameof(RolesController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();

        }

        [Fact]
        public async Task Index_Model_Test()
        {

            //Arrange 
            var rolesInDatabase = await UsingDbContextAsync(async dbContext =>
            {
                return await dbContext.Roles
                    .Where(r => r.IsDeleted == false && r.TenantId != null)
                    .ToListAsync();
            });

            //Login Test User
            LoginAsDefaultTenantAdmin();

            //Set Session Cookie values
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<RolesController>(nameof(RolesController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrWhiteSpace();
            var view = ParseHtml(response);
            var items = view.QuerySelectorAll("table tbody tr");

            //Check task count
            items.Length.ShouldBe(rolesInDatabase.Count);

            //Check if returned list items are same those in the database
            foreach (var listItem in items)
            {
                var row = listItem.QuerySelectorAll("td");
                var roleName = row.First().InnerHtml.Trim();
                rolesInDatabase.Any(t => t.Name == roleName).ShouldBeTrue();
            }

        }

        [Fact]
        public async Task Edit_Modal_Test()
        {

            //Arrange 
            //Login Test User
            LoginAsDefaultTenantAdmin();

            //Set Session Cookie values
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<RolesController>(nameof(RolesController.EditRoleModal), new {roleId = 2}));

            //Assert
            response.ShouldNotBeNullOrWhiteSpace();
            var view = ParseHtml(response);
            var input = (IHtmlInputElement)view.QuerySelector("input#rolename");

            //Check task count
            input.Value.ShouldBe("Admin");
        }

        [Fact]
        public async Task Save_Role_Test()
        {
            LoginAsDefaultTenantAdmin();
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            var model = new RoleDto(){Description = "New Role", DisplayName = "Test", Name = "My Test", NormalizedName = "MYTEST"};

            var data = JsonConvert.SerializeObject(model);
            var url = GetUrl<RolesController>(nameof(RolesController.SaveRole), new { model.Description, model.DisplayName, model.Name, model.NormalizedName });

            var message = new HttpRequestMessage() { Content = new StringContent(data, Encoding.UTF8, "application/json"), RequestUri = new Uri("http://localhose" + url), Method = HttpMethod.Post };
            var response = await SendResponseAsObjectAsync<AjaxResponse>(message);
           
            response.ShouldBeOfType<AjaxResponse>();

        }
    }
}
