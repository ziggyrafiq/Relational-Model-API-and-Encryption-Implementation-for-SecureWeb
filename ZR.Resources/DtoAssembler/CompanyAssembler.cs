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
using ZR.Resources.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZR.Resources.DtoAssembler
{
    public class CompanyAssembler
    {
        public static Company CompanyWriteToModelFromDto(CompanyForCreationDto creationDto)
        {
            Company company = new Company() 
            {
                CompanyId = creationDto.CompanyId,
                RegistrantType = creationDto.RegistrantType,
                CompanyName = creationDto.CompanyName,
                RegistrationNumber=creationDto.RegistrationNumber,
                TrandingAs = creationDto.TrandingAs,
                IsActive = creationDto.IsActive,
                IsSoftDeleted = creationDto.IsSoftDeleted,
                IsHardDeleted = creationDto.IsHardDeleted

            };
            
            return company;
        }

        public static CompanyForCreationDto CompanyWriteToDtoFromModel(Company model)
        {
            CompanyForCreationDto company = new CompanyForCreationDto()
            {
                CompanyId = model.CompanyId,
                RegistrantType = model.RegistrantType,
                CompanyName = model.CompanyName,
                RegistrationNumber = model.RegistrationNumber,
                TrandingAs = model.TrandingAs,
                IsActive = model.IsActive,
                IsHardDeleted  = model.IsHardDeleted,
                IsSoftDeleted = model.IsSoftDeleted,

            };

            return company;
        }
    }
}
