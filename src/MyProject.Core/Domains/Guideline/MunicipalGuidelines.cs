using Abp.Domain.Entities;

namespace MyProject.Domains.Guideline
{
    
    public class MunicipalGuidelines : Entity
    {
        
        public int MunicipalitiesId { get; set; }
        public int GuidelineValuesId { get; set; }

        //Navigation Properties
        public virtual Municipalities Municipalities { get; set; }
        public virtual GuidelineValues GuidelineValues { get; set; }

    }
}
