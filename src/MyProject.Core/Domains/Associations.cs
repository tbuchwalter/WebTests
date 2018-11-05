using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyProject.Domains.Guideline;

namespace MyProject.Domains
{
    [Audited]
    public class Association : FullAuditedEntity, IPassivable
    {
       
        public  string Name { get; set; }
        public string PointOfContact { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int AddressId { get; set; }

        // navigation properties 

        public virtual Address Address { get; set; }
        public IList<AssociationGuidelines> AssociationGuidelines { get; set; }
        public IList<Community.Community> Communities { get; set; }
        

    }
}
