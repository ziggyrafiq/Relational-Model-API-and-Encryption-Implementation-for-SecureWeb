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
    public class DropDownList : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DropDownListId { get; set; }

        [Required(ErrorMessage = "Please Enter Name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter Value.")]
        public string Value { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please Enter Group Name.")]
        public string GroupName { get; set; } = string.Empty;
    }
}
