using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using MyProject.Authorization.Users;

namespace MyProject.Domains
{
    [Audited]
    public class UserSubDivision : AuditedEntity
    {
       
        public int SubDivisionId { get; set; }
        public long UserId { get; set; }

        //navigation properties
        public virtual SubDivision SubDivision { get; set; }
        public virtual User User { get; set; }

    }
}
