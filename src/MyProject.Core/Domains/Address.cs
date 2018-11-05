using System.Collections.Generic;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;

namespace MyProject.Domains
{
    [Audited]
   public class Address : FullAuditedEntity
    {
       
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        // There is no navigation property for this class 
        public IList<Association> Associations { get; set; }
        public IList<Builders> Builders { get; set; }
        public IList<Municipalities> Municipalities { get; set; }


        public void AssignUpdateValues(Address address)
        {

            Address1 = address.Address1;
            Address2 = address.Address2;
            Address3 = address.Address3;
            City = address.City;
            State = address.State;
            Zip = address.Zip;
            Phone = address.Phone;
            Fax = address.Phone;
            CreatorUserId = address.CreatorUserId;
            CreationTime = address.CreationTime;
            DeleterUserId = address.DeleterUserId;
            DeletionTime = address.DeletionTime;
            LastModificationTime = address.LastModificationTime;
            LastModifierUserId = address.LastModifierUserId;
        }

    }
}
