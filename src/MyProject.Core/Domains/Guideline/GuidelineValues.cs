using System;
using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MyProject.Domains.Guideline
{
    [Audited]
    public class GuidelineValues : FullAuditedEntity, IPassivable
    {
        public int GuidelineId { get; set; }
        public int? ValueType { get; set; }
        public int? NumericValue1 { get; set; }
        public int NumericValue2 { get; set; }
        public string TextValue { get; set; } 
        public string Notes { get; set; }
        public string AttachmentRef { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? InactiveDate { get; set; }
        public bool IsActive { get; set; }


        //navigation property
        public virtual Guidelines Guideline { get; set; }
        public IList<AssociationGuidelines> AssociationGuidelines { get; set; }
        public IList<MunicipalGuidelines> MunicipalGuidelines { get; set; }
        public IList<BuilderPreferences> BuilderPreferences { get; set; }


    }
}
