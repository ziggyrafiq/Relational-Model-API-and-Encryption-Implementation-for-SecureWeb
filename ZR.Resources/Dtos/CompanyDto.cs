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


using ZR.Infrastructure.Models;
using ZR.Infrastructure.Models.Enums;

namespace ZR.Resources.Dtos
{
    public class CompanyDto
    {
                

        public Guid CompanyId { get; set; }
        public RegistrantTypeEnum RegistrantType { get; set; } = RegistrantTypeEnum.None;
        public string CompanyName { get; set; }

        public string RegistrationNumber { get; set; } 

        public string TrandingAs { get; set; }

        public bool IsActive { get; set; }  
        public bool IsSoftDeleted { get; set; } 
        public bool IsHardDeleted { get; set; } 

        public IEnumerable<Address>? Addresses { get; set; }
        public IEnumerable<Telephone>? Telephones { get; set; }
        public IEnumerable<Contact>? Contacts { get; set; }

     



    }
}
