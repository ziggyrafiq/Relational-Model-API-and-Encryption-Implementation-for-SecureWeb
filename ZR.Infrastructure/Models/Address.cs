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
    public class Address : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AddressId { get; set; }

        [ForeignKey("CompanyID")]
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "Missing Address Line 1.")]
        public string AddressLine1 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Missing Address Line 2.")]
        public string AddressLine2 { get; set; } = string.Empty;

        [Required(ErrorMessage = "Missing City or Town Name.")]
        public string CityorTown { get; set; } = string.Empty;

        [Required(ErrorMessage = "Missing County, Region or State Name.")]
        public string County { get; set; } = string.Empty;


        [Required(ErrorMessage = "Missing Post Code or Zip Code.")]
        public string PostCode { get; set; } = string.Empty;


        [Required(ErrorMessage = "Missing Country Name.")]

        public string Country { get; set; } = string.Empty;

        public virtual Company Company { get; set; }
    }
}
