using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyProject.Domains;

namespace MyProject.Municipality.Dto
{
    [AutoMap(typeof(Municipalities))]
    public class MunicipalitiesDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string PointOfContact { get; set; }
        public string Email { get; set; }
        public DateTime CreationTime { get; set; }
        public long CreatorUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public long? DeleterUserId { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsActive { get; set; }
        public Domains.Address Address { get; set; }
        public int AddressId { get; set; }
        



    }
}
