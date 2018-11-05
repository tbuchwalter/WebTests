using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyProject.Address.Dto;

namespace MyProject.Address
{
    public interface IAddressServices: IAsyncCrudAppService<AddressDto, int, PagedResultRequestDto, AddressDto, AddressDto>
    {
        
        /// <summary>
        /// Save address to table
        /// </summary>
        /// <param name="address"></param>
        void SaveAddress(Domains.Address address);
    }
}
