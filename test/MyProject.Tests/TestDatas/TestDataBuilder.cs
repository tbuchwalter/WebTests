using Abp.Timing;
using MyProject.Domains;
using MyProject.EntityFrameworkCore;

namespace MyProject.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MyProjectDbContext _context;

        public TestDataBuilder(MyProjectDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.Addresses.AddRange(
                new Domains.Address { Address1 = "123 Straight Way", City = "Arlington", State = 17, Zip = "76012" },
                new Domains.Address { Address1 = "123 Park Blvd", City = "Dallas", State = 17, Zip = "76213" }

                );
            _context.SaveChanges();
            _context.Municipalities.AddRange(
            new Municipalities()
            {
                Name = "Test NameOne",
                PointOfContact = "Tom Jerry",
                Email = "Tom.Jerry@yolo.com",
                CreationTime = Clock.Now,
                //CreatedBy = "Clark Kent",
                LastModificationTime = null,
                //ModifiedBy = "Jessica",
                IsActive = true,
                AddressId = 1
               

            },
            new Municipalities()
            {
                Name = "Test NameTwo",
                PointOfContact = "Kevin Hart",
                Email = "Kevin.Hart@yolo.com",
                CreationTime = Clock.Now,
                //CreatedBy = "Christina Pham",
                LastModificationTime = null,
                //ModifiedBy = "Dominic Young",
                IsActive = true,
                AddressId = 2
            }

          );

            _context.SaveChanges();


            //create test data here...
        }
    }
}