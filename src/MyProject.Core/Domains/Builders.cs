using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.Domains
{
    [Audited]
    public class Builders :FullAuditedEntity, IPassivable
    {

        
        public string Name { get; set; }
        public string PointOfContact { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int AddressId { get; set; }

        //navigation properties

        public virtual Address Address { get; set; }
        public IList<BuilderPreferences> BuilderPreferences { get; set; }
        public IList<SubDivision> SubDivisions { get; set; }




    }
}
