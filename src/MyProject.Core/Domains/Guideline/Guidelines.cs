using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.Domains.Guideline
{
    [Audited]
    public class Guidelines : FullAuditedEntity, IPassivable
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        // navigation properties
        public virtual GuidelineCategories Category { get; set; }
        public IList<GuidelineValues> GuidelineValues { get; set; }
        public IList<GuidelineType> GuidelineTypes { get; set; }

    }
}
