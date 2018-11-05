using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MyProject.Domains;
using MyProject.Municipality;
using Shouldly;
using Xunit;

namespace MyProject.Tests.Municipality
{
    public class Municipality_Tests : MyProjectTestBase
    {
        private readonly IMunicipalitiesService _municipalityService;

        public Municipality_Tests()
        {
            _municipalityService = LocalIocManager.Resolve<IMunicipalitiesService>();
        }

        [Fact]
        public async Task Should_Return_Municipality_By_ID()
        {

            //Arrange 
            LoginAsHostAdmin();

            // Act
            var output = await _municipalityService.Get(new EntityDto { Id = 1 });

            // Assert
            output.ShouldNotBe(null);
            output.Name.ShouldBe("Test NameOne");
        }

        



        [Fact]
        public async Task Should_Return_The_Table()
        {
            //Arrange 
            LoginAsHostAdmin();

            //Act
            var table = await _municipalityService.GetAll(new PagedResultRequestDto());

            //Assert
            table.ShouldNotBe(null);
            table.TotalCount.ShouldBe(2);

        }

        [Fact]
        public async Task Should_Delete_by_Id()
        {
            //Arrange
            LoginAsHostAdmin();
            var municipalityId = new EntityDto(){Id = 1};

            //Act
            var tableBefore = _municipalityService.GetAll(new PagedResultRequestDto());
            await _municipalityService.Delete(municipalityId);

            //Assert
            var table = _municipalityService.GetAll(new PagedResultRequestDto());

            table.ShouldNotBeNull();
            tableBefore.Result.TotalCount.ShouldBe(2);
            table.Result.TotalCount.ShouldBe(1);




        }


        [Theory]
        [InlineData(0, "New Test", "Steve", "new@email.com",null,"Jess",  true, "New Test", 3, 3)]
        [InlineData(1, "Update", "Steve", "new@email.com", null, "Jess", true, "Test NameOne", 2, 1)]

        public async Task Should_Save_Municipality(int id, string name, string pointOfContact, string email, string modifiedBy, string createdBy, bool isActive, string nameComparer, int expectedCount, int expectedId)
        {
            //Arrange
            var addressModel = new Domains.Address {Id = id, Address1 = "123 Straight Way", City = "Arlington", State = 17, Zip = "76012"};
            var model = new Municipalities { Id = id, Name = name, PointOfContact = pointOfContact, Email = email, AddressId = 1, Address = addressModel };
            var countBefore = UsingDbContext(context => { return context.Municipalities.Count(x => x.IsActive); });
                //Act 
                if (id !=0)
            {
                UsingDbContext(context =>
                {
                    var originalData = context.Municipalities.FirstOrDefault(x => x.Id == id);
                    originalData.ShouldNotBeNull();
                    originalData.Name.ShouldBe(nameComparer);


                });
            }

            _municipalityService.SaveMunicipality(model);

            var count = UsingDbContext(context => { return context.Municipalities.Count(); });

            var municipalities = UsingDbContext(context =>
            {
                return context.Municipalities.FirstOrDefault(x => x.Id == expectedId);
            });

            count.ShouldBe(expectedCount);
            municipalities.ShouldNotBeNull();
            municipalities.Name.ShouldBe(name);

        }

        


    }
}
