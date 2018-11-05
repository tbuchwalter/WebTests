using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MyProject.Address.Dto;

namespace MyProject.Address
{
    public class AddressServices: AsyncCrudAppService<Domains.Address, AddressDto, int, PagedResultRequestDto, AddressDto, AddressDto>, IAddressServices
    {
        private readonly IRepository<Domains.Address> _addressRepo;
        public AddressServices(IRepository<Domains.Address> addressRepo) : base(addressRepo)
        {
            _addressRepo = addressRepo;
        }

        


        public void SaveAddress(Domains.Address address)
        {
            if (address.Id == 0)
            {
                _addressRepo.Insert(address);
            }
            else
            {
                var original = _addressRepo.FirstOrDefault(x => x.Id == address.Id);
                if (original != null)
                {
                    original.AssignUpdateValues(address);
                    _addressRepo.Update(original);
                }
                else
                    _addressRepo.InsertOrUpdate(address);
            }
        }





    }
}
