using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyProject.Domains.Guideline;

namespace MyProject.Domains
{
    [Audited]
    public class Municipalities : FullAuditedEntity, IPassivable
    { 


        public string Name { get; set; }
        public  string PointOfContact { get; set; }
        public string Email { get; set; }
        public  bool IsActive { get; set; }
        public int AddressId { get; set; }

        //navigation property
        public virtual Address Address { get; set; }
        public IList<Community.Community> Communities { get; set; }
        public IList<MunicipalGuidelines> MunicipalGuidelines { get; set; }



        public void AssignUpdateValues(Municipalities municipalities)
        {

            Name = municipalities.Name;
            IsActive = municipalities.IsActive;
            PointOfContact = municipalities.PointOfContact;
            Email = municipalities.Email;
            AddressId = municipalities.AddressId;
            CreatorUserId = municipalities.CreatorUserId;
            CreationTime = municipalities.CreationTime;
            DeleterUserId = municipalities.DeleterUserId;
            DeletionTime = municipalities.DeletionTime;
            LastModificationTime = municipalities.LastModificationTime;
            LastModifierUserId = municipalities.LastModifierUserId;
            AddressId = municipalities.Address.Id;
        }


    }
}
