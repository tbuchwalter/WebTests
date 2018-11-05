using Abp.Auditing;
using Abp.Domain.Entities;
using MyProject.Domains.Community;

namespace MyProject.Domains.Guideline
{
    [Audited]
    public class AssociationGuidelines : Entity
    {
       
        public int GuidelineValuesId { get; set; }
        public int AssociationId { get; set; }
        public int? CommunitySectionId { get; set; }

        // navigation properties
        public virtual GuidelineValues GuidelineValues { get; set; } 
        public virtual Association Association { get; set; }
        public virtual CommunitySection CommunitySection { get; set; }
        
    }
}
