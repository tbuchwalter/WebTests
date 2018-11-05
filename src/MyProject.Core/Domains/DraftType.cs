using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyProject.Domains.Guideline;

namespace MyProject.Domains
{
    [Audited]
    public class DraftType : FullAuditedEntity, IPassivable
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public IList<GuidelineType> GuidelineTypes { get; set; }

    }
}
