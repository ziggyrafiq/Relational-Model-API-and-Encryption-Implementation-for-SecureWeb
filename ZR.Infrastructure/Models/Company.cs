/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	25/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/


using ZR.Infrastructure.Entity;
using ZR.Infrastructure.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ZR.Infrastructure.Models
{
    public class Company : EntityBase
    {

        public Company()
        {
            Telephones = Telephones ?? new List<Telephone>();
            Contacts = Contacts ?? new List<Contact>();
            Addresses = Addresses ?? new List<Address>();
        }

        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "Please Select Your Company Registrant Type. If You Do Not Have One Then Select None.")]
        public RegistrantTypeEnum RegistrantType { get; set; }


        [Required(ErrorMessage = "Missing Company Name.")]
        public string CompanyName { get; set; } = string.Empty;

        public string RegistrationNumber { get; set; } = string.Empty;

        public string TrandingAs { get; set; } = string.Empty;


        public virtual ICollection<Telephone> Telephones { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
