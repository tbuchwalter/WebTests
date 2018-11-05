using Abp.Auditing;
using Abp.Domain.Entities;

namespace MyProject.Domains.Guideline
{
    [Audited]
    public class GuidelineType : Entity

    {
        public int GuidelineId { get; set; }
        public int DraftTypeId { get; set; }

        //navigation Properties 

        public virtual Guidelines Guideline { get; set; }
        public virtual DraftType DraftType { get; set; }
        


    }
}
