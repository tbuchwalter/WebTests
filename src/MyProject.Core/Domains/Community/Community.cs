using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.Domains.Community
{
    [Audited]
    public class Community : FullAuditedEntity, IPassivable
    {
        
        public string Name { get; set; }
        public string Location { get; set; }
        public int AssociationId { get; set; }
        public int MunicipalitiesId { get; set; }
        public bool IsActive { get; set; }

        //navigation properties 
        public virtual Association Association { get; set; }
        public virtual Municipalities Municipalities { get; set; }
        public IList<CommunitySection> CommunitySections { get; set; }
        public IList<BuilderPreferences> BuilderPreferences { get; set; }


    }
}
