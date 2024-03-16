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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZR.Infrastructure.Models
{
    public class Contact : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ContactId { get; set; }

        [ForeignKey("CompanyId")]
        public Guid CompanyId { get; set; }

        public string Title { get; set; }=String.Empty;
        public string FirstName { get; set; } = string.Empty;

        public string MiddletName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;

        public string DisplayName()
        {
            return ($"{Title} {FirstName} {LastName}");
        }
        public virtual Company Company { get; set; }
    }
}
