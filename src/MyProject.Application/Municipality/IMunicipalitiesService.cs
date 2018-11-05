using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyProject.Domains;
using MyProject.Municipality.Dto;

namespace MyProject.Municipality
{
    public interface IMunicipalitiesService : IAsyncCrudAppService<MunicipalitiesDto, int, PagedResultRequestDto, MunicipalitiesDto, MunicipalitiesDto>
    {
        /// <summary>
        /// Get item by ID including the query of the assigned AddressId
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<MunicipalitiesDto> Get(EntityDto input);

       
        /// <summary>
        /// Save data to the database 
        /// </summary>
        /// <param name="municipalities"></param>
        void SaveMunicipality(Municipalities municipalities);

        /// <summary>
        /// Get the whole Municipality Table
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="search"></param>
        /// <param name="activeFilter"></param>
        /// <returns></returns>
        IEnumerable<Municipalities> GetDataTable(string sortOrder, string search, bool? activeFilter);

        

    }
}