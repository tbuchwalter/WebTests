using System;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyProject.Domains.Community;
using MyProject.Domains.Guideline;

namespace MyProject.Domains
{
    [Audited]
    public class BuilderPreferences : FullAuditedEntity, IPassivable
    {
        public int BuilderId { get; set; }
        public int GuidelineValueId { get; set; }
        public int? CommunityId { get; set; }
        public int? SectionId { get; set; }
        public bool Override { get; set; }
        public string OverrideNotes { get; set; }
        public string OverrideDocReference { get; set; }
        public  DateTime? OverrideDate { get; set; }
        public string OverrideBy { get; set; }
        public bool IsActive { get; set; }


        //navigation properties

        public virtual Builders Builder { get; set; }
        public virtual  GuidelineValues GuidelineValue { get; set; }
        public virtual Community.Community  Community { get; set; }
        public virtual CommunitySection CommunitySection { get; set; }

    }
}
