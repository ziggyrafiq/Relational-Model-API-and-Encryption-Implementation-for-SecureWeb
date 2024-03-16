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


using ZR.Infrastructure.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Resources.Dtos
{
    public class CompanyForCreationDto
    {

        public Guid CompanyId { get; set; }= Guid.NewGuid();
        public RegistrantTypeEnum RegistrantType { get; set; } = RegistrantTypeEnum.None;

        public string CompanyName { get; set; } = string.Empty;

        public string RegistrationNumber { get; set; } = string.Empty;

        public string TrandingAs { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
        public bool IsSoftDeleted { get; set; } = false;
        public bool IsHardDeleted { get; set; } = false;
    }
}
