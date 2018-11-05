using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Abp.Web.Models;
using AllPoints.Web.Controllers;
using AngleSharp.Dom.Html;
using Microsoft.EntityFrameworkCore;
using MyProject.Municipality.Dto;
using MyProject.Web.Models.Address;
using MyProject.Web.Models.DataTables;
using MyProject.Web.Models.Municipalities;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace MyProject.Web.Tests.Controllers
{
    public class MunicipalitiesController_Tests: MyProjectWebTestBase
    {
        public MunicipalitiesController_Tests()
        {
            LoginAsDefaultTenantAdmin();
        }

        [Fact]
        public async Task Municipalities_Render_View()
        {
            //Arrange
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<MunicipalitiesController>(nameof(MunicipalitiesController.Index))
            );

            //Assert
            response.ShouldNotBeNull();
            var document = ParseHtml(response);
            var municipalitiesRow = document.QuerySelectorAll("#MunicipalitiesTable tr th");
            municipalitiesRow.Length.ShouldBe(5);

        }

        [Fact]
        public async Task Municipalities_Edit_Municipalities()
        {
            //Arrange
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");



            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<MunicipalitiesController>(nameof(MunicipalitiesController.EditMunicipalities), new {municipalitiesId = 1})
            );

            //Assert
            response.ShouldNotBeNull();
            var view = ParseHtml(response);
            var input = (IHtmlInputElement) view.QuerySelector("input#Name");
            input.Value.ShouldBe("Test NameOne");
        }

        [Fact]
        public async Task Municipalities_AddNew_MunicipalityTests()
        {
            //Arrange 
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<MunicipalitiesController>(nameof(MunicipalitiesController.EditMunicipalities), new { municipalitiesId = 0 }));


            //Assert
            response.ShouldNotBeNullOrWhiteSpace();
            var view = ParseHtml(response);
            var input = (IHtmlInputElement)view.QuerySelector("input#Name");
            var isActive = (IHtmlInputElement)view.QuerySelector("input#IsActive");
            var title = view.QuerySelector(".modal-title");
            var titleString = title.TextContent.ToString();
            var result = titleString.Replace(" ", "");
            input.Value.ShouldBe("");
            isActive.Value.ShouldBe("true");
            result.ShouldBe("\nAddMunicipality\n");


        }

        [Fact]

        public async Task Municipalities_Table()
        {
            //Arrange 
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            var model = new DTParameters { Draw = 1, Columns = new[] { new DTColumn { Data = "Name" } }, Length = 600, Order = new DTOrder[] { new DTOrder { Column = 0, Dir = DTOrderDir.ASC } }, Search = new DTSearch() { Value = "" } };
            var baseTableInfo = new BaseDataTableModel { Param = model };
            var data = JsonConvert.SerializeObject(baseTableInfo);


            //Act
            var response = await PostResponseAsObjectAsync<DTResult<Domains.Municipalities>>(
                GetUrl<MunicipalitiesController>(nameof(MunicipalitiesController.MunicipalitiesTable),model),
                new StringContent(data, Encoding.UTF8, "application/json")
                );

            //Assert
            response.ShouldBeOfType<DTResult<Domains.Municipalities>>();
            response.data.Count.ShouldBe(2);
            response.data.First().Name.ShouldBe("Test NameOne");
        }

        [Fact]
        public async Task Municipalities_Save_New_Item()
        {
            //Arrange
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");
            var addressViewModel = new AddressViewModel()
            {
                Address1 = "123 This Way", City = "Arlington", State = 44, Zip = "76001", Phone = "8175555555",
                CreationTime = DateTime.Now
            };

            var viewModelSave = new MunicipalitiesViewModel()
            {
                Name = "Controller Test Name",
                PointOfContact = "Tom Jerry",
                Email = "Tom.Jerry@yolo.com",
                CreationTime = DateTime.Now,
                LastModificationTime = null,
                IsActive = true,
                AddressId = 0,
                MunicipalAddress = addressViewModel
                //Address1 = "123 This Way",
                //City = "Arlington",
                //State = 44,
                //Zip = "76001",
                //Phone = "8175555555"
            };

            /* This is an attempt to use string interpolation to create querystring parameters */
            //var rawData =
            //    $"?Name={viewModelSave.Name}&Id={viewModelSave.Id}&PointOfContat=${viewModelSave.PointOfContact}&Email={viewModelSave.Email}&CreationTime={DateTime.Now}" +
            //    $"&LastModificationTime=&IsActive={viewModelSave.IsActive}&AddressId={viewModelSave.AddressId}&MunicipalAddress.Id={viewModelSave.MunicipalAddress.Id}&MunicipalAddress.Address1={viewModelSave.MunicipalAddress.Address1}" +
            //    $"&MunicipalAddress.City={viewModelSave.MunicipalAddress.City}&MunicipalAddress.State={viewModelSave.MunicipalAddress.State}&MunicipalAddress.Zip={viewModelSave.MunicipalAddress.Zip}&MunicipalAddress.Phone={viewModelSave.MunicipalAddress.Phone}" +
            //    $"&MunicipalAddress.CreationTime={DateTime.Now}&MunicipalAddress.IsActive={viewModelSave.MunicipalAddress.IsActive}";

            /*This is an attempt to create a json object that could be serialize into an object as the "queryStringParamsAsAnonymousObject" that can be used in the GetUrl Helper method below */

            var rawData = $"{{'Name':'Controller Test Name','PointOfContact':'Tom Jerry', 'Email': 'Tom.Jerry@yolo.com',"
                           + "'CreationTime':'" +  DateTime.Now + "','LastModificationTime':'','IsActive' : 'true','AddressId':'0','MunicipalAddress.Id':'0','MunicipalAddress.Address1':'123 This Way',"
                           + "'MunicipalAddress.City':'Arlington','MunicipalAddress.State':'44','MunicipalAddress.Zip':'76001','MunicipalAddress.Phone':'8175555556','MunicipalAddress.IsActive':'true'}";
            var jsonData = JsonConvert.DeserializeObject(rawData);

            //Serialize ViewModel to send with Post as part of the HttpContent object 
            var data = JsonConvert.SerializeObject(viewModelSave);
            var municipleAddress = new
            {
                viewModelSave.MunicipalAddress.Id,
                viewModelSave.MunicipalAddress.Address1,
                viewModelSave.MunicipalAddress.City,
                viewModelSave.MunicipalAddress.State,
                viewModelSave.MunicipalAddress.Zip,
                viewModelSave.MunicipalAddress.Phone,
                viewModelSave.MunicipalAddress.IsActive,
                viewModelSave.MunicipalAddress.CreationTime
            };

            //actually get the url from helper method (with various attempts at creating an anonymousObject directly
            var url = GetUrl<MunicipalitiesController>(nameof(MunicipalitiesController.SaveMunicipalities),
        new
        {
            viewModelSave.Id,
            viewModelSave.Name,
            viewModelSave.PointOfContact,
            viewModelSave.Email,
            viewModelSave.CreationTime,
            viewModelSave.LastModificationTime,
            viewModelSave.IsActive,
            viewModelSave.AddressId,
            municipleAddress
            //MunicipalAddress_Address1 = municipleAddress.Address1,
            //MunicipalAddress_Id = municipleAddress.Id,
            //MunicipleAddress_City = municipleAddress.City,
            //MunicipleAddress_State = municipleAddress.State,
            //MunicipalAddress_Zip = municipleAddress.Zip,
            //MunicipalAddress_Phone = municipleAddress.Phone,
            //MunicipalAddress_IsActive = municipleAddress.IsActive,
            //MunicipalAddress. = new 
            //{
            //    viewModelSave.MunicipalAddress.Id,
            //    viewModelSave.MunicipalAddress.Address1,
            //    viewModelSave.MunicipalAddress.City,
            //    viewModelSave.MunicipalAddress.State,
            //    viewModelSave.MunicipalAddress.Zip,
            //    viewModelSave.MunicipalAddress.Phone,
            //    viewModelSave.MunicipalAddress.IsActive,
            //    viewModelSave.MunicipalAddress.CreationTime
            //},
            //viewModelSave.Address1,
            //viewModelSave.City,
            //viewModelSave.State,
            //viewModelSave.Zip,
            //viewModelSave.Phone
        }

        );
            var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");
           

            //Act
            var response = await PostResponseAsObjectAsync<AjaxResponse>(url, content);

            //Assert
            var count = UsingDbContext(context => { return context.Municipalities.Count(x => x.IsActive); });

            response.ShouldBeOfType<AjaxResponse>();
            response.Result.ShouldNotBeNull();
            count.ShouldBe(3);
        }

        [Fact]
        public async Task should_Delete_Municipalities()
        {
            //Arrange 
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            //checking for original data
            var count = UsingDbContext(context => { return context.Municipalities.Count(x => x.IsActive); });
            count.ShouldBe(2);

            var url = GetUrl<MunicipalitiesController>(nameof(MunicipalitiesController.DeleteMunicipalities), new {municipalitiesId = 1});

            var message = new HttpRequestMessage
            {
                Content = new StringContent("1", Encoding.UTF8, "application/json"),
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localHost" + url)

            };

            //Act
            var response = await SendResponseAsStringAsync(message);

            //Assert
            response.ShouldNotBeNull();
            var afterCount = UsingDbContext(context => { return context.Municipalities.Count(x => x.IsDeleted); });
            afterCount.ShouldBe(1);





        }


        [Fact]
        public async Task Municipalities_Save_Updated_Items()
        {
            //Arrange 
            Client.DefaultRequestHeaders.Add("my-name", "admin");
            Client.DefaultRequestHeaders.Add("my-id", "2");

            //checking for original data
            var addressModel = new AddressViewModel() { Id = 0, Address1 = "123 Straight Way", City = "Arlington", State = 17, Zip = "76012", Phone = "8175555556"};

            var originalData = new Domains.Municipalities();
            UsingDbContext(context =>
            {
                originalData = context.Municipalities.Include(x => x.Address).FirstOrDefault(x => x.Id == 1);
                originalData.ShouldNotBeNull();
                originalData.IsActive.ShouldBe(true);
            });

            var viewModelSave = new MunicipalitiesViewModel(originalData.MapTo<MunicipalitiesDto>());
           // viewModelSave.Phone = "8175555556";
            viewModelSave.IsActive = false;
            var data = JsonConvert.SerializeObject(viewModelSave);

            var url = GetUrl<MunicipalitiesController>(nameof(MunicipalitiesController.SaveMunicipalities),
                new
                {
                    viewModelSave.Id,
                    viewModelSave.Name,
                    viewModelSave.PointOfContact,
                    viewModelSave.Email,
                    viewModelSave.CreationTime,
                    viewModelSave.LastModificationTime,
                    viewModelSave.IsActive,
                    viewModelSave.AddressId,
                    //viewModelSave.Address1,
                    //viewModelSave.City,
                    //viewModelSave.State,
                    //viewModelSave.Zip,
                    //viewModelSave.Phone
                });
            var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");
            var message = new HttpRequestMessage
            {
                Content = content,
                Method = HttpMethod.Post,
                RequestUri =
                    new Uri("http://localhost" + url)

            };





            //Act


            var response = await PostResponseAsObjectAsync<AjaxResponse>(url, content);

            var count = UsingDbContext(context => { return context.Municipalities.Count(x => x.IsActive); });

            var municipalities = UsingDbContext(context =>
            {
                return context.Municipalities.FirstOrDefault(x => x.Id == 1);
            });


            municipalities.IsActive.ShouldBe(false);
            //Assert
            response.ShouldBeOfType<AjaxResponse>();
            response.Result.ShouldNotBeNull();
            count.ShouldBe(1);




        }







    }
}
