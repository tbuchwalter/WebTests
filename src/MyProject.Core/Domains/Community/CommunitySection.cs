using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyProject.Domains.Guideline;

namespace MyProject.Domains.Community
{
    [Audited]
    public class CommunitySection : FullAuditedEntity, IPassivable
    {
       
        public int CommunityId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        //navigation property
        public virtual Community Community { get; set; }
        public IList<BuilderPreferences> BuilderPreferences { get; set; }
        public IList<AssociationGuidelines> AssociationGuidelines { get; set; }
        public IList<SubDivision> SubDivisions { get; set; }


    }
}
