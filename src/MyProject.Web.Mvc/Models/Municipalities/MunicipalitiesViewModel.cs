using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using MyProject.Municipality.Dto;
using MyProject.Web.Models.Address;

namespace MyProject.Web.Models.Municipalities
{
    [AutoMap(typeof(Domains.Municipalities))]
    public class MunicipalitiesViewModel : BaseViewModelEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PointOfContact { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int AddressId { get; set; }
        //[Required]
        //public string Address1 { get; set; }
        //public string Address2 { get; set; }
        //public string Address3 { get; set; }
        //[Required]
        //public string City { get; set; }
        //[Required]
        //public int State { get; set; }
        //[Required]
        //public string Zip { get; set; }
        //[Required]
        //public string Phone { get; set; }
        //public string Fax { get; set; }
        public AddressViewModel MunicipalAddress { get; set; }


        public MunicipalitiesViewModel()
        {
            MunicipalAddress = new AddressViewModel();
        }

        public MunicipalitiesViewModel(MunicipalitiesDto municipalities)
        {
            Id = municipalities.Id;
            Name = municipalities.Name;
            IsActive = municipalities.IsActive;
            PointOfContact = municipalities.PointOfContact;
            Email = municipalities.Email;
            AddressId = municipalities.AddressId;
            CreatorUserId = municipalities.CreatorUserId;
            CreationTime = municipalities.CreationTime;
            DeleterUserId = municipalities.DeleterUserId;
            DeletionTime = municipalities.DeletionTime;
            LastModificationTime = municipalities.LastModificationTime;
            LastModifierUserId = municipalities.LastModifierUserId;
            //Address1 = municipalities.Address.Address1;
            //Address2 = municipalities.Address.Address2;
            //Address3 = municipalities.Address.Address3;
            //City = municipalities.Address.City;
            //State = municipalities.Address.State;
            //Zip = municipalities.Address.Zip;
            //Phone = municipalities.Address.Phone;
            //Fax = municipalities.Address.Fax;
            MunicipalAddress = new AddressViewModel()
            {
                Id = municipalities.Address.Id,
                Address1 = municipalities.Address.Address1,
                Address2 = municipalities.Address.Address2,
                Address3 = municipalities.Address.Address3,
                City = municipalities.Address.City,
                State = municipalities.Address.State,
                Zip = municipalities.Address.Zip,
                Phone = municipalities.Address.Phone,
                Fax = municipalities.Address.Fax,
                CreationTime = municipalities.Address.CreationTime,


            };


        }

        public Domains.Municipalities ConvertToMunicipalities()
        {
            var address = new Domains.Address
            {
                Id = AddressId,
                Address1 = MunicipalAddress.Address1,
                Address2 = MunicipalAddress.Address2,
                Address3 = MunicipalAddress.Address3,
                City = MunicipalAddress.City,
                State = MunicipalAddress.State,
                Zip = MunicipalAddress.Zip,
                Phone = MunicipalAddress.Phone,
                Fax = MunicipalAddress.Fax,
                //Address1 = Address1,
                //Address2 = Address2,
                //Address3 = Address3,
                //City = City,
                //State = State,
                //Zip = Zip,
                //Phone = Phone,
                //Fax = Fax,
                CreationTime = CreationTime,
                CreatorUserId = CreatorUserId,
                DeleterUserId = DeleterUserId,
                DeletionTime = DeletionTime,
                LastModificationTime = LastModificationTime,
                LastModifierUserId = LastModifierUserId
            };


            var municipalities = new Domains.Municipalities
            {
                Id = Id,
                Name = Name,
                IsActive = IsActive,
                PointOfContact = PointOfContact,
                Email = Email,
                AddressId = AddressId,
                CreatorUserId = CreatorUserId,
                CreationTime = CreationTime,
                DeleterUserId = DeleterUserId,
                DeletionTime = DeletionTime,
                LastModificationTime = LastModificationTime,
                LastModifierUserId = LastModifierUserId,
                Address = address
               
            };

            return municipalities;
        }



    }
}
