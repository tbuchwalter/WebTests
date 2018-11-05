using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MyProject.Domains;
using MyProject.Municipality.Dto;

namespace MyProject.Municipality
{
    public class MunicipalitiesService: AsyncCrudAppService<Municipalities, MunicipalitiesDto, int, PagedResultRequestDto, MunicipalitiesDto, MunicipalitiesDto>, IMunicipalitiesService
    {

        private readonly IRepository<Municipalities> _municipalitiesRepo;
        
        public MunicipalitiesService(IRepository<Municipalities> municipalityRepo) : base(municipalityRepo)
        {
            _municipalitiesRepo = municipalityRepo;

        }

       
        

        #region Methods

        public IEnumerable<Municipalities> GetDataTable(string sortOrder, string search, bool? activeFilter)
        {
           var query = _municipalitiesRepo.GetAll();
            if (activeFilter.HasValue)
            {
                query = query.Where(x => x.IsActive == activeFilter);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));

            }


            switch (sortOrder)
            {
                case "name":
                    return query.OrderBy(x => x.Name);
                case "name DESC":
                    return query.OrderByDescending(x => x.Name);
                case "isActive":
                    return query.OrderBy(x => x.IsActive);
                case "isActive DESC":
                    return query.OrderByDescending(x => x.IsActive);
                case "pointOfContact":
                    return query.OrderBy(x => x.PointOfContact);
                case "pointOfContact DESC":
                    return query.OrderByDescending(x => x.PointOfContact);
                case "email":
                    return query.OrderBy(x => x.Email);
                case "email DESC":
                    return query.OrderByDescending(x => x.Email);
            }
            var count = query.Count();

            return query;
        }

       
        
        public void SaveMunicipality(Municipalities municipality)
        {
            

            if (municipality.Id == 0)
            {
               
                _municipalitiesRepo.Insert(municipality);
            }
            else
            {

                var original = _municipalitiesRepo.FirstOrDefault(x => x.Id == municipality.Id);
                if (original != null)
                {
                    original.AssignUpdateValues(municipality);
                    _municipalitiesRepo.Update(original);
                }
                else
                {
                    _municipalitiesRepo.InsertOrUpdate(municipality);
                }
            }
        }


        public async Task<MunicipalitiesDto> Get(EntityDto input)
        {
            var data = Repository.GetAllIncluding(x => x.Address).FirstOrDefault(x => x.Id == input.Id);
            if (data != null)
            {
                var dto = new MunicipalitiesDto
                {
                    Id = data.Id,
                    Name = data.Name,
                    PointOfContact = data.PointOfContact,
                    Email = data.Email,
                    CreationTime = data.CreationTime,
                    IsActive = data.IsActive,
                    AddressId = data.AddressId,
                    LastModificationTime = data.LastModificationTime,
                    Address = data.Address

                   
                };
                return dto;
            }

            return null;
        }
        #endregion

    }


}
