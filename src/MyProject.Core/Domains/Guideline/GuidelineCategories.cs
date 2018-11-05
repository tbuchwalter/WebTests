using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.Domains.Guideline
{
    [Audited]
    public class GuidelineCategories : FullAuditedEntity, IPassivable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // there is no navigation properties 
        public IList<Guidelines> Guidelines { get; set; }



    }
}
