using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities;
using MyProject.Domains.Community;

namespace MyProject.Domains
{
    [Audited]
    public class SubDivision : Entity
    {
       
        public int CommunitySectionId { get; set; }
        public int BuildersId { get; set; }

        //navigation properties
        public virtual CommunitySection CommunitySection { get; set; }
        public virtual Builders Builders { get; set; }

        public IList<UserSubDivision> UserSubDivisions { get; set; }
       
    }
}
