using System.ComponentModel.DataAnnotations;
using MyProject.Address.Dto;

namespace MyProject.Web.Models.Address
{
    public class AddressViewModel : BaseViewModelEntity
    {
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Fax { get; set; }

        public AddressViewModel()
        {

        }
        
        public AddressViewModel(AddressDto address)
        {
            Id = address.Id;
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


        public Domains.Address ConvertToAddress()
        {
            return new Domains.Address
            {
                Id = Id,
                Address1 = Address1,
                Address2 = Address2,
                Address3 = Address3,
                City = City,
                State = State,
                Zip = Zip,
                Phone = Phone,
                Fax = Fax,
                CreationTime = CreationTime,
                CreatorUserId = CreatorUserId,
                DeleterUserId = DeleterUserId,
                DeletionTime = DeletionTime,
                LastModificationTime = LastModificationTime,
                LastModifierUserId = LastModifierUserId

            };
        }

        


    }
}
